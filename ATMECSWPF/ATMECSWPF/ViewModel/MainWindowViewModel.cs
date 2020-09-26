using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ATMECSWPF.Command;
using ATMECSWPF.Helpers;

namespace ATMECSWPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ContactEditViewModel _selectedContactEditViewModel;
        public ICommand AddContactCommand { get; private set; }

        public ICommand CloseContactTabCommand { get; private set; }

        private NavigationViewModel _navigationViewModel = new NavigationViewModel(); 


        public NavigationViewModel NavigationViewModel
        {
            get
            {
                return _navigationViewModel;
            }
            set
            {
                _navigationViewModel = value;
                OnPropertyChanged("NavigationViewModel");
            }
        }

        private ObservableCollection<ContactEditViewModel> contactEditViewModels = new ObservableCollection<ContactEditViewModel>();
        public ObservableCollection<ContactEditViewModel> ContactEditViewModels 
        {
            get
            {
                return contactEditViewModels;
            }
            set
            {
                contactEditViewModels = value;
                OnPropertyChanged("ContactEditViewModels");
            }
             
        }

        public ContactEditViewModel SelectedContactEditViewModel
        {
            get
            {
                return _selectedContactEditViewModel;
            }

            set
            {
                _selectedContactEditViewModel = value;
                OnPropertyChanged("SelectedContactEditViewModel");
            }
        }

        public MainWindowViewModel()
        {
            CloseContactTabCommand = new DelegateCommand(OnCloseContactTabExecute);
            AddContactCommand = new DelegateCommand(OnAddContactExecute);

            
        }

        private void OnCloseContactTabExecute(object obj)
        {
            var contactEditVm = (ContactEditViewModel)obj;
            ContactEditViewModels.Remove(contactEditVm);
        }

        private void OnAddContactExecute(object obj)
        {
            SelectedContactEditViewModel = CreateAndLoadContactEditViewModel(null);
        }

        public ContactEditViewModel CreateAndLoadContactEditViewModel(int? contactId)
        {
            var contactEditVm = new ContactEditViewModel();
            ContactEditViewModels.Add(contactEditVm);
            contactEditVm.Load(contactId);
            return contactEditVm;
        }

        public void Load()
        {
            NavigationViewModel.Load();

            
        }

    }
}
