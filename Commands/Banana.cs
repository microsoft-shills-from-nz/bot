using Discord;
using Discord.Interactions;

public class BananaCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("banana", "banana command")]
    public async Task Banana()
    {
        await RespondAsync("https://banana.malcolmjh.com/image.png");
    }
}