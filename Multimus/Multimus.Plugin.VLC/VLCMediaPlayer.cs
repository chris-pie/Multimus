using System;
using System.Collections.Generic;
using System.Text;
using Multimus.Plugin;
using LibVLCSharp.Shared;

namespace Multimus.Plugin.VLC
{
    public class VLCMediaPlayer : IMediaPlayer
    {
        MediaPlayer mediaPlayer;
        public VLCMediaPlayer(MediaPlayer player)
        {
            mediaPlayer = player;
        }

        ~VLCMediaPlayer()
        {
            mediaPlayer.Dispose();
        }
        public bool IsPaused 
        { 
            get => !mediaPlayer.IsPlaying;
            set
            {
                if (value)
                {
                    mediaPlayer.Pause();
                }
                else
                {
                    mediaPlayer.Play();
                }
            }
        }
        public double Position 
        {
            get => mediaPlayer.Position;
            set => mediaPlayer.Position = (float)value;
        }

    }
}
