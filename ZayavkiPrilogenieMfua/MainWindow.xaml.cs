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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
            LoadPage(new PageLogin());

        }


        internal static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zvezd\source\repos\ZayavkiPrilogenieMfua\ZayavkiPrilogenieMfua\Database1.mdf;Integrated Security=True");
        internal static string username;
        internal static string userpassword;
        internal static int userid;


        public static void LoadPage(Page page) // Метод для загрузки страниц
        {
            Instance.MainFrame.Content = page;
        }

    }
}
