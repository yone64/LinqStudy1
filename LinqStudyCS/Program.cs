using System;
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
            return GetNaturalNumber()
                    .TakeWhile(x => x < limit)
                    .Where(y => y % 3 == 0 || y % 5 == 0)
                    .Sum();
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
            return GetFibonacchiNumber()
                    .TakeWhile(x => x < limit)
                    .Where(y => y % 2 == 0)
                    .Sum();
        }

        /// <summary>
        /// 自然数を返すメソッド
        /// </summary>
        /// <returns>列挙可能な自然数</returns>
        public static IEnumerable<int> GetNaturalNumber()
        {
            int i = 0;
            while (true)
            {
                yield return ++i;
            }
        }

        /// <summary>
        /// フィボナッチ数列を返すメソッド
        /// </summary>
        /// <returns>列挙可能なフィボナッチ数列</returns>
        public static IEnumerable<int> GetFibonacchiNumber()
        {
            int a = 1;
            int b = 1;
            while (true)
            {
                yield return b;

                var temp = a;
                a = b;
                b = a + temp;
            }
        }

    }

    /// <summary>
    /// 拡張メソッドを定義するクラス
    /// </summary>
    static class ExtentionMethods
    {
        /// <summary>
        /// 終了条件を設定するメソッド
        /// </summary>
        /// <param name="source">元数列</param>
        /// <param name="predicate">終了条件</param>
        /// <returns>終了条件が設定された数列</returns>
        public static IEnumerable<int> TakeWhile(this IEnumerable<int> source, Func<int, bool> predicate)
        {
            foreach (var i in source)
            {
                if (predicate(i))
                {
                    yield return i;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 抽出条件を設定するメソッド
        /// </summary>
        /// <param name="source">元数列</param>
        /// <param name="predicate">抽出条件</param>
        /// <returns>抽出条件が設定された数列</returns>
        public static IEnumerable<int> Where(this IEnumerable<int> source, Func<int, bool> predicate)
        {
            foreach (var i in source)
            {
                if (predicate(i))
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// 合計を求めるメソッド
        /// </summary>
        /// <param name="source">元数列</param>
        /// <returns>合計</returns>
        public static int Sum(this IEnumerable<int> source)
        {
            int sum = 0;
            foreach (var i in source)
            {
                sum += i;
            }
            return sum;
        }

    }
}
