using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace PoliceDepartmentConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Ласкаво просимо до програми для обробки даних поліцейського відомства!");

            XDocument doc = LoadXmlDocument();

            while (true)
            {
                Console.WriteLine("Оберіть дію:");
                Console.WriteLine("1. Додати дані про злочин та підозрюваних");
                Console.WriteLine("2. Вивести запити до наявних даних");
                Console.WriteLine("3. Вийти з програми");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Будь ласка, введіть числове значення.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddCrimeData(doc);
                        break;
                    case 2:
                        DisplayQueries(doc);
                        break;
                    case 3:
                        Console.WriteLine("Програма завершує роботу. Дякуємо за користування!");
                        return;
                    default:
                        Console.WriteLine("Введено неправильний вибір. Будь ласка, оберіть доступну опцію.");
                        break;
                }
            }
        }

        static void AddCrimeData(XDocument doc)
        {
            Console.WriteLine("Додавання нових даних про злочини та підозрюваних:");

            // Введення даних про злочин
            Console.WriteLine("Введіть дані про злочин:");
            Console.Write("Дата скоєння (рік-місяць-день): ");
            string dateCommitted = Console.ReadLine();
            Console.Write("Дата вирішення (рік-місяць-день): ");
            string dateSolved = Console.ReadLine();
            Console.Write("Тип злочину: ");
            string crimeType = Console.ReadLine();
            Console.Write("Тяжкість злочину: ");
            string severity = Console.ReadLine();

            // Введення даних про підозрюваного
            Console.WriteLine("Введіть дані про підозрюваного:");
            Console.Write("Прізвище: ");
            string lastName = Console.ReadLine();
            Console.Write("Дата народження (рік-місяць-день): ");
            string dateOfBirth = Console.ReadLine();
            Console.Write("Тип участі: ");
            string involvementType = Console.ReadLine();

            // Введення даних про зброю
            Console.WriteLine("Введіть дані про зброю:");
            Console.Write("Марка: ");
            string brand = Console.ReadLine();
            Console.Write("Країна походження: ");
            string countryOfOrigin = Console.ReadLine();
            Console.Write("Власник: ");
            string owner = Console.ReadLine();

            // Створення нового елемента для злочину та додавання його до документа
            XElement newCrime = new XElement("Crime",
                new XElement("DateCommitted", dateCommitted),
                new XElement("DateSolved", dateSolved),
                new XElement("Type", crimeType),
                new XElement("Severity", severity),
                new XElement("Suspects",
                    new XElement("Suspect",
                        new XElement("LastName", lastName),
                        new XElement("DateOfBirth", dateOfBirth),
                        new XElement("InvolvementType", involvementType)
                    )
                ),
                new XElement("WeaponsUsed",
                    new XElement("Weapon",
                        new XElement("Brand", brand),
                        new XElement("CountryOfOrigin", countryOfOrigin),
                        new XElement("Owner", owner)
                    )
                )
            );

            // Додавання нового злочину до списку злочинів у документі
            doc.Element("PoliceDepartment").Element("Crimes").Add(newCrime);

            // Зберігання змін у файл
            doc.Save("police_department.xml");

            Console.WriteLine("Нові дані про злочин додано успішно.");
        }


        static void DisplayQueries(XDocument doc)
        {
            Console.WriteLine("Виведення запитів до наявних даних:");

            Console.WriteLine("Запит 1: Вивести усі типи злочинів");
            var crimeTypes = doc.Descendants("Type").Select(t => t.Value).Distinct();
            foreach (var type in crimeTypes)
            {
                Console.WriteLine(type);
            }

            Console.WriteLine("Запит 2: Підрахувати кількість злочинів");
            var crimeCount = doc.Descendants("Crime").Count();
            Console.WriteLine($"Загальна кількість злочинів: {crimeCount}");

            Console.WriteLine("Запит 3: Знайти усі важкі злочини");
            var severeCrimes = doc.Descendants("Crime").Where(c =>
                (string)c.Element("Severity") == "Висока" || (string)c.Element("Severity") == "Критична");
            Console.WriteLine("Важкі злочини:");
            foreach (var crime in severeCrimes)
            {
                Console.WriteLine(crime.Element("Type").Value);
            }

            Console.WriteLine("Запит 4: Вивести усі прізвища підозрюваних");
            var suspectLastNames = doc.Descendants("Suspect").Select(s => s.Element("LastName").Value).Distinct();
            Console.WriteLine("Прізвища підозрюваних:");
            foreach (var lastName in suspectLastNames)
            {
                Console.WriteLine(lastName);
            }

            Console.WriteLine("Запит 5: Знайти усі злочини зі зброєю");
            var crimesWithWeapons = doc.Descendants("Crime").Where(c => c.Element("Weapon") != null);
            Console.WriteLine("Злочини зі зброєю:");
            foreach (var crime in crimesWithWeapons)
            {
                Console.WriteLine(crime.Element("Type").Value);
            }

            Console.WriteLine("Запит 6: Знайти усі злочини, скоєні після певної дати");
            DateTime dateThreshold = new DateTime(2023, 1, 1);
            var crimesAfterDate = doc.Descendants("Crime")
                .Where(c => DateTime.Parse((string)c.Element("DateCommitted")) > dateThreshold);
            Console.WriteLine("Злочини, скоєні після 1 січня 2023 року:");
            foreach (var crime in crimesAfterDate)
            {
                Console.WriteLine(crime.Element("Type").Value);
            }

            Console.WriteLine("Запит 7: Вивести усіх підозрюваних, які мають зв'язок з конкретною зброєю");
            string weaponBrand = "AK-47";
            var suspectsWithWeapon = doc.Descendants("Suspect")
                .Where(s => s.Ancestors("Crime").Elements("Weapon")
                    .Any(w => (string)w.Element("Brand") == weaponBrand));
            Console.WriteLine($"Підозрювані, які мають зв'язок з {weaponBrand}:");
            foreach (var suspect in suspectsWithWeapon)
            {
                Console.WriteLine(suspect.Element("LastName").Value);
            }

            Console.WriteLine("Запит 8: Вивести унікальні країни походження зброї");
            var weaponCountries = doc.Descendants("Weapon").Select(w => w.Element("CountryOfOrigin").Value).Distinct();
            Console.WriteLine("Унікальні країни походження зброї:");
            foreach (var country in weaponCountries)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("Запит 9: Підрахувати кількість злочинів, які є вищими за середню тяжкість");
            var avgSeverity = doc.Descendants("Crime")
                .Average(c => (int)Enum.Parse(typeof(Severity), c.Element("Severity").Value));
            var crimesAboveAverageSeverity = doc.Descendants("Crime").Count(c =>
                (int)Enum.Parse(typeof(Severity), c.Element("Severity").Value) > avgSeverity);
            Console.WriteLine(
                $"Злочинів, що є вищими за середню тяжкість ({avgSeverity}): {crimesAboveAverageSeverity}");

            Console.WriteLine("Запит 10: Знайти всі злочини, в яких є два або більше підозрюваних");
            var crimesWithMultipleSuspects = doc.Descendants("Crime").Where(c => c.Elements("Suspect").Count() >= 2);
            Console.WriteLine("Злочини з двома або більше підозрюваними:");
            foreach (var crime in crimesWithMultipleSuspects)
            {
                Console.WriteLine(crime.Element("Type").Value);
            }

            Console.WriteLine("Запит 11: Вивести усі злочини, які є вирішені");
            var solvedCrimes = doc.Descendants("Crime")
                .Where(c => !string.IsNullOrEmpty(c.Element("DateSolved")?.Value));
            Console.WriteLine("Вирішені злочини:");
            foreach (var crime in solvedCrimes)
            {
                Console.WriteLine(crime.Element("Type").Value);
            }

            Console.WriteLine("Запит 12: Вивести усі типи злочинів за певний період");
            DateTime startDate = new DateTime(2023, 1, 1);
            DateTime endDate = new DateTime(2023, 12, 31);
            var crimesInPeriod = doc.Descendants("Crime")
                .Where(c => DateTime.Parse((string)c.Element("DateCommitted")) >= startDate &&
                            DateTime.Parse((string)c.Element("DateCommitted")) <= endDate)
                .Select(c => c.Element("Type").Value)
                .Distinct();
            Console.WriteLine($"Злочини, скоєні з {startDate} по {endDate}:");
            foreach (var type in crimesInPeriod)
            {
                Console.WriteLine(type);
            }

            Console.WriteLine("Запит 13: Знайти усі злочини, в яких використовувався конкретний тип зброї");
            string specificWeaponType = "Пістолет";
            var crimesWithSpecificWeapon = doc.Descendants("Crime")
                .Where(c => c.Elements("Weapon").Any(w => (string)w.Element("Type") == specificWeaponType));
            Console.WriteLine($"Злочини, в яких використовувався {specificWeaponType}:");
            foreach (var crime in crimesWithSpecificWeapon)
            {
                Console.WriteLine(crime.Element("Type").Value);
            }

            Console.WriteLine("Запит 14: Вивести усіх підозрюваних, які є неповнолітніми (менше 18 років)");
            var underageSuspects = doc.Descendants("Suspect")
                .Where(s => DateTime.Parse((string)s.Element("DateOfBirth")) > DateTime.Now.AddYears(-18));
            Console.WriteLine("Неповнолітні підозрювані:");
            foreach (var suspect in underageSuspects)
            {
                Console.WriteLine(suspect.Element("LastName").Value);
            }

            Console.WriteLine("Запит 15: Вивести усі злочини, де використовувалась зброя певного бренду");
            string specificWeaponBrand = "Glock";
            var crimesWithSpecificWeaponBrand = doc.Descendants("Crime")
                .Where(c => c.Elements("Weapon").Any(w => (string)w.Element("Brand") == specificWeaponBrand));
            Console.WriteLine($"Злочини, де використовувалась зброя бренду {specificWeaponBrand}:");
            foreach (var crime in crimesWithSpecificWeaponBrand)
            {
                Console.WriteLine(crime.Element("Type").Value);
            }
        }

        static XDocument LoadXmlDocument()
        {
            string xmlFilePath = "police_department.xml";
            XDocument doc;

            // Перевіряємо, чи існує XML-файл
            if (File.Exists(xmlFilePath))
            {
                // Якщо файл існує, завантажуємо його
                doc = XDocument.Load(xmlFilePath);
            }
            else
            {
                // Якщо файл не існує, створюємо новий XML-документ
                doc = new XDocument(
                    new XElement("PoliceDepartment",
                        new XElement("Crimes"),
                        new XElement("Suspects"),
                        new XElement("Weapons")
                    )
                );

                // Зберігаємо створений документ у файл
                doc.Save(xmlFilePath);
            }

            return doc;
        }
    }
}