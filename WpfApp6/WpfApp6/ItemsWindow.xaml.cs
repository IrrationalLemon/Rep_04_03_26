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
using WpfApp6.Classes;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {
        private string FullName;
        public ItemsWindow(string fullName)
        {
            InitializeComponent();
            FullName = fullName;
            FullNameField.Text = FullName;

            LoadItems();
        }

        private void LoadItems()
        {
            var items = DB.db.Товарs.ToList();
            DGridItems.ItemsSource = items;
        }

        private void ChangeUser_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
