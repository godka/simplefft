using System;
using System.Collections.Generic;
namespace simpleFFT
{
    public class simplefft
    {
        private double[] _source;
        private int _sourcelen;
        public Complex low_ft(int index, bool normalized = true)
        {
            Complex complex = new Complex();
            for (int i = 0; i < _sourcelen; i++)
                complex += w(index * i, _sourcelen) * _source[i];
            if (normalized)
                return complex / _sourcelen;
            else
                return complex;
        }
        private Complex w(double x, int k)
        {
            var _2piux = 2 * Math.PI * x / k;
            var _sinux = Math.Sin(_2piux);
            var _cosux = Math.Cos(_2piux);
            return new Complex(_cosux, -_sinux);
        }
        public Complex[] simple_fft(double[] _tmpsource)
        {
            Complex[] complex_source = new Complex[_tmpsource.Length];
            for (int i = 0; i < _tmpsource.Length; i++)
            {
                complex_source[i] = new Complex(_tmpsource[i]);
            }
            return simple_fft(complex_source);
        }
        public Complex[] simple_fft(Complex[] _tmpsource)
        {
            var _len = _tmpsource.Length;
            //end of loop
            if (_len == 1)
            {
                return _tmpsource;
            }
            else
            {
                Complex[] ret = new Complex[_len];
                List<Complex> _xodd_list = new List<Complex>();
                List<Complex> _xeven_list = new List<Complex>();
                for (int i = 0; i < _len; i++)
                {
                    var tmp = _tmpsource[i];
                    if (i % 2 == 0)
                        _xeven_list.Add(tmp);
                    else
                        _xodd_list.Add(tmp);
                }
                //start loop
                var Xoddlist = simple_fft(_xodd_list.ToArray());
                var Xevenlist = simple_fft(_xeven_list.ToArray());

                //merge
                for (int i = 0; i < _len / 2; i++)
                {
                    ret[i] = (Xevenlist[i] + Xoddlist[i] * w(i, _len)) / 2;
                    ret[i + _len / 2] = (Xevenlist[i] - Xoddlist[i] * w(i, _len)) / 2;
                }
                return ret;
            }
        }
        public simplefft()
        {

        }
        public simplefft(double[] source)
        {
            _source = source;
            _sourcelen = source.Length;
        }
    }
}

