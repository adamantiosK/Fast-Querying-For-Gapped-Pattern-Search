using FSGPM.Models;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace FSGPM.Helper
{
    public static class BinaryTree
    {
        public static int FindNextElementIndex(int[] arr, int predecessor)
        {
            int left = 0;
            int right = arr.Length - 1;
            int resultIndex = -1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] <= predecessor)
                {
                    left = mid + 1;
                }
                else
                {
                    resultIndex = mid;
                    right = mid - 1;
                }
            }

            return resultIndex;
        }

        public static Node SortedArrayToBST(int[] array, int start, int end)
        {
            if (start == end)
                return new Node(start)
                {
                    IsLeaf = true
                };

            var mid = (start + end) / 2;
            var newNode = new Node(array[mid])
            {
                Left = SortedArrayToBST(array, start, mid),
                Right = SortedArrayToBST(array, mid + 1, end),
                IsLeaf = false
            };
            return newNode;
        }

        public static int GetIndexPiorOfSuccessor(Node root, int minIndex)
        {
            if(root.IsLeaf != null && root.IsLeaf == true)
            {
                return root.NodeValue;
            }

            if(root.NodeValue >= minIndex)
            {
                return GetIndexPiorOfSuccessor(root.Left, minIndex);
            }
            else
            {
                return GetIndexPiorOfSuccessor(root.Right, minIndex);
            }

        }

    }
}
