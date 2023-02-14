namespace Moravia.Homework.Storages;

public interface IStorage
{
    T Load<T>() where T : class, new();

    void Save<T>(T obj) where T : class;
}