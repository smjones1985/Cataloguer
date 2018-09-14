namespace DataAccessLayer
{
    public interface ISettingsManager
    {
        object Read();
        bool Save(object settings);
    }
}