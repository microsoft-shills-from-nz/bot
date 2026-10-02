using Discord;
using Discord.Interactions;

public class PingCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("ping", "ping command")]
    public async Task Ping()
    {
        await RespondAsync("Pong!");
    }
}