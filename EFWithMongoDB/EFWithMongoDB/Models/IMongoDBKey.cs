namespace EFWithMongoDB.Models
{
    public interface IKey<TKey>
    {
        TKey Id { get; set; }
    }
}
