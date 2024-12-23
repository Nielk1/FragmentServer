using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Fragment.NetSlum.Networking.Constants;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Sessions;
using Serilog;

namespace Fragment.NetSlum.Networking.Packets;

public abstract class BasePacket
{
    public ILogger Log => Serilog.Log.ForContext(GetType());



    /// <summary>
    /// Helper method to return a single message from a request handler
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    protected static ValueTask<ICollection<FragmentMessage>> SingleMessage(FragmentMessage response) =>
        ValueTask.FromResult(SingleMessageAsync(response));

    protected static ICollection<FragmentMessage> SingleMessageAsync(FragmentMessage response) =>
        new[] { response };

    protected static ValueTask<ICollection<FragmentMessage>> NoResponse() =>
        ValueTask.FromResult<ICollection<FragmentMessage>>(Array.Empty<FragmentMessage>());



    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public FragmentMessage Build(MessageType type, byte[] payload)
    {
        return new FragmentMessage
        {
            Data = payload,
            MessageType = type,
        };
    }
}
