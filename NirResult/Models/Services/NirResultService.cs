﻿using NirResult.Models.Helpers;

namespace NirResult.Models.Services;

public class NirResultService
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
            if (answer != null)
            {
                results.Add(answer);
                Directory.Move(file, Path.Combine(backupPath, Path.GetFileName(file)));
            }
            else
            {
                results.Add(new ResultSummary()
                {
                    Error = true
                });
            }
        }
        return results;
    }
}