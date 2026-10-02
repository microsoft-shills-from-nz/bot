using Discord;
using Discord.Interactions;

public class PingCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("help", "help command")]
    public async Task Ping()
    {
        await RespondAsync("Commands:\n/help: lists commands\n/ping: replies with pong\n/ban <user>: banns a user from the server\n/banana: shows a banana\n/template <name> <image> <textBox> <textBoxPosition>: creates a template meme\n/create <templateName> <textBoxText>: creates a meme from a template\n");
    }
}