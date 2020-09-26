using System;
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
using System.Windows.Shapes;
using ATMECSWPF.Helpers;
using ATMECSWPF.ViewModel;

namespace ATMECSWPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            mainWindowViewModel.Load();

            ViewModelCollection.AddViewModel(ViewModelCollection.MAINWINDOWVIEWMODEL, mainWindowViewModel);

            InitializeComponent();

            this.DataContext = mainWindowViewModel;

            ContactEditViewModel contactEditViewModel = new ContactEditViewModel();
            //this.DataContext = contactEditViewModel;

            ViewModelCollection.AddViewModel(ViewModelCollection.CONTACTSEDITVIEWMODEL, contactEditViewModel);




        }
    }
}
