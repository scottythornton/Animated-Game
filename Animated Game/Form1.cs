using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animated_Game
{
    public partial class Form1 : Form
    {
        Random randGen = new Random();
        
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Program goes directly to the GameScreen method on start
            GameScreen gs = new GameScreen();
            this.Controls.Add(gs);
        }
    }
}
