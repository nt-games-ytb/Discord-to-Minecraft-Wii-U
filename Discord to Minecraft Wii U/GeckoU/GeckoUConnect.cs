using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace geckou
{
    public class GeckoUConnect
    {
        TcpClient tcpClient = null;
        public NetworkStream networkStream = null;

        public string Host { get; private set; }
        public int Port { get; private set; }

        public GeckoUConnect(string host, int port)
        {
            Host = host;
            Port = port;
        }

        /// <summary>
        /// Connects to the Wii U
        /// </summary>
        public void Connect()
        {
            /*tcpClient = new TcpClient()
            {
                NoDelay = true
            };

            IAsyncResult tcpAsyncResult = tcpClient.BeginConnect(Host, Port, null, null);
            WaitHandle tcpWaitHandle = tcpAsyncResult.AsyncWaitHandle;

            try
            {
                if (!tcpAsyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    tcpClient.Close();
                    throw new IOException("Unable to Connect to the Wii U, connection timed-out", new TimeoutException());
                }

                tcpClient.EndConnect(tcpAsyncResult);
                tcpWaitHandle.Close();
            }
            catch
            {
                throw new IOException("Unable to connect to the Wii U, connection timed-out", new TimeoutException());
            }

            networkStream = tcpClient.GetStream();
            networkStream.ReadTimeout = networkStream.WriteTimeout = 10000;*/
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.tcpClient = new TcpClient { NoDelay = true };
            var ar = this.tcpClient.BeginConnect(this.Host, this.Port, null, null);
            var wh = ar.AsyncWaitHandle;
            try
            {
                if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    this.tcpClient.Close();
                    throw new IOException("Connection timeout.", new TimeoutException());
                }

                this.tcpClient.EndConnect(ar);
            }
            finally
            {
                wh.Close();
            }

            this.networkStream = this.tcpClient.GetStream();
            this.networkStream.ReadTimeout = 10000;
            this.networkStream.WriteTimeout = 10000;
        }

        /// <summary>
        /// Disconnect from the Wii U
        /// </summary>
        public void Close()
        {
            try
            {
                if (this.tcpClient == null)
                {
                    return;
                    throw new IOException("Not connected.", new NullReferenceException());
                }

                this.tcpClient.Close();
            }
            finally
            {
                this.tcpClient = null;
            }
            /*try
            {
                if(tcpClient != null)
                {
                    tcpClient.Close();
                    tcpClient.Dispose();
                    networkStream.Close();
                    networkStream.Dispose();
                }
            }
            catch (Exception)
            {
                throw new IOException("Unable to close the connection from the Wii U");
            }
            finally
            {
                tcpClient = null;
                networkStream = null;
            }*/
        }

        /// <summary>
        /// Flushes the NetworkStream
        /// </summary>
        public void Flush()
        {
            try
            {
                if(networkStream != null)
                {
                    networkStream.Flush();
                }
            }
            catch(Exception)
            {
                throw new IOException("Unable to flush the Network Stream");
            }
        }

        /// <summary>
        /// Read from the Wii U from the buffer
        /// </summary>
        /// <param name="buffer">The Buffer</param>
        /// <param name="nobytes">NoBytes</param>
        /// <param name="bytesRead">Amount of bytes read</param>
        public void Read(byte[] buffer, uint nobytes, ref uint bytesRead)
        {
            try
            {
                if (networkStream != null)
                {
                    int offset = 0;
                    bytesRead = 0;

                    while (nobytes > 0)
                    {
                        int read = networkStream.Read(buffer, offset, (int)nobytes);

                        if (read >= 0)
                        {
                            bytesRead += (uint)read;
                            offset += read;
                            nobytes -= (uint)read;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new IOException("Connection closed", e);
            }
        }

        /// <summary>
        /// Read from the Wii U from the buffer
        /// </summary>
        /// <param name="buffer">The Buffer</param>
        /// <param name="nobytes">NoBytes</param>
        /// <param name="bytesRead">Amount of bytes read</param>
        public void Read(byte[] buffer, ulong nobytes, ref uint bytesRead)
        {
            try
            {
                int offset = 0;

                if (networkStream == null)
                {
                    throw new IOException("The NetworkStream was null", new NullReferenceException());
                }

                bytesRead = 0;

                while (nobytes > 0)
                {
                    int read = networkStream.Read(buffer, offset, (int)nobytes);

                    if (read >= 0)
                    {
                        bytesRead += (uint)read;
                        offset += read;
                        nobytes -= (uint)read;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new IOException("Connection closed", e);
            }
        }

        /// <summary>
        /// Write data to the Wii U from the Buffer
        /// </summary>
        /// <param name="buffer">The Buffer</param>
        /// <param name="nobytes">NoBytes</param>
        /// <param name="bytesWritten">Amount of bytes written</param>
        public void Write(byte[] buffer, int nobytes, ref uint bytesWritten)
        {
            try
            {
                if (networkStream == null)
                {
                    throw new IOException("The NetworkStream was null", new NullReferenceException());
                }

                networkStream.Write(buffer, 0, nobytes);

                if (nobytes >= 0)
                {
                    bytesWritten = (uint)nobytes;
                }
                else
                {
                    bytesWritten = 0;
                }

                networkStream.Flush();
            }
            catch (Exception e)
            {
                throw new IOException("Connection closed", e);
            }
        }
    }
}