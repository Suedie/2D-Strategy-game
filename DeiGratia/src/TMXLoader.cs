using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DeiGratia.src
{
    internal class TMXLoader
    {
        public XmlDocument map = new XmlDocument();
        private string filepath;

        public TMXLoader(string filepath)
        {
            this.filepath = filepath;
            map.Load(filepath);
        }

    }
}
