using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() { }
        public SportsCar(string name, int maxSp, int currSp)
        : base(name, maxSp, currSp) { }
        public override void TurboBoost()
        {
            MessageBox.Show("Ramming speed!", "Faster is better");
        }
    }
    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSp, int currSp)
        : base(name, maxSp, currSp) { }
        public override void TurboBoost()
        {
            // Минивэны имеют плохие возможности ускорения'
            egnState = EngineState.engineDead;
            MessageBox.Show("Eek!", "Your engine block exploded!");
        }
    }
}
