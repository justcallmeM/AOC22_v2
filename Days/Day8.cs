namespace AOC22.Days
{
    using Constants;
    using Library;

    public static class Day8
    {
        public static void Execute()
        {
            List<string> trees = ReadMethods.ReadFileIntoList(InputPath.DAY8_INPUT_PATH);

            int[,] treeGrid = new int[trees.First().Length, trees.Count];

            for (int i = 0; i < treeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < treeGrid.GetLength(1); j++)
                {
                    treeGrid[i, j] = int.Parse(trees[i][j].ToString());
                }
            }

            FirstPart(treeGrid);

            SecondPart(treeGrid);
        }

        public static void FirstPart(int[,] treeGrid)
        {
            int counter = 0;

            for (int i = 1; i < treeGrid.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < treeGrid.GetLength(1) - 1; j++)
                {
                    if (TreeVisibleFromEdge(treeGrid, i, j))
                    {
                        counter++;
                    }
                }
            }

            counter += CountEdgeTrees(treeGrid);

            Console.WriteLine($"{counter} trees can be seen from the edges of the forest");

            static int CountEdgeTrees(int[,] treeGrid)
            {
                return treeGrid.GetLength(0) * 2 + (treeGrid.GetLength(1) - 2) * 2;
            }

            static bool TreeVisibleFromEdge(int[,] treeGrid, int x, int y)
            {
                return !LeftToRight(treeGrid, x, y)
                    || !RightToLeft(treeGrid, x, y)
                    || !BottomToTop(treeGrid, x, y)
                    || !TopToBottom(treeGrid, x, y);

                static bool LeftToRight(int[,] treeGrid, int x, int y)
                {
                    int[] array = new int[y];

                    for (int i = 0; i < y; i++)
                    {
                        array[i] = treeGrid[x, i];
                    }

                    bool result = array.Any(z => z >= treeGrid[x, y]);

                    return result;
                }

                static bool RightToLeft(int[,] treeGrid, int x, int y)
                {
                    int rows = treeGrid.GetLength(1) - 1;
                    int[] array = new int[rows - y];

                    for (int i = 0; i < rows - y; i++)
                    {
                        array[i] = treeGrid[x, rows - i];
                    }

                    bool result = array.Any(z => z >= treeGrid[x, y]);

                    return result;
                }

                static bool BottomToTop(int[,] treeGrid, int x, int y)
                {
                    int columns = treeGrid.GetLength(0) - 1;
                    int[] array = new int[columns - x];

                    for (int i = 0; i < columns - x; i++)
                    {
                        array[i] = treeGrid[columns - i, y];
                    }

                    bool result = array.Any(z => z >= treeGrid[x, y]);

                    return result;
                }

                static bool TopToBottom(int[,] treeGrid, int x, int y)
                {
                    int[] array = new int[x];

                    for (int i = 0; i < x; i++)
                    {
                        array[i] = treeGrid[i, y];
                    }

                    bool result = array.Any(z => z >= treeGrid[x, y]);

                    return result;
                }
            }
        }

        public static void SecondPart(int[,] treeGrid)
        {
            int highestScenicScore = 0;

            for (int i = 0; i < treeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < treeGrid.GetLength(1); j++)
                {
                    int scenicScore = FindHighestScenicScore(treeGrid, i, j);

                    if (scenicScore > highestScenicScore)
                        highestScenicScore = scenicScore;
                }
            }

            Console.WriteLine($"{highestScenicScore} is the highest scenic score");

            static int FindHighestScenicScore(int[,] treeGrid, int x, int y)
            {
                return ToTheLeft(treeGrid, x, y) 
                    * ToTheRight(treeGrid, x, y) 
                    * ToTheBottom(treeGrid, x, y) 
                    * ToTheTop(treeGrid, x, y);

                static int ToTheLeft(int[,] treeGrid, int x, int y)
                {
                    int scenicScore = 0;

                    for (int i = y - 1; i >= 0; i--)
                    {
                        if (treeGrid[x, i] < treeGrid[x, y])
                        {
                            scenicScore++;
                        }

                        if (treeGrid[x, i] >= treeGrid[x, y])
                        {
                            scenicScore++;
                            break;
                        }
                    }

                    return scenicScore;
                }

                static int ToTheRight(int[,] treeGrid, int x, int y)
                {
                    int scenicScore = 0;
                    int rows = treeGrid.GetLength(1);

                    for (int i = y + 1; i < rows; i++)
                    {
                        if (treeGrid[x, i] < treeGrid[x, y])
                        {
                            scenicScore++;
                        }

                        if (treeGrid[x, i] >= treeGrid[x, y])
                        {
                            scenicScore++;
                            break;
                        }
                    }

                    return scenicScore;
                }

                static int ToTheBottom(int[,] treeGrid, int x, int y)
                {
                    int scenicScore = 0;
                    int columns = treeGrid.GetLength(0);

                    for (int i = x + 1; i < columns; i++)
                    {
                        if (treeGrid[i, y] < treeGrid[x, y])
                        {
                            scenicScore++;
                        }

                        if (treeGrid[i, y] >= treeGrid[x, y])
                        {
                            scenicScore++;
                            break;
                        }
                    }

                    return scenicScore;
                }

                static int ToTheTop(int[,] treeGrid, int x, int y)
                {
                    int scenicScore = 0;

                    for (int i = x - 1; i >= 0; i--)
                    {
                        if (treeGrid[i, y] < treeGrid[x, y])
                        {
                            scenicScore++;
                        }

                        if (treeGrid[i, y] >= treeGrid[x, y])
                        {
                            scenicScore++;
                            break;
                        }
                    }

                    return scenicScore;
                }
            }
        }
    }
}
