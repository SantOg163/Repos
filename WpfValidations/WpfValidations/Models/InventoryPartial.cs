using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfValidations.Models
{
    public partial class Inventory : IDataErrorInfo
    {
        private string _error;
        public string Error => _error;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(CarId):
                        break;
                    case nameof(Make):
                        if (Make == "ModelT")
                            return "Слишком старая модель";
                        return CheckMakeAndColor();
                    case nameof(Color):
                        return CheckMakeAndColor();
                    case nameof(PetName):
                        break;
                }
                return string.Empty;
            }
        }

        internal string CheckMakeAndColor()
        {
            if (Make == "Chevy" && Color == "Pink")
                return "модель в таком цвете не поставляется";
            return string.Empty;
        }
    }
}
