using Moravia.Homework.Enums;
using Moravia.Homework.Serializers;
using Moravia.Homework.Storages;

namespace Moravia.Homework.Factories;

public interface IStorageFactory
{
    /// <summary>
    /// Create storage for file. The file format is detected by extension.
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    IStorage FromFile(string filename);
}