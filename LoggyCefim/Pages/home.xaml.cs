using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LoggyCefim.Pages
{
    /// <summary>
    /// Logique d'interaction pour home.xaml
    /// </summary>
    public partial class home : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private LogsModel log = new LogsModel();
        private string _filePath;
        private string _fileContent;
        private string _alertDebug;
        private string _alertInfo;
        private string _alertAlert;
        private string _alertError;

        public home()
        {
            InitializeComponent();
            DataContext = this;
            FilePath = "Path: /";
        }

        private void RedirectOnclick(object sender, RoutedEventArgs e) 
        {
            LogsModel logs  = new LogsModel(_filePath, _fileContent);
            //Console.WriteLine("Content: " + logs.getContent());
            //Console.WriteLine("Number of AlertInfo: " + logs.getNbAlertInfo());

            Frame parentFrame = getParentFrame(this);

            parentFrame.Navigate(new logs(logs));
            //NavigationService?.Navigate(new Uri("/Pages/logs.xaml?data=" + logs , UriKind.Relative));
        }

        // Méthode pour récupérer le parent Frame de la page home
        private Frame getParentFrame(DependencyObject current)
        {
            // Parcourir le VisualTree pour trouver le parent Frame
            while (current != null)
            {
                if (current is Frame frame)
                {
                    return frame;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }

        private void LoadFileOnclick(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadLogFile(sender, e);
            }
            catch
            {
                Console.WriteLine("Load File Error");
            }
        }

        private void LoadLogFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers de journal (*.log)|*.log";
            if (openFileDialog.ShowDialog() == true)
            {
                log.setPath(openFileDialog.FileName);
                log.setContent(File.ReadAllText(log.getPath()));

                FilePath = log.getPath();
                _fileContent = log.getContent();
                AlertDebug = log.getNbAlertDebug().ToString();
                AlertInfo = log.getNbAlertInfo().ToString();
                AlertAlert = log.getNbAlertAlert().ToString();
                AlertError = log.getNbAlertError().ToString();
            }
        }


        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (value != _filePath)
                {
                    _filePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AlertDebug
        {
            get { return _alertDebug; }
            set
            {
                if (value != _alertDebug)
                {
                    _alertDebug = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AlertInfo
        {
            get { return _alertInfo; }
            set
            {
                if (value != _alertInfo)
                {
                    _alertInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AlertAlert
        {
            get { return _alertAlert; }
            set
            {
                if (value != _alertAlert)
                {
                    _alertAlert = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AlertError
        {
            get { return _alertError; }
            set
            {
                if (value != _alertError)
                {
                    _alertError = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
