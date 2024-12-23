using Fragment.NetSlum.Core.Buffers;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Guilds;

public class GuildInvitationResultConfirmationResponse : BasePacket, IBaseResponse
{
    private readonly ushort _responseCode;

    public GuildInvitationResultConfirmationResponse(ushort responseCode)
    {
        _responseCode = responseCode;
    }
    public FragmentMessage Build()
    {
        var writer = new MemoryWriter(sizeof(ushort));
        writer.Write(_responseCode);

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataGuildInvitationConfirmationResponse,
            Data = writer.Buffer,
        };
    }
}
