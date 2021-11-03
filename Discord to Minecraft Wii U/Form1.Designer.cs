
namespace Discord_to_Minecraft_Wii_U
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkBoxCT = new System.Windows.Forms.CheckBox();
            this.synchroniseChat = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maxCaracters = new System.Windows.Forms.NumericUpDown();
            this.disconnect = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.ipText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.maxCaracters)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxCT
            // 
            this.checkBoxCT.AutoSize = true;
            this.checkBoxCT.Location = new System.Drawing.Point(183, 0);
            this.checkBoxCT.Name = "checkBoxCT";
            this.checkBoxCT.Size = new System.Drawing.Size(40, 17);
            this.checkBoxCT.TabIndex = 16;
            this.checkBoxCT.Text = "CT";
            this.checkBoxCT.UseVisualStyleBackColor = true;
            this.checkBoxCT.Visible = false;
            this.checkBoxCT.CheckedChanged += new System.EventHandler(this.checkBoxCT_CheckedChanged);
            // 
            // synchroniseChat
            // 
            this.synchroniseChat.AutoSize = true;
            this.synchroniseChat.Enabled = false;
            this.synchroniseChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.synchroniseChat.Location = new System.Drawing.Point(354, 48);
            this.synchroniseChat.Name = "synchroniseChat";
            this.synchroniseChat.Size = new System.Drawing.Size(129, 20);
            this.synchroniseChat.TabIndex = 10;
            this.synchroniseChat.Text = "Synchronise chat";
            this.synchroniseChat.UseVisualStyleBackColor = true;
            this.synchroniseChat.CheckedChanged += new System.EventHandler(this.synchroniseChat_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Number maximal of characters :";
            // 
            // maxCaracters
            // 
            this.maxCaracters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxCaracters.Location = new System.Drawing.Point(221, 47);
            this.maxCaracters.Margin = new System.Windows.Forms.Padding(4);
            this.maxCaracters.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.maxCaracters.Name = "maxCaracters";
            this.maxCaracters.Size = new System.Drawing.Size(125, 22);
            this.maxCaracters.TabIndex = 7;
            this.maxCaracters.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // disconnect
            // 
            this.disconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.disconnect.Enabled = false;
            this.disconnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnect.ForeColor = System.Drawing.Color.White;
            this.disconnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.disconnect.Location = new System.Drawing.Point(354, 14);
            this.disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(125, 26);
            this.disconnect.TabIndex = 14;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = false;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // connect
            // 
            this.connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.connect.Enabled = false;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect.ForeColor = System.Drawing.Color.White;
            this.connect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.connect.Location = new System.Drawing.Point(221, 13);
            this.connect.Margin = new System.Windows.Forms.Padding(4);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(125, 26);
            this.connect.TabIndex = 13;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // ipText
            // 
            this.ipText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ipText.Location = new System.Drawing.Point(13, 13);
            this.ipText.Margin = new System.Windows.Forms.Padding(4);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(200, 26);
            this.ipText.TabIndex = 12;
            this.ipText.Text = "192.168.";
            this.ipText.TextChanged += new System.EventHandler(this.ipText_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 81);
            this.Controls.Add(this.synchroniseChat);
            this.Controls.Add(this.checkBoxCT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxCaracters);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.ipText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discord to Minecraft Wii U by nt games";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxCaracters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCT;
        private System.Windows.Forms.CheckBox synchroniseChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown maxCaracters;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox ipText;
    }
}

