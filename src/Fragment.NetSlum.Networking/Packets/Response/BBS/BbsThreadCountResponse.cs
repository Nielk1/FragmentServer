using System;
using System.Buffers.Binary;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.BBS;

public class BbsThreadCountResponse : BasePacket, IBaseResponse
{
    private readonly ushort _numEntries;

    public BbsThreadCountResponse(ushort numEntries)
    {
        _numEntries = numEntries;
    }

    public FragmentMessage Build()
    {
        var buffer = new Memory<byte>(new byte[2]);
        BinaryPrimitives.WriteUInt16BigEndian(buffer.Span, _numEntries);

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataBbsThreadCountResponse,
            Data = buffer,
        };
    }
}
