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

    private static string[] RandomMessages = [
        "Spinning up 500 subagents...",
        "Sorting through a million db entries...",
        "Harvesting API keys from GitHub...",
        "Scrolling Instagram Reels...",
        "Selling user data...",
        "Installing 10GB worth of node libraries...",
        "Asking Grok...",
        "Initiating 10 Cloudflare workers on a Canadian edge node...",
        "Preparing divorce paperwork...",
        "Using Niko's phone as spare compute power...",
        "Taking down a Cloudflare edge node...",
        "Un-solving world hunger...",
        "Consulting the heavens...",
        "Gone fishing...",
        "Splitting into 30 microservices...",
        "Avoiding empl*yment...",
        "Adding user's profile information to model training data...",
        "NullPointerException",
        "Creating personalised ad experience...",
        "Provisioning ten thousand VPSs across 6 data centers...",
        "Installing League of Legends...",
        "Rerouting request through Google Ad Services...",
        "Stealing session token...",
        "Larping as a Linux user...",
        "Requesting administrator role...",
        "# Requesting a smaller font size...",
        "-# Requesting a larger font size...",
        "Fixing Malcolm's speech problems..."
    ];

    public static string GetARandomMessage() =>
        RandomMessages[new Random().Next(0, RandomMessages.Length)];
}