using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade2
{
    class MainGame
    {
        public Player player;

        

        public MainGame()
        {
            player = new Player();
        }

        public void RunGame()
        {
            UserInterface.DisplayInstructions();
            UserInterface.GetPlayerName();
        }
    }
}
