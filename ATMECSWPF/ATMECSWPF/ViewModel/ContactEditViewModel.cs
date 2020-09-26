using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ATMECS.DataAccess;
using ATMECS.Model2;
using ATMECSWPF.Command;
using ATMECSWPF.Wrapper;

namespace ATMECSWPF.ViewModel
{
    public class ContactEditViewModel : ViewModelBase
    {
        ContactWrapper _contact = new ContactWrapper(); 
        
        
        public ContactEditViewModel()
        {
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute, OnDeleteCanExecute);
        }

        public ICommand SaveCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ContactWrapper Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                OnPropertyChanged("Contact");
            }
        }

        public void Load(int? contactId)
        {
            
            var contact = contactId.HasValue
              ? DataAccessUtils.GetContactById(contactId.Value)
              : new Contact();

            Contact = new ContactWrapper(contact);

            Contact.PropertyChanged += Contact_PropertyChanged;

            InvalidateCommands();
        }

        private void Contact_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvalidateCommands();
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();
        }

        private void OnSaveExecute(object obj)
        {
            DataAccessUtils.SaveContact(Contact.Model);
            Contact.AcceptChanges();
        }

        private bool OnSaveCanExecute(object arg)
        {
            return Contact != null && Contact.IsChanged;
        }

        private void OnDeleteExecute(object obj)
        {
            
                DataAccessUtils.DeleteContact(Contact.Id);
                
            
        }

        private bool OnDeleteCanExecute(object arg)
        {
            return Contact != null && Contact.Id > 0;
        }
    }
}
