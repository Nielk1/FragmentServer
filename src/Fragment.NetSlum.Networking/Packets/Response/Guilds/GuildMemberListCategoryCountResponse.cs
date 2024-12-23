using System;
using System.Buffers.Binary;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Guilds;

public class GuildMemberListCategoryCountResponse : BasePacket, IBaseResponse
{
    private readonly ushort _numEntries;

    public GuildMemberListCategoryCountResponse(ushort numEntries)
    {
        _numEntries = numEntries;
    }

    public FragmentMessage Build()
    {
        var buffer = new Memory<byte>(new byte[2]);
        BinaryPrimitives.WriteUInt16BigEndian(buffer.Span, _numEntries);

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataGuildMemberListCategoryCountResponse,
            Data = buffer,
        };
    }
}
