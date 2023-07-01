using FSGPM.Enum;
using FSGPM.Interfaces;
using FSGPM.Models;
using Microsoft.IdentityModel.Tokens;

namespace FSGPM.DataAccess
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DTUcontext _db;

        public DatabaseService(DTUcontext db)
        {
            _db = db;
        }

        public void CreateConstraintWithConstraintCounts(Guid dataSetGuid)
        {
            var newConstrainGuid = Guid.NewGuid();

            _db.Constraints.AddRange(
                    new List<Constraint>()
                    {
                        new Constraint()
                        {
                            DataSetGuid = dataSetGuid,
                            ConstraintGuid= Guid.NewGuid(),
                            ConstraintCountGuid = ConstraintCountEnum.SmallConstraintGap.GetGuid(),
                            IsDefault = true
                        },
                        new Constraint()
                        {
                            DataSetGuid = dataSetGuid,
                            ConstraintGuid= Guid.NewGuid(),
                            ConstraintCountGuid = ConstraintCountEnum.MediumConstraintGap.GetGuid(),
                            IsDefault = false
                        },
                        new Constraint()
                        {
                            DataSetGuid = dataSetGuid,
                            ConstraintGuid= Guid.NewGuid(),
                            ConstraintCountGuid = ConstraintCountEnum.LargeConstraintGap.GetGuid(),
                            IsDefault = false
                        }
                    }
                );

            _db.SaveChanges();
        }

        public void CreateGeneratedPatterns(Guid dataSetGuid, DataSetWithMostOccouringStrings dataModel)
        {
            foreach (var pattern in dataModel.MostOccouringStringLengthThree)
            {
                _db.Patterns.Add(
                        new Pattern()
                        {
                            DataSetGuid = dataSetGuid,
                            DefaultPatternLength = true,
                            PatternGuid = Guid.NewGuid(),
                            PatternText = pattern
                        }
                    );
            }

            foreach (var pattern in dataModel.MostOccouringStringLengthFive)
            {
                _db.Patterns.Add(
                        new Pattern()
                        {
                            DataSetGuid = dataSetGuid,
                            DefaultPatternLength = false,
                            PatternGuid = Guid.NewGuid(),
                            PatternText = pattern
                        }
                    );
            }

            foreach (var pattern in dataModel.MostOccouringStringLengthSeven)
            {
                _db.Patterns.Add(
                        new Pattern()
                        {
                            DataSetGuid = dataSetGuid,
                            DefaultPatternLength = false,
                            PatternGuid = Guid.NewGuid(),
                            PatternText = pattern
                        }
                    );
            }

            _db.SaveChanges();
        }

        public List<AlgorithmDataSets> GetAllDistinctDataSets(List<Guid> distinctGuids)
        {
            var listToReturn = new List<AlgorithmDataSets>();

            var dataSets = _db.DataSets.Where(n=> distinctGuids.Contains(n.DataSetGuid)).ToList();

            foreach (var dataSetGuid in distinctGuids)
            {
                listToReturn.Add(
                        new AlgorithmDataSets()
                        {
                            DataSetGuid = dataSetGuid,
                            TextT = dataSets.First(n => n.DataSetGuid == dataSetGuid).Text.Replace("\n", "").Replace("\r", "").Replace("\n\r", ""),
                            TwoDimensionalDictionaryLengthPatternCount = ConstructTwoDimentionalDictionaryFromDataSetGuid(dataSetGuid)
                        }
                    );
            }

            //TwoDimensionalDictionaryLengthPatternCount

            return listToReturn;
        }

        private Dictionary<int, Dictionary<int, List<string>>> ConstructTwoDimentionalDictionaryFromDataSetGuid(Guid dsGuid)
        {
            var DictionaryToReturn = new Dictionary<int, Dictionary<int, List<string>>>();

            var kLength = new List<int>() { 
                2,
                4,
                8,
                16
            };

            var patternLenghtList = new List<int>() { 3, 5, 7 };

            var allPatternsForDataSetGuid = GetAllPatternsForSelectedGuid(dsGuid);


            foreach (var k_l in kLength)
            {
                var RoundDictionary = new Dictionary<int, List<string>>();

                foreach (var p_l in patternLenghtList)
                {
                    RoundDictionary[p_l] = SelectRandomPatterns(allPatternsForDataSetGuid.Where(n => n.Length == p_l).ToList(), k_l);
                }

                DictionaryToReturn[k_l] = RoundDictionary;
            }


            return DictionaryToReturn;
        }

        private List<string> SelectRandomPatterns(List<string> originalPatternList, int count)
        {
            List<string> selectedItems = new List<string>();
            Random rand = new Random();

            while (selectedItems.Count < count)
            {
                int index = rand.Next(originalPatternList.Count);
                string selectedItem = originalPatternList[index];
                if (!selectedItems.Contains(selectedItem))
                {
                    selectedItems.Add(selectedItem);
                }
            }

            return selectedItems;
        }

        private List<string> GetAllPatternsForSelectedGuid(Guid dataSetGuid)
        {
            return _db.Patterns.Where(n => n.DataSetGuid == dataSetGuid).Select(s => s.PatternText??"").ToList();
        }

        public List<Guid> GetAllDistinctAvailableDataSetsGuids()
        {
            return _db.DataSets.Where(n => n.AvailableToRun == true).Select(s => s.DataSetGuid).Distinct().ToList();
        }

        public Guid GetNewReportProgressIdentifier()
        {
            var newReportProgressId = Guid.NewGuid();

            _db.ReportStatuses.Add(
                    new ReportStatus()
                    {
                        StatusGuid = newReportProgressId,
                        ProgressStatus = ReportStatusEnum.Created.GetDescription(),
                        ReportCompleted = false,
                        DateCreated = DateTime.Now,
                    }
                );

            _db.SaveChanges();

            return newReportProgressId;
        }

        public ReportStatusModel GetReportProgressFromIdentifier(Guid reportProgressIdentifier)
        {
            var reportStatus = _db.ReportStatuses.FirstOrDefault(n => n.StatusGuid == reportProgressIdentifier);

            if (reportStatus == null)
            {
                return new ReportStatusModel() { };
            }

            return new ReportStatusModel()
            {
                ProgressStatus = reportStatus.ProgressStatus,
                ReportCompleted = reportStatus.ReportCompleted
            };
        }

        public Guid InsertNewDataSet(string? textT, string? DataSetName)
        {
            if (textT.IsNullOrEmpty())
            {
                throw new ArgumentNullException("Here is the null text : " + textT);
            }

            var newDataSetGuid = Guid.NewGuid();

            _db.DataSets.Add(
                    new DataSet()
                    {
                        DataSetGuid = newDataSetGuid,
                        Text = textT,
                        DataSetName = DataSetName
                    }
                );

            _db.SaveChanges();

            return newDataSetGuid;
        }

        public void UpdateReportProgressStatus(Guid reportProgressIdentifier, ReportStatusEnum reportEnum, string ProgressStatus)
        {
            var reportStatus = _db.ReportStatuses.FirstOrDefault(n => n.StatusGuid == reportProgressIdentifier);

            if (reportStatus != null)
            {
                reportStatus.ProgressStatus = ProgressStatus;
                reportStatus.ReportCompleted = reportEnum == ReportStatusEnum.Completed;

                _db.SaveChanges();
            }
        }

        public List<ConstraintModel> GetAllConstraintModels()
        {
            return _db.ConstraintCounts.Select(c => new ConstraintModel()
            {
                ConstraintCountGuid= c.ConstraintCountGuid,
                ConstraintMax = c.ConstraintMax,
                ConstraintMin = c.ConstraintMin
            }).ToList();
        }

        public void SaveResultToDatabase(List<AlgoDataSetResult> results)
        {
            _db.AlgoDataSetResults.AddRange(results);
            _db.SaveChanges();
        }

        public string GetGuidFromString(Guid dataSetGuid)
        {
            return _db.DataSets.FirstOrDefault(n => n.DataSetGuid == dataSetGuid)?.Text ?? "";
        }

        public void UpdateTextInDataSet(Guid dataSetGuid, string text)
        {
            var ds = _db.DataSets.FirstOrDefault(n => n.DataSetGuid == dataSetGuid);

            if (ds != null)
            {
                ds.Text = text;
                _db.SaveChanges();
            }
        }

        public List<AlgoDataSetResultApproved> GetApprovedResultsForDataSet(Guid DataResultGuids)
        {
            return _db.AlgoDataSetResultsApproved.Where(n => n.DataSetGuid == DataResultGuids).ToList();
        }

        public string GetDataSetName(Guid dataSetGuid)
        {
            return _db.DataSets.FirstOrDefault(n => n.DataSetGuid == dataSetGuid)?.DataSetName?? "Data Set Name Not Found";
        }

        public bool ApproveResultsFromResultGuid(Guid ResultGuid)
        {
            var results = _db.AlgoDataSetResults.Where(s => s.DS_Result_Guid == ResultGuid).ToList();

            _db.AlgoDataSetResultsApproved.AddRange(results.Select(s => new AlgoDataSetResultApproved()
            {
                AlgoResultGuid = s.AlgoResultGuid,
                DS_Result_Guid = s.DS_Result_Guid,
                AlgorithmName = s.AlgorithmName,
                K_Selection = s.K_Selection,
                DataSetGuid = s.DataSetGuid,
                ConstraintCountGuid = s.ConstraintCountGuid,
                PatternLength = s.PatternLength,
                Miliseconds = s.Miliseconds,
                Miliseconds_Preproccesing = s.Miliseconds_Preproccesing,
                Miliseconds_AverageRun = s.Miliseconds_AverageRun
            }));

            _db.SaveChanges();

            return true;
        }

        public DataSet GetDataSetModelByGuid(Guid dataSetGuid)
        {
            var dataset = _db.DataSets.FirstOrDefault(n => n.DataSetGuid == dataSetGuid);

            if (dataset == null)
            {
                throw new ArgumentNullException("DataSet not found");
            }

            return dataset;
        }

        public void SaveCalculatedSuffixArrayResults(Guid DataSetGuid, int[] suffixArrayBuild, long elapsedTime)
        {
            var dataSet = _db.DataSets.FirstOrDefault(n => n.DataSetGuid == DataSetGuid);

            if (dataSet == null) {
                throw new ArgumentNullException("DataSet not found");
            }

            _db.SuffixArraySets.Add(new SuffixArraySet()
            {
                SuffixArrayGuid = Guid.NewGuid(),
                DataSetGuid = DataSetGuid,
                SuffixArray = string.Join(", ", suffixArrayBuild)
            });

            dataSet.SACalculated = true;
            dataSet.OverHeadMsCalculated = elapsedTime;

            _db.SaveChanges();
        }

        public (int[] suffixArrayBuild, long elapsedTime) GetSAandETbyDataSetGuid(Guid dataSetGuid)
        {
        
            var dataSet = _db.DataSets.FirstOrDefault(n => n.DataSetGuid == dataSetGuid);

            if (dataSet == null)
            {
                throw new ArgumentNullException("DataSet not found");
            }

            var suffixArrayString = _db.SuffixArraySets.FirstOrDefault(n => n.DataSetGuid == dataSetGuid).SuffixArray;

            if (suffixArrayString == null)
            {
                throw new ArgumentException("Suffix not calculated");
            }

            var suffixArray = Array.ConvertAll(suffixArrayString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);

            return (suffixArray, dataSet.OverHeadMsCalculated);
        }
    }
}
