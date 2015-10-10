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
            for (int i = 0; i < 20; i++)
            {
                float output = p.PerlinNoiseGeneration(p.noise(i, 0.5f), 0.5f, 4, PerlinNoise.InterpolationType.CosineInterp);

                Console.WriteLine(output);
            }

            Console.ReadKey();
        }
    }
}
