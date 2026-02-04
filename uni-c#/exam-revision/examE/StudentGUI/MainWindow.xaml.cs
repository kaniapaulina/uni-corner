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
using examE;

namespace StudentGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MixedFieldGroup group = new MixedFieldGroup("paulina testuje");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(cbFoS.SelectedItem is ComboBoxItem selecteditem)
            {
                string field = selecteditem.Content.ToString();
                group.AddStudent(field);

                lbStudents.ItemsSource = null;
                lbStudents.ItemsSource = group.Students.Values;
            }
        }

        private void btnGrade_Click(object sender, RoutedEventArgs e)
        {
            if(lbStudents.SelectedItem is Student student)
            {
                student.AddGrade();
                lbStudents.Items.Refresh();
            }
        }

        private void btnBest_Click(object sender, RoutedEventArgs e)
        {
            List<Student> lista = group.StudentsWithHighestAverageGRade();
            lbBestStudents.ItemsSource = lista;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}