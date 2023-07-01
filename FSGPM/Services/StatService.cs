using FSGPM.DataAccess;
using FSGPM.Enum;
using FSGPM.Interfaces;
using FSGPM.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace FSGPM.Services
{
    public class StatService : IStatService
    {
        private readonly DTUcontext _db;
        private readonly List<IFS_GPM_Implementation> _algorithms;

        public StatService(DTUcontext db, IServiceProvider serviceProvider)
        {
            _db = db;
            _algorithms = serviceProvider.GetServices<IFS_GPM_Implementation>().ToList();
        }

        public List<List<string>> GetBenchMarksByGuid(Guid DS_Results_Guid, bool staticConstraintTrueStaticPatternLenghtFalse)
        {
            var listToReturn = new List<List<string>>();

            var headerModel = GetHeaderRows(DS_Results_Guid, staticConstraintTrueStaticPatternLenghtFalse);

            listToReturn.AddRange(headerModel.HeaderRows);

            for (int i = 0; i < 4; i++)
            {
                var k = (int)Math.Pow(2, i + 1);
                var k_line = new List<string>
                {
                    (k).ToString()
                };

                for (int j = 0; j < listToReturn[0].Count - 1; j++)
                {
                    k_line.Add("");
                }

                listToReturn.Add(k_line);

                //ForEachAlgorithm for the K for Static being what it is: 

                foreach (var algo in _algorithms)
                {
                    var algoName = GetAlgoName(algo);

                    if (AlgoRunWIthData(DS_Results_Guid, headerModel.DataSetModels[0].DataSetGuid, algoName, k, CountConstraint: ConstraintCountEnum.SmallConstraintGap.GetGuid()))
                    {

                        var _algoLine = new List<string>()
                        {
                            algoName
                        };

                        foreach (var dataSet in headerModel.DataSetModels)
                        {
                            if (staticConstraintTrueStaticPatternLenghtFalse)
                            {
                                _algoLine.Add(GetMiliSecondsOfAlgoForSpecifications(DS_Results_Guid, dataSet.DataSetGuid, algoName, k, 3));
                                _algoLine.Add(GetMiliSecondsOfAlgoForSpecifications(DS_Results_Guid, dataSet.DataSetGuid, algoName, k, 5));
                                _algoLine.Add(GetMiliSecondsOfAlgoForSpecifications(DS_Results_Guid, dataSet.DataSetGuid, algoName, k, 7));
                            }
                            else
                            {
                                _algoLine.Add(GetMiliSecondsOfAlgoForSpecifications(DS_Results_Guid, dataSet.DataSetGuid, algoName, k, CountConstraint: ConstraintCountEnum.SmallConstraintGap.GetGuid()));
                                _algoLine.Add(GetMiliSecondsOfAlgoForSpecifications(DS_Results_Guid, dataSet.DataSetGuid, algoName, k, CountConstraint: ConstraintCountEnum.MediumConstraintGap.GetGuid()));
                                _algoLine.Add(GetMiliSecondsOfAlgoForSpecifications(DS_Results_Guid, dataSet.DataSetGuid, algoName, k, CountConstraint: ConstraintCountEnum.LargeConstraintGap.GetGuid()));
                            }
                        }

                        listToReturn.Add(_algoLine);

                    }
                }
            }

            //return ConvertListToDataTable(listToReturn);
            return listToReturn;
        }

        private bool AlgoRunWIthData(Guid DS_Results_Guid, Guid dataSetGuid, string algoName, int k_Selection, int p_Length = 3, Guid? CountConstraint = null)
        {
            if (CountConstraint == null)
            {
                CountConstraint = ConstraintCountEnum.SmallConstraintGap.GetGuid();
            }

            return _db.AlgoDataSetResults.Where(n =>
                    n.DS_Result_Guid == DS_Results_Guid &&
                    n.DataSetGuid == dataSetGuid &&
                    n.AlgorithmName == algoName &&
                    n.K_Selection == k_Selection &&
                    n.PatternLength == p_Length &&
                    n.ConstraintCountGuid == CountConstraint
                ).ToList().Count() > 0;
        }

        private string GetMiliSecondsOfAlgoForSpecifications(Guid DS_Results_Guid, Guid dataSetGuid, string algoName, int k_Selection, int p_Length = 3, Guid? CountConstraint = null)
        {
            if (CountConstraint == null)
            {
                CountConstraint = ConstraintCountEnum.SmallConstraintGap.GetGuid();
            }

            var results = _db.AlgoDataSetResults.First(n =>
                    n.DS_Result_Guid == DS_Results_Guid &&
                    n.DataSetGuid == dataSetGuid &&
                    n.AlgorithmName == algoName &&
                    n.K_Selection == k_Selection &&
                    n.PatternLength == p_Length &&
                    n.ConstraintCountGuid == CountConstraint
                );


            //return results.Miliseconds.ToString();
            return $"{results.Miliseconds.ToString()}, {results.Miliseconds_Preproccesing.ToString()}, {results.Miliseconds_AverageRun.ToString()}({results.PatternsFound.ToString()})";
        }


        private string GetAlgoName(IFS_GPM_Implementation algorithms)
        {
            // Get the type of the instance
            Type type = algorithms.GetType();

            // Get the PropertyInfo for the AlgorithmName property
            PropertyInfo property = type.GetProperty("AlgorithmName");

            // Get the value of AlgorithmName from the instance and return it
            return (string)property.GetValue(algorithms);

        }

        private HeaderRowsModel GetHeaderRows(Guid DS_Results_Guid, bool staticConstraintTrueStaticPatternLenghtFalse)
        {
            var objectToReturn = new HeaderRowsModel();

            var listToReturn = new List<List<string>>();

            var listToAddToReturn1 = new List<string>() { "Method" };

            var distinctDataSets = _db.AlgoDataSetResults.Where(n => n.DS_Result_Guid == DS_Results_Guid).Select(s => s.DataSetGuid).Distinct().ToList();

            var dataSets = _db.DataSets.Where(n => distinctDataSets.Contains(n.DataSetGuid)).Select(s => new DataSetModel()
            {
                DataSetGuid = s.DataSetGuid,
                DataSetName = s.DataSetName
            }).ToList();

            foreach (var dataSet in dataSets)
            {
                listToAddToReturn1.Add("");
                listToAddToReturn1.Add(dataSet.DataSetName);
                listToAddToReturn1.Add("");
            }

            listToReturn.Add(listToAddToReturn1);

            var listToAddToReturn2 = new List<string>() { "" };

            if (staticConstraintTrueStaticPatternLenghtFalse)
            {
                foreach (var dataSet in dataSets)
                {
                    listToAddToReturn2.Add("3");
                    listToAddToReturn2.Add("5");
                    listToAddToReturn2.Add("7");
                }
            }
            else
            {
                foreach (var dataSet in dataSets)
                {
                    listToAddToReturn2.Add(ConstraintCountEnum.SmallConstraintGap.GetDescription());
                    listToAddToReturn2.Add(ConstraintCountEnum.MediumConstraintGap.GetDescription());
                    listToAddToReturn2.Add(ConstraintCountEnum.LargeConstraintGap.GetDescription());
                }
            }
            listToReturn.Add(listToAddToReturn2);

            objectToReturn.HeaderRows = listToReturn;
            objectToReturn.DataSetModels = dataSets;

            return objectToReturn;
        }

        public DataTable ConvertListToDataTable(List<List<string>> listOfLists)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < listOfLists[0].Count; i++)
            {
                dt.Columns.Add("Column" + (i + 1));
            }

            foreach (List<string> list in listOfLists)
            {
                DataRow dr = dt.NewRow();

                for (int i = 0; i < list.Count; i++)
                {
                    dr[i] = list[i];
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public List<BenchMarkHistoryModel> GetOldBenchMarks()
        {
            return _db.ReportStatuses.Distinct().Select(s =>
                new BenchMarkHistoryModel()
                {
                    ResultGuid = s.StatusGuid,
                    DateTimeResultConducted = ((DateTime)s.DateCreated).ToString("HH:mm dd/MM/yyyy").Replace(".", ":")
                }).ToList();
        }
    }

    public class HeaderRowsModel
    {
        public List<DataSetModel> DataSetModels { get; set; }
        public List<List<string>> HeaderRows { get; set; }
    }

    public class DataSetModel
    {
        public string DataSetName { get; set; }
        public Guid DataSetGuid { get; set; }
    }
}
