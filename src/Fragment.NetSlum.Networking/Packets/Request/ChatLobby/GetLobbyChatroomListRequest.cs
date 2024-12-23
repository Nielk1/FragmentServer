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

namespace Fragment.NetSlum.Networking.Packets.Request.ChatLobby
{
    [FragmentPacket(ServerType.Lobby, MessageType.Data, OpCodes.DataGetLobbyChatroomListRequest)]
    public class GetLobbyChatroomListRequest : BasePacket, IBaseRequest
    {
        private readonly ILogger<GetLobbyChatroomListRequest> _logger;
        private readonly ChatLobbyStore _chatLobbyStore;

        public GetLobbyChatroomListRequest(ILogger<GetLobbyChatroomListRequest> logger, ChatLobbyStore chatLobbyStore)
        {
            _logger = logger;
            _chatLobbyStore = chatLobbyStore;
        }

        public ValueTask<ICollection<FragmentMessage>> GetResponse(FragmentTcpSession session, FragmentMessage request)
        {
            // If no default lobby was found, attempt to look up by guild
            var gameLobby = _chatLobbyStore.GetLobbyBySession(session, ChatLobbyType.Default) ?? _chatLobbyStore.GetLobbyBySession(session, ChatLobbyType.Guild);

            var availableLobbies = _chatLobbyStore.GetLobbiesByType(ChatLobbyType.Chatroom)
                .Where(l => l.ParentChatLobby == gameLobby)
                .ToList();

            var responses = new List<FragmentMessage>();

            responses.Add(new LobbyChatroomCategoryCountResponse((ushort)(availableLobbies.Count + 1)).Build());

            responses.Add(
                new LobbyChatroomCategoryEntryResponse()
                    .SetCategoryName("-- Create New --")
                    .SetIsCreationEntry(true)
                    .Build());

            foreach (var lobby in availableLobbies)
            {
                responses.Add(
                    new LobbyChatroomCategoryEntryResponse()
                        .SetCategoryId(lobby.LobbyId)
                        .SetCategoryName(lobby.LobbyName)
                        .SetCurrentPlayerCount(lobby.PlayerCount)
                        .SetPasswordRequired(!string.IsNullOrWhiteSpace(lobby.Password))
                        .Build());
            }

            return ValueTask.FromResult<ICollection<FragmentMessage>>(responses);
        }
    }
}
