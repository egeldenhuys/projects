using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HackMe1
{
    public partial class Form1 : Form
    {
        int TheNumber;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateNumber();

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            GenerateNumber();
        }

        private void GenerateNumber()
        {
            if (TheNumber == 100)
            {
                lblWin.Visible = true;
            }

            TheNumber = Rnd(0, 100);
            lblNumber.Text = TheNumber.ToString();

           
        }

        private int Rnd(int min, int max)
        {
            Random randomNumber = new Random();
            return randomNumber.Next(min, max);

        }

    }
}
