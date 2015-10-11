using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perlin_Noise;
namespace random_floats
{
    class Program
    {
        
        static void Main(string[] args)
        {
            PerlinNoise p = new PerlinNoise();
            for (float i = 0; i < 100; i+=0.1f)
            {
                float output = p.PerlinNoiseGeneration(p.noise((int)(i * 10), 0.5f), 0.5f, 4, PerlinNoise.InterpolationType.CubicInterp);

                Console.WriteLine("{0}: {1}", (int)(i * 10), output);
            }

            Console.ReadKey();
        }
    }
}
