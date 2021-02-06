using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Multimus.Plugin;


namespace Multimus.Models
{
    static class CurrentPlayer
    {
        private static IMediaPlayer currendMediaPlayer = new NullPlayer();
        public static ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();

        public static IMediaPlayer CurrendMediaPlayer {
            get 
            {
                readerWriterLock.EnterReadLock();
                try
                {
                    return currendMediaPlayer;
                }
                finally
                {
                    readerWriterLock.ExitReadLock();
                }
                
            } 
            set
            {
                readerWriterLock.EnterWriteLock();
                try
                {
                    var oldplayer = currendMediaPlayer;
                    currendMediaPlayer = value;
                    oldplayer.IsPaused = true;
                    oldplayer.Dispose();
                }
                finally
                {
                    readerWriterLock.ExitWriteLock();
                }

            }
        }
    }
}
