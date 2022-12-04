namespace AOC22.Days._3
{
    using Constants;
    using Library;

    public static class Day3
    {
        public static void Execute()
        {
            List<string> rucksacks = ReadMethods.ReadFileIntoList(InputPath.DAY3_INPUT_PATH);

            GetSumOfItemTypePriorities(rucksacks);

            GetSumOfItemTypePriorities_Groups(rucksacks);
        }

        public static void GetSumOfItemTypePriorities_Groups(List<string> rucksacks)
        {
            int sumOfItemPriorities = 0;

            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                string sharedItemType = FindSharedItemType(rucksacks[i], rucksacks[i+1], rucksacks[i+2]);

                sumOfItemPriorities += GetItemTypePriority(sharedItemType);
            }

            Console.WriteLine($"Sum of item priorities of groups: {sumOfItemPriorities}");
        }

        public static void GetSumOfItemTypePriorities(List<string> rucksacks)
        {
            int sumOfItemPriorities = 0;

            foreach (string rucksack in rucksacks)
            {
                string[] compartments = GetRucksackCompartments(rucksack);

                string sharedItemType = FindSharedItemType(compartments[0], compartments[1]);

                sumOfItemPriorities += GetItemTypePriority(sharedItemType);
            }

            Console.WriteLine($"Sum of item priorities: {sumOfItemPriorities}");
        }

        public static int GetItemTypePriority(string itemType)
        {
            return (int)Enum.Parse(typeof(ItemTypePriority), itemType);
        }

        public static string FindSharedItemType(string firstCompartment, string secondCompartment) 
        {
            string sharedItem = string.Empty;

            for (int i = 0; i < firstCompartment.Length; i++)
            {
                sharedItem = firstCompartment[i].ToString();

                if (secondCompartment.Contains(sharedItem))
                    break;
            }

            return sharedItem;
        }

        public static string FindSharedItemType(string firstRucksack, string secondRucksack, string thirdRucksack)
        {
            string sharedItem = string.Empty;

            string biggestRucksack = GetLongestString(firstRucksack, secondRucksack, thirdRucksack);

            for (int i = 0; i < biggestRucksack.Length; i++)
            {
                sharedItem = biggestRucksack[i].ToString();

                if (firstRucksack.Contains(sharedItem) && secondRucksack.Contains(sharedItem) && thirdRucksack.Contains(sharedItem))
                    break;
            }

            return sharedItem;

            static string GetLongestString(string a, string b, string c)
            {
                if(a.Length > b.Length && a.Length > c.Length)
                {
                    return a;
                } 
                else if (b.Length > a.Length && b.Length > c.Length)
                {
                    return b;
                }
                else
                {
                    return c;
                }
            }
        }

        public static string[] GetRucksackCompartments(string rucksack)
        {
            string firstCompartment = rucksack.Substring(0, rucksack.Length / 2);
            string secondCompartment = rucksack.Substring(firstCompartment.Length, rucksack.Length / 2);

            return new string[] { firstCompartment, secondCompartment };
        }

        public enum ItemTypePriority
        {
            a = 1,
            b = 2,
            c = 3,
            d = 4,
            e = 5,
            f = 6,
            g = 7,
            h = 8,
            i = 9,
            j = 10,
            k = 11,
            l = 12,
            m = 13,
            n = 14,
            o = 15,
            p = 16,
            q = 17,
            r = 18,
            s = 19,
            t = 20,
            u = 21,
            v = 22,
            w = 23,
            x = 24,
            y = 25,
            z = 26,
            A = 27,
            B = 28,
            C = 29,
            D = 30,
            E = 31,
            F = 32,
            G = 33,
            H = 34,
            I = 35,
            J = 36,
            K = 37,
            L = 38,
            M = 39,
            N = 40,
            O = 41,
            P = 42,
            Q = 43,
            R = 44,
            S = 45,
            T = 46,
            U = 47,
            V = 48,
            W = 49,
            X = 50,
            Y = 51,
            Z = 52
        }
    }
}
