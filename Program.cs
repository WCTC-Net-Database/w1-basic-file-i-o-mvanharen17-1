class Program
{
    static void Main()
    {

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Level Up Character");

        var menuOption = Console.ReadLine();

        if (menuOption == "1") //Display Character
        {
            var lines = File.ReadAllLines("C:\\Users\\melan\\OneDrive\\WCTC\\Spring 2025\\.Net\\w1-basic-file-i-o-mvanharen17-1\\input.csv");

            Console.WriteLine("== Characters ==");

            for (int i = 0; i < lines.Length; i++)
            {
                var cols = lines[i].Split(",");

                var name = cols[0];
                var profession = cols[1];
                var level = cols[2];
                var hitPoints = cols[3];
                var equipment = cols[4];
                
                Console.WriteLine($"\nName: {name}");
                Console.WriteLine($"Job: {profession}");
                Console.WriteLine($"Level: {level}");
                Console.WriteLine($"Hit Points: {hitPoints}");
                Console.WriteLine($"Equipment: {equipment}");
            }
        }
        if (menuOption == "2") //Add Character
        {
            Console.WriteLine("== Add a Character ==");

            Console.Write("Enter your character's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your character's class: ");
            string characterClass = Console.ReadLine();

            Console.Write("Enter your character's level: ");
            int level = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's hitpoints: ");
            int hp = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's equipment (separate items with a '|'): ");
            string[] equipment = Console.ReadLine().Split('|');

            Console.WriteLine($"Welcome, {name} the {characterClass}! You are level {level} with {hp} and your equipment includes: {string.Join(", ", equipment)}.");

            using (StreamWriter writer = new StreamWriter("C:\\Users\\melan\\OneDrive\\WCTC\\Spring 2025\\.Net\\w1-basic-file-i-o-mvanharen17-1\\input.csv", true))
            {
                writer.WriteLine($"{name},{characterClass},{level},{hp},{string.Join("|", equipment)}");
            }
        }

        if (menuOption == "3")
        {
            var lines = File.ReadAllLines("C:\\Users\\melan\\OneDrive\\WCTC\\Spring 2025\\.Net\\w1-basic-file-i-o-mvanharen17-1\\input.csv");

            Console.WriteLine("== Level Up a Character ==");

            Console.WriteLine("Which character would you like to level up?");
            var nameToLevel = Console.ReadLine();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                var cols = lines[i].Split(",");

                var name = cols[0];
                var profession = cols[1];
                var level = cols[2];
                var hitPoints = cols[3];
                var equipment = cols[4];

                if (line.Contains(nameToLevel))
                {
                    lines[i] = ($"{name},{profession},{level},{hitPoints},{string.Join("|", equipment)}");

                    int j = int.Parse(level);
                    var newLevel = Convert.ToString(j + 1);

                    using (StreamWriter writer = new StreamWriter("C:\\Users\\melan\\OneDrive\\WCTC\\Spring 2025\\.Net\\w1-basic-file-i-o-mvanharen17-1\\input.csv", true))
                    {
                        writer.WriteLine($"{name}, {profession}, {newLevel}, {hitPoints}, {string.Join("|", equipment)}");
                    }
                    Console.WriteLine($"{name} is now Level {newLevel}");
                }
            }
        }
    }
}