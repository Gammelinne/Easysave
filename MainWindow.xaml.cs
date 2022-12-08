﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace EasySaveApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string json = File.ReadAllText("../../../Settings.json");
            Dictionary<string, string> setting = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            Application.Current.Properties["TypeOfLog"] = setting["TypeOfLog"];
            Application.Current.Properties["ExtensionToCrypt"] = ".txt .exe";
            Application.Current.Properties["CryptKey"] = 100;
        }
    }
}
