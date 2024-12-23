using System;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;


namespace Fragment.NetSlum.Networking.Packets.Response.AreaServer;

public class AreaServerPublishDetailsResponse :BasePacket, IBaseResponse
{
    public OpCodes PacketType { get; set; }
    public byte[] Data { get; set; } = [];

    public FragmentMessage Build()
    {
        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = PacketType,
            Data = Data,
        };
    }
}
