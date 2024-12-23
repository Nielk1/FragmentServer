using System;
using System.Buffers.Binary;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Guilds;

public class ShoppableGuildEntryCountResponse : BasePacket, IBaseResponse
{
    private readonly ushort _numCategories;

    public ShoppableGuildEntryCountResponse(ushort numCategories)
    {
        _numCategories = numCategories;
    }

    public FragmentMessage Build()
    {
        var buffer = new Memory<byte>(new byte[2]);
        BinaryPrimitives.WriteUInt16BigEndian(buffer.Span, _numCategories);

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.ShoppableGuildEntryCountResponse,
            Data = buffer,
        };
    }
}
