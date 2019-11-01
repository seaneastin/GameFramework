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
            Examples();
            //Game game = new Game();
            //game.Run();

            



        }
        static void Examples()
        {

            Console.WriteLine(new Matrix3(1, 4, 7, 2, 5, 8, 3, 6, 9) * new Matrix3(9, 6, 3, 8, 5, 2, 7, 4, 1));
            
            
            
            
            /* Console.WriteLine(new Vector2(1f, 0f).DotProduct(new Vector2(0f, 1f)));
 Console.WriteLine(new Vector2(1f, 1f).DotProduct(new Vector2(-1f, -1f)));
 Console.WriteLine(new Vector3(2f, 3f, 1f).DotProduct(new Vector3(-3f, 1f, 2f)));
 Console.WriteLine(new Vector3(2f, 3f, 1f).CrossProduct(new Vector3(-3f, 1f, 2f)));
 Console.WriteLine(new Vector2(1f, 3f).AngleBetween(new Vector2(.5f, -.25f)));
 Console.WriteLine(new Vector3(2f, 3f, 1f).AngleBetween(new Vector3(-1f, 0f, -1f))); */

        /*    Vector3 playerLoc = new Vector3(10f, 0f, 18f);
            Vector3 enemyLoc = new Vector3(-7.5f, 0f, 9f);
            Vector3 enemyDir = new Vector3(0.857f, 0f, -0.514f);
            Vector3 up = new Vector3(0f, 1f, 0f);

            Vector3 enemyLeft = enemyDir.CrossProduct(up);
            Vector3 enemyToPlayer = playerLoc - enemyLoc;

            Console.WriteLine("Distance from enemy to player: " + enemyToPlayer);

            if (enemyDir.DotProduct(enemyToPlayer) > 0)
            {
                Console.WriteLine("player is in front of enemy.");
            }
            else
            {
                Console.WriteLine("player is behind the  enemy.");
            }


            if (enemyLeft.DotProduct(enemyToPlayer) > 0)
            {
                Console.WriteLine("player is to the left of the enemy.");
            }
            else
            {
                Console.WriteLine("player is not to the  enemy.");
            }
           /* if (enemyFoward.GetAngle(enemyToPlayer) <= Math.PI / 4 || enemyForward.GetAngle(enemyToPlayer) >= 7 * Math.PI 4)
            {
                Console.WriteLine("i've got you in my sights");
            } */



            Console.ReadKey();
            return;
        }
    }
}
