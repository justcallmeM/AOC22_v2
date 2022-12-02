namespace AOC22.Days._1
{
    using Library;
    using Constants;

    public class Day1
    {
        public static void Execute()
        {

            List<string> items = ReadMethods.ReadFileIntoList(InputPath.DAY1_INPUT_PATH);

            var reindeerCalories = GetReindeerCalories(items);

            var biggestCalorie = GetBiggestCalorieAmount(reindeerCalories);

            Console.WriteLine("Biggest calorie: " + biggestCalorie.Item1);
            Console.WriteLine("Top 3 biggest calories: " + biggestCalorie.Item2);
        }

        public static List<int> GetReindeerCalories(List<string> listOfCalories)
        {
            List<int> reindeerCalories = new();
            int calories = 0;

            for (int i = 0; i < listOfCalories.Count; i++)
            {
                if (!string.IsNullOrEmpty(listOfCalories[i]))
                {
                    calories += int.Parse(listOfCalories[i]);
                }
                else
                {
                    reindeerCalories.Add(calories);
                    calories = 0;
                }  
            }

            return reindeerCalories;
        }

        public static (int, int) GetBiggestCalorieAmount(List<int> calories)
        {
            int biggestCalorie = 0;
            int topThreeBiggestCaloriesCombined = 0;

            for (int i = 0; i < 3; i++)
            {
                topThreeBiggestCaloriesCombined += GetBiggestAndRemoveIt(ref calories);

                if (i == 0)
                    biggestCalorie = topThreeBiggestCaloriesCombined;
            }

            return (biggestCalorie, topThreeBiggestCaloriesCombined);

            static int GetBiggestAndRemoveIt(ref List<int> calories)
            {
                int biggestCalorie = 0;
                int? biggestCaloriePosition = null;

                for (int i = 0; i < calories.Count; i++)
                {
                    if (calories[i] > biggestCalorie)
                    {
                        biggestCalorie = calories[i];
                        biggestCaloriePosition = i;
                    }  
                }

                if(biggestCaloriePosition != null)
                    calories.RemoveAt((int)biggestCaloriePosition);

                return biggestCalorie;
            }
        }
    }
}
