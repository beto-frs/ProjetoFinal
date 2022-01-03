namespace Destino_Certo.Crypto
{
    public interface ICrypto
    {
        string Encrypt(string Senha);

        string Decrypt(string Senha);
    }
}
