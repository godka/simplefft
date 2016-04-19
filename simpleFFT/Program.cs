using System;

namespace simpleFFT
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("=========Start dft=========");
			double[] source = { 1, 2, 3, 4, 5, 6, 7,8};
			simplefft fft = new simplefft (source);
			for(int i = 0;i < source.Length;i++)
				Console.WriteLine (fft.low_ft (i,true).ToString ());
			Console.WriteLine ("=========Start fft=========");
			var ret = fft.simple_fft (source);
			foreach (var t in ret)
				Console.WriteLine (t.ToString ());
		}
	}
}
