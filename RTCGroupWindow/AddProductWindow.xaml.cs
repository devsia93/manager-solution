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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private int _id;
        public void Load(ProductDto productDto)
        {
            if (productDto == null)
                return;
            _id = productDto.ID;
            this.tbCount.Text = productDto.Count.ToString();
            this.tbImporter.Text = productDto.Importer.ToString();
            this.tbMrc.Text = productDto.MRC.ToString();
            this.tbPrice.Text = productDto.Price.ToString();
            tbReserve.Text = productDto.Reserve.ToString();
            tbTitle.Text = productDto.Title.ToString();
        }
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductDto productDto = new ProductDto();
                productDto.Count = int.Parse(tbCount.Text);
                productDto.Importer = tbImporter.Text;
                productDto.MRC = double.Parse(tbMrc.Text);
                productDto.Price = double.Parse(tbPrice.Text);
                productDto.Reserve = int.Parse(tbReserve.Text);
                productDto.Title = tbTitle.Text;
                IProductProcess productProcess = ProcessFactory.GetProductProcess();

                if (_id == 0)
                {
                    productProcess.Add(productDto);
                }
                else
                {
                    productDto.ID = _id;
                    productProcess.Update(productDto);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
