using System;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerialization
{
    [Serializable]
    internal class StringData : ISerializable
    {
        private string dataItemOne = "First data block";
        private string dataItemTwo = "More data";
        public StringData() { }
        protected StringData(SerializationInfo si, StreamingContext ctx)
        {
            // Восстановить переменные-члены из потока.
            dataItemOne = si.GetString("First_Item").ToLower();
            dataItemTwo = si.GetString("dataItemTwo").ToLower();
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Наполнить объект SerializationInfo форматированными данными.
            info.AddValue("First_Item", dataItemOne.ToUpper());
            info.AddValue("dataItemTwo", dataItemTwo.ToUpper());
        }        
    }
}
