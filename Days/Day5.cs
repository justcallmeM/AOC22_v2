namespace AOC22.Days
{
    using Constants;
    using Library;

    public static class Day5
    {
        public static void Execute()
        {
            List<string> list = ReadMethods.ReadFileIntoList(InputPath.DAY5_INPUT_PATH);

            List<char> alphabet = new() { 'A', 'B', 'C', 'D', 'E', 'F', 'H', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

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

            foreach (string alternativeStackRow in alternativeStackList)
            {
                if (alternativeStackRow.Any(x => char.IsLetter(x)))
                {
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

            foreach (string alternativeStackRow in reversedStrings)
            {
                Stack<char> stackToAdd = new();

                foreach (char ch in alternativeStackRow)
                {
                    stackToAdd.Push(ch);
                }

                stacks.Add(stackToAdd);
            }

            List<string> commands = new();

            int indexOfEmptyLine = list.IndexOf(string.Empty);

            commands = list.Skip(indexOfEmptyLine + 1).ToList();


            foreach (var command in commands)
            {
                (int, int, int) movementInfo = DigestCommandInto_Amount_From_To(command);

                //MoveCreates9000(stacks, movementInfo.Item1, movementInfo.Item2, movementInfo.Item3); //part1
                MoveCrates9001(stacks, movementInfo.Item1, movementInfo.Item2, movementInfo.Item3); //part2
            }

            string answer = GetTopCratesFromEachStack(stacks);

            Console.WriteLine(answer);
        }

        public static (int, int, int) DigestCommandInto_Amount_From_To(string command)
        {
            string[] commandParts = command.Split(' ');

            int amount = int.Parse(commandParts[1]);
            int from = int.Parse(commandParts[3]) - 1;
            int to = int.Parse(commandParts[5]) - 1;

            return (amount, from, to);
        }

        public static void MoveCreates9000(List<Stack<char>> stacks, int amount, int from, int to)
        {
            for (int i = 0; i < amount; i++)
            {
                char crate = stacks[from].Pop();

                stacks[to].Push(crate);
            }
        }

        public static void MoveCrates9001(List<Stack<char>> stacks, int amount, int from, int to)
        {
            List<char> tempCrateStorage = new();

            for (int i = 0; i < amount; i++)
            {
                tempCrateStorage.Add(stacks[from].Pop());
            }

            tempCrateStorage.Reverse();

            for (int i = 0; i < amount; i++)
            {
                stacks[to].Push(tempCrateStorage[i]);
            }
        }

        public static string GetTopCratesFromEachStack(List<Stack<char>> stacks)
        {
            string topCrates = string.Empty;

            foreach (Stack<char> stack in stacks)
            {
                topCrates += stack.Pop();
            }

            return topCrates;
        }

    }
}
