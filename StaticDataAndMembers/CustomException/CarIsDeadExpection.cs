using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class CarIsDeadExpection :   ApplicationException
    {
        public DateTime ErorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadExpection() { }
        public CarIsDeadExpection(string message, string cause, DateTime time)
        {
            CauseOfError = cause;
            ErorTimeStamp = time;
        }
        // Переопределить свойство Exception.Message

    }
}
