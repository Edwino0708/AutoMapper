using System;
using AutoMapper;

namespace ValueConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Sources, Destination>()
                    .ForMember(dest => dest.Percentage, opt => opt.ConvertUsing(new PercentageFormatter(), src => src.Percentage));
            });

            var source = new Sources
            {
                Percentage = 1
            };
            var destination = Mapper.Map<Destination>(source);
            Console.WriteLine(destination.Percentage);
        }
    }

    public class PercentageFormatter : IValueConverter<decimal, string>
    {
        public string Convert(decimal sourceMember, ResolutionContext context)
            => sourceMember.ToString("p1");
    }

    public class Sources
    {
        public decimal Percentage { get; set; }
    }
    public class Destination
    {
        public string Percentage { get; set; }
    }
}
