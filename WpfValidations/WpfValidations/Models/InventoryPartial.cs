using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;

namespace WpfValidations.Models
{
    public partial class Inventory : IDataErrorInfo, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors => _errors.Count != 0;

        public string Error => throw new NotImplementedException();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void OnErrorsChanged(string propertyName) => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.Values;
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }
        private void AddError(string propertyName, string error) => AddErrors(propertyName, new List<string> { error });
        private void AddErrors(string propertyName, IList<string> errors)
        {
            var changed = false;
            if (!errors.Contains(propertyName))
            {
                _errors.Add(propertyName, new List<string>());
                changed = true;
            }
            foreach (var error in errors)
            {
                if (_errors[propertyName].Contains(error))
                    continue;
                _errors[propertyName].Add(error);
                changed = true;
            }
            if (changed)
                OnErrorsChanged(propertyName);
        }
        protected void ClearErrors(string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName))
                _errors.Clear();
            else
                _errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
        /*IDataErrorInfo*/
        //private string _error;
        //public string Error => _error;

        public string this[string columnName]
        {
            get
            {
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(CarId):
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
                        break;
                    case nameof(Color):
                        hasError = CheckMakeAndColor();
                        if(!hasError)
                        {
                            ClearErrors(nameof(Make));
                            ClearErrors(nameof(Color));
                        }
                        break;
                    case nameof(PetName):
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
