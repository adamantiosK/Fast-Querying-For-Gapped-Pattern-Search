using FSGPM.Helper;
using System;

namespace FSGPM.Algo_Helper_Implementations
{
    public static class SA_Search_Pruning_Singleton
    {
        private static Dictionary<Guid, Dictionary<int, PrunnedDirectory>> _prunedDirectories = new Dictionary<Guid, Dictionary<int, PrunnedDirectory>>();
        //public static Guid InstanceGuid { get; private set; 

        //public static Dictionary<int, PrunnedDirectory> _prunedDirectories;

        static SA_Search_Pruning_Singleton()
        {
            _prunedDirectories = new Dictionary<Guid, Dictionary<int, PrunnedDirectory>>();
        }

        public static Dictionary<int, PrunnedDirectory> GetInstance(Guid? guid = null)
        {
            if (guid == null || !_prunedDirectories.ContainsKey(guid.Value))
            {
                if (guid == null)
                {
                    guid = Guid.NewGuid();
                }

                _prunedDirectories[guid.Value] = new Dictionary<int, PrunnedDirectory>();
            }

            return _prunedDirectories[guid.Value];
        }

        public static void DeleteInstance(Guid prunedDictionaryGuid)
        {
            if(_prunedDirectories.ContainsKey(prunedDictionaryGuid))
            {
                _prunedDirectories.Remove(prunedDictionaryGuid);
            }
        }

        public static void InsertRoadMaps(this Dictionary<int, PrunnedDirectory> prunedDictionary, int Index, List<List<int>> roadMap)
        {
            if(!prunedDictionary.ContainsKey(Index))
            {
                prunedDictionary[Index] = new PrunnedDirectory();
            }

            if(roadMap.Count == 0)
            {
                return;
            }

            var j = BinaryTree.FindNextElementIndex(roadMap[0].ToArray(), Index);

            if(j == -1)
            {
                return;
            }

            foreach (var rm in roadMap)
            {
                var newPrunedDirectory = new List<int>(rm.Count - j + 1);

                for (int k = j; k < rm.Count; k++)
                {
                    newPrunedDirectory.Add(rm[k]);
                }

                prunedDictionary[Index].PrunedDirectories.Add(newPrunedDirectory);
            }
        }

        public static bool IsIndexedPruned(this Dictionary<int, PrunnedDirectory> prunedDictionary, int Index)
        {
            return prunedDictionary.ContainsKey(Index) ? prunedDictionary[Index].PruneForIndexCompleted : false;
        }

        public static void MarkIndexAsPrunned(this Dictionary<int, PrunnedDirectory> prunedDictionary, int Index)     
        {
            prunedDictionary[Index].PruneForIndexCompleted = true;
        }

        public static List<List<int>> GetPrunedDirectories(this Dictionary<int, PrunnedDirectory> prunedDictionary, int index, List<int> activeDirectory) 
        {
            if (!prunedDictionary.ContainsKey(index))
            {
                return new List<List<int>> {};
            }

            var PD = prunedDictionary[index].PrunedDirectories;

            List<List<int>> combinedDirectories = new List<List<int>>();
            foreach (List<int> subDirectory in PD)
            {
                List<int> concatinatedDirectory = new List<int>(activeDirectory) { index };
                concatinatedDirectory.AddRange(subDirectory);
                combinedDirectories.Add(concatinatedDirectory);
            }

            return combinedDirectories;
        }
    }

    public class PrunnedDirectory
    {
        public PrunnedDirectory()
        {
            PruneForIndexCompleted = false;
            PrunedDirectories = new List<List<int>>();
        }

        public bool PruneForIndexCompleted { get; set; }
        public List<List<int>> PrunedDirectories { get; set; }
    }
}
