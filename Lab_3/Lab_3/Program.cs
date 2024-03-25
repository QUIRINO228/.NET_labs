using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Зчитуємо JSON з файлу з кодуванням UTF-8
            string jsonFilePath = "data.json";
            string json = File.ReadAllText(jsonFilePath, System.Text.Encoding.UTF8);

            // Десеріалізація JSON до об'єкту
            var crimes = JsonConvert.DeserializeObject<JObject>(json);

            // Виведення деяких даних з об'єкту з використанням JsonDocument
            Console.WriteLine("Деякі дані з використанням JsonDocument:");
            foreach (var crime in crimes["crimes"])
            {
                var type = crime["type"].ToString();
                var severity = crime["severity"].ToString();
                Console.WriteLine($"Тип злочину: {type}, Ступінь тяжкості: {severity}");
            }

            // Виведення деяких даних з об'єкту з використанням JsonNode
            Console.WriteLine("\nДеякі дані з використанням JsonNode:");
            foreach (var crime in crimes["crimes"])
            {
                var type = crime["type"].Value<string>();
                var severity = crime["severity"].Value<string>();
                Console.WriteLine($"Тип злочину: {type}, Ступінь тяжкості: {severity}");
            }
            
            // Серіалізація об'єкту назад у JSON
            string serializedJson = JsonConvert.SerializeObject(crimes, Formatting.Indented);
            Console.WriteLine("\nСеріалізовані дані у форматі JSON:");
            Console.WriteLine(serializedJson);
        }
    }
}