using IndividualProjectPartB_GeorgeMalandris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB_GeorgeMalandris
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menus.menuRunner();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
