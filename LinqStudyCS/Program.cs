﻿using System;
using System.Collections.Generic;
//とりあえず最初はLinqなしで
//using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace LinqStudyCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(C#)Problem1:" + Problem1(1000));
            Console.WriteLine("(C#)Problem2:" + Problem2(4000000));
        }

        // http://odz.sakura.ne.jp/projecteuler/index.php?cmd=read&page=Problem%201
        /// <summary>
        /// 10未満の自然数のうち, 3 もしくは 5 の倍数になっているものは 3, 5, 6, 9 の4つがあり, これらの合計は 23 になる.
        /// 同じようにして, 1000 未満の 3 か 5 の倍数になっている数字の合計を求めよ.
        /// </summary>
        /// <param name="limit">制限値</param>
        /// <returns>答え</returns>
        public static int Problem1(int limit)
        {
            int sum = 0;
            for (int i = 0; i < limit; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }

        // http://odz.sakura.ne.jp/projecteuler/index.php?cmd=read&page=Problem%202
        /// <summary>
        /// フィボナッチ数列の項は前の2つの項の和である. 最初の2項を 1, 2 とすれば, 最初の10項は以下の通りである.
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        /// 数列の項の値が400万を超えない範囲で, 偶数値の項の総和を求めよ.
        /// </summary>
        /// <param name="limit">制限値</param>
        /// <returns>答え</returns>
        public static int Problem2(int limit)
        {
            int sum = 0;

            int a = 1;
            int b = 1;
            while (b < limit)
            {
                if (b % 2 == 0)
                {
                    sum += b;
                }

                var temp = a;
                a = b;
                b = a + temp;
            }

            return sum;
        }
    }
}
