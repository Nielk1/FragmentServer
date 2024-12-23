using Fragment.NetSlum.TcpServer.Options;

namespace Fragment.NetSlum.AreaServer.Servers;

public class ServerConfiguration : TcpServerOptions
{
    public new bool ManualMode { get; set; } = true;
    public int TickRate { get; set; } = 30;
}
