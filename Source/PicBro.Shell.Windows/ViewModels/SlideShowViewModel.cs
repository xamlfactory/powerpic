﻿
namespace PicBro.Shell.Windows.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Timers;
    using System.Windows;
    using System.Windows.Media.Animation;
    using System.Windows.Threading;
    using Microsoft.Practices.Prism.Commands;
    using PicBro.DataModel.Windows;
    using PicBro.Foundation.Windows.Infrastructure;
    using PicBro.Shell.Windows.Common;
    public sealed class SlideShowViewModel : ViewModelBase
    {
        private int index = -1;
        private string currentImage;
        private Window slideShowWindow;
        private DispatcherTimer timer;
        public List<ImageModel> Images { get; set; }
        public string CurrentImage
        {
            get { return this.currentImage; }
            set
            {
                this.currentImage = value;
                this.RaisePropertyChanged(() => this.CurrentImage);
            }
        }
        public DelegateCommand SlideShowCloseCommand { get; private set; }
        public DelegateCommand NextCommand { get; private set; }
        public DelegateCommand PreviousCommand { get; private set; }
        public DelegateCommand EscapeSlideShowCommand { get; private set; }

        public SlideShowViewModel(Window owner, List<ImageModel> images)
            : base()
        {
            this.slideShowWindow = owner;
            this.Images = images;
            this.InitializeCommands();
            this.OnNextCommandExectue();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (this.index >= this.Images.Count - 1)
            {
                this.index = -1;
            }

            this.OnNextCommandExectue();
        }

        private void InitializeCommands()
        {
            this.EscapeSlideShowCommand = new DelegateCommand(this.OnEscapeCommandExecuted);
            this.NextCommand = new DelegateCommand(this.OnNextCommandExectue);
            this.PreviousCommand = new DelegateCommand(this.OnPreviousCommandExecute);
            this.SlideShowCloseCommand = new DelegateCommand(this.OnSlideShowCloseCommandExecute);
        }

        private void OnSlideShowCloseCommandExecute()
        {
            SessionService<string>.Remove(Constants.SlideShowWindow);
            this.StopSlideShowTimerifPossible();
        }
        private void OnPreviousCommandExecute()
        {
            if (this.index >= 1)
            {
                this.StopSlideShowTimerifPossible();
                this.index--;
                this.CurrentImage = this.Images[this.index].Path;
                this.AnimateSlideImages(this.slideShowWindow);
                this.StartSlideShowTimerIfPossible();
            }
        }

        private void OnNextCommandExectue()
        {
            if (this.index < this.Images.Count - 1)
            {
                this.StopSlideShowTimerifPossible();
                this.index++;
                this.CurrentImage = this.Images[this.index].Path;
                this.AnimateSlideImages(this.slideShowWindow);
                this.StartSlideShowTimerIfPossible();
            }
        }

        private void OnEscapeCommandExecuted()
        {
            this.index = -1;
            this.slideShowWindow.Close();
        }

        private void AnimateSlideImages(object param)
        {
            Window window = param as Window;
            if (window != null)
            {
                if (this.slideShowWindow == null)
                {
                    this.slideShowWindow = window;
                }

                Storyboard storyBoard = window.TryFindResource("SlideShowFadeOutStoryBoard") as Storyboard;
                storyBoard.Begin();
            }
        }

        private void StartSlideShowTimerIfPossible()
        {
            if (this.Images.Count > 1)
            {
                this.timer = new DispatcherTimer();
                this.timer.Interval = new TimeSpan(0, 0, 4);
                this.timer.Tick += timer_Tick;
                this.timer.Start();
            }
        }

        private void StopSlideShowTimerifPossible()
        {
            if (this.timer != null)
            {
                this.timer.Tick -= timer_Tick;
                this.timer.Stop();
            }
        }
        public override bool IsNavigationTarget(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public override void OnNavigatedFrom(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
