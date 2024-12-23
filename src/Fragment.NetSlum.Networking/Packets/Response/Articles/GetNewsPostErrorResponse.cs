using System;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Articles;

public class GetNewsPostErrorResponse : BasePacket, IBaseResponse
{
    public FragmentMessage Build()
    {
        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataNewsPostErrorResponse,
            Data = new Memory<byte>(new byte[2]),
        };
    }
}
