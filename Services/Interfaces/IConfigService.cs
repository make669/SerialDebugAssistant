using System;
using Models;
using Properties;

namespace Services.Interfaces
{
    public interface IConfigService
    {
        OperationResult Save(AppSettings settings, string? filePath = null);

        OperationResult Load(string? filePath = null);

        OperationResult LoadOrCreateDefault(string? filePath = null);
    }
}
