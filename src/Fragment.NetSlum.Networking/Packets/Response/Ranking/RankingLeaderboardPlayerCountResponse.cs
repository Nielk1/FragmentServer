using System;
using System.Buffers.Binary;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Ranking;

public class RankingLeaderboardPlayerCountResponse : BasePacket, IBaseResponse
{
    private readonly uint _numEntries;

    public RankingLeaderboardPlayerCountResponse(uint numEntries)
    {
        _numEntries = numEntries;
    }

    public FragmentMessage Build()
    {
        var buffer = new Memory<byte>(new byte[4]);
        BinaryPrimitives.WriteUInt32BigEndian(buffer.Span, _numEntries);

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.RankingLeaderboardPlayerCountResponse,
            Data = buffer,
        };
    }
}
