using Discord;
using Discord.Interactions;

public class HelpCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("help", "help command")]
    public async Task Help()
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
        Embed embed = new EmbedBuilder()
            .WithTitle("Commands")
            .WithDescription("""
`/help`: lists commands
`/ping`: replies with pong
`/ban <user>`: banns a user from the server
`/banana`: shows a banana
`/template <name> <image> <textBox> <textBoxPosition>`: creates a template meme
`/create <templateName> <textBoxText>`: creates a meme from a template
""")
            .Build();
        await ModifyOriginalResponseAsync(msg => {
            msg.Content = string.Empty;
            msg.Embed = embed;
        });
    }
}