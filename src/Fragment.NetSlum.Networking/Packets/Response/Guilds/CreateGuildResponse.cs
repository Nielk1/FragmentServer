using System;
using System.Buffers.Binary;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Guilds;

public class CreateGuildResponse : BasePacket, IBaseResponse
{
    private readonly ushort _guildId;

    public CreateGuildResponse(ushort guildId)
    {
        _guildId = guildId;
    }

    public FragmentMessage Build()
    {
        var buffer = new Memory<byte>(new byte[2]);
        BinaryPrimitives.WriteUInt16BigEndian(buffer.Span, _guildId);

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataCreateGuildSuccessResponse,
            Data = buffer,
        };
    }
}
