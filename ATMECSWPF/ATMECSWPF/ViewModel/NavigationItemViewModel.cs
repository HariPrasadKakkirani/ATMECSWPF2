using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ATMECSWPF.Command;
using ATMECSWPF.Helpers;

namespace ATMECSWPF.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;

        public NavigationItemViewModel(int id,string displayMember)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenContactEditViewCommand = new DelegateCommand(OnContactEditViewExecute);
            
        }

        public void OnContactEditViewExecute(object obj)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)ViewModelCollection.GetViewModel(ViewModelCollection.MAINWINDOWVIEWMODEL);

            mainWindowViewModel.CreateAndLoadContactEditViewModel(Id);
        }

        public int Id { get; private set; }
        public ICommand OpenContactEditViewCommand { get; private set; }

        public string DisplayMember
        {
            get
            {
                return _displayMember;
            }

            set
            {
                _displayMember = value;
                OnPropertyChanged("DisplayMember");
            }
        }
    }
}
