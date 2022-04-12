using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;

namespace WpfCommands.Models
{
    public partial class Inventory : EntityBase, IDataErrorInfo, INotifyDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(CarId):
                        AddErrors(nameof(CarId), GetErrorsFromAnnotations(nameof(CarId), CarId));
                        break;
                    case nameof(Make):
                        hasError = CheckMakeAndColor();
                        if (Make == "ModelT")
                        {
                            hasError = true;
                            AddError(nameof(Make), "to old");
                        }
                        if(!hasError)
                        {
                            // Логика не безупречна, а просто иллюстрирует паттерн
                            ClearErrors(nameof(Make));
                            ClearErrors(nameof(Color));
                        }
                        AddErrors(nameof(Make), GetErrorsFromAnnotations(nameof(Make), Make));
                        break;
                    case nameof(Color):
                        hasError = CheckMakeAndColor();
                        if(!hasError)
                        {
                            ClearErrors(nameof(Make));
                            ClearErrors(nameof(Color));
                        }
                        AddErrors(nameof(Color), GetErrorsFromAnnotations(nameof(Color), Color));
                        break;
                    case nameof(PetName):
                        AddErrors(nameof(PetName), GetErrorsFromAnnotations(nameof(PetName), PetName));
                        break;
                }
                return string.Empty;
            }
        }

        internal bool CheckMakeAndColor()
        {
            if (Make == "Chevy" && Color == "Pink")
            {
                AddError(nameof(Make), $"{Make}, 's don't come in {Color}");
                AddError(nameof(Color), $"{Make}, 's don't come in {Color}");
                return true;
            }
            return false;
        }
    }
}
