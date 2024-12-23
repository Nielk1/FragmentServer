using System;
using Fragment.NetSlum.Core.Buffers;
using Fragment.NetSlum.Core.Extensions;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Mail;

public class MailContentResponse : BasePacket, IBaseResponse
{
    private string _content = "";
    private string _avatarDescriptor = "";

    public MailContentResponse SetContent(string content)
    {
        _content = content;

        return this;
    }

    public MailContentResponse SetAvatarDescriptor(string desc)
    {
        _avatarDescriptor = desc;

        return this;
    }

    public FragmentMessage Build()
    {
        var contentBytes = _content.ToShiftJis(false).EnsureSize(1200);
        var avatarBytes = _avatarDescriptor.ToShiftJis(false).EnsureSize(130);

        var writer = new MemoryWriter(contentBytes.Length +
                                      avatarBytes.Length +
                                      sizeof(ushort) * 2 +
                                      sizeof(uint)
        );

        var foo = new Span<byte>(new byte[130]);
        foo[2] = 0x20;

        writer.Write((byte)5);
        writer.Skip(3);
        writer.Write((ushort)0);
        writer.Write(contentBytes);
        writer.Write((ushort)0);
        writer.Write(foo);

        return new FragmentMessage
        {
            MessageType = MessageType.Data,
            DataPacketType = OpCodes.DataGetMailContentResponse,
            Data = writer.Buffer,
        };
    }
}
