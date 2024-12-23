using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Fragment.NetSlum.Core.Extensions;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Response;
using Fragment.NetSlum.Networking.Sessions;
using Microsoft.Extensions.Logging;
using Fragment.NetSlum.Networking.Packets.Response.AreaServer;
using Fragment.NetSlum.TcpServer.Extensions;

namespace Fragment.NetSlum.Networking.Packets.Request.AreaServer;

[FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.Data_AreaServerDateTimeRequest)]
public class AreaServerDateTimeRequest : BasePacket, IBaseRequest
{
    private readonly ILogger<AreaServerIPAddressPortRequest> _logger;

    public AreaServerDateTimeRequest(ILogger<AreaServerIPAddressPortRequest> logger)
    {
        _logger = logger;
    }

    public ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        IBaseResponse response = new AreaServerDateTimeResponse();
        return SingleMessage(response.Build());
    }
}
