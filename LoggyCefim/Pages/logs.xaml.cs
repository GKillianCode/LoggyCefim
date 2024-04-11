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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoggyCefim.Pages
{
    /// <summary>
    /// Logique d'interaction pour logs.xaml
    /// </summary>
    public partial class logs : Page
    {
        private LogsModel _logsModel;
        public logs()
        {
            InitializeComponent();
            _logsModel = new LogsModel();
            DataContext = _logsModel;
        }

        public logs(LogsModel logsModel) : this()
        {
            _logsModel = logsModel; // Utilise l'objet LogsModel passé en argument
        }
    }
}
