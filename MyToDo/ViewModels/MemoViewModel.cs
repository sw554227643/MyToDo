using MyToDo.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyToDo.ViewModels
{
    public class MemoViewModel:BindableBase
    {
        public MemoViewModel()
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            AddCommand = new DelegateCommand(Add);
            CreatList();
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

        private ObservableCollection<MemoDto> memoDtos;
        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { SetProperty(ref memoDtos, value); }
        }

        public DelegateCommand AddCommand { get; set; }


        void CreatList()
        {
            for (int i = 0; i < 20; i++)
            {
                MemoDtos.Add(new MemoDto()
                {
                    Title = "标题 " + i,
                    Content = "测试数据"
                });
            }
        }

    }
}
