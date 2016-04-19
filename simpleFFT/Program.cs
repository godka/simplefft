﻿using System;
using System.Collections.Generic;
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
            Console.Write("dft:");
            for (int i = 0; i < source.Length; i++)
                fft.low_ft(i);
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
            //List<double> source = new List<double>();
            //Random rand = new Random();
            //for (int i = 0; i < 16; i++)
            //    source.Add(rand.Next());
			double[] source = { 1, 2, 3, 4, 5, 6, 7,8};
            testRight(source);
           // Console.WriteLine("{0}ms", testdft(source.ToArray()));
            //Console.WriteLine("{0}ms", testfft(source.ToArray()));
            Console.ReadKey();
		}
	}
}
