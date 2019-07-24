using System;
using AutoMapper;

namespace GenericsMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(Source<>), typeof(Destination<>)));

            var source = new Source<int> { Value = 10 };

            var destination = Mapper.Map<Source<int>, Destination<int>>(source);
            Console.WriteLine(destination.Value);

        }
    }

    public class Source<T>
    {
        public T Value { get; set; }
    }

    public class Destination<T>
    {
        public T Value { get; set; }
    }

}
