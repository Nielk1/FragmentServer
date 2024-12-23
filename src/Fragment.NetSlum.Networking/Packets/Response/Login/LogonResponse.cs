using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Login;

public class LogonResponse : BasePacket, IBaseResponse
{
    public FragmentMessage Build()
    {
        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataLogonResponse,
            Data = new byte[] { 0x74, 0x32 } // Represents "t2" in UTF8?
        };
    }
}
