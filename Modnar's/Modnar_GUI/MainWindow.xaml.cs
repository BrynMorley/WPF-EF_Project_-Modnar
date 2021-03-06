﻿using System;
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
using Modnar_View;

namespace Modnar_GUI
{ 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseManager dm = new DatabaseManager();
        
      public Player playerOne = new Player("Player 1", 100, 10,1,100);
      public  Player playerTwo = new Player("Player 2", 100, 10,1,100);
      public  Player playerThree = new Player("Player 3", 100, 10,1,100);
      public  Player playerFour = new Player("Player 4", 100, 10,1,100);
            
        Player currentPlayer = new Player("Default", 50, 5, 1,100);

        Monster currentMonster = new Monster("Monster", 100, 10, 2);

        Queue playerQueue = new Queue();

       public int killCount = 0;
        int playerDeaths = 0;
        int turnsPassed = 0;

        public MainWindow()
        {  
            InitializeComponent();
            
            PlayerSelect playerSelect = new PlayerSelect();
            playerSelect.ShowDialog();

            Label_P1Name.Content = playerOne.Name;
            Label_P1Health.Content = $"Health :{playerOne.Health}";

            Label_P2Name.Content = playerTwo.Name;
            Label_P2Health.Content = $"Health :{playerTwo.Health}";

            Label_P3Name.Content = playerThree.Name;
            Label_P3Health.Content = $"Health :{playerThree.Health}";

            Label_P4Name.Content = playerFour.Name;
            Label_P4Health.Content = $"Health :{playerFour.Health}";

            playerQueue.Enqueue(playerOne);
            playerQueue.Enqueue(playerTwo);
            playerQueue.Enqueue(playerThree);
            playerQueue.Enqueue(playerFour);


            currentMonster = dm.ReadFirstMonster();
            Label_MonsterName.Content = $"Monster: {currentMonster.Name}";
            Label_MonsterHealth.Content = $"Health:{currentMonster.Health}";
        }
       


        private void Button_Attack_Click(object sender, RoutedEventArgs e)
        {
           
            currentPlayer = (Player)playerQueue.Dequeue();

            //int i = 0;
            //while (currentPlayer.Health<=0 && i <4)  
            //{
            //    i++;

            //    if (i== 4)
            //    {
            //        GameOver gameOver = new GameOver();
            //        gameOver.ShowDialog();
            //    }
            //    currentPlayer = (Player)playerQueue.Dequeue();
            //} 

            //if (playerDeaths == 4)
            //{
            //    GameOver gameOver = new GameOver();
            //    gameOver.ShowDialog();
            //}

            playerQueue.Enqueue(currentPlayer);
            if (currentPlayer.Health > 0)
            {




                Label_Info.Content = currentPlayer.Attack(currentMonster);
                Label_MonsterHealth.Content = $"Health:{currentMonster.Health}";

                if (currentMonster.Health > 0)
                {
                    Random rand = new Random();
                    int random = rand.Next(1, 5);

                    switch (random)
                    {
                        case 1:
                            Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerOne));
                            Label_P1Health.Content = $"Health :{playerOne.Health}";
                            Label_P1Name.Content = playerOne.Name;
                            if (playerOne.Health < 0) { Label_P1Health.Content = "DEAD"; playerDeaths++; }
                            break;
                        case 2:
                            Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerTwo));
                            Label_P2Name.Content = playerTwo.Name;
                            Label_P2Health.Content = $"Health :{playerTwo.Health}";
                            if (playerTwo.Health < 0) { Label_P2Health.Content = "DEAD"; playerDeaths++; }
                            break;
                        case 3:
                            Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerThree));
                            Label_P3Name.Content = playerThree.Name;
                            Label_P3Health.Content = $"Health :{playerThree.Health}";
                            if (playerThree.Health < 0) { Label_P3Health.Content = "DEAD"; playerDeaths++; }
                            break;
                        case 4:
                            Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerFour));
                            Label_P4Name.Content = playerFour.Name;
                            Label_P4Health.Content = $"Health :{playerFour.Health}";
                            if (playerFour.Health < 0) { Label_P4Health.Content = "DEAD"; playerDeaths++; }
                            break;
                    }

                }
                else
                {
                    killCount++;
                    Label_Kills.Content = $"Monster Kills: {killCount}";
                    currentMonster = dm.RandomMonster();
                    Label_MonsterName.Content = $"Monster: {currentMonster.Name}";
                    Label_MonsterHealth.Content = $"Health:{currentMonster.Health}";
                }

                turnsPassed++;
                Label_Current_Turn.Content = $"Turn: {turnsPassed}";
            }
           
        }

        private void Button_Heal_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer = (Player)playerQueue.Dequeue();
            playerQueue.Enqueue(currentPlayer);

            if (currentPlayer.Health > 0)
            {
                if (currentPlayer.Name == playerOne.Name)
                {
                    Label_Info.Content = playerOne.Heal();
                    Label_P1Name.Content = playerOne.Name;
                    Label_P1Health.Content = $"Health :{playerOne.Health}";
                }
                else if (currentPlayer.Name == playerTwo.Name)
                {
                    Label_Info.Content = playerTwo.Heal();
                    Label_P2Name.Content = playerTwo.Name;
                    Label_P2Health.Content = $"Health :{playerTwo.Health}";
                }
                else if (currentPlayer.Name == playerThree.Name)
                {
                    Label_Info.Content = playerThree.Heal();
                    Label_P3Name.Content = playerThree.Name;
                    Label_P3Health.Content = $"Health :{playerThree.Health}";
                }
                else if (currentPlayer.Name == playerFour.Name)
                {
                    Label_Info.Content = playerFour.Heal();
                    Label_P4Health.Content = $"Health :{playerFour.Health}";
                    Label_P4Name.Content = playerFour.Name;
                }






                Random rand = new Random();
                int random = rand.Next(1, 5);

                switch (random)
                {
                    case 1:
                        Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerOne));
                        Label_P1Name.Content = playerOne.Name;
                        Label_P1Health.Content = $"Health :{playerOne.Health}";
                        if (playerOne.Health < 0) { Label_P1Health.Content = "DEAD"; playerDeaths++; }
                        break;
                    case 2:
                        Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerTwo));
                        Label_P2Name.Content = playerTwo.Name;
                        Label_P2Health.Content = $"Health :{playerTwo.Health}";
                        if (playerTwo.Health < 0) { Label_P2Health.Content = "DEAD"; playerDeaths++; }
                        break;
                    case 3:
                        Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerThree));
                        Label_P3Name.Content = playerThree.Name;
                        Label_P3Health.Content = $"Health :{playerThree.Health}";
                        if (playerThree.Health < 0) { Label_P3Health.Content = "DEAD"; playerDeaths++; }
                        break;
                    case 4:
                        Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerFour));
                        Label_P4Health.Content = $"Health :{playerFour.Health}";
                        Label_P4Name.Content = playerFour.Name;
                        if (playerFour.Health < 0) { Label_P4Health.Content = "DEAD"; playerDeaths++; }
                        break;
                }

                turnsPassed++;
                Label_Current_Turn.Content = $"Turn: {turnsPassed}";
            }
        }

        private void Button_Taunt_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer = (Player)playerQueue.Dequeue();
            Label_Info.Content = currentPlayer.Taunt(currentMonster);
            playerQueue.Enqueue(currentPlayer);
            if (currentPlayer.Health > 0)
            {
                if (currentPlayer.Name == playerOne.Name)
                {
                    Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerOne));
                    Label_P1Health.Content = $"Health :{playerOne.Health}";
                    Label_P1Name.Content = playerOne.Name;
                    if (playerOne.Health < 0) { Label_P1Health.Content = "DEAD"; playerDeaths++; }
                }
                else if (currentPlayer.Name == playerTwo.Name)
                {
                    Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerTwo));
                    Label_P2Name.Content = playerTwo.Name;
                    Label_P2Health.Content = $"Health :{playerTwo.Health}";
                    if (playerTwo.Health < 0) { Label_P2Health.Content = "DEAD"; playerDeaths++; }
                }
                else if (currentPlayer.Name == playerThree.Name)
                {
                    Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerThree));
                    Label_P3Name.Content = playerThree.Name;
                    Label_P3Health.Content = $"Health :{playerThree.Health}";
                    if (playerThree.Health < 0) { Label_P3Health.Content = "DEAD"; playerDeaths++; }
                }
                else if (currentPlayer.Name == playerFour.Name)
                {
                    Label_Info.Content += Environment.NewLine + (currentMonster.Attack(playerFour));
                    Label_P4Health.Content = $"Health :{playerFour.Health}";
                    Label_P4Name.Content = playerFour.Name;
                    if (playerFour.Health < 0) { Label_P4Health.Content = "DEAD"; playerDeaths++; }
                }



                turnsPassed++;
                Label_Current_Turn.Content = $"Turn: {turnsPassed}";
            }
        }

        private void Button_CreatePlayer_Click(object sender, RoutedEventArgs e)
        {
            CreatePlayer createPlayer = new CreatePlayer();
            createPlayer.Show();
        }

        private void Button_SelectPlayers_Click(object sender, RoutedEventArgs e)
        {
            playerQueue.Dequeue();
            playerQueue.Dequeue();
            playerQueue.Dequeue();
            playerQueue.Dequeue();
            
            PlayerSelect playerSelect = new PlayerSelect();
            playerSelect.ShowDialog();

            Label_P1Name.Content = playerOne.Name;
            Label_P1Health.Content = $"Health :{playerOne.Health}";

            Label_P2Name.Content = playerTwo.Name;
            Label_P2Health.Content = $"Health :{playerTwo.Health}";

            Label_P3Name.Content = playerThree.Name;
            Label_P3Health.Content = $"Health :{playerThree.Health}";

            Label_P4Name.Content = playerFour.Name;
            Label_P4Health.Content = $"Health :{playerFour.Health}";

            playerQueue.Enqueue(playerOne);
            playerQueue.Enqueue(playerTwo);
            playerQueue.Enqueue(playerThree);
            playerQueue.Enqueue(playerFour);

        }

        private void Button_CreateMonster_Click(object sender, RoutedEventArgs e)
        {
            CreateMonster createMonster = new CreateMonster();
            createMonster.Show();
        }
    } 
}
