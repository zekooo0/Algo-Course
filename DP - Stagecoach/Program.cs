namespace DP___Stagecoach
{

    public class State
    {
        public string From
        {
            get;
            set;
        }
        public string To
        {
            get;
            set;
        }
        public int Cost
        {
            get;
            set;
        }
    }
    internal class Program
    {
        static void Main( string[] args )
        {
            string[] labels = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            int[,] data = {
        {0, 2, 4, 3, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 7, 4, 6, 0, 0, 0},
        {0, 0, 0, 0, 3, 2, 4, 0, 0, 0},
        {0, 0, 0, 0, 4, 1, 5, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 1, 4, 0},
        {0, 0, 0, 0, 0, 0, 0, 6, 3, 0},
        {0, 0, 0, 0, 0, 0, 0, 3, 3, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 4},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    };

            int n = data.GetLength( 0 );
            State[] states = new State[n];

            states[n - 1] = new State { From = "", To = "", Cost = 0 };

            int i = n - 2;
            int j;
            for ( ; i >= 0; i-- )
            {
                j = i + 1;
                states[i] = new State { From = labels[i], To = labels[j], Cost = int.MaxValue };
                for ( ; j < n; j++ )
                {
                    if ( data[i, j] == 0 )
                        continue;
                    int new_cost = data[i, j] + states[j].Cost;

                    if ( new_cost < states[i].Cost )
                    {
                        states[i].To = labels[j];
                        states[i].Cost = new_cost;
                    }
                }
            }

            List<string> path = new List<string>();
            path.Add( "A" );
            i = 0;
            j = 0;

            while ( i < states.Length )
            {
                if ( states[i].From == path[j] )
                {
                    path.Add( states[i].To );
                    j++;
                }
                i++;
            }

            Console.WriteLine( $"Min Cost: {states[0].Cost}" );
            foreach ( string str in path )
            {
                Console.Write( str + "\t" );
            }

        }

    }
}
