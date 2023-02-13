using Moravia.Homework.Interfaces;

namespace Moravia.Homework;

class Transferer
{
    public void Transfer<T>(IStorage source, IStorage destination)
    where T : class, new()
    {
        var content = source.Load<T>();
        destination.Save(content);
    }
}