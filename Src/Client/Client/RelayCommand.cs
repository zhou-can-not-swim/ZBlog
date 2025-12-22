using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client
{
    public class RelayCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged;

        private Action<object> _Excute { get; set; }

        private Predicate<object> _CanExcute { get; set; }

        //委托
        public RelayCommand(Action<object> ExcuteMethod, Predicate<object> CanExcuteMethod)
        {
            _Excute = ExcuteMethod;
            _CanExcute = CanExcuteMethod;
        }

        //主要包含CanExecute  Execute
        public bool CanExecute(object? parameter)
        {
            return _CanExcute(parameter);
        }

        public void Execute(object? parameter)
        {
            //当调用此命令时，应执行的操作。
            _Excute(parameter);
        }
    }
}
