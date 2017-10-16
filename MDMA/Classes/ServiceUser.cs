using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDMA.Service
{
    public class ServiceUser
    {
            #region Variables & Properties
            private long id;
            private ulong sessionID;
            private string keyHex;
            private string ivHex;
            private enumLang lang;
            private string loginname;
            private string msisdn;
            private string encpass;
            private string pass;
            private short channel;
            private short _version;
            private short _custType; // OnlineCustomer - 5, Affiliate - 2
            private int rettype;
            private string retdesc;
            private string hostip = "";
            private string hostname = "";
            private string hostmac = "";

         
            public virtual long ID
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                }
            }
            public virtual ulong SessionID
            {
                get
                {
                    return sessionID;
                }
                set
                {
                    sessionID = value;
                }
            }
            public virtual String KeyHex
            {
                get
                {
                    return keyHex;
                }
                set
                {
                    keyHex = value;
                }
            }
            public virtual String IVHex
            {
                get
                {
                    return ivHex;
                }
                set
                {
                    ivHex = value;
                }
            }
            public virtual enumLang Lang
            {
                get
                {
                    return lang;
                }
                set
                {
                    lang = (enumLang)value;
                }
            }
            public virtual String LoginName
            {
                get
                {
                    return loginname;
                }
                set
                {
                    loginname = value;
                }
            }
            public virtual String MSISDN
            {
                get
                {
                    return msisdn;
                }
                set
                {
                    msisdn = value;
                }
            }
            public virtual String Pin
            {
                get
                {
                    return pin;
                }
                set
                {
                    pin = value;
                }
            }
            public virtual String EncPass
            {
                get
                {
                    return encpass;
                }
                set
                {
                    encpass = value;
                }
            }
            public short Channel
            {
                get { return channel; }
                set { channel = value; }
            }
            
            public virtual short Version
            {
                get
                {
                    return _version;
                }
                set
                {
                    _version = value;
                }
            }
            public virtual short CustType
            {
                get
                {
                    return _custType;
                }
                set
                {
                    _custType = value;
                }
            }
            public virtual int retType
            {
                get
                {
                    return rettype;
                }
                set
                {
                    rettype = value;
                }
            }
            public virtual string retDesc
            {
                get
                {
                    return retdesc;
                }
                set
                {
                    retdesc = value;
                }
            }

            public virtual string HostIP
            {
                get
                {
                    return hostip;
                }
                set
                {
                    hostip = value;
                }
            }
            public virtual string HostName
            {
                get
                {
                    return hostname;
                }
                set
                {
                    hostname = value;
                }
            }
            public virtual string HostMac
            {
                get
                {
                    return hostmac;
                }
                set
                {
                    hostmac = value;
                }
            }
            public byte[] key(int len)
            {
                byte[] bKey = new byte[len];
                for (int i = 0; i < keyHex.Length; i += 2)
                {
                    bKey[i / 2] = (byte)Func.HexToDec(keyHex.Substring(i, 2));
                }
                return bKey;
            }
            public byte[] iv(int len)
            {
                byte[] bIV = new byte[len];
                for (int i = 0; i < ivHex.Length; i += 2)
                {
                    bIV[i / 2] = (byte)Func.HexToDec(ivHex.Substring(i, 2));
                }
                return bIV;
            }
            #endregion

    }
}