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
using System.Data;

namespace ZayavkiPrilogenieMfua
{
    /// <summary>
    /// Логика взаимодействия для PageAdminZayvki.xaml
    /// </summary>
    public partial class PageAdminZayvki : Page
    {
        public PageAdminZayvki()
        {
            InitializeComponent();
            DataGridCreatinon();
        }

        private void DataGridCreatinon() // Обновить / Создать Таблицу
        {
            MainWindow.connection.Open();


            string sqlString = "SELECT * FROM Zayavki  ";
            SqlCommand cmd = new SqlCommand(sqlString, MainWindow.connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGrid.ItemsSource = dt.DefaultView;
            MainWindow.connection.Close();

        }

        private void CloseZayvky(object sender, RoutedEventArgs e) // Закрыть заявку
        {
            try
            {
                using (MainWindow.connection)
                {
                    MainWindow.connection.Open();
                    string sqlCommand = "Update Zayavki set IsDone=@IsDone where Id=@Id";
                    SqlCommand cmd = new SqlCommand(sqlCommand, MainWindow.connection);
                    cmd.Parameters.AddWithValue("@IsDone", true);
                    cmd.Parameters.AddWithValue("@Id", IdTextBox.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("Обновлено");
                    }
                    MainWindow.connection.Close();
                    
                }
            }
            catch (Exception exept)
            {
                MessageBox.Show("Ошибка " + exept);
            }
            DataGridCreatinon();
        }

        private void DeleteAllCloseZayvki(object sender, RoutedEventArgs e) // Удалить все закрытые заявки
        {
            MainWindow.connection.Open();
            string query = "Delete from Zayavki where IsDone = 'True'";
            SqlCommand sqlcmd = new SqlCommand(query, MainWindow.connection);
            sqlcmd.ExecuteNonQuery();
            MessageBox.Show("Удалено");
            MainWindow.connection.Close();
            DataGridCreatinon();
        }

        private void SeeZayvkiByDate(object sender, RoutedEventArgs e)// Показать заявки по датам
        {
            MainWindow.connection.Open();


            string sqlString = "SELECT * FROM Zayavki where Date >='" + DateFromPick.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'" + "And Date <='" + DateToPick.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
            SqlCommand cmd = new SqlCommand(sqlString, MainWindow.connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGrid.ItemsSource = dt.DefaultView;
            MainWindow.connection.Close();

        }



    }

   

}
