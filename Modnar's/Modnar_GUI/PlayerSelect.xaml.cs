using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Modnar_Classes;
using Modnar_Model;

namespace Modnar_GUI
{
    /// <summary>
    /// Interaction logic for PlayerSelect.xaml
    /// </summary>
   
    public partial class PlayerSelect : Window
    {
        DatabaseManager dm = new DatabaseManager();
        public PlayerSelect()
        {
            InitializeComponent();
            ListBox_PlayerSelect.ItemsSource = dm.ReadPlayer_List();
        }

        private void Button_SelectPlayerOne_Click(object sender, RoutedEventArgs e)
        {
            Player player = ListBox_PlayerSelect.SelectedItem as Player;
            ((MainWindow)Application.Current.MainWindow).playerOne = player;
            
        }

        private void Button_SelectPlayerTwo_Click(object sender, RoutedEventArgs e)
        {
            Player player = ListBox_PlayerSelect.SelectedItem as Player;
            ((MainWindow)Application.Current.MainWindow).playerTwo = player;
        }

        private void Button_SelectPlayerThree_Click(object sender, RoutedEventArgs e)
        {
            Player player = ListBox_PlayerSelect.SelectedItem as Player;
            ((MainWindow)Application.Current.MainWindow).playerThree = player;
        }

        private void Button_SelectPlayerFour_Click(object sender, RoutedEventArgs e)
        {
            Player player = ListBox_PlayerSelect.SelectedItem as Player;
            ((MainWindow)Application.Current.MainWindow).playerFour = player;
        }
    }
}
