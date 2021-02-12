namespace Base.Core.Util
{
    public interface ICryptography
    {
        string Decrypt(string text);
        string Encrypt(string text);
    }
}
