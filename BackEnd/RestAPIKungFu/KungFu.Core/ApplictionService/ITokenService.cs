namespace KungFu.Core.ApplictionService
{
    public interface ITokenService
    {
        string getRefreshToken(string username);

        void SaveRefreshToken(string user, string refreshToSave);
    }
}