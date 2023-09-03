using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace BT1
{
    public partial class Form1 : Form
    {
        const int MAX_SEND_BUFFER = 1024;
        byte[] m_sendBuffer = new byte[MAX_SEND_BUFFER];
        
        const ushort MAX_MESSAGE = 300;
        //STX
        byte[] bSTX = { 0x02 };
        //CMD
        byte[] bMOVL = { 0x4D, 0x4F, 0x56, 0x4C };
        byte[] bGPOS = { 0x47, 0x50, 0x4F, 0x53 };
        byte[] bGVEL = { 0x47, 0x56, 0x45, 0x4C };
        byte[] bGSTT = { 0x47, 0x53, 0x54, 0x54 };
        //OPTION
        byte[] bOPT = { 0x00, 0x00, 0x00 };
        //DATA
        byte[] bDATA = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01 };
        //SYNC/ACK
        byte[] bSYNC = { 0x16 };
        byte[] bACK = { 0x06 };
        //ETX
        byte[] bETX = { 0x03 };

        //RECEIVE
        byte[] bProtocolDataBuffer = new byte[18];
        byte[] bProtocolData = new byte[8];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            if(serialPort1.IsOpen)
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;

            SerialPort serialPort = new SerialPort(comboBox1.Text);
            bool portActivated = serialPort.IsOpen;
            if (!portActivated)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Open")
            {
                serialPort1.Open();
                button1.Text = "Close";
            }
            else
            {
                serialPort1.Close();
                button1.Text = "Open";
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
        }

        private void btnSend1_Click(object sender, EventArgs e)
        {
            string cmd = textBox1.Text;
            byte[] bytesToSend = SoapHexBinary.Parse(cmd).Value;
            Write(bytesToSend, bytesToSend.Length);
        }
        /**
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[serialPort1.BytesToRead];
            int bytesRead = serialPort1.Read(buffer, 0, buffer.Length);
            OnEventRead(buffer, bytesRead);
        }
        
        private void OnEventRead(byte[] inPacket, int inLength)
        {
            string csInPacket;
          
            csInPacket = "Receive: ";
            m_lsbReadSerial.Items.Insert(0, csInPacket);
            csInPacket = "";

            for (int i = 0; i < inLength; i++)
            {
                csInPacket += inPacket[i].ToString("X2");
            }
            m_lsbReadSerial.Items.Insert(0, csInPacket);

            ProcessData(inPacket, inLength);

            string str;
            str = inLength + " bytes read";

            m_staticInfo.Text = str;
        }
        **/

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[18];
            int bytesRead = serialPort1.Read(buffer, 0, buffer.Length);
            this.Invoke(new Action(() => OnEventRead(buffer, bytesRead)));
        }

        private void OnEventRead(byte[] inPacket, int inLength)
        {
            //if (inLength != 18) return;
            string csInPacket;

            csInPacket = "Receive: ";
            this.Invoke(new Action(() => m_lsbReadSerial.Items.Insert(0, csInPacket)));
            csInPacket = "";

            for (int i = 0; i < inLength; i++)
            {
                csInPacket += inPacket[i].ToString("X2");
            }
            this.Invoke(new Action(() => m_lsbReadSerial.Items.Insert(0, csInPacket)));

            ProcessData(inPacket, inLength);

            string str;
            str = inLength + " bytes read";

            this.Invoke(new Action(() => m_staticInfo.Text = str));
        }


        private void ProcessData(byte[] data, int inLength)
        {
            string cmd = "";
            for (int i = 0; i < inLength; i++)
            {
                bProtocolDataBuffer[i] = (byte)data[i];
            }
            for (int i = 1; i <= 4; i++)
            {
                cmd += (char)bProtocolDataBuffer[i];
            }
     
            for (int i = 8; i <= 15; i++)
            {
                bProtocolData[i - 8] = bProtocolDataBuffer[i];
            }
            if (cmd == "GPOS")
            {

            }
            else if (cmd == "MOVL")
            {

            }
            else if (cmd == "GVEL")
            {

            }
            else if (cmd == "GSTT")
            {
                if (bProtocolDataBuffer[12] == 0x01)
                {
                    cBtnLedCheck1.Checked = true;
                }
                else
                {
                    cBtnLedCheck1.Checked = false;
                }

                if (bProtocolDataBuffer[13] == 0x01)
                {
                    cBtnGPIO1.Checked = true;
                }
                else
                {
                    cBtnGPIO1.Checked = false;
                }

                if (bProtocolDataBuffer[14] == 0x01)
                {
                    cBtnLedCheck2.Checked = true;
                }
                else
                {
                    cBtnLedCheck2.Checked = false;
                }

                if (bProtocolDataBuffer[15] == 0x01)
                {
                    cBtnGPIO2.Checked = true;
                }
                else
                {
                    cBtnGPIO2.Checked = false;
                }

            }
        }



        private void Write(byte[] outPacket, int outLength)
        {
            int m_sendSize;
            if (outLength <= MAX_SEND_BUFFER)
            {
                Array.Copy(outPacket, m_sendBuffer, outLength);
                m_sendSize = outLength;
                //SetSendActivate(true);
                serialPort1.Write(m_sendBuffer, 0, m_sendSize);
            }
            else
            {
                Console.WriteLine("buffer over flow");
                OnEventWrite(-1);
            }
            return; 
        }

        private void OnEventWrite(int nWritten)
        {
            if (nWritten < 0)
            {
                Console.WriteLine("write error");
            }
            else
            {
                Console.WriteLine("{0} bytes send", nWritten);
            }
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            byte[] ProtocolFrame = new byte[50];
            int index = 0;
            //if (!GetPortActivateValue()) return;
            Array.Copy(bSTX, 0, ProtocolFrame, index, bSTX.Length);
            index += bSTX.Length;
            Array.Copy(bGPOS, 0, ProtocolFrame, index, bGPOS.Length);
            index += bGPOS.Length;
            Array.Copy(bOPT, 0, ProtocolFrame, index, bOPT.Length);
            index += bOPT.Length;
            Array.Copy(bDATA, 0, ProtocolFrame, index, bDATA.Length);
            index += bDATA.Length;
            Array.Copy(bSYNC, 0, ProtocolFrame, index, bSYNC.Length);
            index += bSYNC.Length;
            Array.Copy(bETX, 0, ProtocolFrame, index, bETX.Length);
            index += bETX.Length;
            /*STD::COPY(FRAME.begin(), FRAME.end(), res;*/
            Write(ProtocolFrame, index);

            string cmd = string.Format("POS CMD: ");
            m_lsbReadSerial.Items.Insert(0, cmd);
            cmd = string.Empty;
            for (int i = 0; i < index; i++)
            {
                cmd += string.Format("{0:X2}", ProtocolFrame[i]);

            }
            m_lsbReadSerial.Items.Insert(0, cmd);
        }

        private void btnVEL_Click(object sender, EventArgs e)
        {
            byte[] ProtocolFrame = new byte[50];
            int index = 0;
            //if (!GetPortActivateValue()) return;
            Array.Copy(bSTX, 0, ProtocolFrame, index, bSTX.Length);
            index += bSTX.Length;
            Array.Copy(bGVEL, 0, ProtocolFrame, index, bGVEL.Length);
            index += bGVEL.Length;
            Array.Copy(bOPT, 0, ProtocolFrame, index, bOPT.Length);
            index += bOPT.Length;
            Array.Copy(bDATA, 0, ProtocolFrame, index, bDATA.Length);
            index += bDATA.Length;
            Array.Copy(bSYNC, 0, ProtocolFrame, index, bSYNC.Length);
            index += bSYNC.Length;
            Array.Copy(bETX, 0, ProtocolFrame, index, bETX.Length);
            index += bETX.Length;
            /*STD::COPY(FRAME.begin(), FRAME.end(), res;*/
            Write(ProtocolFrame, index);

            string cmd = string.Format("VEL CMD: ");
            m_lsbReadSerial.Items.Insert(0, cmd);
            cmd = string.Empty;
            for (int i = 0; i < index; i++)
            {
                cmd += string.Format("{0:X2}", ProtocolFrame[i]);

            }
            m_lsbReadSerial.Items.Insert(0, cmd);
        }

        private void btnMOV_Click(object sender, EventArgs e)
        {
            byte[] ProtocolFrame = new byte[50];
            int index = 0;
            //if (!GetPortActivateValue()) return;
            Array.Copy(bSTX, 0, ProtocolFrame, index, bSTX.Length);
            index += bSTX.Length;
            Array.Copy(bMOVL, 0, ProtocolFrame, index, bMOVL.Length);
            index += bMOVL.Length;
            Array.Copy(bOPT, 0, ProtocolFrame, index, bOPT.Length);
            index += bOPT.Length;
            Array.Copy(bDATA, 0, ProtocolFrame, index, bDATA.Length);
            index += bDATA.Length;
            Array.Copy(bSYNC, 0, ProtocolFrame, index, bSYNC.Length);
            index += bSYNC.Length;
            Array.Copy(bETX, 0, ProtocolFrame, index, bETX.Length);
            index += bETX.Length;
            /*STD::COPY(FRAME.begin(), FRAME.end(), res;*/
            Write(ProtocolFrame, index);

            string cmd = string.Format("MOV CMD: ");
            m_lsbReadSerial.Items.Insert(0, cmd);
            cmd = string.Empty;
            for (int i = 0; i < index; i++)
            {
                cmd += string.Format("{0:X2}", ProtocolFrame[i]);

            }
            m_lsbReadSerial.Items.Insert(0, cmd);
        }

        private void btnSTT_Click(object sender, EventArgs e)
        {
            byte[] ProtocolFrame = new byte[50];
            int index = 0;
            //if (!GetPortActivateValue()) return;
            Array.Copy(bSTX, 0, ProtocolFrame, index, bSTX.Length);
            index += bSTX.Length;
            Array.Copy(bGSTT, 0, ProtocolFrame, index, bGSTT.Length);
            index += bGSTT.Length;
            Array.Copy(bOPT, 0, ProtocolFrame, index, bOPT.Length);
            index += bOPT.Length;
            Array.Copy(bDATA, 0, ProtocolFrame, index, bDATA.Length);
            index += bDATA.Length;
            Array.Copy(bSYNC, 0, ProtocolFrame, index, bSYNC.Length);
            index += bSYNC.Length;
            Array.Copy(bETX, 0, ProtocolFrame, index, bETX.Length);
            index += bETX.Length;
            /*STD::COPY(FRAME.begin(), FRAME.end(), res;*/
            Write(ProtocolFrame, index);

            string cmd = string.Format("STT CMD: ");
            m_lsbReadSerial.Items.Insert(0, cmd);
            cmd = string.Empty;
            for (int i = 0; i < index; i++)
            {
                cmd += string.Format("{0:X2}", ProtocolFrame[i]);

            }
            m_lsbReadSerial.Items.Insert(0, cmd);
        }
    }
}
