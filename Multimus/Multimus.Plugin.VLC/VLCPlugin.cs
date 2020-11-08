using System;
using System.Threading;
using LibVLCSharp.Shared;
using Multimus.Plugin;

namespace Multimus.Plugin.VLC
{
    public class VLCPlugin : IPlayerPlugin
    {
        private LibVLC libvlc;
        public VLCPlugin()
        {
            Core.Initialize();
            libvlc = new LibVLC();
            
        }
        ~VLCPlugin()
        {
            libvlc.Dispose();
        }

        public Tuple<PluginAnswerType, object> resolve(string media)
        {
            var vlcmedia = new Media(libvlc, media, FromType.FromLocation);
            var player = new VLCMediaPlayer(libvlc);
            player.Media = vlcmedia;
            vlcmedia.Dispose();
            if (player == null)
            {
                return new Tuple<PluginAnswerType, object>(PluginAnswerType.NotSupported, null);
            }
            return new Tuple<PluginAnswerType, object>(PluginAnswerType.Play, player);

        }
    }
}
