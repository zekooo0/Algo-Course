using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Coding
{

    public class HeapNode
    {
        public char data;
        public int freq;
        public HeapNode left;
        public HeapNode right;

        public HeapNode(char data, int freq)
        {
            this.data = data;
            this.freq = freq;
            this.left = this.right = null;
        }
    }


    public class Huffman
    {
        private char internal_char = (char) 0;
        private PriorityQueue<HeapNode, int> minHeap = new PriorityQueue<HeapNode, int>();
        public Hashtable codes = new Hashtable();
        public Huffman( string message )
        {
            Hashtable freqHash = new Hashtable();

            int i;
            for ( i = 0; i < message.Length; i++ )
            {
                if ( freqHash[message[i]] == null )
                {
                    freqHash[message[i]] = 1;
                }
                else
                {
                    freqHash[message[i]] = (int) freqHash[message[i]] + 1;
                }
            }

            foreach ( char k in freqHash.Keys )
            {
                HeapNode newNode = new HeapNode( k, (int) freqHash[k] );
                minHeap.Enqueue( newNode, (int) freqHash[k] );
            }

            HeapNode top, left, right;
            int newFreq;
            while ( minHeap.Count != 1 )
            {
                left = minHeap.Dequeue();
                right = minHeap.Dequeue();
                newFreq = left.freq + right.freq;

                top = new HeapNode(internal_char, newFreq );
                top.left = left;
                top.right = right;
                minHeap.Enqueue( top, newFreq );
            }
            this.generateCodes( minHeap.Peek(), "" );
        }

        private void generateCodes( HeapNode node, string str )
        {
            if ( node == null )
                return;

            if ( node.data != internal_char )
            {
                codes[node.data] = str;
            }

            generateCodes( node.left, str + '0' );
            generateCodes( node.right, str + '1' );

        }

    }

}

