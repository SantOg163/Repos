using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectlnstantiation
{
    class Song
    {
        string Artist { get; set; }
        public string TrackName { get; set; }
        public double TrackLenght { get; set; }
    }
    class AllTracks
    {
        // Наш проигрыватель может содержать
        // максимум 10 000 композиций,
        Song[] allSongs = new Song[10000];
        public AllTracks()
        {
            // Предположим, что здесь производится
            // заполнение массива объектов Song.
            Console.WriteLine("Filling up the songs!");
        }
    }
    class MediaPlayer
    {
        // Предположим, что эти методы делают что-то полезное,
        public void Play() { /* Воспроизведение композиции */ }
        public void Pause() { /* Пауза в воспроизведении */ }
        public void Stop() { /* Останов воспроизведения */ }
        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>(()=>
        {
            Console.WriteLine("Creating AllTracks object! " ) ;
            return new AllTracks();
        });
        public AllTracks GetAllTracks()
        {
            // Возвратить все композиции,
            return allSongs.Value;
        }
    }
}