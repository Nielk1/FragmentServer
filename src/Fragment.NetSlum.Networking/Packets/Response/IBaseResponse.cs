using System.Runtime.CompilerServices;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Serilog;

namespace Fragment.NetSlum.Networking.Packets.Response;

public interface IBaseResponse
{
    //public ILogger Log => Serilog.Log.ForContext(GetType());

    public FragmentMessage Build();
}
