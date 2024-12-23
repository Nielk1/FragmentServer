using System;
using System.IO;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Extensions;
using Fragment.NetSlum.Networking.Objects;

namespace Fragment.NetSlum.Networking.Packets.Response.Security;

public class KeyExchangeResponse : BasePacket, IBaseResponse
{
    private readonly Memory<byte> _clientKey = new byte[16];
    private readonly Memory<byte> _serverKey = new byte[16];

    public KeyExchangeResponse SetClientKey(Memory<byte> key)
    {
        _clientKey.Replace(key);

        return this;
    }

    public KeyExchangeResponse SetServerKey(Memory<byte> key)
    {
        _serverKey.Replace(key);

        return this;
    }

    public FragmentMessage Build()
    {
        using var buffer = new MemoryStream();

        buffer.WriteByte(0);
        buffer.WriteByte(0x10);
        buffer.Write(_clientKey.Span);
        buffer.WriteByte(0);
        buffer.WriteByte(0x10);
        buffer.Write(_serverKey.Span);
        buffer.Write(new byte[] { 0, 0, 0, 0xe, 0, 0, 0, 0, 0, 0 });

        return base.Build(MessageType.KeyExchangeResponse, buffer.ToArray());
    }
}
