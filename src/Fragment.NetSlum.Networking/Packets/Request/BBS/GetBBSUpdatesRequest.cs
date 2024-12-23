using System.Collections.Generic;
using System.Threading.Tasks;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Response;
using Fragment.NetSlum.Networking.Sessions;
using Microsoft.Extensions.Logging;
using Fragment.NetSlum.Networking.Packets.Response.BBS;

namespace Fragment.NetSlum.Networking.Packets.Request.BBS;

[FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.DataBBSGetUpdatesRequestRequest)]
public class GetBBSUpdatesRequest:BasePacket, IBaseRequest
{
    private readonly ILogger<GetBBSUpdatesRequest> _logger;

    public GetBBSUpdatesRequest(ILogger<GetBBSUpdatesRequest> logger)
    {
        _logger = logger;
    }

    public ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        IBaseResponse response = new GetBBSUpdatesResponse();

        return SingleMessage(response.Build());
    }
}
