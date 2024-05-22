namespace ST.Application.Commons.Abstractions
{
    public interface IPasswordHasher
    {
        (string, string) HashPassword(string password);
    }
}