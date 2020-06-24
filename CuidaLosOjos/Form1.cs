using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuidaLosOjos
{
    public partial class mainForm : Form
    {

        private int timeLeft;
        private int interval;

        public mainForm()
        {
            InitializeComponent();
            timerBox.Text = "0";
           
            
        }

        private void timerBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
           } 
        }

        private void startBtn_Click(object sender, EventArgs e)
        {

            if (startBtn.Text == "START")
            {
                if (timerBox.Text == "0")
                {
                    MessageBox.Show("Combien de minutes entre chaque alertes ?", "Saisie un interval de temps", MessageBoxButtons.OK);
                }
                else
                {
                    startBtn.Text = "STOP";                  
                    interval = Convert.ToInt32(timerBox.Text);
                    timeLeft = (interval * 60);

                   
                    timerBox.ReadOnly = true;

                    timer.Tick += new EventHandler(timer_Tick);
                    timer.Start();
                }
            } else
            {
                startBtn.Text = "START";
                timer.Stop();
                timeLeft = 0;
                timerBox.ReadOnly = false;
                timerBox.Text = "0";
            }




        }

        private void timer_Tick(object sender, EventArgs e)
        {            
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                var timespan = TimeSpan.FromSeconds(timeLeft);
                int minutesLeft = (timeLeft / 60) + 1;
                timerBox.Text = minutesLeft.ToString();
            }
            else
            {
                timer.Stop();                
                System.Windows.Forms.MessageBox.Show("Regarde au loin pendant 2 minutes !", "Cuida Los Ojos Querida !", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                timerBox.Text = interval.ToString();
                timeLeft = (interval * 60);
                timer.Start();



            }
        }

        private void timerBox_Click(object sender, EventArgs e)
        {
            timerBox.Text = "";
        }
    }
}
