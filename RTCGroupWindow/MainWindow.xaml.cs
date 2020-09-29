using RTC.BusinessLayer;
using RTC.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTCGroupWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _currentTable;
        private int _currentIdManager = 1;
        public MainWindow()
        {
            InitializeComponent();
            dgStore.ItemsSource = ProcessFactory.GetProductProcess().GetList();
            _currentTable = "Product";
        }

        private void MiFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MiEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MiHelp_Click(object sender, RoutedEventArgs e)
        {

        }



        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (_currentTable)
            {
                case ("Product"):
                    AddProductWindow addProductWindow = new AddProductWindow();
                    addProductWindow.ShowDialog();
                    return;
                case ("Order"):
                    AddOrder addOrder = new AddOrder();
                    addOrder.ShowDialog();
                    return;
                case ("Customer"):
                    AddClientWindow addClientWindow = new AddClientWindow();
                    addClientWindow.ShowDialog();
                    return;
            }
        }



        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            AddedToProductWindow addedToProductWindow = new AddedToProductWindow();
            addedToProductWindow.ShowDialog();
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void TabItem_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
        }

        private void TabItem_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
        }

        private void DgStore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tiClient != null && tiClient.IsSelected)
            {
                _currentTable = "Customer";
                dgClient.ItemsSource = ProcessFactory.GetCustomerProcess().GetList();
            }

            if (tiStore != null && tiStore.IsSelected)
            {
                _currentTable = "Product";
                dgStore.ItemsSource = ProcessFactory.GetProductProcess().GetList();
            }

            if (tiOrder != null && tiOrder.IsSelected)
            {
                _currentTable = "Order";
                dgRequest.ItemsSource = ProcessFactory.GetOrderProcess().GetFromManager(_currentIdManager);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<object> grid = null;
            switch (_currentTable)
            {
                case ("Product"):
                   grid = dgProduct.ItemsSource.Cast<object>().ToList();
                    break;
                case ("Order"):
                    grid = dgRequest.ItemsSource.Cast<object>().ToList();
                    break;
                case ("Customer"):
                    grid = dgClient.ItemsSource.Cast<object>().ToList();
                    break;
            }
           

            SaveFileDialog saveXlsxDialog = new SaveFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files(.xlsx) | *.xlsx",
                AddExtension = true,
                FileName = _currentTable
            };

            bool? result = Convert.ToBoolean(saveXlsxDialog.ShowDialog());

            if (result == true)
            {
                FileInfo xlsxFile = new FileInfo(saveXlsxDialog.FileName);
                ProcessFactory.GetReport().fillExcelTableByType(grid, _currentTable, xlsxFile);
                System.Windows.MessageBox.Show("Отчет успешно создан!", "Результат");
            }
        }
    }
}
