using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Multimus.Plugin
{
    public interface IMediaPlayer
    {

        bool IsPaused { get; set; }
        double Position { get; set; }

    }
}
