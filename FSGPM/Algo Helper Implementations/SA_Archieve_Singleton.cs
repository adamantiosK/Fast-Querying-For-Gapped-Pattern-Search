using Microsoft.Identity.Client;

namespace FSGPM.Algo_Helper_Implementations
{

    public sealed class SA_Archieve_Singleton
    {
        private static SA_Archieve_Singleton instance = null;
        private Dictionary<Guid, Tuple<int[],long>> myDictionary;

        private SA_Archieve_Singleton()
        {
            myDictionary = new Dictionary<Guid, Tuple<int[], long>>();
        }

        public static SA_Archieve_Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SA_Archieve_Singleton();
                }
                return instance;
            }
        }

        public bool HasSuffixArrayBeenCalculated(Guid DataSetGuid)
        {
            return myDictionary.ContainsKey(DataSetGuid);
        }

        public (int[], long) Get_SA_From_DataSetGuid(Guid DataSetGuid)
        {
            var dictionaryTuple = myDictionary[DataSetGuid];

            return (dictionaryTuple.Item1, dictionaryTuple.Item2);
        }

        public void AddSuffixArrayCalculationsToDictionary(Guid DataSetGuid, int[] SA, long elapsedMilliseconds)
        {
            myDictionary.Add(DataSetGuid, Tuple.Create(SA, elapsedMilliseconds));
        }
    }

}