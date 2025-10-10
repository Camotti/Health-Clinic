using System.Linq;
using System;

namespace healthclinic.utils
{
    public class Validator
    {
        public int ReadInt(string prompt) //metodo 1 , leer opciones enteras del menu
        {
            int result;
            while (true)
            {
                Console.WriteLine($"Entry: {prompt}");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result; // exitosa 
                }
                Console.WriteLine("Invalid entry, please try again");
            }
        }

        //metodo 2 , buscar por ID

        public Guid ReadGuid()
        {
            Guid result;
            while (true)
            {
                Console.WriteLine("Entry the ID: ");
                string? input = Console.ReadLine();
                if (Guid.TryParse(input, out result))
                {
                    return result; // exito 
                }
                Console.WriteLine("ID invalid , please try again with the correct format.");
            }
        }


        // metodo 3 , leer string no vacios para nombre 

        public string ReadNonEmptyString (string prompt)
        {
            string? input;
            while (true)
            {
                Console.WriteLine($"Entry {prompt}:");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }
                Console.WriteLine("Please try again the input cannot be empty. ");
            }
        }
        
    }
}