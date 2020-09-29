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
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        private double sum = 0;
        public static List<ItemsDto> itemsDto { get; set; }
        private string[] status = { "Отменен", "Собирается", "В пути", "Завершен" };
        private string[] typePayment = { "Безналичный расчет", "Наличный расчет", "Рассрочка"};
        public AddOrder()
        {
            InitializeComponent();
            cbStatus.ItemsSource = status;
            cbStatus.SelectedIndex = 0;
            cbTypePayment.ItemsSource = typePayment;
            cbTypePayment.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAddPosition_Click(object sender, RoutedEventArgs e)
        {
            AddPositionWindow addPositionWindow = new AddPositionWindow();
            addPositionWindow.ShowDialog();
            if (itemsDto != null)
            {
                foreach (var item in itemsDto)
                {
                    sum += item.Price * item.Count;
                    lbItems.Items.Add(ProcessFactory.GetProductProcess().Get(item.ProductID).Title);
                }
                if (lbItems.Items.Count != 0)
                {
                    lblPosition.Visibility = Visibility.Collapsed;
                }
                else
                {
                    lblPosition.Visibility = Visibility.Visible;
                }
                tbPrice.Text = sum.ToString();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sum != double.Parse(tbPrice.Text))
                {
                    MessageBox.Show("Сумма по чеку и сумма продаваемого товара не совпадают.", "Ошибка.", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
