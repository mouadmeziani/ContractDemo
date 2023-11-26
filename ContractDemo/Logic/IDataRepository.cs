public interface IDataRepository
{
    IEnumerable<String> LoadData(string source);
}