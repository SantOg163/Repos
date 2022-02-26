using System;
using System.Collections.Generic;
// Создать псевдоним для объектной модели Excel,
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDataToOfficeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> carsInStock = new List<Car>
            {
                new Car {Color="Green", Make="VW", PetName="Mary"},
                new Car {Color="Red", Make="Saab", PetName="Mel"},
                new Car {Color="Black", Make="Ford", PetName="Hank"},
                new Car {Color="Yellow", Make="BMW", PetName="Davie"}
            };
            ExportToExcel(carsInStock);
            Console.ReadKey();
        }
        static void ExportToExcel(List<Car> CarInStock)
        {
            // Загрузить Excel и затем создать новую пустую рабочую книгу.
            Excel.Application excelApp = new Excel.Application();
            // Сделать пользовательский интерфейс Excel видимым на рабочем столе.
            excelApp.Visible = true;
            // В этом примере используется единственный рабочий лист.
            Excel._Worksheet worksheet = excelApp.ActiveSheet;
            // Установить заголовки столбцов в ячейках.
            worksheet.Cells[1, "A"] = "Make";
            worksheet.Cells[1, "B"] = "Color";
            worksheet.Cells[1, "C"] = "Petname";
            // Отобразить все данные из List<Car> на ячейки электронной таблицы.
            int row = 1;
            foreach(Car car in CarInStock)
            {
                row++;
                worksheet.Cells[row, "A"] = car.Make;
                worksheet.Cells[row, "B"] = car.Color;
                worksheet.Cells[row, "C"] = car.PetName;
            }
            // Придать симпатичный вид табличным данным.
            worksheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            // Сохранить файл, завершить работу Excel и отобразить сообщение пользователю.
            worksheet.SaveAs($@"{Environment.CurrentDirectory}\Inventory.xlsx");
            excelApp.Quit();
            Console.WriteLine("Файл Inventory.xslx сохранен в папке приложения");
        }
    }
}
