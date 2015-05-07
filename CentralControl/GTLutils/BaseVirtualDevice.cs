﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace GTLutils
{
    public class BaseVirtualDevice : BaseDevice
    {
        private Socket mySocket;
        public Socket MySocket 
        {
            get 
            {
                return this.mySocket;
            }
            set 
            {
                this.mySocket = value;
            }
        }

        private Thread myThread;


        public BaseVirtualDevice()
        {
            myThread = null;
            mySocket = null;
        }

        ~BaseVirtualDevice()
        {
            if (mySocket != null) mySocket.Close();
            //if (myThread != null) myThread.Abort();
        }

        private bool isTerminating;
        public void init()
        {
            if (mySocket != null)
            {
                isTerminating = false;
                try
                {
                    myThread = new Thread(SocketReceiveMsg);
                    myThread.IsBackground = true;
                    myThread.Start();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void deinit() 
        {
            isTerminating = true;
        }

        public override void SendMsg(String msg)
        {
            if (mySocket != null)
            {
                try
                {
                    mySocket.Send(StringByteHelper.StringToBytes(msg));
                    deviceManager.sendMsg(this, msg);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public override void ReceiveMsg(String s) { }

        private void SocketReceiveMsg()//接收socket消息
        {
            byte[] buffer = new byte[1024 * 1024];
            int n;
            String s;
            while (true)
            {
                if (isTerminating) break;
                if (mySocket == null) break;
                try
                {
                    n = mySocket.Receive(buffer);
                    s = StringByteHelper.BytesToString(buffer,0,n);
                    ReceiveMsg(s);
                    deviceManager.receiveMsg(this, s);
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}
