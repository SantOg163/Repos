using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescnption desk = new PointDescnption();
        public Point() { }
        public Point(int x, int y) { X = x; Y = y; }
        public Point(int x, int y, string Name) { X = x; Y = y; desk.PetName = Name; }
        // Переопределить Object.ToString().
        public override string ToString() => $"X = {X} ; Y = {Y} ; Name: {desk.PetName} ; ID: {desk.PointID}";
        // Возвратить копию текущего объекта.
        public object Clone()
        {
            // Сначала получить поверхностную копию.
            Point newPoint = (Point)MemberwiseClone();
            //восполнить пробелы
            PointDescnption currentDesc = new PointDescnption();
            currentDesc.PetName = desk.PetName;
            newPoint.desk = currentDesc;
            return newPoint;
        }
        public class PointDescnption
        {
            public string PetName { get; set; }
            public Guid PointID { get; set; }
            public PointDescnption()
            {
                PetName = "No-name";
                PointID = Guid.NewGuid();
            }
        }
    }
}
