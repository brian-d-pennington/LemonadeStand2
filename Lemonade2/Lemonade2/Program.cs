using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class Program
    {
        static void Main(string[] args)
        {
            MainGame newGame = new MainGame();
            newGame.RunGame();
            Console.ReadLine();
        }
    }
}
