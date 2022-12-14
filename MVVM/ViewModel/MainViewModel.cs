﻿using EasySaveApp.Core;
using EasySaveApp.MVVM.Model;
using EasySaveApp.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EasySaveApp.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand SwitchLanguageEN { get; set; }
        public RelayCommand SwitchLanguageFR { get; set; }
        public RelayCommand AddExtensionToEncrypt { get; set; }

        public RelayCommand ShutdownWindowCommand { get; set; }
        public static RelayCommand HomeViewCommand { get; set; }
        public static RelayCommand SaveHomeViewModelCommand { get; set; }
		public RelayCommand SaveViewModelCommand { get; set; }
        public RelayCommand SettingViewModelCommand { get; set; }
        public static RelayCommand ProgressionViewModelCommand { get; set; }
        public static RelayCommand SetProgressionCommand { get; set; }
        public static RelayCommand SetFileLeftCommand { get; set; }
        public static RelayCommand SetFileTotalCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public SaveViewModel SaveVM { get; set; }
		public SaveHomeViewModel SaveHomeVM { get; set; }
        public SettingViewModel SettingVM { get; set; }
        public ProgressionViewModel ProgressionVM { get; set; }

        private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set 
			{ 
			_currentView = value;
			OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
            ShutdownWindowCommand = new RelayCommand(o => { App.Current.Shutdown(); });
            HomeVM = new HomeViewModel();
            SaveHomeVM = new SaveHomeViewModel();
            SaveVM = new SaveViewModel();
            SettingVM = new SettingViewModel();
            ProgressionVM = new ProgressionViewModel();

            CurrentView = SaveHomeVM;

            
            HomeViewCommand = new RelayCommand(o => 
			{
				CurrentView= HomeVM;
			});

            SaveHomeViewModelCommand = new RelayCommand(o =>
            {
                CurrentView = SaveHomeVM;
            });

            SaveViewModelCommand = new RelayCommand(o =>
            {
                CurrentView = SaveVM;
            });

            SettingViewModelCommand = new RelayCommand(o =>
            {
                CurrentView = SettingVM;
            });

            ProgressionViewModelCommand = new RelayCommand(o =>
            {
                
                CurrentView = ProgressionVM;
            });

            SwitchLanguageEN = new RelayCommand(o =>
            {
                ResourceDictionary dict = new ResourceDictionary();
                dict.Source = new Uri("..\\Languages\\StringResources_en.xaml", UriKind.Relative);
            });

            SwitchLanguageFR = new RelayCommand(o =>
            {
                ResourceDictionary dict = new ResourceDictionary();
                dict.Source = new Uri("..\\Languages\\StringResources_fr.xaml", UriKind.Relative);
            });

            SetProgressionCommand = new RelayCommand(o =>
            {
                ProgressionVM.ProgressionValue = (int)o;
            });

            SetFileLeftCommand = new RelayCommand(o =>
            {
                ProgressionVM.FileLeftToTransfert = o.ToString();
            });

            SetFileTotalCommand = new RelayCommand(o =>
            {
                ProgressionVM.FileTotal = (int)o;
            });
           
        }
    }
}
