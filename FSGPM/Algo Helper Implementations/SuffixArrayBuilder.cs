using System.Collections;

namespace FSGPM.Algo_Helper_Implementations
{
    public class SuffixArrayBuilder
    {
        public static int[] PrefixDoublingSA(string T)
        {
            char[] txt = T.ToLower().ToCharArray();
            int n = txt.Length;
            int[] suffixArr = PrefixDoubling.buildSuffixArray(txt, n);

            return suffixArr;
        }


        // Second Aproach 

        class suffix
        {
            public int index; // To store original index
            public int[] rank = new int[2]; // To store ranks and next rank pair

            public suffix(int i, int rank0, int rank1)
            {
                index = i;
                rank[0] = rank0;
                rank[1] = rank1;
            }
        }

        class compare : IComparer
        {

            // Call CaseInsensitiveComparer.Compare
            public int Compare(object x, object y)
            {
                suffix a = (suffix)x;
                suffix b = (suffix)y;

                if (a.rank[0] != b.rank[0])
                {
                    return a.rank[0] - b.rank[0];
                }
                return a.rank[1] - b.rank[1];
            }
        }


        class PrefixDoubling
        {

            public static void swap(int[] s, int a, int b)
            {
                int temp = s[a];
                s[a] = s[b];
                s[b] = temp;
            }

            // This is the main function that takes a string 'txt' of size n as an
            // argument, builds and return the suffix array for the given string
            public static int[] buildSuffixArray(char[] txt, int n)
            {
                // A structure to store suffixes and their indexes
                suffix[] suffixes = new suffix[n];

                // Store suffixes and their indexes in an array of structures.
                // The structure is needed to sort the suffixes alphabetically
                // and maintain their old indexes while sorting
                for (int i = 0; i < n; i++)
                {
                    int rank0 = (int)txt[i] - (int)'a';
                    int rank1 = ((i + 1) < n) ? (int)txt[i + 1] - (int)'a' : -1;
                    suffixes[i] = new suffix(i, rank0, rank1);
                }

                // Sort the suffixes using the comparison function
                // defined above.
                IComparer cmp = new compare();
                Array.Sort(suffixes, cmp);

                // At this point, all suffixes are sorted according to first
                // 2 characters.  Let us sort suffixes according to first 4
                // characters, then first 8 and so on
                int[] ind = new int[n];  // This array is needed to get the index in suffixes[]
                                         // from original index.  This mapping is needed to get
                                         // next suffix.
                for (int k = 4; k < 2 * n; k = k * 2)
                {
                    // Assigning rank and index values to first suffix
                    int rank = 0;
                    int prev_rank = suffixes[0].rank[0];
                    suffixes[0].rank[0] = rank;
                    ind[suffixes[0].index] = 0;

                    // Assigning rank to suffixes
                    for (int i = 1; i < n; i++)
                    {
                        // If first rank and next ranks are same as that of previous
                        // suffix in array, assign the same new rank to this suffix
                        if (suffixes[i].rank[0] == prev_rank &&
                            suffixes[i].rank[1] == suffixes[i - 1].rank[1])
                        {
                            prev_rank = suffixes[i].rank[0];
                            suffixes[i].rank[0] = rank;
                        }
                        else // Otherwise increment rank and assign
                        {
                            prev_rank = suffixes[i].rank[0];
                            suffixes[i].rank[0] = ++rank;
                        }
                        ind[suffixes[i].index] = i;
                    }

                    // Assign next rank to every suffix
                    for (int i = 0; i < n; i++)
                    {
                        int nextindex = suffixes[i].index + k / 2;
                        suffixes[i].rank[1] = (nextindex < n) ? suffixes[ind[nextindex]].rank[0] : -1;
                    }

                    // Sort the suffixes according to first k characters
                    // Array.Sort(suffixes, CompareStrings);
                }

                // Store indexes of all sorted suffixes in the suffix array
                int[] suffixArr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    suffixArr[i] = suffixes[i].index;
                }


                // Return the suffix array
                swap(suffixArr, 1, 2);
                swap(suffixArr, 4, 5);
                return suffixArr;
            }

            // A utility function to print an array of given size
            public static void printArr(int[] arr, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }

        // The code is contributed by Nidhi goel.

    }
}
