using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game
{
    internal class settings
    {
        public static int width { get; set; }
        public static int height { get; set; }

        public static string direction;

        public settings()
        {
            width = 18;
            height = 18;
            direction = "left";
        }

    }
}
