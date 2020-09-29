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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private int _id;
        public void Load(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return;
            }

            _id = customerDto.ID;
            this.tbAdress.Text = customerDto.Adress.ToString();
            this.tbInfo.Text = customerDto.Info.ToString();
            this.tbName.Text = customerDto.Name.ToString();
            this.tbPhone.Text = customerDto.Phone.ToString();
        }
        public AddClientWindow()
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
                CustomerDto customerDto = new CustomerDto();
                //divisionDto.idDivision = int.Parse(tbDivisionID.Text);
                customerDto.Adress = tbAdress.Text;
                customerDto.Info = tbInfo.Text;
                customerDto.Name = tbName.Text;
                customerDto.Phone = tbPhone.Text;
                customerDto.ManagerID = int.Parse(tbManager.Text);
                ICustomerProcess cutomerProcess = ProcessFactory.GetCustomerProcess();

                if (_id == 0)
                {
                    cutomerProcess.Add(customerDto);
                }
                else
                {
                    customerDto.ID = _id;
                    cutomerProcess.Update(customerDto);
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

