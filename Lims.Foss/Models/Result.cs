namespace Lims.Foss.Models;

public class Result
{
    public string Name { get; set; }
    public double Value { get; set; }
    public double Limit1 { get; set; }
    public double Limit2 { get; set; }
    public double Limit3 { get; set; }
    public Result(string name)
    {
        this.Name = name;
    }
}
