using System;
using System.Buffers.Binary;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.ChatLobby;

public class LobbyServerCategoryCountResponse : BasePacket, IBaseResponse
{
    private readonly ushort _count;

    public LobbyServerCategoryCountResponse(ushort count)
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
            DataPacketType = OpCodes.DataLobbyGetServersCategoryList,
            Data = buffer,
        };
    }
}
