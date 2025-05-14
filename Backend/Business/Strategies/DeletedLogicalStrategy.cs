using Data.Core;

namespace Business.Strategies;

public class DeletedLogicalStrategy<T> : IDeletedStrategy where T : class
{
    private readonly DataBase<T> _dataBase;

    public DeletedLogicalStrategy(DataBase<T> dataBase)
    {
        _dataBase = dataBase;
    }

    public async Task Delete (int id)
    {
        await _dataBase.DeleteLogical(id);
    }

}
