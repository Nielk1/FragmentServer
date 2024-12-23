using System.Linq;
using Fragment.NetSlum.Networking.Attributes;
using Fragment.NetSlum.Networking.Messaging;
using Fragment.NetSlum.Networking.Objects;
using Fragment.NetSlum.Networking.Packets.Request;
using Fragment.NetSlum.Networking.Pipeline;
using Fragment.NetSlum.Networking.Pipeline.Builder;
using Fragment.NetSlum.Networking.Pipeline.Decoders;
using Fragment.NetSlum.Networking.Sessions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Fragment.NetSlum.Networking.Crypto;
using Fragment.NetSlum.Networking.Pipeline.Encoders;
using Serilog;
using Fragment.NetSlum.Networking.Constants;

namespace Fragment.NetSlum.Networking.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddPacketHandling(this IServiceCollection services, ServerType serverType)
    {
        var asm = typeof(BaseRequest).Assembly.GetTypes()
            .Where(a => typeof(BaseRequest).IsAssignableFrom(a) && a.IsClass && !a.IsAbstract);

        var cache = new PacketCache();

        int totalPackets = 0;
        foreach (var a in asm)
        {
            var mediusMessages = a.GetCustomAttributes<FragmentPacket>();

            foreach (var m in mediusMessages)
            {
                if ((m.ServerType & serverType) != 0)
                {
                    cache.AddRequest(m, a);
                    totalPackets++;
                }
            }

            // Was transient, but switching to scoped to reduce DI and memory overhead.
            // Might need to change this back if it introduces side-effects
            services.AddScoped(a);

            Log.Verbose(cache.ToString());
        }
        Log.Information("Registered {Count} packets into cache", totalPackets);

        services.AddSingleton(cache);
        services.AddScoped<CryptoHandler>();

        services.AddPacketPipeline()
            .AddDecoder<FragmentFrameDecoder>()
            .AddEncoder<DataTypeEnvelopeEncoder>()
            .AddEncoder<EncryptionEncoder>()
            .UsePacketHandler<FragmentMessage, FragmentPacketHandler>()
            .AddSessionPipeline<FragmentPacketPipeline<FragmentTcpSession>>();
    }
}
