using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Mercurius.Infrastructure.Services;
using Mercurius.Presentation.ViewModel;
using Microsoft.Win32;

namespace Mercurius.Presentation
{
    public partial class MainWindow : Window
    {
        private readonly StorageService _storageService;
        private readonly ApplicationViewModel _applicationView;

        public MainWindow()
        {
            _storageService = new StorageService();
            _applicationView = new ApplicationViewModel();

            GenerateContactList();
            _applicationView.ActiveChat = _applicationView.AllChats.FirstOrDefault();

            DataContext = _applicationView;
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "VMG Files |*.vmg",
                Multiselect = true
            };

            if (fileDialog.ShowDialog() == true)
            {
                var allFilesPaths = fileDialog.FileNames;
                _storageService.Create(allFilesPaths);

                GenerateContactList();
            }
        }

        private void ContactItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listBoxItem = sender as ListBoxItem;
            if (listBoxItem != null)
            {
                var newActiveChat = listBoxItem.Content as ViewModelChat;
                _applicationView.ActiveChat = newActiveChat;
            }
        }

        private void GenerateContactList()
        {
            _applicationView.AllChats = _storageService.GetAll()
                .Select(Adapter.Request).ToList();
        }
    }
}