﻿using System.Windows;

namespace MyToDo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
                else this.WindowState = WindowState.Maximized;
            };
            btnClose.Click += (s, e) => { this.Close(); };

            ColorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };

            ColorZone.MouseDoubleClick += (s, e) =>
            {
                if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
                else this.WindowState = WindowState.Normal;
            };

            menuBar.SelectionChanged += (s, e) => { drawerhost.IsLeftDrawerOpen = false; };
        }

        
    }
}
