using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMECS.Model2;
using ATMECSWPF.ViewModel;

namespace ATMECSWPF.Wrapper
{
    public class ContactWrapper : ViewModelBase
    {
       
        
            private Contact _contact = new Contact();
            private bool _isChanged;

            public ContactWrapper()
            {

            }

            public ContactWrapper(Contact contact)
            {
                _contact = contact;
            }

            public Contact Model { get { return _contact; } }

            public bool IsChanged
            {
                get { return _isChanged; }
                private set
                {
                    _isChanged = value;
                OnPropertyChanged("IsChanged");
                    
                }
            }

            public void AcceptChanges()
            {
                IsChanged = false;
            }

            public int Id
            {
                get { return _contact.Id; }
                set 
                { 
                    _contact.Id = value;
                OnPropertyChanged("Id");
                }
            }

            public string FirstName
            {
                get { return _contact.FirstName; }
                set
                {
                    _contact.FirstName = value;
                IsChanged = true;
                OnPropertyChanged("FirstName");
            }
            }

            public string LastName
            {
                get { return _contact.LastName; }
                set
                {
                    _contact.LastName = value;
                IsChanged = true;
                OnPropertyChanged("LastName");
            }
            }

            public DateTime? Birthday
            {
                get { return _contact.Birthday; }
                set
                {
                    _contact.Birthday = value;
                    IsChanged = true;
                OnPropertyChanged("Birthday");
                }
            }
        }
}
