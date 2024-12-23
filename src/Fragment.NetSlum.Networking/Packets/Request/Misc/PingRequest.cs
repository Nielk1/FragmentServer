using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Response;
using Fragment.NetSlum.Networking.Packets.Response.Misc;
using Fragment.NetSlum.Networking.Sessions;

namespace Fragment.NetSlum.Networking.Packets.Request.Misc;

[FragmentPacket(ServerType.Lobby, MessageType.PingRequest)]
[FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.DataPing)]
public class PingRequest : BaseRequest
{
    public override ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        session.LastContacted = DateTime.UtcNow;

        BaseResponse response = new PingResponse();

        return SingleMessage(response.Build());

    }
}
