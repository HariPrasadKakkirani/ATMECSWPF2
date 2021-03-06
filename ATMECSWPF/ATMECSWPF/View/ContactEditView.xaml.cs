﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ATMECSWPF.ViewModel;
using ATMECSWPF.Helpers;

namespace ATMECSWPF.View
{
    /// <summary>
    /// Interaction logic for ContactEditView.xaml
    /// </summary>
    public partial class ContactEditView : UserControl
    {
        public ContactEditView()
        {
            InitializeComponent();

            ContactEditViewModel contactEditViewModel = new ContactEditViewModel();
            this.DataContext = contactEditViewModel;

            ViewModelCollection.AddViewModel(ViewModelCollection.CONTACTSEDITVIEWMODEL, contactEditViewModel);
        }

        
    }
}
