using System;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using System.Buffers.Binary;

namespace Fragment.NetSlum.Networking.Packets.Response.ChatLobby;

public class ChatLobbyCountResponse:BasePacket, IBaseResponse
{
    private ushort _chatLobbyCount;
    public ChatLobbyCountResponse SetChatLobbyCount(ushort count)
    {
        _chatLobbyCount = count;

        return this;
    }


    public FragmentMessage Build()
    {
        var buffer = new Memory<byte>(new byte[2]);
        var bufferSpan = buffer.Span;

        BinaryPrimitives.WriteUInt16BigEndian(bufferSpan[0..], _chatLobbyCount);
        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataLobbyLobbyList,
            Data =buffer,
        };
    }
}
