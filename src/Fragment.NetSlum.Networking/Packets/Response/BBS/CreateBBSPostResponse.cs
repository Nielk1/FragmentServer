using System;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.BBS;

public class CreateBBSPostResponse : BasePacket, IBaseResponse
{
    public FragmentMessage Build() => new FragmentMessage
    {
        MessageType = MessageType.Data,
        DataPacketType = OpCodes.DataBbsCreatePostResponse,
        Data = new Memory<byte>(new byte[2]),
    };
}
