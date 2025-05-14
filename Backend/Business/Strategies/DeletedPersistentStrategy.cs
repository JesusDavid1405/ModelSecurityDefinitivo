using Data.Core;

namespace Business.Strategies;

public class DeletedPersistentStrategy<T> : IDeletedStrategy where T : class
{
    private readonly DataBase<T> _dataBase;

    public DeletedPersistentStrategy(DataBase<T> dataBase)
    {
        _dataBase = dataBase;
    }

    public async Task Delete (int id)
    {
        await _dataBase.Delete(id);
    }
}
