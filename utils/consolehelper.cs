using System.Linq;
using System;

namespace healthclinic.utils
{
    public static class ConsoleHelper
    {
        public static byte Readbyte(string prompt) //metodo 1 , leer opciones enteras del menu
        {
            byte result;
            while (true)
            {
                Console.WriteLine($"Entry: {prompt}");
                string? input = Console.ReadLine();
                if (byte.TryParse(input, out result))
                {
                    return result; // exitosa 
                }
                Console.WriteLine("Invalid entry, please try again");
            }
        }

        //metodo 2 , buscar por ID

        public static Guid ReadGuid()
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

        


        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.WriteLine($"{prompt} ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Invalid entry, write a number again.");
            }
        }





        // public static byte ReadByte(string prompt)
        // {
        //     byte result;
        //     while (true)
        //     {
        //         Console.Write($"{prompt}");
        //         string? input = Console.ReadLine();
        //         if (byte.TryParse(input, out result))
        //             return result;
        //         Console.WriteLine("❌ Entrada inválida, intenta de nuevo (solo números entre 0-255).");
        //     }
        // }

        // 
        public static Guid ReadGuid(string prompt)
        {
            Guid result;
            while (true)
            {
                Console.Write($"{prompt}");
                string? input = Console.ReadLine();
                if (Guid.TryParse(input, out result))
                    return result;
                Console.WriteLine("❌ ID inválido, formato incorrecto (ejemplo: a3f0e132-6f57-4f2b-8e1c-9a84ef89d2a3).");
            }
        }



        // metodo 3 , leer string no vacios para nombre 

        public static string ReadNonEmptyString(string prompt)
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






        public static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}");
                string? input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                    return date;

                Console.WriteLine("❌ Formato inválido. Usa el formato correcto: dd/MM/yyyy (por ejemplo 09/10/2025)");
            }
        }


        public static string ReadString( string prompt)
        {
            return ReadNonEmptyString(prompt);
        }
    }
}