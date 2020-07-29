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
using System.Collections;
using Modnar_Model;
using Modnar_Classes;


namespace Modnar_GUI
{ 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseManager dm = new DatabaseManager();

        Player playerOne = new Player("Player 1", 100, 10,1);
        Player playerTwo = new Player("Player 2", 100, 10,1);
        Player playerThree = new Player("Player 3", 100, 10,1);
        Player playerFour = new Player("Player 4", 100, 10,1);

        Player currentPlayer = new Player("Default", 50, 5, 1);

        //Player randomPlayer = new Player("Random", 50, 5, 1);

        Monster currentMonster = new Monster("Monster", 100, 10, 2);

        Queue playerQueue = new Queue();

        int killCount = 0;
        int turnsPassed = 0;

        public MainWindow()
        {
            InitializeComponent();
            playerOne = dm.ReadPlayerID(1);
            playerTwo = dm.ReadPlayerID(2);
            playerThree = dm.ReadPlayerID(3);
            playerFour = dm.ReadPlayerID(4);

            Label_P1Name.Content = playerOne.Name;
            Label_P1Health.Content = playerOne.Health;

            Label_P2Name.Content = playerTwo.Name;
            Label_P2Health.Content = playerTwo.Health;

            Label_P3Name.Content = playerThree.Name;
            Label_P3Health.Content = playerThree.Health;

            Label_P4Name.Content = playerFour.Name;
            Label_P4Health.Content = playerFour.Health;

            playerQueue.Enqueue(playerOne);
            playerQueue.Enqueue(playerTwo);
            playerQueue.Enqueue(playerThree);
            playerQueue.Enqueue(playerFour);

            currentMonster = dm.ReadFirstMonster();
        }
       


        private void Button_Attack_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer = (Player)playerQueue.Dequeue();
            playerQueue.Enqueue(currentPlayer);

            Label_Info.Content = currentPlayer.Attack(currentMonster);
            if (currentMonster.Health > 0)
            {
                Random rand = new Random();
                int random = rand.Next(1, 5);

                switch (random)
                {
                    case 1:
                        Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerOne));
                        Label_P1Health.Content = playerOne.Health;
                        break;
                    case 2:
                        Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerTwo));
                        Label_P2Health.Content = playerTwo.Health;
                        break;
                    case 3:
                        Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerThree));
                        Label_P3Health.Content = playerThree.Health;
                        break;
                    case 4:
                        Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerFour));
                        Label_P4Health.Content = playerFour.Health;
                        break;
                }
                
            }
            else
            {
                killCount++;
                Label_Kills.Content = $"Monster Kills: {killCount}";
                currentMonster =dm.RandomMonster();
            }
            turnsPassed++;
            Label_Current_Turn.Content = $"Turn: {turnsPassed}";
        }

        private void Button_Heal_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer = (Player)playerQueue.Dequeue();
            

            Label_Info.Content = currentPlayer.Heal();
            playerQueue.Enqueue(currentPlayer);
            Random rand = new Random();
            int random = rand.Next(1, 5);

            switch (random)
            {
                case 1:
                    Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerOne));
                    Label_P1Health.Content = playerOne.Health;
                    break;
                case 2:
                    Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerTwo));
                    Label_P2Health.Content = playerTwo.Health;
                    break;
                case 3:
                    Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerThree));
                    Label_P3Health.Content = playerThree.Health;
                    break;
                case 4:
                    Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerFour));
                    Label_P4Health.Content = playerFour.Health;
                    break;
            }

            turnsPassed++;
            Label_Current_Turn.Content = $"Turn: {turnsPassed}";
        }
    } 
}
