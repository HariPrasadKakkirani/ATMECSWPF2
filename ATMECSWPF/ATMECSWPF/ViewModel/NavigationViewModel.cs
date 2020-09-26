using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMECS.DataAccess;
using ATMECS.Model2;

namespace ATMECSWPF.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        public NavigationViewModel()
        {
            Contacts = new ObservableCollection<NavigationItemViewModel>();
        }

        private void OnContactDeleted(int contactId)
        {
            var navigationItem = Contacts.Single(n => n.Id == contactId);
            Contacts.Remove(navigationItem);
        }

        private void OnContactSaved(Contact contact)
        {
            var displayMember = $"{contact.FirstName} {contact.LastName}";
            var navigationItem = Contacts.SingleOrDefault(n => n.Id == contact.Id);
            if (navigationItem != null)
            {
                navigationItem.DisplayMember = displayMember;
            }
            else
            {
                navigationItem = new NavigationItemViewModel(contact.Id,
                  displayMember
                  );
                Contacts.Add(navigationItem);
            }
        }

        public void Load()
        {
            Contacts.Clear();
            foreach (var contact in DataAccessUtils.GetAllContacts())
            {
                Contacts.Add(new NavigationItemViewModel(
                  contact.Id, contact.DisplayMember));
            }
        }

        private ObservableCollection<NavigationItemViewModel> _contacts = new ObservableCollection<NavigationItemViewModel>();
        public ObservableCollection<NavigationItemViewModel> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                OnPropertyChanged("Contacts");
            }
        }
    }
}

