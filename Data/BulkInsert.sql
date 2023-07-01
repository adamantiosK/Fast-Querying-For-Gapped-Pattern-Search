
CREATe TABLE #temp (Line VARChar(MAX));

BULK INSERT #temp 
FROM 'C:\Code\Data\Unzipped\Source Code\sources.50MB\sources.50MB'
WITH(
    FieldTerminator = '\0',
    RowTerminator = '\0'
);

DECLARE @filecontents varchar(max);

select @filecontents = COalesce(@filecontents+ '', '') + Line
FROM #temp;

SELECT @filecontents;

  UPDATE [dtu-fsgpm].[dbo].[DataSets]
  SET [Text] = @filecontents
  WHERE [DataSetGuid] = 'fd26b6ea-ccb6-4835-b4bc-bdfaa9a3e95d'
 
DROP table #temp

