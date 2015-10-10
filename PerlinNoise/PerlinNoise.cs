using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Perlin_Noise
{
	public class PerlinNoise
	{

		/// <summary>
		/// The type of interpolation
		/// </summary>
		public enum InterpolationType
		{
			LinearInterp = 1,
			CosineInterp,
			CubicInterp
		};

		/// <summary>
		/// The three prime numbers used for noise generation
		/// </summary>
		[Obsolete("Use primesList instead", false)]
		public int[] primes = { 15731, 789221, 1376312589 };

		/// <summary>
		/// List of an array of primes
		/// </summary>
		public List<int[]> primesList = new List<int[]>();

		public PerlinNoise()
		{
			addPrimes();
		}

		/// <summary>
		/// produces a pseudo-random number from 0.0 to 1.0 based on seed 
		/// </summary>
		/// <remarks>Not entirely sure how this works</remarks>
		/// <param name="seed">The seed to feed the generator</param>
		/// <returns>Any value from 0.0 to 1.0</returns>
		[Obsolete("Use the overloaded method noise(int seed, float octave) instead", false)]
		public float noise(int seed)
		{
			int n = (seed << 13) ^ seed; // bitwise shift to the left by 13 places then rased to n
			//& performs a bitwise multiplication (i.e. 0*0 =0, 1*0=0, 1*1=1
			//it makes this multiplication with the largerst possible int
			//i.e. +111111.....1111
			return (float)(1.0 - ((n * (n * n * primes[0] + primes[1]) + primes[2]) & int.MaxValue) / 1073741824f);
		}

		/// <summary>
		/// produces a pseudo-random number from 0.0 to 1.0 based on seed and the octave
		/// </summary>
		/// <param name="seed">The seed to feed the generator</param>
		/// <param name="octave">Determines primes to use in</param>
		/// <returns></returns>
		public float noise(float seed, float octave)
		{
			int n = (((int)seed) << 13) ^ (int)seed; // bitwise shift to the left by 13 places then rased to n
			//& performs a bitwise multiplication (i.e. 0*0 =0, 1*0=0, 1*1=1
			//it makes this multiplication with the largerst possible int
			//i.e. +111111.....1111
			int index = ((int)octave);
			return (float)(1.0 - ((n * (n * n * (primesList[index][0]) + (primesList[index][1])) + (primesList[index][2])) & int.MaxValue) / 1073741824f);
		}

		/// <summary>
		/// Looks pretty bad, like those cheap things that people use to generate landscape, however it's
		/// a simple algorithm and would make sense to use if you are trying to generate perlin noise
		/// in real time
		/// </summary>
		/// <param name="LowerBound">Lower bound of interpolation</param>
		/// <param name="UpperBound">Upper bound of interpolation</param>
		/// <param name="noise">Any value from 0.0 to 1.0</param>
		/// <returns>Some value between the upper and lower bound</returns>
		public float LinearInterpolate(float LowerBound, float UpperBound, float noise)
		{
			return LowerBound * (1 - noise) + UpperBound * noise;
		}

		/// <summary>
		/// This method gives a much smoother curve than linear intorplation. There is a 
		/// slight cost in speed, however.
		/// </summary>
		/// <param name="LowerBound">Lower bound of interpolation</param>
		/// <param name="UpperBound">Upper bound of interpolation</param>
		/// <param name="noise">Any value from 0.0 to 1.0</param>
		/// <returns>Some value between the upper and lower bound</returns>
		public float CosineInterpolate(float LowerBound, float UpperBound, float noise)
		{
			var ft = noise * Math.PI;
			var f = (1 - Math.Cos(ft)) * .5;

			return (float)(LowerBound * (1 - f) + UpperBound * f);
		}

		/// <summary>
		/// Gives even smoother results than cosine interpolation, however this
		/// method has an even higher cost in speed.
		/// </summary>
		/// <param name="beforeLowerBound">The point before the lower bound</param>
		/// <param name="LowerBound">Lower bound of interpolation</param>
		/// <param name="UpperBound">Upper bound of interpolation</param>
		/// <param name="afterUpperBound">The point after the upper bound</param>
		/// <param name="noise">Any value from 0.0 to 1.0</param>
		/// <returns>Some value between the upper and lower bound</returns>
		public float CubicInterpolate(float beforeLowerBound, float LowerBound, float UpperBound, float afterUpperBound, float noise)
		{
			float v0 = beforeLowerBound;        // \
			float v1 = LowerBound;              //  \
			float v2 = UpperBound;              //   |- I'm using the mathmatical equation, therefore i want the algorithm to look like the equation
			float v3 = afterUpperBound;         //  /
			float x = noise;                    // /

			var P = (v3 - v2) - (v0 - v1);
			var Q = (v0 - v1) - P;
			var R = v2 - v0;
			var S = v1;

			var result = (P * Math.Pow(x, 3)) + (Q * Math.Pow(x, 2)) + (R * x) + S;
			return (float)result;
		}

		/// <summary>
		/// Smooths out the noise for one dimensional perlin noise generation
		/// </summary>
		/// <param name="x">Point on the x-axis</param>
		/// <returns>Smoothed out point</returns>
		public float SmoothNoiseOneDimensional(float x, float octave)
		{
			return (noise(x, octave) / 2) + (noise(x - 1, octave) / 4) + (noise(x + 1, octave) / 4);
		}

		/// <summary>
		/// Interpolates noise
		/// </summary>
		/// <param name="noise">Any value from 0.0 to 1.0</param>
		/// <param name="interpolationType">The type of interpolation to be performed</param>
		/// <returns>The interpolated noise</returns>
		private float InterpolatedNoise(float noise, float octave, InterpolationType interpolationType)
		{
			int intNoise = (int)noise;
			float fractionalNoise = noise - intNoise;

			var LowerBound = SmoothNoiseOneDimensional(intNoise, octave);
			var UpperBound = SmoothNoiseOneDimensional(intNoise + 1, octave);

			float flag = 0.0f;

			switch (interpolationType)
			{
				case InterpolationType.LinearInterp:
					flag = LinearInterpolate(LowerBound, UpperBound, fractionalNoise);
					break;
				case InterpolationType.CosineInterp:
					flag = CosineInterpolate(LowerBound, UpperBound, fractionalNoise);
					break;
				case InterpolationType.CubicInterp:
					// I don't know if this will actually do what i want it to (I'm not even sure I know what I want it to do anyways)
					flag = CubicInterpolate(SmoothNoiseOneDimensional(intNoise - 1, octave), LowerBound, UpperBound, SmoothNoiseOneDimensional(intNoise + 2, octave), fractionalNoise);
					break;
				default:
					break;
			}

			return flag;

		}

		/// <summary>
		/// Generates one dimensional Perlin Noise
		/// </summary>
		/// <param name="noise">The noise (can be interpolated for smoother results)</param>
		/// <param name="persistence"></param>
		/// <param name="octaves"></param>
		/// <param name="interpolationType"></param>
		/// <returns>Perlin Noise</returns>
		public float PerlinNoiseGeneration(float noise, float persistence, float octaves, InterpolationType interpolationType)
		{
			float total = 0.0f;
			for (int octave = 0; octave < octaves - 1; octave++)
			{
				float frequency = (float)Math.Pow(2, octave);
				float amplitude = (float)Math.Pow(persistence, octave);

				total += InterpolatedNoise((noise * frequency), octave, interpolationType) * amplitude;
			}
			return total;
		}

		/// <summary>
		/// Method to be ran at initialization of class
		/// </summary>
		void addPrimes()
		{
			int prime1 = 0;
			int prime2 = 0;
			int prime3 = 0;
			for (int i = 1; i < 10000000; i += 2)
			{
				if (isPrime(i))
				{
					prime1 = i;
					for (; i < 10000000; i += 2)
					{
						if (isPrime(i))
						{
							prime2 = i;
							for (; i < 10000000; i += 2)
							{
								if (isPrime(i))
								{
									prime3 = i;
									primesList.Add(new int[] { prime1, prime2, prime3 });
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Checks input to see if it is prime
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		bool isPrime(int n)
		{
			if (n % 2 == 0)
				return false;
			for (int i = 3; i * i <= n; i += 2)
			{
				if (n % i == 0)
					return false;
			}
			return true;
		}
	}
}
