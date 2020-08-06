using System;
using System.Collections.Generic;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //We can specify types like this as well
            string result = FizzBuzz<string>("NirajDahal");
            Console.WriteLine($"Passed string and got {result}");

            result = FizzBuzz(123456789);
            Console.WriteLine($"Passed int and got {result}");

            result = FizzBuzz(false);
            Console.WriteLine($"Passed boolean and got {result}");

            PersonModel person = new PersonModel { FirstName="Niraj", Age=21};
            result = FizzBuzz(person);
            Console.WriteLine($"Passed object and got {result}");

            PersonModel person1 = new PersonModel { FirstName = "Niraj", Age = 21, HasError = false };
            PersonModel person2 = new PersonModel { FirstName = "Dahal", Age = 22, HasError = false };

            PersonModel person3 = new PersonModel { FirstName = "Nir", Age = 29, HasError = true };
            PersonModel person4 = new PersonModel { FirstName = "Dal", Age = 25, HasError = true };

            GenericHelper<PersonModel> genericHelp = new GenericHelper<PersonModel>();


            genericHelp.CheckItemAndAdd(person1);
            genericHelp.CheckItemAndAdd(person2);
            genericHelp.CheckItemAndAdd(person3);
            genericHelp.CheckItemAndAdd(person4);
        }


        

        //If a number is divisble by 3 -print fizz , 5- print buzz, 3 & 5 = print fizz buzz

        private static string FizzBuzz<T>(T item)
        {
            string output ="Oops";
            int itemLength = item.ToString().Length;
           
            if(itemLength % 3 == 0)
            {
                output = "Fizz";
               
            }

            if(itemLength %5 == 0)
            {
                output = "Buzz";
            }

            if (itemLength %3 ==0 && itemLength % 5 == 0)
            {
                output = "FizzBuzz";
            }

            return output;
        }
    }

    public class PersonModel: IErrorCheck
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public bool HasError { get; set; }
    }

    public class CarModel
    {
        public string  Manufacturer { get; set; }

        public int YearOfManufacture { get; set; }
        
    }

    public class GenericHelper<T> where T : class, IErrorCheck
    {
        public List<T> Items { get; set; } = new List<T>();

        public List<T> RejectedItems { get; set; } = new List<T>();


        public void CheckItemAndAdd(T item)
        {
            if (item.HasError)
            {
                RejectedItems.Add(item);
            }
            else
            {
                Items.Add(item);
            }
           
        }
    }

    public interface IErrorCheck
    {
        bool HasError { get; set; }
    }
}
