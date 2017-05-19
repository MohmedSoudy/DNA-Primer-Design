using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Primer
{
    public partial class Form2 : Form
    {
        public primerDesign Myprimer;
        public Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Myprimer = new primerDesign();
            Myprimer.Primerdesign(form1, this);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //it cleans all the data from the form .. it should return to frist form
            Numbertxt.Clear();
            Primertxt.Clear();
            Numbertxt2.Clear();
            Revercetxt.Clear();
        }

        private void Numbertxt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Numbertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    public class Function_Ezzat
    {
        public int Primer_start;
        public int Reverce_start;
        //public char[] Primer = new char[20];
        //public char[] Reverce_Primer = new char[20];
        public char[] check = new char[6];
        //public String Sequence;
        public String Reverce_Sequence;
        public bool hair = true;
        //public Form2 form2;
        public void Get_Primer(Form2 form2)
        {


            //while (sr.Peek() != -1)
            //{

            //Sequence = 
            //Reverce_Sequence =
            //sr.Close();
            //}
            //Primer_start = int.Parse(form2.Numbertxt.Text);
            //Reverce_start = int.Parse(form2.Numbertxt2.Text);
            //if (Primer_start + 20 > Sequence.Length)
            //{
            //    MessageBox.Show("Primer is bigger than Sequence");
            //    return;
            //}
            //else
            //{
            //        for (int i = Primer_start, j = 0; i < Primer_start + 20; j++, i++)
            //        {
            //            if (Sequence[i] == 'A')
            //            {
            //                Primer[j] = 'T';
            //            }
            //            else if (Sequence[i] == 'T')
            //            {
            //                Primer[j] = 'A';
            //            }
            //            else if (Sequence[i] == 'C')
            //            {
            //                Primer[j] = 'G';
            //            }
            //            else if (Sequence[i] == 'G')
            //            {
            //                Primer[j] = 'C';
            //            }
            //        }
            //        for (int i = Reverce_start, j = 0; i < Reverce_start + 20; j++, i++)
            //        {
            //            if (Reverce_Sequence[i] == 'A')
            //            {
            //                Reverce_Primer[j] = 'T';
            //            }
            //            else if (Reverce_Sequence[i] == 'T')
            //            {
            //                Reverce_Primer[j] = 'A';
            //            }
            //            else if (Reverce_Sequence[i] == 'C')
            //            {
            //                Reverce_Primer[j] = 'G';
            //            }
            //            else if (Reverce_Sequence[i] == 'G')
            //            {
            //                Reverce_Primer[j] = 'C';
            //            }
            //        }
            //    }
            //    for (int i = 0; i < Primer.Length; i++)
            //    {
            //        if (i <= Primer.Length - 6)
            //        {
            //            int x = i;
            //            for (int j = 0; j < 6; j++)
            //            {
            //                check[j] = Primer[x];
            //                x++;
            //            }
            //            if (((check[0] == 'A') && (check[5] == 'T')) || ((check[0] == 'G') && (check[5] == 'C')) || ((check[0] == 'T') && (check[5] == 'A')) || ((check[0] == 'C') && (check[5] == 'G')))
            //            {
            //                if (((check[1] == 'A') && (check[4] == 'T')) || ((check[1] == 'G') && (check[4] == 'C')) || ((check[1] == 'T') && (check[4] == 'A')) || ((check[1] == 'C') && (check[4] == 'G')))
            //                {
            //                    if (((check[2] == 'A') && (check[3] == 'T')) || ((check[2] == 'G') && (check[3] == 'C')) || ((check[2] == 'T') && (check[3] == 'A')) || ((check[2] == 'C') && (check[3] == 'G')))
            //                    {
            //                        //cout << "Hairpin" << endl;
            //                        hair = false;
            //                        break;
            //                    }
            //                    continue;
            //                }
            //                continue;
            //            }
            //            else
            //            {
            //                hair = true;
            //                continue;
            //            }
            //        }
            //    }
            //    if (hair)
            //    {
            //        form2.Primertxt.Text = new String(Primer);
            //        form2.Revercetxt.Text = new String(Reverce_Primer);
            //    }
            //    else
            //        MessageBox.Show("Hairpin found!");
            //}
        }
    }
}
