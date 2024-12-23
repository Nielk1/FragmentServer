using System;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.ChatLobby
{
    public class LobbyExitResponse:BasePacket, IBaseResponse
    {
        public FragmentMessage Build()
        {
            return new FragmentMessage
            {
                MessageType = MessageType.Data,
                DataPacketType = OpCodes.DataLobbyExitRoomOk,
                Data = new Memory<byte>(new byte[2]),
            };
        }
    }
}
