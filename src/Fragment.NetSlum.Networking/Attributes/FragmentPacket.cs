using System;
using Fragment.NetSlum.Networking.Constants;

namespace Fragment.NetSlum.Networking.Attributes;

[AttributeUsage(AttributeTargets.Struct|AttributeTargets.Class, AllowMultiple = true)]
public class FragmentPacket : Attribute
{
    public readonly ServerType ServerType;
    public readonly MessageType MessageType;
    public readonly OpCodes DataPacketType;

    public FragmentPacket(ServerType serverType, MessageType messageType)
    {
        ServerType = serverType;
        MessageType = messageType;
        DataPacketType = OpCodes.None;
    }

    public FragmentPacket(ServerType serverType, MessageType messageType, OpCodes dataPacketType)
    {
        ServerType = serverType;
        MessageType = messageType;
        DataPacketType = dataPacketType;
    }
}
