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
    /// Логика взаимодействия для AddPositionWindow.xaml
    /// </summary>
    public partial class AddPositionWindow : Window
    {
        private string[] PositionType = { "Коробок", "Блоков" };
        private IList<ProductDto> ItemsPosition = ProcessFactory.GetProductProcess().GetList();
        private List<string> products = new List<string>();
        private int orderId = ProcessFactory.GetOrderProcess().GetMaxID() + 1;
        public AddPositionWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach (var product in ItemsPosition)
            {
                products.Add(product.Title);
            }
            AddPositionUserControl addPositionUserControl = new AddPositionUserControl(products, PositionType);
            lbControl.Items.Add(addPositionUserControl);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbControl.Items.Count > 0)
            {
                if (lbControl.SelectedItem == null)
                {
                    MessageBox.Show("Выделите позицию для удаления.", "Ошибка удаления.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    lbControl.Items.Remove(lbControl.SelectedItem);
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            AddPositionUserControl uc;
            ItemsDto item = new ItemsDto();
            List<ItemsDto> itemsDtos = new List<ItemsDto>();
           
            for (int i = 0; i < lbControl.Items.Count; i++)
            {
                uc = lbControl.Items[i] as AddPositionUserControl;
                item.ProductID = ProcessFactory.GetProductProcess().GetID(uc.cbPosition.SelectedItem.ToString()).ID;
                if (uc.cbCountType.SelectedItem.ToString() == "Коробок") {
                    item.Count = int.Parse(uc.tbCount.Text) * 50*10;
                } else
                {
                    item.Count = int.Parse(uc.tbCount.Text);
                }
                item.Price = int.Parse(uc.tbPrice.Text);
                item.OrderID = orderId;
                itemsDtos.Add(item);
            }
            //AddOrder.itemsDto.Clear();
            AddOrder.itemsDto = itemsDtos;
            Close();
        }
    }
}
