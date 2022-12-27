using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

       



        private void Loginbutton_Click(object sender, RoutedEventArgs e) // Кнопка логина
        {


           MainWindow.username = NameBox.Text;
           MainWindow.userpassword = PasseBox.Text;

            try
            {
                string viborka = "SELECT * FROM Accounts WHERE UserName= '" + MainWindow.username + "' AND Password ='" + MainWindow.userpassword + "'";
                SqlDataAdapter sqladapter = new SqlDataAdapter(viborka,MainWindow.connection);

                DataTable dataTable = new DataTable();
                sqladapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0) // Проверка, нашли ли данные
                {

                    foreach (DataRow row in dataTable.Rows)
                    {
    
                            MainWindow.userid = int.Parse(row["Id"].ToString());
                        
                       
                        
                        if (row["IsAdmin"].ToString() == "True")
                        {
                           MainWindow.LoadPage(new PageAdminZayvki());
                        }
                        else
                        {
                           MainWindow.LoadPage(new PageZayavka());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверные данные пользователя");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка");
            }
            finally
            {
                MainWindow.connection.Close();
            }

        }


    }
}
