using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Sequence = textBox1.Text.ToUpper();
            if (Sequence.Trim() == "")        //Removes Any Whitespace From our string
            {
                //MessageBox.Show("Enter A valid DNA Sequence");
                textBox1.Clear();
                return;
            }
            for (int i = 0; i < Sequence.Length; i++)
            {
                if (char.IsNumber(Sequence[i]))
                {
                    MessageBox.Show("Your Sequence containts Number");
                    textBox1.Clear();
                    return;
                }
            }
            foreach (char str in Sequence)
            {
                if (str != 'A' && str != 'C' && str != 'G' && str != 'T')
                {
                    MessageBox.Show("Enter A valid DNA Sequence");
                    textBox1.Clear();
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 form2 = new Form2();
            form2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }     // End class form 
    
   public class primerDesign
    {
        public char[] primer = new char[20];
        public char[] Reverce_Primer = new char[20];

     
        public bool Primerdesign(Form1 form ,Form2 form2)
        {
            int Primer_start;
            int Reverce_start;
            char[] check = new char[6];
            string Sequence;
            bool hair = true;
            TextBox Sequence_Text = Application.OpenForms["Form1"].Controls["textBox1"] as TextBox;
            Sequence = Sequence_Text.Text;
            char[] ReverceSequence = new char[Sequence.Length];
            Primer_start = int.Parse(form2.Numbertxt.Text);
            Reverce_start = int.Parse(form2.Numbertxt2.Text);
            if (Primer_start + 20 > Sequence.Length)
            {
                MessageBox.Show("Primer is bigger than Sequence");
                return false;
            }
            
            for (int i = 0; i < Sequence.Length; i++)
            {
                if (Sequence[i] == 'A')
                {
                    ReverceSequence[i] = 'T';
                }
                else if (Sequence[i] == 'T')
                {
                    ReverceSequence[i] = 'A';
                }
                else if (Sequence[i] == 'C')
                {
                    ReverceSequence[i] = 'G';
                }
                else if (Sequence[i] == 'G')
                {
                    ReverceSequence[i] = 'C';
                }
            }
            string Reverce_Sequence = new string(ReverceSequence);
             for (int i = Primer_start, j = 0; i < Primer_start + 20; j++, i++)
                {
                    if (Sequence[i] == 'A')
                    {
                        primer[j] = 'T';
                    }
                    else if (Sequence[i] == 'T')
                    {
                        primer[j] = 'A';
                    }
                    else if (Sequence[i] == 'C')
                    {
                        primer[j] = 'G';
                    }
                    else if (Sequence[i] == 'G')
                    {
                        primer[j] = 'C';
                    }
                }
                
                for (int i = Reverce_start, j = 0; i < Reverce_start + 20; j++, i++)
                {
                    if (Reverce_Sequence[i] == 'A')
                    {
                        Reverce_Primer[j] = 'T';
                    }
                    else if (Reverce_Sequence[i] == 'T')
                    {
                        Reverce_Primer[j] = 'A';
                    }
                    else if (Reverce_Sequence[i] == 'C')
                    {
                        Reverce_Primer[j] = 'G';
                    }
                    else if (Reverce_Sequence[i] == 'G')
                    {
                        Reverce_Primer[j] = 'C';
                    }
                }
            for (int i = 0; i < primer.Length; i++)
            {
                if (i <= primer.Length - 6)
                {
                    int x = i;
                    for (int j = 0; j < 6; j++)
                    {
                        check[j] = primer[x];
                        x++;
                    }
                    if (((check[0] == 'A') && (check[5] == 'T')) || ((check[0] == 'G') && (check[5] == 'C')) || ((check[0] == 'T') && (check[5] == 'A')) || ((check[0] == 'C') && (check[5] == 'G')))
                    {
                        if (((check[1] == 'A') && (check[4] == 'T')) || ((check[1] == 'G') && (check[4] == 'C')) || ((check[1] == 'T') && (check[4] == 'A')) || ((check[1] == 'C') && (check[4] == 'G')))
                        {
                            if (((check[2] == 'A') && (check[3] == 'T')) || ((check[2] == 'G') && (check[3] == 'C')) || ((check[2] == 'T') && (check[3] == 'A')) || ((check[2] == 'C') && (check[3] == 'G')))
                            {
                                //cout << "Hairpin" << endl;
                                hair = false;
                                break;
                            }
                            continue;
                        }
                        continue;
                    }
                    else
                    {
                        hair = true;
                        continue;
                    }
                }
            }
            string Primer_toString = new string(primer);
            string Reverse_tostring = new string(Reverce_Primer);
            if (!hair || calculate_TM(Primer_toString,Reverse_tostring) ||Amr_Task(Primer_toString,Reverse_tostring))
            {
                form2.Primertxt.Text = new String(primer);
                form2.Revercetxt.Text = new String(Reverce_Primer);
                return false;
            }
            else
            {
                MessageBox.Show("The required sequence can't be a primer");
            }
            return true;
        
        }
        public bool Amr_Task(string primer ,string forward)
        {
            char[] forword_primer = new char[20];
            string x = " ";
            x = primer;
            for (int i = 0; i < 20; i++)
            {
                forword_primer[i] = x[i];
            }
            char[] reverse_primer = new char[20];
            //Console.WriteLine("Enter reverse primer");
            //Console.ReadLine();           
            string z = new string( Reverce_Primer);
            for (int i = 0; i < 20; i++)
            {
                reverse_primer[i] = z[i];
            }
            if (comp(forword_primer[17], reverse_primer[17]))
            {
                if (comp(forword_primer[18], reverse_primer[18]))
                {
                    if (comp(forword_primer[19], reverse_primer[19]))
                    {
                        //         Console.WriteLine("Sorry Your Primer have a tail complementry");
                        return false; //Not primer
                    }
                    return true;
                }
            }
            return true;
        }
        public bool comp(char base1, char base2)
        {
            if ((base1 == 'A' && base2 == 'T') || (base1 == 'T' && base2 == 'A') || (base1 == 'G' && base2 == 'C') || (base1 == 'C' && base2 == 'G'))
            {
                // Console.WriteLine("Sorry Your Primer have a tail complementry");
                return true;
            }

            else
                return false;
        }
        public bool calculate_TM(string Forward,string Reverse)
        {
            int A_TForward = 0;
            int C_GForward = 0;
            int A_TReverse = 0;
            int C_GReverse = 0;
            int Forward_TM,annealing_Forward=0;
            int Reverse_TM,annealing_Reverse=0;
            foreach(char str1 in Forward)
            {
                if(str1 == 'A'|| str1 == 'T')
                {
                    A_TForward++;
                }
                if(str1 == 'C'|| str1 == 'G')
                {
                    C_GForward++;
                }
                Forward_TM = (2 * (A_TForward) + 4 * (C_GForward));
                annealing_Forward = Forward_TM - 5;
            }
            foreach (char str1 in Reverse)
            {
                if (str1 == 'A' || str1 == 'T')
                {
                    A_TReverse++;
                }
                if (str1 == 'C' || str1 == 'G')
                {
                    C_GReverse++;
                }
                Reverse_TM = (2 * (A_TReverse) + 4 * (C_GReverse));
                annealing_Reverse = Reverse_TM - 5;
            }
            if(Math.Abs(annealing_Forward-annealing_Reverse)>5)
            {
                //MessageBox.Show("Can't Be A Primer");
                return true;     //Not A primer
            }
            return false;        //Primer
        }//End Calc
    }    //End class
}        //End namespace primer
