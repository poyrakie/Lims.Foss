using NirResult.Models;

namespace NirResult.Services;

public interface INirResultService
{
    List<ResultSummary> GetResultSummary(string path, string backupPath);
}
