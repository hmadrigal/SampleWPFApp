using SampleWPFApp.Interactivity;
using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleWPFApp.ViewModels
{

    public class MainWindowViewModel : BaseViewModel
    {
        private string _item = string.Empty;
        public string Item
        {
            get { return _item; }
            set { SetField(ref _item, value, nameof(Item)); }
        }

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        public ObservableCollection<string> Items { get; private set; } = new ObservableCollection<string>();
        public MainWindowViewModel()
        {
            AddCommand = new ActionCommand<string>(ExecuteAddCommand, CanExecuteAddCommand);
            RemoveCommand = new ActionCommand<string>(ExecuteRemoveCommand, CanExecuteRemoveCommand);
        }

        private void ExecuteRemoveCommand(string arg)
        {
            Items.Remove(arg);
        }

        private bool CanExecuteRemoveCommand(string arg) => !string.IsNullOrEmpty(arg);

        private bool CanExecuteAddCommand(string arg) => !string.IsNullOrWhiteSpace(arg);

        private void ExecuteAddCommand(string text)
        {
            Items.Add(text);
            Item = string.Empty;
        }
    }

}
