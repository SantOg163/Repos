using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectlnstantiation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Память под объект AllTracks здесь не выделяется!
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();
            // Размещение объекта AllTracks происходит
            // только в случае вызова метода GetAllTracks().
            MediaPlayer yourPlayer = new MediaPlayer();
            AllTracks yourMusic = yourPlayer.GetAllTracks();
            Console.ReadLine();
        }
    }
}
