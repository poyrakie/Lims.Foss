using Lims.Foss.Models;

namespace Lims.Foss.Services;

public interface INirResultService
{
    List<ResultSummary> GetResultSummary(string path, string backupPath);
}
