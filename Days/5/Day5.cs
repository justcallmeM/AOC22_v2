namespace AOC22.Days._5
{
    using Constants;
    using Library;

    public static class Day5
    {
        //public static void Execute()
        //{
        //    List<string> list = ReadMethods.ReadFileIntoList(InputPath.DAY5_INPUT_PATH);

        //    List<string> cratesData = new();

        //    foreach (string item in list)
        //    {
        //        if (string.IsNullOrEmpty(item))
        //            break;

        //        cratesData.Add(item);
        //    }

        //    string stackNumbers = cratesData.Last();
        //    cratesData.Remove(stackNumbers);

        //    List<int> stackNumberPositions = new();

        //    var a = stackNumbers.Split(" ").ToList();
        //    for (int i = 0; i < a.Count; i++)
        //    {
        //        if (!string.IsNullOrEmpty(a[i]))
        //        {
        //            stackNumberPositions.Add(i);
        //        }
        //    }

        //    List<Stack<char>> stacks = new();

        //    cratesData.Reverse();

        //}
        
        public static void Execute()
        {
            List<string> list = ReadMethods.ReadFileIntoList(InputPath.DAY5_INPUT_PATH);

            List<char> alphabet = new() { 'A', 'B', 'C','D','E', 'F', 'H', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            List<string> stackList = new();

            foreach (string item in list)
            {
                if (string.IsNullOrEmpty(item))
                    break;

                stackList.Add(item);
            }

            int numberOfStacks = int.Parse(stackList.Last()
                                                .Split(" ").ToList()
                                                .Where(x => !string.IsNullOrEmpty(x))
                                                .ToList().Last());

            stackList.Remove(stackList.Last());

            List<string> alternativeStackList = new();

            string newItem = "";

            for (int j = 0; j < stackList[0].Length; j++)
            {
                for (int i = 0; i < stackList.Count; i++)
                {
                    newItem += stackList[i][j];
                }

                alternativeStackList.Add(newItem);
                newItem = "";
            }

            List<string> cleanAlternativeStackList = new();

            foreach(string alternativeStackRow in alternativeStackList)
            {
                if(alternativeStackRow.Any(x => char.IsLetter(x))) {
                    cleanAlternativeStackList.Add(alternativeStackRow);
                }
            }

            List<string> reversedStrings = new();

            foreach (string alternativeStackRow in cleanAlternativeStackList)
            {
                var charList = alternativeStackRow.Reverse().ToList();

                string newString = string.Empty;

                foreach (var ch in charList)
                {
                    newString += ch;
                }

                reversedStrings.Add(newString.Trim());
            }

            List<Stack<char>> stacks = new();

            foreach(string alternativeStackRow in reversedStrings)
            {
                Stack<char> stackToAdd = new();

                foreach (char ch in alternativeStackRow)
                {
                    stackToAdd.Push(ch);
                }

                stacks.Add(stackToAdd);
            }


        }

    }
}
