using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSenalize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создать объект JamesBondCar и установить состояние.
            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.theRadio.stationPresets = new double[] {89.3,105.1,97.1};
            jbc.theRadio.hasTweeters = true;
            //Сохранить объект JamesBondCar в указанном файле в двоичном формате.
            SaveAsBinaryFormat(jbc, "CarData.txt");
            LoadFromBinaryFile("CarData.txt");
            Console.ReadKey();
        }
        static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            // Сохранить граф объектов в файл CarData.dat в двоичном виде.
            BinaryFormatter binFormat = new BinaryFormatter();
            using(Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
        }
        static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            // Прочитать объект JamesBondCar из двоичного файла.
            using(Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisc = (JamesBondCar)binFormat.Deserialize(fStream);
                Console.WriteLine("Может летать: " + carFromDisc.canFly);
            }
        }
        static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            // Сохранить граф объектов в файле CarData.soap в формате SOAP
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) 
            { 
                soapFormat.Serialize(fStream, objGraph);
            }
        }
    }
}
