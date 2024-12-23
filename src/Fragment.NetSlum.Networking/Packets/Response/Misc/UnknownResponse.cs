using System;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Misc;

public class UnknownResponse : BasePacket, IBaseResponse
{
    private readonly OpCodes _packetType;
    private Memory<byte> _data = new Memory<byte>(new byte[2]);

    public UnknownResponse(OpCodes packetType)
    {
        _packetType = packetType;
    }

    public UnknownResponse SetData(Memory<byte> data)
    {
        _data = data;

        return this;
    }

    public FragmentMessage Build()
    {
        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = _packetType,
            Data = _data,
        };
    }
}
