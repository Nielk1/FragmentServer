using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Sessions;
using Microsoft.Extensions.Logging;
using System.Buffers.Binary;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;

namespace Fragment.NetSlum.Networking.Packets.Request.AreaServer;

[FragmentPacket(OpCodes.Data, OpCodes.Data_AreaServerUpdateUserCountRequest)]
public class AreaServerUpdateUserCountRequest :BaseRequest
{
    private readonly ILogger<AreaServerUpdateUserCountRequest> _logger;

    public AreaServerUpdateUserCountRequest(ILogger<AreaServerUpdateUserCountRequest> logger)
    {
        _logger = logger;
    }

    public override Task<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        session.AreaServerPlayerCount = BinaryPrimitives.ReadUInt16BigEndian(request.Data[2..4].ToArray());
        return Task.FromResult<ICollection<FragmentMessage>>(Array.Empty<FragmentMessage>());
    }
}