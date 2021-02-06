using System.Collections.Generic;
using Multimus.Plugin;


namespace Multimus
{

    static class PlayerChooser
    {
        private const int maxRepolls = 1;
        public static void Init(List<PluginSettings> plugins)
        {
            playerPlugins = plugins;
        }
        static List<PluginSettings> playerPlugins;
        public static IMediaPlayer ChoosePlayer(string media)
        {
            int repolls = 0;
        loop:
            foreach (var plugin in playerPlugins)
            {
                var response = plugin.ResolvePoll(media);
                if (response.Item1 == PluginAnswerType.Repoll)
                {
                    if (repolls < maxRepolls)
                    {
                        media = (string)response.Item2;
                        repolls += 1;
                        goto loop;
                    }
                }
                if (response.Item1 == PluginAnswerType.Play)
                {
                    return (IMediaPlayer)response.Item2;
                }
            }
            return new NullPlayer();
        }
    }
}
