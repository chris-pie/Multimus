﻿using Multimus.Plugin;
using System;
using System.Collections.Generic;
using System.Text;
using Multimus.Models;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using AsyncAwaitBestPractices.MVVM;

namespace Multimus.ViewModels
{
    class PlayerViewmodel : BaseINPC
    {

        public PlayerViewmodel()
        {
            InitCommand = new AsyncCommand(() => setAudio());
            PlayCommand = new Command(() => togglePlay());
        }

        public string MediaPath { get; set; }

        public ICommand InitCommand { get; private set; }
        public ICommand PlayCommand { get; private set; }
        public double Position 
        {
            get => CurrentPlayer.CurrendMediaPlayer.Position; 
            set => CurrentPlayer.CurrendMediaPlayer.Position = value; 
        }
        void togglePlay()
        {
            CurrentPlayer.CurrendMediaPlayer.IsPaused = !(CurrentPlayer.CurrendMediaPlayer.IsPaused);
            //Task.Run(() =>
            //{
            //    var pos = Position;
            //    while (!(CurrentPlayer.CurrendMediaPlayer.IsPaused))
            //    {
            //        if (pos != Position)
            //        {
            //            pos = Position;
            //            RaisePropertyChanged("Position");
            //            Thread.Sleep(100);
            //        }
            //    }
            //});
        }
        async Task setAudio()
        {
            await Task.Run(() =>
            {
                //TODO: Ensure single task runs at any time
                CurrentPlayer.CurrendMediaPlayer.Dispose();
                CurrentPlayer.CurrendMediaPlayer = PlayerChooser.ChoosePlayer(MediaPath);
                togglePlay();
            });
        }


    }
}
