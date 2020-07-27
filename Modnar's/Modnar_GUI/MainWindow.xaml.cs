using System;
using System.Collections.Generic;
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
using Modnar_Classes;

namespace Modnar_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player playerTest = new Player("Test", 100, 10);
        Monster currentMonster = new Monster("Monster", 100, 10);

        public MainWindow()
        {
            InitializeComponent();
            Label_P1Name.Content = playerTest.Name;
            Label_P1Health.Content = playerTest.Health;
            
        }
       


        private void Button_Attack_Click(object sender, RoutedEventArgs e)
        {
            Label_Info.Content = playerTest.Attack(currentMonster);
            if (currentMonster.Health > 0)
            {
                Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerTest));
                Label_P1Health.Content = playerTest.Health;
            }

        }
    } 
}
