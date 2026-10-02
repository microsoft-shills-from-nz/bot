using System.Reflection;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;

public class Bot
{
    private DiscordSocketClient? client;
    public static InteractionService? interactions;

    public async Task Run()
    {
        client = new DiscordSocketClient(new DiscordSocketConfig()
        {
            GatewayIntents = GatewayIntents.All
        });

        interactions = new InteractionService(client);
        await interactions.AddModulesAsync(Assembly.GetEntryAssembly(), null);
        
        client.Log += message =>
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        };

        client.Ready += async () =>
        {
            await interactions.RegisterCommandsGloballyAsync();
        };

        client.InteractionCreated += async (interaction) =>
        {
            var context = new SocketInteractionContext(client, interaction);
            await interactions.ExecuteCommandAsync(context, null);
        };

        await client.LoginAsync(TokenType.Bot, File.ReadAllText("token.txt"));
        await client.StartAsync();

        await Task.Delay(-1);
    }
}