using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fragment.NetSlum.Core.Buffers;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Response.Guilds;
using Fragment.NetSlum.Networking.Sessions;
using Fragment.NetSlum.Persistence;

namespace Fragment.NetSlum.Networking.Packets.Request.Guilds;

[FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.DataDonateCoinsToGuild)]
public class DonateCoinsToGuildRequest : BasePacket, IBaseRequest
{
    private readonly FragmentContext _database;

    public DonateCoinsToGuildRequest(FragmentContext database)
    {
        _database = database;
    }

    public ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        var reader = new SpanReader(request.Data.Span);

        var guildId = reader.ReadUInt16();
        var goldDonated = reader.ReadUInt16();
        var silverDonated = reader.ReadUInt16();
        var bronzeDonated = reader.ReadUInt16();

        var guildStats = _database.GuildStats
            .First(g => g.Id == guildId);

        guildStats.GoldAmount += goldDonated;
        guildStats.SilverAmount += silverDonated;
        guildStats.BronzeAmount += bronzeDonated;

        _database.SaveChanges();

        return SingleMessage(new DonateCoinsToGuildResponse(goldDonated, silverDonated, bronzeDonated).Build());
    }
}
