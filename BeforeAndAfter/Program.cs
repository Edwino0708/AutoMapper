using System;
using AutoMapper;

namespace BeforeAndAfter
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Person, PersonDTO>()
                    .BeforeMap((src, dest) => src.Age = src.Age + 10)
                    .AfterMap<CallMeJohnDoe>();
            });

            var destination = Mapper.Map<PersonDTO>(new Person { Name = "Doe" });
            Console.WriteLine(destination.Name);
            Console.WriteLine(destination.Age);
        }
    }

    public class CallMeJohnDoe : IMappingAction<Person, PersonDTO>
    {
        public void Process(Person source, PersonDTO destination)
        {
            destination.Name = $"John {destination.Name}";
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
