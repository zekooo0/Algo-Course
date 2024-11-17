using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractional_knapsack_problem
{
    public class Item
    {
        public string name;
        public double weight;
        public double value;
        public double ratio;

        public Item( string name, double weight, double value )
        {
            this.name = name;
            this.weight = weight;
            this.value = value;
            this.ratio = value / weight;
        }
    }

    public class Knapsack
    {
        public double maxCapacity;
        public double currentCapacity;
        public double totalValue;
        public List<Item> items;
        
        public Knapsack( int maxCapacity )
        {
            this.maxCapacity = maxCapacity;
            this.currentCapacity = 0;
            this.totalValue = 0;
            this.items = new List<Item>();
        }

        public void add_item( Item newItem )
        {
            if ( newItem.weight > maxCapacity - currentCapacity )
            {
                double diff = maxCapacity - currentCapacity;
                newItem.weight = diff;
                newItem.value = diff * newItem.ratio;
            }

            currentCapacity += newItem.weight;
            totalValue += newItem.value;
            items.Add( newItem );  

        }


        public static void merge_sort( Item[] arr, int start, int end )
        {

            if ( end <= start )
                return;
            int mid = ( end + start ) / 2;

            merge_sort( arr, start, mid );
            merge_sort( arr, mid + 1, end );

            merge( arr, start, mid, end );
        }

        public static void merge( Item[] arr, int start, int mid, int end )
        {
            int i, j, k;
            int left_length = mid - start + 1;
            int right_length = end - mid;

            Item[] left_array = new Item[left_length];
            Item[] right_array = new Item[right_length];

            for ( i = 0; i < left_length; i++ )
            {
                left_array[i] = arr[start + i];
            }

            for ( j = 0; j < right_length; j++ )
            {
                right_array[j] = arr[mid + 1 + j];
            }

            i = 0;
            j = 0;
            k = start;

            while ( i < left_length && j < right_length )
            {
                if ( left_array[i].ratio > right_array[j].ratio )
                {
                    arr[k] = left_array[i];
                    i++;
                    k++;
                }
                else
                {
                    arr[k] = right_array[j];
                    j++;
                    k++;
                }
            }

            while ( i < left_length )
            {
                arr[k] = left_array[i];
                i++;
                k++;
            }

            while ( j < right_length )
            {
                arr[k] = right_array[j];
                j++;
                k++;
            }

        }



    }
}
