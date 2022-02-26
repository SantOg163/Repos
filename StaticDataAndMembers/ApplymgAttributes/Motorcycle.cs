using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplymgAttributes
{
    // Этот класс может быть сохранен на диске.
    [Serializable]
    internal class Motorcycle
    {
        // Однако это поле сохраняться не будет.
        [NonSerialized]
        float weightOfCurrentPassengers;
        // Эти поля остаются сериализируемыми.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;

    }
}
