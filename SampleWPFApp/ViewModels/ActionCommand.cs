using System;
using System.Windows.Input;

namespace SampleWPFApp.ViewModels
{
    public class ActionCommand<T> : ICommand
    {
        public Action<T> Action { get; set; } = _ => { };
        public Func<T, bool> Predicate { get; set; } = _ => true;

        public ActionCommand(Action<T> action)
        {
            Action = action;
        }

        public ActionCommand(Action<T> action, Func<T, bool> predicate)
        {
            Action = action;
            Predicate = predicate;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is T p)
            { return Predicate.Invoke(p); }

            return false;
        }

        public void Execute(object? parameter)
        {
            if (CanExecute(parameter) && parameter is T p)
            { Action?.Invoke(p); }
        }
    }

}
