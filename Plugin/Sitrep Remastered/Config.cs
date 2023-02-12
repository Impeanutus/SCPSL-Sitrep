using Exiled.API.Interfaces;

namespace Sitrep_Remastered
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = true;

        public string ip { get; set; } = "http://127.0.0.1:6868";
    }
}
