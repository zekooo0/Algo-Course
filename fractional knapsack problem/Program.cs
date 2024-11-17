namespace fractional_knapsack_problem
{
    internal class Program
    {
        static void Main( string[] args )
        {
            int[] values = { 4, 9, 12, 11, 6, 5 };
            int[] weights = { 1, 2, 10, 4, 3, 5 };
            
            int n = weights.Length;
            
            List<Item> itemList = new List<Item>();
   
            
            for ( int i = 0; i < n; i++ )
            {
                Item newItem = new Item( $"#{i}", weights[i], values[i] );
                itemList.Add( newItem );
            }
            
            Item[] items = itemList.ToArray();

            // sort desc based on the ratio
            Knapsack.merge_sort( items, 0, n - 1 );


            

            Knapsack bag = new Knapsack( 12 );

            int j = 0;
            while ( bag.currentCapacity < bag.maxCapacity )
            {
                bag.add_item( items[j] );
                j++;
            }


            // Print the list after the sort 
            Console.WriteLine( "Name Value Weight Ratio" );
            foreach ( var item in items )
            {
                Console.WriteLine( $"{item.name} {item.value} {item.weight} {item.ratio}" );
            }

            Console.WriteLine( "=================================" );
            Console.WriteLine( $"current capacity: {bag.currentCapacity} total value: {bag.totalValue}" );


            foreach ( var item in bag.items )
            {
                Console.WriteLine( $"{item.name} {item.weight} {item.value} {item.ratio}" );
            }
        }
    }
}
