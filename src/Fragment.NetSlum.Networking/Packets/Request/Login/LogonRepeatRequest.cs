using System.Collections.Generic;
using System.Threading.Tasks;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Response.Login;
using Fragment.NetSlum.Networking.Packets.Response;
using Fragment.NetSlum.Networking.Sessions;
using Microsoft.Extensions.Logging;

namespace Fragment.NetSlum.Networking.Packets.Request.Login;

[FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.DataLogonRepeatRequest)]
public class LogonRepeatRequest :BaseRequest
{
    private readonly ILogger<LogonRepeatRequest> _logger;

    public LogonRepeatRequest(ILogger<LogonRepeatRequest> logger)
    {
        _logger = logger;
    }

    public override ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        BaseResponse response = new LogonRepeatResponse();

        return SingleMessage(response.Build());
    }
}
