using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Client.VM
{
    //INotifyPropertyChanged接口用于实现数据绑定中的属性更改通知,没有它，扩展123没办法实现        前端---->后端
    //当绑定到UI元素的数据源中的属性值发生更改时，INotifyPropertyChanged接口可以通知UI元素更新。
    public class Page3ViewModel : INotifyPropertyChanged
    {
        public ICommand AddUserCommand { get; set; }

        public Page3ViewModel()
        {
            // 从设置加载热键
            var modifiers = Properties.Settings.Default.Modifiers;
            var key = Properties.Settings.Default.Key;
            HotkeyDisplay = $"{modifiers} + {key}";
            //Users = UserManager.GetUsers();
            //AddUserCommand = new RelayCommand(AddUser, CanAddUser);//给外部的AddUserCommand赋值操作，前端点击“添加”按钮调用AddUser方法
            ////扩展2：在构造函数中添加：
            //TestCommand = new RelayCommand(Test, CanTest);
        }







        private string _hotkeyDisplay;
        public string HotkeyDisplay
        {
            get => _hotkeyDisplay;
            set
            {
                _hotkeyDisplay = value;
                OnPropertyChanged(nameof(HotkeyDisplay));
            }
        }



        //private string? _content;
        //public string? Content
        //{
        //    get { return _content; }
        //    set
        //    {
        //        if (_content != value)
        //        {
        //            _content = value;
        //            OnPropertyChanged(nameof(Content));
        //        }
        //    }
        //}





        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
