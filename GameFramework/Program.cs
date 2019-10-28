using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Vector3 vec3 = new Vector3(1, 1, 1);
            Console.WriteLine(vec3.Magnitude());
            Vector2 vec4 = new Vector2(3, -2);
            Console.WriteLine(vec4.Magnitude());
            Vector3 vec5 = new Vector3( -1, 1, -1);
            Console.WriteLine(vec5.Magnitude());
            Vector3 vec6 = new Vector3(0.5f, -1, .25f);
            Console.WriteLine(vec6.Magnitude());
            Vector2 vec1a = new Vector2(-2, 5.5f);
            Vector2 vec1b = new Vector2(9, -22);
            Console.WriteLine(vec1a.Distance(vec1b));
            Vector3 vec2a = new Vector3(0 ,1 ,2 );
            Vector3 vec2b = new Vector3(9 ,-2 ,7 );
            Console.WriteLine(vec2a.Distance(vec2b));

            Console.ReadKey();
            return; */
            Game game = new Game();
            game.Run();





        }
    }
}
