using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    // Этот интерфейс определяет поведение ’’наличия вершин”,
    public interface IPointy
    {
        // Неявно открытый и абстрактный,
        byte Points { get; }
    }
}
