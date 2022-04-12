using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfValidations.Models
{
    public class EntityBase : INotifyDataErrorInfo
    {
        protected readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors => _errors.Count != 0;

        public string Error => throw new NotImplementedException();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected string[] GetErrorsFromAnnotations<T>(string propertyName, T value)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            var vc = new ValidationContext(this, null, null) { MemberName = propertyName };
            var isValid = Validator.TryValidateProperty(value, vc, results);
            return isValid ? null : Array.ConvertAll(results.ToArray(), o => o.ErrorMessage);
        }

        protected void OnErrorsChanged(string propertyName) => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.Values;
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }
        protected void AddError(string propertyName, string error) => AddErrors(propertyName, new List<string> { error });
        protected void AddErrors(string propertyName, IList<string> errors)
        {
            var changed = false;
            if (errors == null) 
                return;
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
    }
}