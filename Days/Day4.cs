namespace AOC22.Days
{
    using Constants;
    using Library;

    public static class Day4
    {
        public static void Execute()
        {
            List<string> assignmentPairs = ReadMethods.ReadFileIntoList(InputPath.DAY4_INPUT_PATH);
            int isinside = 0;

            for (int i = 0; i < assignmentPairs.Count; i++)
            {
                string[] pairs = assignmentPairs[i].Split(',');

                if (SequencesOverlap(pairs[0], pairs[1]))
                {
                    isinside++;
                }
            }

            Console.WriteLine(isinside);
        }

        public static bool SequenceContainsSequence(string firstSequence, string secondSequence)
        {
            string[] firstSequenceEndings = firstSequence.Split('-');
            string[] secondSequenceEndings = secondSequence.Split('-');

            int firstSequenceBeginning = int.Parse(firstSequenceEndings[0]);
            int firstSequenceEnding = int.Parse(firstSequenceEndings[1]);

            int secondSequenceBeginning = int.Parse(secondSequenceEndings[0]);
            int secondSequenceEnding = int.Parse(secondSequenceEndings[1]);

            bool firstSequenceContainsSecondSequence = firstSequenceBeginning <= secondSequenceBeginning
                && firstSequenceEnding >= secondSequenceEnding;
            bool secondSequenceContainsfirstSequence = secondSequenceBeginning <= firstSequenceBeginning
                && secondSequenceEnding >= firstSequenceEnding;

            return firstSequenceContainsSecondSequence || secondSequenceContainsfirstSequence;
        }

        public static bool SequencesOverlap(string firstSequence, string secondSequence)
        {
            string[] firstSequenceEndings = firstSequence.Split('-');
            string[] secondSequenceEndings = secondSequence.Split('-');

            int firstRowBeginning = int.Parse(firstSequenceEndings[0]);
            int firstRowEnding = int.Parse(firstSequenceEndings[1]);

            int secondRowBeginning = int.Parse(secondSequenceEndings[0]);
            int secondRowEnding = int.Parse(secondSequenceEndings[1]);

            bool a = firstRowEnding == secondRowBeginning;
            bool b = firstRowBeginning <= secondRowBeginning && firstRowEnding >= secondRowEnding;
            bool c = secondRowBeginning <= firstRowBeginning && secondRowEnding >= firstRowEnding;
            bool d = firstRowBeginning == secondRowEnding;
            bool e = secondRowBeginning < firstRowEnding && secondRowBeginning >= firstRowBeginning;
            bool f = firstRowBeginning < secondRowEnding && firstRowBeginning >= secondRowBeginning;

            return a || b || c || d || e || f;
        }
    }
}
