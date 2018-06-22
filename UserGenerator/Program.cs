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
            var collection = des.GetManyDiffUser(3);

            if (collection.Result != null)
            {
                foreach (var item in collection.Result.results)
                {
                    Console.WriteLine(item.name.first + " " + item.name.last);
                    Console.WriteLine(item.dob.date);
                    Console.Write(collection.Result.info.results);
                    Console.WriteLine(" " + collection.Result.info.seed + " " + collection.Result.info.version);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("***********************************");
            var singler = des.GetSingleDiffUser();
            if (singler.Result != null)
            {
                Console.WriteLine(singler.Result.results[0].name.first + " " + singler.Result.results[0].name.last);
                Console.WriteLine(singler.Result.results[0].dob.date);
                Console.Write(singler.Result.info.results);
                Console.WriteLine(" " + singler.Result.info.seed + " " + singler.Result.info.version);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}