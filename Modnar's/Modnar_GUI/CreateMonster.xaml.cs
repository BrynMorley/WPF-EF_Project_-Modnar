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
    /// Interaction logic for CreateMonster.xaml
    /// </summary>
    public partial class CreateMonster : Window
    {
        DatabaseManager dm = new DatabaseManager();
        public CreateMonster()
        {
            InitializeComponent();
        }

        private void Button_MonsterPlayer_Click(object sender, RoutedEventArgs e)
        {
            dm.CreateMonster(Textbox_MonsterName.Text, Convert.ToInt32(Textbox_MonsterHealth.Text), Convert.ToInt32(Textbox_MonsterDamage.Text), Convert.ToInt32(Textbox_MonsterSpeed.Text));
        }
    }
}
