using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using LoggyCefim.ViewModels;

namespace LoggyCefim.Pages
{
    /// <summary>
    /// Logique d'interaction pour logs.xaml
    /// </summary>
    public partial class logs : Page
    {
        private LogViewModel _logsViewModel;

        public ObservableCollection<LogItemViewModel> ListLog { get; set;  }
        public logs()
        {
            InitializeComponent();
            _logsViewModel = new LogViewModel();
            DataContext = this;
        }


        public logs(LogViewModel logsViewModel) : this()
        {
            _logsViewModel = logsViewModel;
            ListLog = new ObservableCollection<LogItemViewModel>(logsViewModel.LogItems);
        }
    }
}
