using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Login;

public class AreaServerDiskAuthorizationResponse : BasePacket, IBaseResponse
{
    public FragmentMessage Build()
    {
        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.Data_AreaServerDiskAuthorizationSuccess,
            Data = new byte[] { 0x00, 0x00 },
        };
    }
}
