using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bazededate
{
    public partial class Form2 : Form
    {
       public string variable1;
       public string variable2;
        public string variable3;
        public string variable4;
        public string variable5;
        int type;
        public Form2(int i)
        {
            type = i;
            InitializeComponent();
            panel_vin.Parent = panel_nume_client.Parent;
            panel_add_vanz.Parent= panel_nume_client.Parent;
            panel_idpass.Parent = panel_nume_client.Parent;
            panel_addclient.Parent = panel_nume_client.Parent;
            panel_add_masina.Parent = panel_nume_client.Parent;
            panel_add_masina.Visible = false;
            panel_add_vanz.Visible = false;
            panel_addclient.Visible = false;
            panel_vin.Visible = false;
            panel_nume_client.Visible = false;
            panel_idpass.Visible = false;
           switch(i)
            {
                case 0:
                    panel_vin.Visible = true;
                    break;
                case 1:
                    panel_nume_client.Visible = true;
                    break;
                case 2:
                    panel_add_vanz.Visible = true;
                    break;
                case 3:
                    panel_idpass.Visible = true;
                    break;
                case 4:
                    panel_addclient.Visible = true;
                    break;
                case 5:
                    panel_add_masina.Visible = true;
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(type==1)
            {
                variable1 = text_nume.Text;
                variable2 = text_prenume.Text;
            }
            if(type==0)
            {
                variable1 = textvin.Text;
                

            }
            if(type==3)
            {
                variable1 = name.Text;
                    variable2 = pass.Text;
            }
            if(type==4)
            {
                variable1 = namec.Text;
                variable2 = prenumec.Text;
                variable3 = telefonc.Text;
                variable4 = numarcardc.Text;
            }
            if(type==5)
            {
                variable1 = textBox4.Text;
                variable2 = textBox3.Text;
                variable3 = textBox2.Text;
                variable4 = textBox1.Text;
                variable5 = textBox5.Text;
            }
            this.Close();
        }
    }
}
