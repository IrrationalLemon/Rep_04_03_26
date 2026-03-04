using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp6.Classes;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Auth_btn_Click(object sender, RoutedEventArgs e)
        {
            var users = DB.db.Пользовательs.ToList();

            var login = LoginField.Text.Trim();
            var password = PasswordField.Text.Trim();
            bool isUserFound = false;

            if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(login))
            {
                foreach (var user in users)
                {
                    if (user.Логин == login && user.Пароль == password)
                    {
                        MessageBox.Show("Вход успешно выполнен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        string fullName = user.Фио;
                        ItemsWindow items = new ItemsWindow(fullName);
                        items.Show();
                        this.Close();
                        isUserFound = true;
                        break;
                    }
                }

                if (!isUserFound)
                {
                    MessageBox.Show("Неверно введен логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните пустые поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}