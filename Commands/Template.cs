using Discord;
using Discord.Interactions;

public enum TextboxPosition { Top, Bottom }

public class TemplateCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("template", "Generate a template")]
    public async Task Template(IAttachment image, TextboxPosition textboxPos)
    {
        await DeferAsync();
        
    }
}