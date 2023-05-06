using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Character;

public class SelectCharacterResponse : BaseResponse
{
    public override FragmentMessage Build()
    {
        return new FragmentMessage
        {
            OpCode = OpCodes.Data,
            DataPacketType = OpCodes.DataSelectCharSuccess,
            Data = new Memory<byte>(new byte[2]),
        };
    }
}
