namespace AOC22.Days._6
{
    using Constants;
    using Library;

    public static class Day6
    {
        public static void Execute()
        {
            List<string> list = ReadMethods.ReadFileIntoList(InputPath.DAY6_INPUT_PATH);

            int answer = ScanCharactersForStartOfPacketMarker(list.First());

            Console.WriteLine(answer);
        }

        public static int ScanCharactersForStartOfPacketMarker(string message)
        {
            int amountOfCharacters = 0;
            //int mask = 4; // for part1
            int mask = 14; // for part2

            for (int i = 0; i <= message.Length - mask; i++)
            {
                string partOfMessage = message.Substring(i, mask);

                if (AllCharsDifferent(partOfMessage))
                {
                    amountOfCharacters = i + mask;
                    break;
                }
                    
            }

            return amountOfCharacters;
        }

        public static bool AllCharsDifferent(string partOfMessage)
        {
            return partOfMessage.Distinct().Count() == partOfMessage.Length;
        }
    }
}
