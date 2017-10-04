namespace Elf.Core.Providers
{
    public interface IClientInfoProvider
    {
        string BrowserInfo { get; }

        string ClientIpAddress { get; }
    }
}
