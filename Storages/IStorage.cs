namespace Moravia.Homework.Storages;

interface IStorage
{
    T Load<T>() where T : class, new();

    void Save<T>(T obj) where T : class;
}