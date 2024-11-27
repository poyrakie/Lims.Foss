using Lims.Foss.Helpers;
using Lims.Foss.Models;

namespace Lims.Foss.Services;

public class NirResultService : INirResultService
{
    public NirResultService()
    {

    }


    public List<ResultSummary> GetResultSummary(string filePath, string backupPath)
    {
        List<ResultSummary> results = new List<ResultSummary>();
        string[] files = Directory.GetFiles(filePath);
        foreach (var file in files)
        {
            var answer = CsvHelpers.ParseCsvToResultSummary(file);
            if (!answer.Error)
            {
                results.Add(answer);
                Directory.Move(file, Path.Combine(backupPath, Path.GetFileName(file)));
            }
            else
            {
                results.Add(answer);
            }
        }
        return results;
    }
}