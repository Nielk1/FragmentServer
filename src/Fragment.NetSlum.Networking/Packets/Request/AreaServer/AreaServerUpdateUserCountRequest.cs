using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Sessions;
using Microsoft.Extensions.Logging;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;

namespace Fragment.NetSlum.Networking.Packets.Request.AreaServer;

[FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.Data_AreaServerUpdateUserCountRequest)]
public class AreaServerUpdateUserCountRequest :BasePacket, IBaseRequest
{
    private readonly ILogger<AreaServerUpdateUserCountRequest> _logger;

    public AreaServerUpdateUserCountRequest(ILogger<AreaServerUpdateUserCountRequest> logger)
    {
        _logger = logger;
    }

    public ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        session.AreaServerInfo!.CurrentPlayerCount = BinaryPrimitives.ReadUInt16BigEndian(request.Data[2..4].ToArray());
        return NoResponse();
    }
}
