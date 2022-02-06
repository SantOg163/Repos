using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    public struct Square
    {
        public int Length { get; set; }
        public Square(int lenght) : this()
        {
            Length = lenght;
        }
        public override string ToString()=>$"Lenght: {Length}";
        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        // Rectangle можно явно преобразовывать в Square,
        public static explicit operator Square(Rectangle r)=>new Square(r.Height );

        public static explicit operator Square(int value) => new Square(value);

        public static explicit operator int(Square value)=> (int)value.Length;
        public static Square operator +(Square a,Square b) => new Square(a.Length + b.Length);       
    }
}