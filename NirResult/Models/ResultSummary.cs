namespace NirResult.Models;

public class ResultSummary
{
    public DateTime ResultDate { get; set; }
    public bool Error { get; set; }
    public bool Valid { get; set; }
    public string ProductName { get; set; } = null!;
    public string ProductCode { get; set; } = null!;
    public string SampleType { get; set; } = null!;
    public string SampleId { get; set; } = null!;
    public string SampleComment { get; set; }
    public string InstrumentName { get; set; } = null!;
    public string InstrumentSerialNumber { get; set; } = null!;
    public string CupId { get; set; } = null!;
    public string CupType { get; set; } = null!;
    public List<Result> Results { get; set; } = [];
    public ResultSummary()
    {

    }
    public ResultSummary(string[] data)
    {

    }
}
