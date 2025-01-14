namespace Samples.Security.DataAccess.Interfaces.DataSets;

internal interface IDataSet<T> where T : class
{
    T[] Load();
    void Save(T[] users);
}