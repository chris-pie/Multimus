using System;
using System.Collections.Generic;
using System.Text;
using Multimus.Plugin;

namespace Multimus
{
    class PluginSettings
    {
        private readonly IPlayerPlugin _plugin;

        public IPlayerPlugin Plugin => _plugin;
        public PluginSettings(IPlayerPlugin plugin)
        {
            _plugin = plugin;
        }
        public Tuple<PluginAnswerType, Object> ResolvePoll(string media)
        {
            //TODO: implement chaining
            return Plugin.resolve(media);
        }
    }
}
