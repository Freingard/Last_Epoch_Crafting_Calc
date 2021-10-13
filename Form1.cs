using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LE_Craft_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            checkBox2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var calc = new CraftCalculations();
            //string craftResults;
            int[] initAffixes = { Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown4.Value) };
            int[] desiredAffixes = { Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown6.Value), Convert.ToInt32(numericUpDown7.Value), Convert.ToInt32(numericUpDown8.Value) };
            int instability = Convert.ToInt32(numericUpDown9.Value);
            //var lastPoint = new CraftingPoint();
            var lastPoint = calc.Calculating(instability, initAffixes, desiredAffixes, checkBox2.Checked);
           // results = "probability="+lastPoint.probability*100+"%";
           // results += lastPoint.howToCraftResult;
            label1.Text = lastPoint.howToCraftResult;
            label11.Text = lastPoint.probability * 100 + "%";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value>5)
            {
                numericUpDown1.Value = 5;
            }
            if (numericUpDown1.Value < 0)
            {
                numericUpDown1.Value = 0;
            }
            if (numericUpDown5.Value < numericUpDown1.Value) numericUpDown5.Value = numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value > 5)
            {
                numericUpDown2.Value = 5;
            }
            if (numericUpDown2.Value < 0)
            {
                numericUpDown2.Value = 0;
            }
            if (numericUpDown6.Value < numericUpDown2.Value) numericUpDown6.Value = numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value > 5)
            {
                numericUpDown3.Value = 5;
            }
            if (numericUpDown3.Value < 0)
            {
                numericUpDown3.Value = 0;
            }
            if (numericUpDown7.Value < numericUpDown3.Value) numericUpDown7.Value = numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown4.Value > 5)
            {
                numericUpDown4.Value = 5;
            }
            if (numericUpDown4.Value < 0)
            {
                numericUpDown4.Value = 0;
            }
            if (numericUpDown8.Value < numericUpDown4.Value) numericUpDown8.Value = numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown5.Value > 5)
            {
                numericUpDown5.Value = 5;
            }
            if (numericUpDown5.Value < numericUpDown1.Value)
            {
                numericUpDown5.Value = numericUpDown1.Value;
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown6.Value > 5)
            {
                numericUpDown6.Value = 5;
            }
            if (numericUpDown6.Value < numericUpDown2.Value)
            {
                numericUpDown6.Value = numericUpDown2.Value;
            }
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown7.Value > 5)
            {
                numericUpDown7.Value = 5;
            }
            if (numericUpDown7.Value < numericUpDown3.Value)
            {
                numericUpDown7.Value = numericUpDown3.Value;
            }
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown8.Value > 5)
            {
                numericUpDown8.Value = 5;
            }
            if (numericUpDown8.Value < numericUpDown4.Value)
            {
                numericUpDown8.Value = numericUpDown4.Value;
            }
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57)&&e.KeyChar!='\b')
            {
                e.Handled = true;
            }
        }
        private void numericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void numericUpDown3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void numericUpDown4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void numericUpDown5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void numericUpDown6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void numericUpDown7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void numericUpDown8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value > 100)
            {
                numericUpDown3.Value = 100;
            }
            if (numericUpDown3.Value < 0)
            {
                numericUpDown3.Value = 0;
            }
        }
        private void numericUpDown9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
