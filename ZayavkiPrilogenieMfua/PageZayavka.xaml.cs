using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ZayavkiPrilogenieMfua
{
    /// <summary>
    /// Логика взаимодействия для PageZayavka.xaml
    /// </summary>
    public partial class PageZayavka : Page
    {
        public PageZayavka()
        {
            InitializeComponent();
            UsernameTextBlock.Text = "Вы вошли в систему как " + MainWindow.username;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.connection.Open();

            string sqlString = "Insert Into Zayavki (NameId, Description, Date, IsDone) Values (@NameId, @Description, @Date, @IsDone)";
            using (SqlCommand cmd = new SqlCommand(sqlString, MainWindow.connection))
            {
                cmd.Parameters.Add(new SqlParameter("@NameId", MainWindow.userid));
                cmd.Parameters.Add(new SqlParameter("@Description", DescripTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@Date", DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                cmd.Parameters.Add(new SqlParameter("@IsDone", false));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Заявка успешно отправленна!");
            }
            MainWindow.connection.Close();

            System.Windows.Application.Current.Shutdown();
        }
    }
}
