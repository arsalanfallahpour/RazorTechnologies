using System;
using System.Threading;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace RazorTechnologies.TagHelpers.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<FirstBenchmarking>();
        }
    }
    [MemoryDiagnoser]
    public class FirstBenchmarking
    {
        [Benchmark]
        public void StringAppending()
        {
            var firstWord = "Hel";
            var secondWord = new string('o', 5);
            var Sentence = firstWord + secondWord;  
        }
        [Benchmark]
        public void StringReplacing()
        {
            var firstWord = "Helooooooooow";
            var @finally = string.Create(firstWord.Length, firstWord, (span, value) =>
            {
                value.AsSpan().CopyTo(span);
                span[3..11].Fill('.');
            });
        }
    }
}
