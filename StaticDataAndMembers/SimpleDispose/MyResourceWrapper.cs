using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    class MyResourceWrapper : IDisposable
    {
        // После окончания работы с объектом пользователь
        // объекта должен вызывать этот метод,
        public void Dispose()
        {
            // Очистить неуправляемые ресурсы...
            // Освободить другие освобождаемые объекты, содержащиеся внутри.
            // Только для целей тестирования.
            Console.WriteLine("***** in Dispose! *****");
        }
    }
}
