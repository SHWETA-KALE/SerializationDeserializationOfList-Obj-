using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Text.Json;
using SerlizationDeserlizationListAssignment.Models;

namespace SerlizationDeserlizationListAssignment
{
    internal class Program
    {
        static string path = ConfigurationManager.AppSettings["filePath"]!.ToString();

        static List<Person> Persons = new List<Person>
        {
            new Person{Id=1, Name="Neha", Email="neha@gmail.com"},
            new Person{Id=2, Name="Joe", Email="joe@gmail.com" },
            new Person{Id=3, Name="yami", Email="yami@gmail.com"},
            new Person{Id=4, Name="Allen", Email="allen@gmail.com"},
            new Person{Id=5, Name="Ana", Email="ana@gmail.com"},
            new Person{Id=6, Name="Emma", Email="emma@gmail.com"}
        };

        static void Main(string[] args)
        {
            SerializeList(Persons);
            DeserializeList();
        }

        static void DeserializeList()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Create a file first and then read it");
                return;
            }
            using (StreamReader sr = new StreamReader(path))
            {
                List<Person> persons = JsonSerializer.Deserialize<List<Person>>(sr.ReadToEnd()); //deserialized list
                Console.WriteLine($"Count of people:{persons.Count()}");
                
                //printing the readed data to the console
                //int count = 0;
                foreach (var person in persons)
                {
                    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Email: {person.Email}");
                    //count++;
                }
                //Console.WriteLine($"List contains {count} persons");
            }

        }

        static void SerializeList(List<Person> persons)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(JsonSerializer.Serialize(persons));
                Console.WriteLine("List of Persons written successfully to the file");
            }
        }

        

    }
}

//use list.count method for counting