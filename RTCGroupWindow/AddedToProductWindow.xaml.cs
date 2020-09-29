using RTC.BusinessLayer;
using RTC.Dto;
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

namespace RTCGroupWindow
{
    /// <summary>
    /// Логика взаимодействия для AddedToProductWindow.xaml
    /// </summary>
    public partial class AddedToProductWindow : Window
    {
        public AddedToProductWindow()
        {
            InitializeComponent();
            IList<ProductDto> products = ProcessFactory.GetProductProcess().GetList();
            foreach (var product in products)
                cbTitle.Items.Add(product.Title);
            cbTitle.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IProductProcess productProcess = ProcessFactory.GetProductProcess();
                productProcess.AddCount(int.Parse(tbCount.Text), productProcess.GetID(cbTitle.SelectedItem.ToString()).ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }
    }
}
