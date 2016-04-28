using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGameApi;

namespace BoardGameApi
{
    class Program
    {

        
        static void Main(string[] args)
        {
           
            ActorTest actorTest = new ActorTest();

            if (!actorTest.idCorrect())
            {
                Console.WriteLine("Actor id no correct"); 
            }

            if (!actorTest.idDiferent())
            {
                Console.WriteLine("Actor id is repited");
            }

            if (!actorTest.idCountGotMax())
            {
                Console.WriteLine("Actor idCount dosent count well");
            }


            Console.WriteLine("test finished");
            Console.ReadKey();
        }
        
    }
}
