namespace Warden.Services.Stats.Modules
{
    public class HomeModule : ModuleBase
    {
        public HomeModule()
        {
            Get("", args => "Welcome to the Warden.Services.Stats API!");
        }
    }
}