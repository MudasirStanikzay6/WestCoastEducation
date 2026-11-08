using Avalonia.Controls;
using Avalonia.Interactivity;

namespace WestCoastEducation.Desktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CoursesCard_Click(object? sender, RoutedEventArgs e)
    {
        MainTabs.SelectedIndex = 1;
    }

    private void StudentsCard_Click(object? sender, RoutedEventArgs e)
    {
        MainTabs.SelectedIndex = 2;
    }

    private void TeachersCard_Click(object? sender, RoutedEventArgs e)
    {
        MainTabs.SelectedIndex = 3;
    }
}