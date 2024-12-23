using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fragment.NetSlum.Core.Constants;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Response.ChatLobby;
using Fragment.NetSlum.Networking.Sessions;
using Fragment.NetSlum.Networking.Stores;
using Microsoft.Extensions.Logging;

namespace Fragment.NetSlum.Networking.Packets.Request.ChatLobby;

[FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.DataLobbyGetMenuRequest)]
public class ChatLobbyGetMenuRequest : BasePacket, IBaseRequest
{
    private readonly ILogger<ChatLobbyGetMenuRequest> _logger;
    private readonly ChatLobbyStore _chatLobbyStore;

    public ChatLobbyGetMenuRequest(ILogger<ChatLobbyGetMenuRequest> logger, ChatLobbyStore chatLobbyStore)
    {
        _logger = logger;
        _chatLobbyStore = chatLobbyStore;
    }

    public ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
    {
        //var channels = _database.ChatLobbies.Where(c => c.DefaultChannel == true).ToList();
        var lobbies = _chatLobbyStore.GetLobbiesByType(ChatLobbyType.Default);
        var responses = new List<FragmentMessage>
        {
            //Add the ChatLobby count response to the collection list
            new ChatLobbyCountResponse()
                .SetChatLobbyCount((ushort)lobbies.Length)
                .Build(),
        };

        //Build the Chat Lobby List
        responses.AddRange(lobbies.Select(c =>
        {
            // Include counts of all players that may be in chat lobbies within this server lobby
            var childLobbyPlayerCount = _chatLobbyStore.GetLobbiesByType(ChatLobbyType.Chatroom)
                .Where(cl => cl.ParentChatLobby == c)
                .Sum(cl => cl.PlayerCount);

            return new ChatLobbyEntryResponse()
                .SetChatLobbyName(c.LobbyName)
                .SetChatLobbyId(c.LobbyId)
                .SetClientCount((ushort)(c.PlayerCount + childLobbyPlayerCount))
                .Build();
        }));

        return ValueTask.FromResult<ICollection<FragmentMessage>>(responses);
    }
}
