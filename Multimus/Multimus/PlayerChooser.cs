using System.Collections.Generic;
using Multimus.Plugin;


namespace Multimus
{

    static class PlayerChooser
    {
        public static void Init(List<IPlayerPlugin> plugins)
        {
            playerPlugins = plugins;
        }
        static List<IPlayerPlugin> playerPlugins;
        public static IMediaPlayer ChoosePlayer(string media)
        {
        loop:
            foreach (var plugin in playerPlugins)
            {
                var response = plugin.resolve(media);
                if (response.Item1 == PluginAnswerType.Repoll)
                {
                    media = (string)response.Item2;
                    goto loop;
                }
                if (response.Item1 == PluginAnswerType.Play)
                {
                    return (IMediaPlayer)response.Item2;
                }
            }
            return null;
        }
    }
}
