namespace AOC22.Days._2
{
    using Library;
    using Constants;

    public class Day2
    {
        public static void Execute()
        {
            List<string> matches = ReadMethods.ReadFileIntoList(InputPath.DAY2_INPUT_PATH);

            Part1(matches);

            Part2(matches);
        }

        public static void Part1(List<string> matches)
        {
            int acumulativeScore = 0;

            foreach (string match in matches)
            {
                string[] hands = match.Split(" ");

                Outcome outcome = PlayRockPaperScissors(hands[1], hands[0]);

                acumulativeScore += CalcMatchScore(hands[1], outcome);
            }

            Console.WriteLine($"If everything goes exactly according to the FIRST strategy guide \nscore would be: {acumulativeScore}\n");

            static Outcome PlayRockPaperScissors(string me, string opponent) => me switch
            {
                "X" when opponent is "A" => Outcome.Draw,
                "X" when opponent is "B" => Outcome.Loss,
                "X" when opponent is "C" => Outcome.Victory,

                "Y" when opponent is "A" => Outcome.Victory,
                "Y" when opponent is "B" => Outcome.Draw,
                "Y" when opponent is "C" => Outcome.Loss,

                "Z" when opponent is "A" => Outcome.Loss,
                "Z" when opponent is "B" => Outcome.Victory,
                "Z" when opponent is "C" => Outcome.Draw,

                _ => throw new Exception("unexpected inputs")
            };

            static int CalcMatchScore(string myHand, Outcome matchOutcome)
            {
                if (myHand == "X")
                {
                    return 1 + (int)matchOutcome;
                }
                else if (myHand == "Y")
                {
                    return 2 + (int)matchOutcome;
                }
                else
                {
                    return 3 + (int)matchOutcome;
                }
            }
        }

        public static void Part2(List<string> matches)
        {
            int acumulativeScore = 0;

            foreach (string match in matches)
            {
                string[] symbol = match.Split(" ");

                string shapeOfHand = FigureOutTheShapeOfMyHand(symbol[0], symbol[1]);

                acumulativeScore += CalcMatchScore(shapeOfHand, symbol[1]);
            }

            Console.WriteLine($"If everything goes exactly according to the SECOND strategy guide \nscore would be: {acumulativeScore}\n");

            static string FigureOutTheShapeOfMyHand(string opponent, string outcome) => opponent switch
            {
                "A" when outcome is "X" /*lose*/ => "C",
                "A" when outcome is "Y" /*draw*/ => "A",
                "A" when outcome is "Z" /*win*/  => "B",

                "B" when outcome is "X" /*lose*/ => "A",
                "B" when outcome is "Y" /*draw*/ => "B",
                "B" when outcome is "Z" /*win*/  => "C",

                "C" when outcome is "X" /*lose*/ => "B",
                "C" when outcome is "Y" /*draw*/ => "C",
                "C" when outcome is "Z" /*win*/  => "A",

                _ => throw new Exception("unexpected inputs")
            };

            static int CalcMatchScore(string shapeOfHand, string matchOutcome)
            {
                if (shapeOfHand == "A")
                {
                    return 1 + StringToIntOfMatchOutcome(matchOutcome);
                }
                else if (shapeOfHand == "B")
                {
                    return 2 + StringToIntOfMatchOutcome(matchOutcome);
                }
                else
                {
                    return 3 + StringToIntOfMatchOutcome(matchOutcome);
                }

                static int StringToIntOfMatchOutcome(string matchOutcome)
                {
                    if(matchOutcome == "X")
                    {
                        return 0;
                    }
                    else if (matchOutcome == "Y")
                    {
                        return 3;
                    }
                    else
                    {
                        return 6;
                    }
                }
            }
        }

        public enum Outcome
        {
            Loss = 0,
            Draw = 3,
            Victory = 6
        }
    }
}
