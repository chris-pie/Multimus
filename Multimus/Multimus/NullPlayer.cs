using Multimus.Plugin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multimus
{
    class NullPlayer : IMediaPlayer
    {
        bool IMediaPlayer.IsPaused { get => true; set { } }
        double IMediaPlayer.Position { get => 0.0; set { } }
    }
}
