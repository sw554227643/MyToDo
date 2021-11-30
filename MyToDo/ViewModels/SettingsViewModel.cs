using MyToDo.Common.Models;
using MyToDo.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace MyToDo.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        public SettingsViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this.regionManager = regionManager;
            CreatMenuBar();
        }

        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;
        public DelegateCommand<MenuBar> NavigateCommand { get; set; }


        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { SetProperty(ref menuBars, value); }
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.Title))
            {
                return;
            }
            regionManager.Regions[PrismManager.SettingRegionName].RequestNavigate(obj.NameSpace);


        }


        private void CreatMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "个性化", NameSpace = "SkinView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "系统设置", NameSpace = "" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookPlus", Title = "关于更多", NameSpace = "AboutView" });
        }
    }
}
