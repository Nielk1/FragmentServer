using System;
using System.Buffers.Binary;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Articles;

public class NewsCategoryCountResponse : BasePacket, IBaseResponse
{
    private readonly ushort _count;

    public NewsCategoryCountResponse(ushort count)
    {
        _count = count;
    }

    public FragmentMessage Build()
    {
        var buffer = new Memory<byte>(new byte[2]);
        BinaryPrimitives.WriteUInt16BigEndian(buffer.Span, _count);

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataNewsCategoryList,
            Data = buffer,
        };
    }
}
