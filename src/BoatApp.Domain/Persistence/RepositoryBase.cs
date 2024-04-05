namespace BoatApp.Domain.Persistence;

public class RepositoryBase
{
    protected IMobileDatabase DB;

    public RepositoryBase(IMobileDatabase db)
    {
        DB = db;
    }
}
