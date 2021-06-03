using IndividualProjectPartB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
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
