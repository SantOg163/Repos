using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringData myData = new StringData();
            SoapFormatter soapFormat = new SoapFormatter();
            using(Stream fStream = new FileStream("MyData.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, myData);
            }
        }
    }
}
