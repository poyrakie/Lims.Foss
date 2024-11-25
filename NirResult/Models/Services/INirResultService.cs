namespace NirResult.Models.Services;

public interface INirResultService
{
    List<ResultSummary> GetResultSummary(string path, string backupPath);
}
