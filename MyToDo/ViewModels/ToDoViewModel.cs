using MyToDo.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyToDo.ViewModels
{
    public class ToDoViewModel:BindableBase
    {
        public ToDoViewModel()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            AddCommand = new DelegateCommand(Add);
            CreatDotoList();
        }

        private void Add()
        {
            IsRightDrawerOpen = true;
        }


        private bool isRightDrawerOpen;
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { SetProperty(ref isRightDrawerOpen, value); }
        }

        private ObservableCollection<ToDoDto> toDoDtos;
        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { SetProperty(ref toDoDtos, value); }
        }

        public DelegateCommand AddCommand { get; set; }


        void CreatDotoList()
        {
            for (int i = 0; i < 20; i++)
            {
                ToDoDtos.Add(new ToDoDto()
                {
                    Title = "标题 " + i,
                    Content = "测试数据"
                });
            }
        }

    }
}
