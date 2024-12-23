using System.Collections.Generic;
using System.Threading.Tasks;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Response.Character;
using Fragment.NetSlum.Networking.Sessions;

namespace Fragment.NetSlum.Networking.Packets.Request.Character;

[FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.DataSelectCharRequest)]
public class SelectCharacterRequest : BasePacket, IBaseRequest
{
    public ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        return SingleMessage(new SelectCharacterResponse().Build());
    }
}
