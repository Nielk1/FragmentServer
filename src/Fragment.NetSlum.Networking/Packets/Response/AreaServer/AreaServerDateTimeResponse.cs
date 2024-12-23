using Fragment.NetSlum.Core.Buffers;
using Fragment.NetSlum.Core.Extensions;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using System;

namespace Fragment.NetSlum.Networking.Packets.Response.AreaServer;

public class AreaServerDateTimeResponse : BasePacket, IBaseResponse
{
    public FragmentMessage Build()
    {
        var writer = new MemoryWriter(8);
        writer.Write((uint)0);
        writer.Write((uint)DateTime.UtcNow.ToEpoch());

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.Data_AreaServerDateTimeSuccess,
            Data = writer.Buffer,
        };
    }
}
