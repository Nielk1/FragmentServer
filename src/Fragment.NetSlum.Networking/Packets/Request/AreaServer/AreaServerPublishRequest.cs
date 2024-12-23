using System.Collections.Generic;
using System.Threading.Tasks;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Response;
using Fragment.NetSlum.Networking.Sessions;
using Microsoft.Extensions.Logging;
using Fragment.NetSlum.Networking.Packets.Response.AreaServer;

namespace Fragment.NetSlum.Networking.Packets.Request.AreaServer;

[FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.Data_AreaServerPublishRequest)]
public class AreaServerPublishRequest :BasePacket, IBaseRequest
{
    private readonly ILogger<AreaServerPublishRequest> _logger;

    public AreaServerPublishRequest(ILogger<AreaServerPublishRequest> logger)
    {
        _logger = logger;
    }

    public ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        IBaseResponse response = new AreaServerPublishResponse();
        return SingleMessage(response.Build());
    }
}
