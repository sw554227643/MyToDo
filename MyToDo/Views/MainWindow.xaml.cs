using MyToDo.Common.Event;
using MyToDo.Extensions;
using Prism.Events;
using Prism.Regions;
using System;
using System.Windows;

namespace MyToDo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;

        public MainWindow(IEventAggregator eventAggregator,IRegionManager regionManager)
        {
            InitializeComponent();

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
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            //加载事件
            eventAggregator.GetEvent<StringMessageEvent>().Subscribe(Execute);
            //加载首页
            this.Loaded += (s, e) =>
            {
                regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("IndexView");
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Min":
                    WindowState = WindowState.Minimized;
                    break;
                case "Max":
                    WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
                    break;
                case "Exit":
                   // var dialogResult = await dialogHost.Question("温馨提示", "确认退出系统？");
                    //if (dialogResult.Result != ButtonResult.OK) return;
                    Application.Current.Shutdown();
                    break;
                default:
                    break;
            }
        }
    }
}
