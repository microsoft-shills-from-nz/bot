using Discord;
using Discord.Interactions;

public class PingCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("test", "test command")]
    public async Task Ping()
    {
        await RespondAsync("https://klipy.com/gifs/theres-no-limit-to-the-larp-flight");
    }
}