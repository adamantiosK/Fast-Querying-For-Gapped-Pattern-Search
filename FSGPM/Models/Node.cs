namespace FSGPM.Models
{
    public class Node
    {
        public int NodeValue { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public bool? IsLeaf { get; set; }   

        public Node(int value)
        {
            NodeValue = value;
        }
    }
}
