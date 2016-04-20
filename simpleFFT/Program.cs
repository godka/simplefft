using System;
using System.Collections.Generic;
using System.Numerics;
namespace simpleFFT
{
	class MainClass
    {
        public static int testfft(double[] source)
        {
            var t1 = Environment.TickCount;
            simplefft fft = new simplefft();
            Console.Write("fft:");
            fft.simple_fft(source);
            return Environment.TickCount - t1;
        }
        public static int testdft(double[] source)
        {
            var t1 = Environment.TickCount;
            simplefft fft = new simplefft(source);
            Console.Write("dft-single:");
            for (int i = 0; i < source.Length; i++)
                fft.low_ft(i);
            return Environment.TickCount - t1;
        }
        public static int testdft2(double[] source)
        {
            var t1 = Environment.TickCount;
            simplefft fft = new simplefft(source);
            Console.Write("dft-parallel:");

            System.Threading.Tasks.Parallel.For(0, source.Length, (i) => { fft.low_ft(i); });
            return Environment.TickCount - t1;
        }
        public static void testRight(double[] source)
        {
            List<Complex> dft = new List<Complex>();
            simplefft fft = new simplefft(source);
            for (int i = 0; i < source.Length; i++)
                dft.Add(fft.low_ft(i));
            Console.WriteLine("dft:");
            var ret = fft.simple_fft(source);
            for (int i = 0; i < source.Length; i++)
                Console.WriteLine("{0},{1}", i, dft[i].ToString());
            Console.WriteLine("fft:");
            for (int i = 0; i < source.Length; i++)
                Console.WriteLine("{0},{1}", i,ret[i].ToString());
        }
		public static void Main (string[] args)
		{
            for (int j = 6; j < 20; j++)
            {
                Console.Write("start {0}: ", Math.Pow(2, j));
                List<double> source = new List<double>();
                Random rand = new Random();
                for (int i = 0; i < Math.Pow(2,j); i++)
                    source.Add(rand.Next());
                //Console.Write("{0}ms ", testdft(source.ToArray()));
                Console.Write("{0}ms ", testdft2(source.ToArray()));
                Console.WriteLine("{0}ms", testfft(source.ToArray()));
            }
            Console.ReadKey();
		}
	}
}
