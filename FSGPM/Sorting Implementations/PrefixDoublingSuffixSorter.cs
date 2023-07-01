using static System.Net.Mime.MediaTypeNames;

namespace FSGPM.Sorting_Implementations
{
    public class PrefixDoublingSuffixSorter
    {

        public static int[] GenerateAndSortSuffixes(string TextT)
        {
            string text = "banana";

            var strings = GenerateSuffixes(TextT);

            RadixSort(strings);

            //return sortedSuffixes.Select(s => s.Index).ToArray();
            return new int[] { 0 };
        }


        // A utility function to get the maximum value in arr[]
        private static int getMax(string[] arr)
        {
            int max = arr[0].Length;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].Length > max)
                {
                    max = arr[i].Length;
                }
            }
            return max;
        }

        // A function to do counting sort of arr[] according to the digit represented by exp.
        private static void countSort(string[] arr, int exp)
        {
            int n = arr.Length;
            string[] output = new string[n];
            int[] count = new int[256];
            for (int i = 0; i < 256; i++)
            {
                count[i] = 0;
            }

            // Store count of occurrences in count[]
            for (int i = 0; i < n; i++)
            {
                int index = (exp < arr[i].Length) ? (int)arr[i][exp] : 0;
                count[index]++;
            }

            // Change count[i] so that count[i] now contains actual position of this digit in output[]
            for (int i = 1; i < 256; i++)
            {
                count[i] += count[i - 1];
            }

            // Build the output array
            for (int i = n - 1; i >= 0; i--)
            {
                int index = (exp < arr[i].Length) ? (int)arr[i][exp] : 0;
                output[count[index] - 1] = arr[i];
                count[index]--;
            }

            // Copy the output array to arr[], so that arr[] now contains sorted strings according to current digit
            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }

        // The main function to sort arr[] of size n using Radix Sort
        public static void RadixSort(string[] arr)
        {
            int n = arr.Length;
            int m = getMax(arr);

            // Do counting sort for every digit from LSD to MSD
            for (int exp = m - 1; exp >= 0; exp--)
            {
                countSort(arr, exp);
            }
        }

        static string[] GenerateSuffixes(string text)
        {
            int n = text.Length;
            string[] suffixes = new string[n];
            int[] suffixArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                suffixes[i] = text.Substring(i);
                suffixArray[i] = i;
            }

            return suffixes;
        }
    }
}