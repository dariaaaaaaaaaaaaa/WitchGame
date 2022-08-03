namespace Core.DataStorage
{
    public interface IDataSaveSystem
    {
        void Save();

        T GetDataSaveContainer<T>();
        void AddSaveContainer(IDataSaveContainer dataSaveContainer);
        void RemoveDataSaveContainer(IDataSaveContainer dataSaveContainer);

        void RemoveAll();
    }
}