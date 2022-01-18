using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExpceptions
{
    internal class CarIsDeadExpection : ApplicationException
    {
        public DateTime ErorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadExpection() { }
        public CarIsDeadExpection(string message, string cause, DateTime time):base (message)
        {
            CauseOfError = cause;
            ErorTimeStamp = time;
        }
        public CarIsDeadExpection(string message) : base(message) { }
        public CarIsDeadExpection(string message, Exception inner) : base(message, inner) { }
        protected CarIsDeadExpection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
}
