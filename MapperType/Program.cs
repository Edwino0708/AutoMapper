using System;
using AutoMapper;

namespace MapperType
{
    class Program
    {
        static void Main(string[] args)
        {

            //Static Mapper
            Mapper.Initialize(cfg => cfg.CreateMap<Source, Destination>());
            var destination = Mapper.Map<Destination>(new Source);

            //Instace of Mapper
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Source, Destination>()
            );
            IMapper mapper = new Mapper(config);
            //OR
            var mapper1 = config.CreateMapper();

        }
    }

    public class Source
    {
        public string Name { get; set; }

    }
    public class Destination
    {
        public string Name { get; set; }

    }
}
