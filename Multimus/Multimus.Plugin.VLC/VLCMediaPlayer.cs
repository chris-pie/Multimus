using System;
using System.Collections.Generic;
using System.Text;
using Multimus.Plugin;
using LibVLCSharp.Shared;

namespace Multimus.Plugin.VLC
{
    public class VLCMediaPlayer : MediaPlayer, IMediaPlayer
    {
        public VLCMediaPlayer(LibVLC libVLC) : base(libVLC)
        {
        }

        public VLCMediaPlayer(Media media) : base(media)
        {
        }

        public bool IsPaused 
        { 
            get => !IsPlaying;
            set
            {
                if (value)
                {
                    Pause();
                }
                else
                {
                    Play();
                }
            }
        }
        public new double Position 
        {
            get => base.Position;
            set => base.Position = (float)value;
        }

    }
}
