using Discord;
using Discord.Interactions;

public class PingCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("ping", "ping command")]
    public async Task Ping()
    {
        await RespondAsync(Bot.GetARandomMessage());
        for (int i = 0; i < 3; i++)
        {
            await Task.Delay(3000);
            await ModifyOriginalResponseAsync(msg => {
                msg.Content = Bot.GetARandomMessage();
            });
        }
        await Task.Delay(3000);

        if (new Random().Next(0, 2) == 0)
        {
            await ModifyOriginalResponseAsync(msg => {
                msg.Content = "Pong!";
            });
        }
        else
        {
            await ModifyOriginalResponseAsync(msg => {
                msg.Content = "Something went wrong. Please try again later.";
            });
        }
    }
}