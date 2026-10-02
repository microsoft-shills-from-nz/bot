using Discord;
using Discord.Interactions;

public class PingCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("banana", "banana command")]
    public async Task Ping()
    {
        await RespondAsync("https://banana.malcolmjh.com/image.png");
    }
}