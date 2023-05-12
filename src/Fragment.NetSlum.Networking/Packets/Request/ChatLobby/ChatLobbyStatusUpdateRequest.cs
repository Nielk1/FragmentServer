using System.Data;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Response.ChatLobby;
using Fragment.NetSlum.Networking.Sessions;
using Fragment.NetSlum.Networking.Stores;
using Microsoft.Extensions.Logging;

namespace Fragment.NetSlum.Networking.Packets.Request.ChatLobby;

[FragmentPacket(OpCodes.Data, OpCodes.DataLobbyStatusUpdate)]
public class ChatLobbyStatusUpdateRequest:BaseRequest
{
    private readonly ILogger<ChatLobbyStatusUpdateRequest> _logger;
    private readonly ChatLobbyStore _chatLobbyStore;
    public ChatLobbyStatusUpdateRequest(ILogger<ChatLobbyStatusUpdateRequest> logger, ChatLobbyStore chatLobbyStore)
    {
        _logger = logger;
        _chatLobbyStore = chatLobbyStore;
    }

    public override Task<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        var cl = _chatLobbyStore.GetLobbyBySession(session);

        var myChatLobbyPlayer = cl?.GetPlayerByAccountId(session.PlayerAccountId);

        if (cl == null || myChatLobbyPlayer == null)
        {
            throw new DataException("Invalid chat room or player not found");
        }

        ushort clientCount = cl.PlayerCount;
        var response = new ChatLobbyEnterRoomResponse().SetClientCount((ushort)clientCount).Build();

        //We have to send out a status update to all clients in this chat room but I don't understand where that comes from?
        cl.NotifyAllExcept(myChatLobbyPlayer, new ChatLobbyStatusUpdateResponse()
            .SetLastStatus(session.LastStatus)
            .Build());

        return Task.FromResult<ICollection<FragmentMessage>>(new[] { response });
    }
}
