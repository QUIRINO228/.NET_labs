using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Створюємо об'єкти злочинів
            Crime crime1 = new Crime
            {
                DateCommitted = new DateTime(2024, 3, 1),
                DateSolved = new DateTime(2024, 3, 5),
                Type = "Вбивство",
                Severity = "Важкий"
            };

            Crime crime2 = new Crime
            {
                DateCommitted = new DateTime(2024, 2, 15),
                DateSolved = new DateTime(2024, 2, 18),
                Type = "Грабіж",
                Severity = "Середній"
            };

            Crime crime3 = new Crime
            {
                DateCommitted = new DateTime(2024, 4, 10),
                DateSolved = new DateTime(2024, 4, 15),
                Type = "Вбивство",
                Severity = "Середній"
            };

            Crime crime4 = new Crime
            {
                DateCommitted = new DateTime(2024, 5, 20),
                DateSolved = new DateTime(2024, 5, 22),
                Type = "Крадіжка",
                Severity = "Легкий"
            };

            // Створюємо об'єкти підозрюваних
            Suspect suspect1 = new Suspect
            {
                LastName = "Іванов",
                DateOfBirth = new DateTime(1990, 5, 10),
                InvolvementType = "Основний підозрюваний"
            };

            Suspect suspect2 = new Suspect
            {
                LastName = "Петров",
                DateOfBirth = new DateTime(1985, 10, 15),
                InvolvementType = "Співучасник"
            };

            Suspect suspect3 = new Suspect
            {
                LastName = "Сидоров",
                DateOfBirth = new DateTime(1995, 3, 20),
                InvolvementType = "Співучасник"
            };

            Suspect suspect4 = new Suspect
            {
                LastName = "Ковальчук",
                DateOfBirth = new DateTime(1980, 12, 5),
                InvolvementType = "Основний підозрюваний"
            };

            // Створюємо об'єкти зброї
            Weapon weapon1 = new Weapon
            {
                Brand = "Glock",
                CountryOfOrigin = "Австрія",
                Owner = "Іванов"
            };

            Weapon weapon2 = new Weapon
            {
                Brand = "AK-47",
                CountryOfOrigin = "Росія",
                Owner = "Петров"
            };

            Weapon weapon3 = new Weapon
            {
                Brand = "Beretta",
                CountryOfOrigin = "Італія",
                Owner = "Сидоров"
            };

            Weapon weapon4 = new Weapon
            {
                Brand = "Smith & Wesson",
                CountryOfOrigin = "США",
                Owner = "Ковальчук"
            };

            // Додаємо підозрюваних та зброю до відповідних злочинів
            crime1.Suspects.Add(suspect1);
            crime1.WeaponsUsed.Add(weapon1);

            crime2.Suspects.Add(suspect2);
            crime2.WeaponsUsed.Add(weapon2);

            crime3.Suspects.Add(suspect3);
            crime3.WeaponsUsed.Add(weapon3);

            crime4.Suspects.Add(suspect4);
            crime4.WeaponsUsed.Add(weapon4);

            // Створюємо об'єкт відділення поліції та додаємо злочини
            PoliceStation policeStation = new PoliceStation();
            policeStation.Crimes.Add(crime1);
            policeStation.Crimes.Add(crime2);
            policeStation.Crimes.Add(crime3);
            policeStation.Crimes.Add(crime4);

            Query1(policeStation);
            Query2(policeStation);
            Query3(policeStation);
            Query4(policeStation);
            Query5(policeStation);
            Query6(policeStation);
            Query7(policeStation);
            Query8(policeStation);
            Query9(policeStation);
            Query10(policeStation);
            Query11(policeStation);
            Query12(policeStation);
            Query13(policeStation);
            Query14(policeStation);
            Query15(policeStation);
            Query16(policeStation);
            Query17(policeStation);
            Query18(policeStation);
            Query19(policeStation);
            Query20(policeStation);
        }


        public static void Query1(PoliceStation policeStation)
        {
            var query1 = policeStation.Crimes.Where(c => c.Severity == "Важкий");
            Console.WriteLine("Запит 1: Злочини середньої або важкої тяжкості:");
            foreach (var crime in query1)
            {
                Console.WriteLine(
                    $"Дата вчинення: {crime.DateCommitted}, Тип: {crime.Type}, Тяжкість: {crime.Severity}");
            }
        }

        public static void Query2(PoliceStation policeStation)
        {
            var query2 = policeStation.Crimes.Where(c => c.DateCommitted > new DateTime(2024, 3, 1));
            Console.WriteLine("Запит 2: Злочини, вчинені після 1 березня 2024 року:");
            foreach (var crime in query2)
            {
                Console.WriteLine(
                    $"Дата вчинення: {crime.DateCommitted}, Тип: {crime.Type}, Тяжкість: {crime.Severity}");
            }
        }

        public static void Query3(PoliceStation policeStation)
        {
            var query3 = policeStation.Crimes.SelectMany(c => c.Suspects)
                .Where(s => s.InvolvementType == "Основний підозрюваний");
            Console.WriteLine("Запит 3: Усі основні підозрювані:");
            foreach (var suspect in query3)
            {
                Console.WriteLine(
                    $"Прізвище: {suspect.LastName}, Дата народження: {suspect.DateOfBirth}, Тип участі: {suspect.InvolvementType}");
            }
        }

        public static void Query4(PoliceStation policeStation)
        {
            var query4 = policeStation.Crimes.SelectMany(c => c.Suspects).Where(s => s.DateOfBirth.Year > 1990);
            Console.WriteLine("Запит 4: Підозрювані, які народилися після 1990 року:");
            foreach (var suspect in query4)
            {
                Console.WriteLine(
                    $"Прізвище: {suspect.LastName}, Дата народження: {suspect.DateOfBirth}, Тип участі: {suspect.InvolvementType}");
            }
        }

        public static void Query5(PoliceStation policeStation)
        {
            var query5 = policeStation.Crimes.Where(c =>
                c.DateCommitted >= new DateTime(2024, 3, 1) && c.DateCommitted <= new DateTime(2024, 4, 1));
            Console.WriteLine("Запит 5: Злочини, вчинені у березні 2024 року:");
            foreach (var crime in query5)
            {
                Console.WriteLine(
                    $"Дата вчинення: {crime.DateCommitted}, Тип: {crime.Type}, Тяжкість: {crime.Severity}");
            }
        }

        public static void Query6(PoliceStation policeStation)
        {
            var query6 = policeStation.Crimes.Select(c => c.Type).Distinct();
            Console.WriteLine("Запит 6: Унікальні типи злочинів:");
            foreach (var crimeType in query6)
            {
                Console.WriteLine(crimeType);
            }
        }

        public static void Query7(PoliceStation policeStation)
        {
            var query7 = policeStation.Crimes.SelectMany(c => c.WeaponsUsed).Select(w => w.CountryOfOrigin).Distinct();
            Console.WriteLine("Запит 7: Унікальні країни виготовлення зброї:");
            foreach (var country in query7)
            {
                Console.WriteLine(country);
            }
        }

        public static void Query8(PoliceStation policeStation)
        {
            var query8 = policeStation.Crimes.GroupBy(c => c.DateCommitted.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() });
            Console.WriteLine("Запит 8: Кількість злочинів, вчинених кожного дня:");
            foreach (var group in query8)
            {
                Console.WriteLine($"Дата: {group.Date}, Кількість: {group.Count}");
            }
        }

        public static void Query9(PoliceStation policeStation)
        {
            var query9 = policeStation.Crimes.SelectMany(c => c.Suspects).Select(s => s.LastName).Distinct();
            Console.WriteLine("Запит 9: Унікальні прізвища всіх підозрюваних:");
            foreach (var lastName in query9)
            {
                Console.WriteLine(lastName);
            }
        }

        public static void Query10(PoliceStation policeStation)
        {
            var query10 = policeStation.Crimes.SelectMany(c => c.Suspects).Where(s => s.DateOfBirth.Year < 1990)
                .Select(s => s.LastName);
            Console.WriteLine("Запит 10: Підозрювані, які народилися до 1990 року:");
            foreach (var lastName in query10)
            {
                Console.WriteLine(lastName);
            }
        }

        public static void Query11(PoliceStation policeStation)
        {
            var query11 = policeStation.Crimes.GroupBy(c => c.Type)
                .Select(g => new { CrimeType = g.Key, Count = g.Count() });
            Console.WriteLine("Запит 11: Кількість злочинів за кожен тип:");
            foreach (var group in query11)
            {
                Console.WriteLine($"Тип: {group.CrimeType}, Кількість: {group.Count}");
            }
        }

        public static void Query12(PoliceStation policeStation)
        {
            var query12 = policeStation.Crimes.SelectMany(c => c.Suspects)
                .Average(s => (DateTime.Now - s.DateOfBirth).Days / 365);
            Console.WriteLine($"Запит 12: Середній вік підозрюваних: {query12}");
        }

        public static void Query13(PoliceStation policeStation)
        {
            var query13 = policeStation.Crimes.SelectMany(c => c.Suspects)
                .Where(s => (DateTime.Now - s.DateOfBirth).Days / 365 < 30);
            Console.WriteLine("Запит 13: Підозрювані молодше 30 років:");
            foreach (var suspect in query13)
            {
                Console.WriteLine(
                    $"Прізвище: {suspect.LastName}, Дата народження: {suspect.DateOfBirth}, Тип участі: {suspect.InvolvementType}");
            }
        }

        public static void Query14(PoliceStation policeStation)
        {
            var query14 = policeStation.Crimes.Where(c => c.Severity == "Важкий" && c.Suspects.Count > 1);
            Console.WriteLine("Запит 14: Злочини, які є важкими та мають більше одного учасника:");
            foreach (var crime in query14)
            {
                Console.WriteLine(
                    $"Дата вчинення: {crime.DateCommitted}, Тип: {crime.Type}, Тяжкість: {crime.Severity}");
            }
        }

        public static void Query15(PoliceStation policeStation)
        {
            var query15 = policeStation.Crimes.SelectMany(c => c.Suspects).Where(s => s.LastName == "Іванов");
            Console.WriteLine("Запит 15: Злочини, учасниками яких є підозрювані з прізвищем 'Іванов':");
            foreach (var suspect in query15)
            {
                Console.WriteLine(
                    $"Прізвище: {suspect.LastName}, Дата народження: {suspect.DateOfBirth}, Тип участі: {suspect.InvolvementType}");
            }
        }

        public static void Query16(PoliceStation policeStation)
        {
            var query16 = policeStation.Crimes.SelectMany(c => c.WeaponsUsed).Where(w => w.Brand == "Glock");
            Console.WriteLine("Запит 16: Злочини, де було використано зброю марки 'Glock':");
            foreach (var weapon in query16)
            {
                Console.WriteLine(
                    $"Марка: {weapon.Brand}, Країна виготовлення: {weapon.CountryOfOrigin}, Власник: {weapon.Owner}");
            }
        }

        public static void Query17(PoliceStation policeStation)
        {
            var query17 = policeStation.Crimes.SelectMany(c => c.WeaponsUsed).Where(w => w.CountryOfOrigin == "США")
                .Select(w => w.Owner).Distinct();
            Console.WriteLine("Запит 17: Унікальні власники зброї, виготовленої в США:");
            foreach (var owner in query17)
            {
                Console.WriteLine(owner);
            }
        }

        public static void Query18(PoliceStation policeStation)
        {
            var query18 = policeStation.Crimes.Where(c => c.Severity == "Важкий")
                .OrderByDescending(c => c.DateCommitted);
            Console.WriteLine(
                "Запит 18: Злочини важкої тяжкості, відсортовані за датою вчинення у зворотньому порядку:");
            foreach (var crime in query18)
            {
                Console.WriteLine(
                    $"Дата вчинення: {crime.DateCommitted}, Тип: {crime.Type}, Тяжкість: {crime.Severity}");
            }
        }

        public static void Query19(PoliceStation policeStation)
        {
            var query19 = policeStation.Crimes.Join(policeStation.Crimes.Where(c => c.Severity == "Середній"),
                c1 => c1.Type, c2 => c2.Type,
                (c1, c2) => new { Crime1 = c1, Crime2 = c2 });
            Console.WriteLine("Запит 19: Пари злочинів одного типу, один з яких має середню тяжкість:");
            foreach (var pair in query19)
            {
                Console.WriteLine($"Злочин 1: {pair.Crime1.Type}, Тяжкість: {pair.Crime1.Severity}");
                Console.WriteLine($"Злочин 2: {pair.Crime2.Type}, Тяжкість: {pair.Crime2.Severity}");
            }
        }

        public static void Query20(PoliceStation policeStation)
        {
            var query20 = policeStation.Crimes.SelectMany(c => c.WeaponsUsed)
                .GroupBy(w => w.CountryOfOrigin)
                .OrderByDescending(g => g.Count())
                .Select(g => new { Country = g.Key, WeaponCount = g.Count() })
                .First();
            Console.WriteLine(
                $"Запит 20: Країна з найбільшою кількістю використаної зброї: {query20.Country}, Кількість: {query20.WeaponCount}");
        }
    }
}