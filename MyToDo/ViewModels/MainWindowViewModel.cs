using MyToDo.Common.Event;
using MyToDo.Common.Models;
using MyToDo.Extensions;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace MyToDo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            HomeCommand = new DelegateCommand(Home);
            MenuBars = new ObservableCollection<MenuBar>();
            CreatMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal!= null && journal.CanGoBack)
                {
                    journal.GoBack();
                }
            });

            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();
            });

            
            ExecuteCommand = new DelegateCommand<string>((arg) =>
            {
                //注册事件
                eventAggregator.GetEvent<StringMessageEvent>().Publish(arg);
            });

        }


        private void Home()
        {
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("IndexView");
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.Title))
            {
                return;
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                journal = back.Context.NavigationService.Journal;
            });

            
        }
        public DelegateCommand HomeCommand { get; set; }
        public DelegateCommand<MenuBar> NavigateCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand<string> ExecuteCommand { get; set; }
        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private  IRegionNavigationJournal journal;


        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { SetProperty(ref menuBars, value); }
        }


        private void CreatMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "首页", NameSpace = "IndexView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "待办事项", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" });
        }
    }
}
