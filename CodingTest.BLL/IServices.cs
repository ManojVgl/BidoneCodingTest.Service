namespace CodingTest.BLL
{
    public interface IServices<out T>
    {
        T Service { get; }
    }
}
