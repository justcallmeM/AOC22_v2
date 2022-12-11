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

            int counter = 0;

            for (int i = 1; i < treeGrid.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < treeGrid.GetLength(1) - 1; j++)
                {
                    if(TreeVisibleFromEdge(treeGrid, i, j))
                    {
                        counter++;
                    }
                }
            }

            counter += CountEdgeTrees(treeGrid);

            Console.WriteLine(counter);
        }

        public static int CountEdgeTrees(int[,] treeGrid)
        {
            return treeGrid.GetLength(0) * 2 + (treeGrid.GetLength(1) - 2) * 2;
        }

        public static bool TreeVisibleFromEdge(int[,] treeGrid, int x, int y)
        {
            return !LeftToRight() 
                || !RightToLeft() 
                || !BottomToTop() 
                || !TopToBottom();

            bool LeftToRight()
            {
                int[] array = new int[y];

                for (int i = 0; i < y; i++)
                {
                    array[i] = treeGrid[x, i];
                }

                bool result = array.Any(z => z >= treeGrid[x, y]);

                return result;
            }

            bool RightToLeft()
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

            bool BottomToTop()
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

            bool TopToBottom()
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
}
