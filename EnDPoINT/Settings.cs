﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EnDPoINT
{
    class Settings
    {
        private IPAddress _serverIP;
        private int _port;
        private String _AETitle;
        private String _printer;
        private bool _printHeader;

        // Get/Set
        public IPAddress serverIP
        {
            get { return _serverIP; }
            set { this._serverIP = value; }
        }

        public int serverPort
        {
            get { return this._port; }
            set { this._port = value; }
        }

        public String AETitle
        {
            get { return this._AETitle; }
            set { this._AETitle = value; }
        }

        public String Printer
        {
            get { return this._printer; }
            set { this._printer = value; }
        }

        public bool PrintHeader
        {
            get { return this._printHeader; }
            set { this._printHeader = value; }
        }

        /// <summary>
        /// Standard Constructor for default settings
        /// </summary>
        public Settings()
        {
            this._serverIP = this.findNetworkAddress();
            this._port = 104;
            this._AETitle = "EnDPoINT";
            this._printer = "None";
            this._printHeader = false;
        }

        /// <summary>
        /// Finds the External network adress, if any
        /// </summary>
        /// <returns>External IPv4 Address, oder loopback if none is found</returns>
        private IPAddress findNetworkAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            IPAddress _ip;
            IPAddress.TryParse("127.0.0.1",out _ip);
            return _ip;
        }
    }
}
