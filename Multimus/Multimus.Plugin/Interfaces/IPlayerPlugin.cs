using System;
using System.Collections.Generic;
using System.Text;


namespace Multimus.Plugin
{
    public enum PluginAnswerType
    {
        NotSupported,
        Repoll,
        Play
    }
    public interface IPlayerPlugin
    {
        Tuple<PluginAnswerType, Object> resolve(string media);
    }
}
