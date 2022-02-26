using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    // Представляет состояние двигателя,
    public enum EngineState
    { engineAlive, engineDead }
    // Абстрактный базовый класс в иерархии,
    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        protected EngineState egnState = EngineState.engineAlive;
        public EngineState EngineState => egnState;
        public abstract void TurboBoost();
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            MessageBox.Show("CarLibrary Version 2.0!");
            PetName = name; MaxSpeed = maxSp; CurrentSpeed = currSp;
        }
        public void TurnOnRadio(bool musicOn, MusicMedia mm) => MessageBox.Show(musicOn ? $"Играет {mm}" : "Выключено");
        
    }
    // Тип музыкального устройства, установленного в автомобиле,
    public enum MusicMedia
    {
        musicCd,
        musicTape,
        musicRadio,
        musicMp3
    }
}
