using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace serializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
            {
                Name = "John Doe",
                Address = null,
                Gender = Gender.Male,
                SSN = "123-45-6789"
            };

            var personJson = JsonConvert.SerializeObject(person); 
            Console.WriteLine(personJson);

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new FilterContractResolver(new string[]{"SSN"})
            };
            settings.Converters.Add(new StringEnumConverter());

            personJson = JsonConvert.SerializeObject(person,settings);
            Console.WriteLine(personJson);

            Console.ReadLine();
        }
    }
}
