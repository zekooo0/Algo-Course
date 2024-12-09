namespace LCS
{
    // In this problem we will use DP to find the Longest common subsequence
    // by Implement a table the rows will be the short string and the columns will be the long string.
    // in the 2D table we check every cell, there is 2 cases
    // - if the row match the column, then we update the current cell value to table[i-1, j-1] + 1
    // - else we update teh current cell value to MAX(table[i-1, j], table[i, j-1]) 
    internal class Program
    {
        static void Main(string[] args)
        {
            string text_01 = "HELLOWORLD";
            string text_02 = "OHELOD";

            int m = text_02.Length;
            int n = text_01.Length;

            text_01 = " " + text_01;
            text_02 = " " + text_02;

            int[,] arr = new int[m + 1, n + 1];

            int i;
            int j;
            for ( i = 1; i <= m; i++)
            {
                for ( j = 1; j <= n; j++)
                {
                    if (text_02[i] == text_01[j])
                    {
                        arr[i, j] = 1 + arr[i - 1, j - 1];
                    }
                    else
                    {
                        arr[i, j] = Math.Max(arr[i - 1, j], arr[i, j - 1]);
                    }
                }
            }

            string sol = "";

            i = m;
            j = n;
            while (i > 0  && j > 0)
            {
                // Check if the current value is greater than the left value
                if (arr[i, j] > arr[i, j - 1])
                {
                    // Check if the current value is equal to the top value
                    // then this value is inherited from the top row,
                    // so we don't need to go throw this row.
                    if (arr[i, j] == arr[i - 1, j])
                    {
                        i--;
                    }
                    // If it's greater than the top value, then this char is a match.
                    else
                    {
                        sol = text_02[i] + sol;
                        i--;
                        j--;
                    }
                }
                // If not greater than the left value, keep going.
                else
                {
                    j--;
                }
            } 

            Console.WriteLine(sol);
        }
    }
    
}


