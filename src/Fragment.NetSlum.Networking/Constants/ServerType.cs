using System;

namespace Fragment.NetSlum.Networking.Constants;

[Flags]
public enum ServerType
{
    Lobby = 0x01,
    Area = 0x02,
}
