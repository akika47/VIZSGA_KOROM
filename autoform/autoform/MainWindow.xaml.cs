using autoapp.Model;
using Microsoft.Win32;
using System.Collections.ObjectModel;
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

namespace autoform;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Auto> cars;
    public MainWindow()
    {
        InitializeComponent();

    }

    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofd = new()
        {
            Filter = "CSV files (*.csv)|*.csv"
        };
        if (ofd.ShowDialog() == true)
        {
            
         List<Auto> temp = Auto.LoadCars(ofd.FileName);
         cars = new(temp);
        }
        dtgCars.ItemsSource = cars;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Biztos, hogy ki akar lépni?", "Confirm", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Application.Current.Shutdown();
        }
    }

    private void txtSpecYear_TextChanged(object sender, TextChangedEventArgs e)
    {
        int filterYear = int.Parse(txtSpecYear.Text);
        List<Auto> filteredCars = cars.Where(x => x.Gyartasiev == filterYear).ToList();

        foreach (var item in filteredCars)
        {
            lbSpecYear.Items.Add($"{item.Marka} {item.Modell}");
        }
    }
}