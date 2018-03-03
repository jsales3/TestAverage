using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double Average(int[] iArray)
        {
            int total = 0;
            double average;

            for(int i = 0; i < iArray.Length; i++)
            {
                total += iArray[i]; 
            }

            average = (double)total / iArray.Length;

            return average;
        }

        private int Highest(int[] iArray)
        {
            int highest = iArray[0];

            for(int i = 1; i < iArray.Length; i++)
            {
                if(iArray[i] > highest)
                {
                    highest = iArray[i];
                }
            }

            return highest;
        }

        private int Lowest(int[] iArray)
        {

            int lowest = iArray[0];

            for(int i = 1; i < iArray.Length; i++)
            {
                if(iArray[i] < lowest)
                {
                    lowest = iArray[i];
                }
            }

            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {

                const int SIZE = 5;
                int[] scores = new int[SIZE];
                int index = 0;
                int highestScore;
                int lowestScore;
                double averageScore;
                StreamReader inputFile;

                inputFile = File.OpenText("TestScores.txt");

                while (!inputFile.EndOfStream && index < scores.Length)
                {
                    scores[index] = int.Parse(inputFile.ReadLine());
                    index++;

                }

                inputFile.Close();

                foreach (int value in scores)
                {
                    testScoresListBox.Items.Add(value);
                }

                highestScore = Highest(scores);
                lowestScore = Lowest(scores);
                averageScore = Average(scores);

                highScoreLabel.Text = highestScore.ToString();
                lowScoreLabel.Text = lowestScore.ToString();
                averageScoreLabel.Text = averageScore.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
