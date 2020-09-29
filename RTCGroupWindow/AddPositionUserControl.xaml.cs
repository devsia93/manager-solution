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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTCGroupWindow
{
    /// <summary>
    /// Логика взаимодействия для AddPositionUserControl.xaml
    /// </summary>
    public partial class AddPositionUserControl : UserControl
    {
        public AddPositionUserControl(List<string> products, string[] positionType)
        {
            InitializeComponent();
            cbPosition.ItemsSource = products;
            cbPosition.SelectedIndex = 0;
            cbCountType.ItemsSource = positionType;
            cbCountType.SelectedIndex = 0;
        }
    }
}
