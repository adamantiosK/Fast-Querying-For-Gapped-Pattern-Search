using FSGPM.Models;
using System.Data;

namespace FSGPM.Interfaces
{
    public interface IStatService
    {
        public List<List<string>> GetBenchMarksByGuid(Guid DS_Results_Guid, bool staticConstraintTrueStaticPatternLenghtFalse);
        public List<BenchMarkHistoryModel> GetOldBenchMarks();
    }
}
