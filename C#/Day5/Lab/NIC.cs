using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    enum Type
    {
        ethernet,
        tokenRing
    }
    internal class NIC(string manufacture, string mac, Type type)
    {
        string manufacture { get; } = manufacture;
        string mac { get; } = mac;
        Type type { get; } = type;
        static NIC singleton = null;
        public static NIC getInstance()
        {
            if (singleton == null)
            {
                singleton = new NIC("", "", default);
            }
            return singleton;
        }
        public override string ToString()
        {
            return $"Manufacture: {manufacture}\nMac: {mac}\nType: {type}";
        }
    }
}
