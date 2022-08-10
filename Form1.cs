using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.IO;

namespace Computer_Odometer_V2
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer aTimer;
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Speed.KMHBox = Convert.ToInt32(KMHTextbox.Text);
            Speed.MS = ((double)Speed.MS + (double)Speed.KMHBox / 36.0);
            Speed.MSInt = Convert.ToInt32(Speed.MS);
            StatusTextBox.Text = "Running At: " + (KMHTextbox.Text) + " KM/h";
            MSTest.Text = Convert.ToString(Speed.MSInt);
            Speed.HMS = Speed.MSInt;
            // If the value is 1000 it would equal ONE second, so work out X speed to a second then divide by X. (Yay maths!)
            aTimer = new System.Timers.Timer(100); //1000
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += StartButton_Click;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if ((Speed.HMS % 100.0) == 0 && Speed.HMS != 0) //this add +1 to Hundred Metres every 100 metres
            {
                Unit.TripHundredMetre++;
            }

            if ((Speed.MSInt % 1000) == 0 && Speed.MSInt != 0)
            {
               Unit.OdoKilometre++;
               Unit.TripKilometre++;
            }

            if ((Speed.MSInt % 10000) == 0 && Speed.MSInt != 0)
            {
                Unit.OdoTenKilometre++;
                Unit.TripTenKilometre++;
            }

            if ((Speed.MSInt % 100000) == 0 && Speed.MSInt != 0)
            {
                Unit.OdoHundredKilometre++;
                Unit.TripHundredKilometre++;
            }

            if ((Speed.MSInt % 1000000) == 0 && Speed.MSInt != 0)
            {
                Unit.OdoThousandKilometre++;
            }

            if ((Speed.MSInt % 10000000) == 0 && Speed.MSInt != 0)
            {
                Unit.OdoTenThousandKilometre++;
            }

            if ((Speed.MSInt % 100000000) == 0 && Speed.MSInt != 0)
            {
                Unit.OdoHundredThousandKilometre++;
            }

            if (Unit.TripHundredMetre >= 9.9) //this resets the Hundred Metre counter everytime it hits 10.
            {
                Unit.TripHundredMetre -= 10;
            }


            if (Unit.OdoKilometre >= 9.9) //I know all the code under this is out of order, I'm okay with it!
            {
                Unit.OdoKilometre -= 10;
            }

            if (Unit.OdoTenKilometre >= 9.9)
            {
                Unit.OdoTenKilometre -= 10;
            }

            if (Unit.OdoHundredKilometre >= 9.9)
            {
                Unit.OdoHundredKilometre -= 10;
            }

            if (Unit.TripKilometre >= 9.9)
            {
                Unit.TripKilometre -= 10;
            }

            if (Unit.TripTenKilometre >= 9.9)
            {
                Unit.TripTenKilometre -= 10;
            }

            if (Unit.TripHundredKilometre >= 9.9)
            {
                Unit.TripHundredKilometre -= 10;
            }

            if (Unit.OdoThousandKilometre >= 9.9)
            {
                Unit.OdoThousandKilometre -= 10;

            }
            if (Unit.OdoTenThousandKilometre >= 9.9)
            {
                Unit.OdoTenThousandKilometre -= 10;
            }

            if (Unit.OdoHundredThousandKilometre >= 9.9)
            {
                Unit.OdoHundredThousandKilometre -= 10;
            }

            if (Speed.HMS >= 100)
            {
                Speed.HMS -= 100; //This line of code makes the 100m trip part work over 100KM/h speeds. Otherwise it wigs out! (Because it measures 100m spacing)
            }

            // Here is all the Odo/Trip Box Outputs. Once Again out of order, Still okay with it haha!
            OdoKilometre.Text = Convert.ToString(Unit.OdoKilometre);
            OdoTenKilometre.Text = Convert.ToString(Unit.OdoTenKilometre);
            OdoHundredKilometre.Text = Convert.ToString(Unit.OdoHundredKilometre);
            OdoThousandKilometre.Text = Convert.ToString(Unit.OdoThousandKilometre);
            OdoTenThousandKilometre.Text = Convert.ToString(Unit.OdoTenThousandKilometre);
            OdoHundredThousandKilometre.Text = Convert.ToString(Unit.OdoHundredThousandKilometre);
            TripKilometre.Text = Convert.ToString(Unit.TripKilometre);
            TripHundredMetre.Text = Convert.ToString(Unit.TripHundredMetre);
            TripTenKilometre.Text = Convert.ToString(Unit.TripTenKilometre);
            TripHundredKilometre.Text = Convert.ToString(Unit.TripHundredKilometre);

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StatusTextBox.Text = "Odometer Stopped!";
            aTimer.Enabled = false;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            StatusTextBox.Text = "Odometer Reading Loaded!";
            // create reader & open file
            TextReader tr = new StreamReader("SavedGame.txt");

            // read lines of text
            string KilometreString = tr.ReadLine();
            string TenKilometreString = tr.ReadLine();
            string HundredKilometreString = tr.ReadLine();
            string ThousandKilometreString = tr.ReadLine();
            string TenThousandKilometreString = tr.ReadLine();
            string HundredThousandKilometreString = tr.ReadLine();

            //Convert the strings to int
            Unit.OdoKilometre = Convert.ToInt32(KilometreString);
            Unit.OdoTenKilometre = Convert.ToInt32(TenKilometreString);
            Unit.OdoHundredKilometre = Convert.ToInt32(HundredKilometreString);
            Unit.OdoThousandKilometre = Convert.ToInt32(ThousandKilometreString);
            Unit.OdoTenThousandKilometre = Convert.ToInt32(TenThousandKilometreString);
            Unit.OdoHundredThousandKilometre = Convert.ToInt32(HundredThousandKilometreString);

            //This should display Odo readings on load
            OdoKilometre.Text = Convert.ToString(Unit.OdoKilometre);
            OdoTenKilometre.Text = Convert.ToString(Unit.OdoTenKilometre);
            OdoHundredKilometre.Text = Convert.ToString(Unit.OdoHundredKilometre);
            OdoThousandKilometre.Text = Convert.ToString(Unit.OdoThousandKilometre);
            OdoTenThousandKilometre.Text = Convert.ToString(Unit.OdoTenThousandKilometre);
            OdoHundredThousandKilometre.Text = Convert.ToString(Unit.OdoHundredThousandKilometre);

            // close the stream
            tr.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            StatusTextBox.Text = "Odometer Reading Saved!";
            TextWriter tw = new StreamWriter("SavedGame.txt");

            // write lines of text to the file
            tw.WriteLine(Unit.OdoKilometre);
            tw.WriteLine(Unit.OdoTenKilometre);
            tw.WriteLine(Unit.OdoHundredKilometre);
            tw.WriteLine(Unit.OdoThousandKilometre);
            tw.WriteLine(Unit.OdoTenThousandKilometre);
            tw.WriteLine(Unit.OdoHundredThousandKilometre);

            // close the stream     
            tw.Close();
        }
    }
}
