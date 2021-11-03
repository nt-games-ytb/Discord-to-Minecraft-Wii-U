#region Using Normal
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.CodeDom;
using System.Collections;
using System.Configuration;
using System.Deployment;
using System.Dynamic;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Resources;
using System.Runtime;
using System.Security;
using System.Timers;
using System.Web;
using System.Windows;
using System.Xml;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.DesignerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Hosting;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Windows.Markup;
using System.Windows.Input;
using System.Net.Cache;
using System.Net.Sockets;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO.Compression;
#endregion
using Discord_to_Minecraft_Wii_U;
using Discord_to_Minecraft_Wii_U.Properties;
using geckou;

namespace Discord_to_Minecraft_Wii_U
{
    public partial class Form1 : Form
    {
        #region Private
        public static GeckoUCore GeckoU;
        public static GeckoUConnect GeckoUConnection;
        public static GeckoUDump GeckoUDump;
        string discordText;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ipText.Text = File.ReadAllText("IP.txt");
            }
            catch { }
        }

        #region Connection
        #region Text
        public static bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
                return false;

            if (ipString == "127.0.0.1")
                return false;

            string[] splitValues = ipString.Split('.');

            if (splitValues.Length != 4)
                return false;

            return splitValues.All(r => byte.TryParse(r, out byte tempForParsing));
        }

        private void ipText_TextChanged(object sender, EventArgs e)
        {
            if (ValidateIPv4(ipText.Text) == true)
            {
                connect.Enabled = true;
            }
            else
            {
                connect.Enabled = false;
            }
        }
        #endregion

        #region Button
        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                GeckoU = new GeckoUCore(ipText.Text);
                GeckoU.GUC.Connect();
                GeckoU.makeAssembly(0x039156C0, "9421ff887c0802a63ce031003d0031009001007c3d4031003d20310093c10070610802143bc00000614a02186129021c60e70210934100609381006893a1006c93e100743fe0109c80e7000063ffd8e48349000083a80000838a000093c1005493610064813f000093c1005081290034812900f8812900c87f69382e480000110067006900760065000000007c8802a63d20020b38610008612908d47d2903a64e8004213d20024661290e54814100107d2903a681210014800100187f47d378808100087f86e3788061000c7fa5eb788161001c3901002891410030912100348141002081210024900100389361004893c1004c90810028388100489061002c386100509161003c91410040912100444e800421811f0000814100503d200304810800346129a5d88161005438810058806808787d2903a6914100589161005c4e8004218001007c83410060836100647c0803a68381006883a1006c83c1007083e10074382100784e80002060000000");
                checkBoxCT.Checked = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Discord to Minecraft Wii U");
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("Error: your ip is not the right one or you are not connected to the internet !", "Discord to Minecraft Wii U");
            }
            catch
            {
                MessageBox.Show("An unknown error has occurred !", "Discord to Minecraft Wii U");
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            checkBoxCT.Checked = false;
            GeckoU.GUC.Close();
        }
        #endregion

        private void checkBoxCT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCT.Checked)
            {
                ipText.Enabled = false;
                StreamWriter streamWriterIP = new StreamWriter("IP.txt");
                streamWriterIP.Write(ipText.Text);
                streamWriterIP.Close();
                connect.Enabled = false;
                disconnect.Enabled = true;

                synchroniseChat.Enabled = true;
            }
            else
            {
                ipText.Enabled = true;
                connect.Enabled = true;
                disconnect.Enabled = false;

                synchroniseChat.Checked = false;
                synchroniseChat.Enabled = false;
            }
        }
        #endregion

        #region Discord
        private void executeSynchroniseChat()
        {
            while (synchroniseChat.Checked)
            {
                try
                {
                    if (File.ReadAllText("discord message.txt") == "")
                    { }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            try
                            {
                                discordText = File.ReadAllText("discord message.txt");
                                discordText = discordText.Substring(0, (int)maxCaracters.Value);
                            }
                            catch
                            {
                                discordText = File.ReadAllText("discord message.txt");
                            }
                        }));

                        GeckoU.WriteUInt(0x31000214, 0x1);//item id
                        GeckoU.WriteUInt(0x31000218, 0x0);//number
                        GeckoU.WriteUInt(0x3100021C, 0x0);//damage

                        GeckoU.clearString2(0x1061F270, GeckoU.Mix4_V2(0x1061F274, maxCaracters.Value / 2));
                        GeckoU.WriteStringUTF16(0x1061F270, discordText);
                        GeckoU.WriteUInt(GeckoU.Mix4_V2(0x1061F270, maxCaracters.Value / 2), 0x00000000);
                        GeckoU.CallFunction(0x039156C0, new uint[] { 0x0 });

                        StreamWriter streamWriterIP = new StreamWriter("discord message.txt");
                        streamWriterIP.Write("");
                        streamWriterIP.Close();
                    }
                    Thread.Sleep(5);
                }
                catch
                {}
            }
        }

        private void synchroniseChat_CheckedChanged(object sender, EventArgs e)
        {
            Thread synchroniseChatThread = new Thread(executeSynchroniseChat);
            if (synchroniseChat.Checked)
            {
                GeckoU.WriteUInt(0x31000214, 0x1);//ID de l'item
                GeckoU.WriteUInt(0x31000218, 0x0);//Nombre d'items
                GeckoU.WriteUInt(0x3100021C, 0x0);//Dégats (damage)

                GeckoU.clearString2(0x1061F270, 0x1061F2C4);
                GeckoU.WriteStringUTF16(0x1061F270, "Discord chat replay : ENABLE");
                GeckoU.CallFunction(0x039156C0, new uint[] { 0x0 });
                Thread.Sleep(500);

                synchroniseChatThread.Start();
            }
            else
            {
                synchroniseChatThread.Abort();

                try
                {
                    GeckoU.WriteUInt(0x31000214, 0x1);//item id
                    GeckoU.WriteUInt(0x31000218, 0x0);//number
                    GeckoU.WriteUInt(0x3100021C, 0x0);//damage

                    GeckoU.clearString2(0x1061F270, 0x1061F2C4);
                    GeckoU.WriteStringUTF16(0x1061F270, "Discord chat replay : DISABLE");
                    GeckoU.CallFunction(0x039156C0, new uint[] { 0x0 });
                }
                catch { }
            }
        }
        #endregion
    }
}
