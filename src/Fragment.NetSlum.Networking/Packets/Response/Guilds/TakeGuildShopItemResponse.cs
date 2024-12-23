using System;
using System.Buffers.Binary;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Guilds;

public class TakeGuildShopItemResponse : BasePacket, IBaseResponse
{
    private readonly ushort _quantityTaken;

    public TakeGuildShopItemResponse(ushort quantityTaken)
    {
        _quantityTaken = quantityTaken;
    }

    public FragmentMessage Build()
    {
        var buffer = new Memory<byte>(new byte[2]);
        BinaryPrimitives.WriteUInt16BigEndian(buffer.Span, _quantityTaken);

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataTakeGuildShopItemResponse,
            Data = buffer,
        };
    }
}
