using System;
using DLL.DataGenerator;

namespace UserGenerator
{
    // for example, how use .dll DataGenerator
    // Random user data API - http://randomuser.me/
    internal class Program
    {
        private static void Main(string[] args)
        {
            JsonDeserialize des = new JsonDeserialize();
            var collection = des.GetManyDiffUser(50);

            if (collection != null)
            {
                foreach (var item in collection.results)
                {
                    Console.WriteLine(item.name.first + " " + item.name.last);
                    Console.WriteLine(item.dob.date);
                    Console.Write(collection.info.results);
                    Console.WriteLine(" " + collection.info.seed + " " + collection.info.version);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("***********************************");
            var singler = des.GetSingleDiffUser();
            if (singler != null)
            {
                Console.WriteLine(singler.results[0].name.first + " " + singler.results[0].name.last);
                Console.WriteLine(singler.results[0].dob.date);
                Console.Write(singler.info.results);
                Console.WriteLine(" " + singler.info.seed + " " + singler.info.version);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}