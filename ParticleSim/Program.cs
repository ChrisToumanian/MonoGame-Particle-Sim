using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSim
{
    class Program
    {
        public static Simulator simulator;

        static void Main(string[] args)
        {
            simulator = new Simulator();
            simulator.Run();
        }
    }
}
