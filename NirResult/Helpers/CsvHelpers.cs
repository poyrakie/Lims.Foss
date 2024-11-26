using System.Globalization;
using NirResult.Models;

namespace NirResult.Helpers;

public class CsvHelpers
{
    public static ResultSummary ParseCsvToResultSummary(string file)
    {
        try
        {

            using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {

                using (var sr = new StreamReader(fs))
                {
                    string line;
                    int lineNumber = 0;
                    ResultSummary result = new ResultSummary();
                    List<string> analysNames = new();

                    while ((line = sr.ReadLine()!) != null)
                    {
                        lineNumber++;
                        if (lineNumber == 1)
                        {
                            List<string> parseResult = ParseCsvLine(line);

                            for (int i = 8; i < parseResult.Count - 2; i = i + 4)
                                analysNames.Add(parseResult[i]);
                        }
                        else if (lineNumber == 2)
                        {
                            List<string> parseResult = ParseCsvLine(line);

                            result.ResultDate = DateTime.Parse(parseResult[0]);
                            result.ProductName = parseResult[1];
                            result.ProductCode = parseResult[2];
                            result.SampleType = parseResult[3];
                            result.SampleId = parseResult[4];
                            result.SampleComment = parseResult[5];
                            result.InstrumentName = parseResult[6];
                            result.InstrumentSerialNumber = parseResult[7];
                            result.CupId = parseResult[parseResult.Count() - 2];
                            result.CupType = parseResult[parseResult.Count() - 1];
                            result.Results = new List<Result>();

                            int i = 8;
                            foreach (string title in analysNames)
                            {
                                result.Results.Add(CreateResult(result.ProductName, title, parseResult, i));
                                i = i + 4;
                            }
                        }
                    }
                    return result;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }

    }
    static Result CreateResult(string productName, string arrayIndex, List<string> parseResult, int i)
    {
        Result resultToAdd = new($"{productName}_{arrayIndex}")
        {
            Value = ConvertToDouble(parseResult[i]),
            Limit1 = ConvertToDouble(parseResult[i + 1]),
            Limit2 = ConvertToDouble(parseResult[i + 2]),
            Limit3 = ConvertToDouble(parseResult[i + 3])
        };
        return resultToAdd;
    }
    static List<string> ParseCsvLine(string line)
    {
        var result = new List<string>();
        bool insideQuotes = false;
        string current = "";
        foreach (var c in line)
        {
            if (c == '\"')
                insideQuotes = !insideQuotes;
            else if (c == ',' && !insideQuotes)
            {
                result.Add(current);
                current = "";
            }
            else
                current += c;

        }
        if (!string.IsNullOrEmpty(current))
            result.Add(current);
        return result;
    }
    public static double ConvertToDouble(string value)
    {
        value = value.Replace(",", ".");
        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
        {
            if (result < 0)
                result = 0;
            return result;
        }

        throw new Exception($"Could not read value '{value}' as a number");
    }
    public CsvHelpers()
    {

    }
}
