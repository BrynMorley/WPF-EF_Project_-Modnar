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
using Modnar_Model;
namespace Modnar_View
{
    /// <summary>
    /// Interaction logic for CreatePlayer.xaml
    /// </summary>
    public partial class CreatePlayer : Window
    {

        DatabaseManager dm = new DatabaseManager();
        public CreatePlayer()
        {
            InitializeComponent();
        }

        private void Button_CreatePlayer_Click(object sender, RoutedEventArgs e)
        {
            dm.CreatePlayer(Textbox_PlayerName.Text, Convert.ToInt32( Textbox_PlayerHealth.Text), Convert.ToInt32(Textbox_PlayerDamage.Text), Convert.ToInt32(Textbox_PlayerSpeed.Text));
           
        }
    }
}
