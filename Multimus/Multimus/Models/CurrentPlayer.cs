using System;
using System.Collections.Generic;
using System.Text;
using Multimus.Plugin;

namespace Multimus.Models
{
    static class CurrentPlayer
    {
        public static IMediaPlayer CurrendMediaPlayer { get; set; } = new NullPlayer();
    }
}
