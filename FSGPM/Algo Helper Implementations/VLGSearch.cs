using FSGPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class VLGSearch
{
    public AhoCorasick Automaton { get; private set; }

    public VLGSearch()
    {
        Automaton = new AhoCorasick();
    }


    public List<SA_Scan_Model> Search(string[] subpatterns, string text)
    {
        Automaton.Build(subpatterns);

        return Automaton.Match(text)
            .GroupBy(t => t.Item1)
            .OrderBy(g => g.Key)
            .Select(g => new SA_Scan_Model
            {
                M = g.Count(),
                PatternArray = g.Select(t => t.Item2).ToArray() 
            }).ToList();
    }

    public class AhoCorasick
    {
        private class TrieNode
        {
            public int Depth;
            public TrieNode FailureLink;
            public TrieNode Parent;
            public char TransitionChar;
            public Dictionary<char, TrieNode> Transitions;
            public List<int> Outputs;

            public TrieNode(TrieNode parent, char transitionChar, int depth)
            {
                Parent = parent;
                TransitionChar = transitionChar;
                Depth = depth;
                Transitions = new Dictionary<char, TrieNode>();
                Outputs = new List<int>();
            }
        }

        private TrieNode _root;
        private List<string> _patterns;

        public AhoCorasick()
        {
            _root = new TrieNode(null, ' ', 0);
        }

        public void Build(string[] patterns)
        {
            _patterns = patterns.ToList();
            BuildTrie(patterns);
            BuildFailureLinks();
        }

        public IEnumerable<Tuple<int, int>> Match(string text)
        {
            TrieNode currentNode = _root;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                currentNode = Traverse(currentNode, c);

                if (currentNode.Outputs.Count > 0)
                {
                    foreach (int patternIndex in currentNode.Outputs)
                    {
                        yield return new Tuple<int, int>(patternIndex, i - (_patterns[0].Length - 1) );
                    }
                }
            }
        }

        private void BuildTrie(string[] patterns)
        {
            for (int i = 0; i < patterns.Length; i++)
            {
                string pattern = patterns[i];
                TrieNode currentNode = _root;

                foreach (char c in pattern)
                {
                    if (!currentNode.Transitions.ContainsKey(c))
                    {
                        currentNode.Transitions[c] = new TrieNode(currentNode, c, currentNode.Depth + 1);
                    }
                    currentNode = currentNode.Transitions[c];
                }

                currentNode.Outputs.Add(i);
            }
        }

        private void BuildFailureLinks()
        {
            Queue<TrieNode> queue = new Queue<TrieNode>();

            foreach (TrieNode node in _root.Transitions.Values)
            {
                node.FailureLink = _root;
                queue.Enqueue(node);
            }

            while (queue.Count > 0)
            {
                TrieNode currentNode = queue.Dequeue();

                foreach (TrieNode childNode in currentNode.Transitions.Values)
                {
                    TrieNode fallbackNode = currentNode.FailureLink;

                    while (fallbackNode != _root && !fallbackNode.Transitions.ContainsKey(childNode.TransitionChar))
                    {
                        fallbackNode = fallbackNode.FailureLink;
                    }

                    if (fallbackNode.Transitions.ContainsKey(childNode.TransitionChar))
                    {
                        childNode.FailureLink = fallbackNode.Transitions[childNode.TransitionChar];
                    }
                    else
                    {
                        childNode.FailureLink = _root;
                    }

                    childNode.Outputs.AddRange(childNode.FailureLink.Outputs);

                    queue.Enqueue(childNode);
                }
            }
        }

        private TrieNode Traverse(TrieNode currentNode, char c)
        {
            while (currentNode != _root && !currentNode.Transitions.ContainsKey(c))
            {
                currentNode = currentNode.FailureLink;
            }

            if (currentNode.Transitions.ContainsKey(c))
            {
                currentNode = currentNode.Transitions[c];
            }

            return currentNode;
        }
    }
}
