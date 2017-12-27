using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace bazededate
{
   
    public partial class down : Form
    {
        int idtype=0;
        string name, pass;
        DataClasses1DataContext dbContext;
        string variable1;
        string variable2;
        string variable3;
        string variable4;
        string variable5;
        Panel a;
        public down()
        {
           
            FormBorderStyle = FormBorderStyle.None;
        WindowState = FormWindowState.Maximized;
          InitializeComponent();
           dbContext = new DataClasses1DataContext();
            


                panel_mecanic.Parent = panel_client.Parent;
           panel_vanz.Parent = panel_client.Parent;
            panel_director.Parent = panel_client.Parent;
            panel_client.Visible = false;
            panel_mecanic.Visible = false;
            panel_vanz.Visible = false;
            panel_director.Visible = false;
            dataGridView4.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Client_Click(object sender, EventArgs e)
        {
            if(a!=null)
            a.Visible = false;
            a = panel_client;
            panel_client.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // System.Windows.Forms.MessageBox.Show("My message here");
            Form2 dialog1 = new Form2(0);///numeclient
            dialog1.ShowDialog();
            variable1=dialog1.variable1;

            //var projection = from emp in dbContext.proprietars
            //                 join dealer in dbContext.mecanics on emp.masinas equals dealer.ID
            //                 select contact;


            //List <bazededate.reparatie> list = projection.ToList();
            //var  projection = from rep in dbContext.reparaties
            //                    select rep;
            var projection = (from rep in dbContext.reparaties
                              join oper in dbContext.operaties on rep.id equals oper.fk_reparatie
                              join mecan in dbContext.mecanics on oper.fk_mecanic equals mecan.id
                              where rep.fk_masina == variable1
                              select new { IdReparatie = rep.id, NumeMecanic = mecan.nume + mecan.prenume ,DescriereReparatie = rep.descriere,DescriereOperatie = oper.descriere }).ToList();
            //  List<bazededate.reparatie> list =
            //var projector = from emp in dbContext.proprietars
            //                select emp;
            //                 join dealer in dbContext.mecanics on emp.masinas equals dealer.ID
            //                 select contact;
            dataGridView4.DataSource = projection;

            //dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView4.AutoResizeColumns();
            dataGridView4.Visible = true;
      

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 dialog1 = new Form2(1);//vinclient
            dialog1.ShowDialog();
            variable1 = dialog1.variable1;
            variable2 = dialog1.variable2;

            //// Prompt.ShowDialog("stuff", "caption");
            ////var queryLondonCustomers = from cust in
            ////                               // where cust.City == "London"
            ////                           select cust;

            //dataGridView1.DataSource = queryLondonCustomers;
            var projection = (from rep in dbContext.reparaties
                              join oper in dbContext.operaties on rep.id equals oper.fk_reparatie
                              join mecan in dbContext.mecanics on oper.fk_mecanic equals mecan.id
                              join masin in dbContext.masinas on rep.fk_masina equals masin.vin
                              join prop in dbContext.proprietars on masin.fk_proprietar equals prop.id
                              where prop.nume == variable1 && prop.prenume==variable2
                              select new { IdReparatie = rep.id,Idmasina=masin.vin, NumeMecanic = mecan.nume + mecan.prenume, DescriereReparatie = rep.descriere, DescriereOperatie = oper.descriere }).ToList();
            //  List<bazededate.reparatie> list =
            //var projector = from emp in dbContext.proprietars
            //                select emp;
            //                 join dealer in dbContext.mecanics on emp.masinas equals dealer.ID
            //                 select contact;
            dataGridView4.DataSource = projection;

            //dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView4.AutoResizeColumns();
            dataGridView4.Visible = true;
        }

        private void mecanic_Click(object sender, EventArgs e)
        {
            Form2 dialog1 = new Form2(3);//vinclient
            dialog1.ShowDialog();
            name = dialog1.variable1;
            pass = dialog1.variable2;
            idtype = 1;
            if (name.Count() != 0&&pass.Count()!=0)
            {
                if (a != null)
                    a.Visible = false;
                a = panel_mecanic;
                panel_mecanic.Visible = true;
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            if (a != null)
                a.Visible = false;
            a = panel_vanz;
            panel_vanz.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (a != null)
                a.Visible = false;
            a = panel_director;
            panel_director.Visible = true;
        }

        private void vezi_dispozitive_Click(object sender, EventArgs e)
        {
            var projection = (from rep in dbContext.dispozitivs
                              join brev in dbContext.tip_brevets on rep.brevet_necesar equals brev.id
                                    
                             
                              select new { DispozitivId=rep.id,DispozitivNume=rep.nume,TipBrevet=brev.tip }).ToList();
            dataGridView1.DataSource = projection;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            var projection = (from rep in dbContext.brevet_dispozitivs
                              join mecs in dbContext.mecanics on rep.fk_mecanic equals mecs.id
                              join brev in dbContext.tip_brevets on rep.tipbrevet equals brev.id
                              where mecs.nume == name


                              select new { brev.tip,brev.id }).ToList();
            dataGridView1.DataSource = projection;
        }

        private void cauta_dispozitiv_Click(object sender, EventArgs e)
        {
            var projection = (from rep in dbContext.dispozitivs
                              join brev in dbContext.tip_brevets on rep.brevet_necesar equals brev.id
                              where rep.nume == textBox1.Text

                              select new { DispozitivId = rep.id, DispozitivNume = rep.nume, TipBrevet = brev.tip }).ToList();
            dataGridView1.DataSource = projection;
        }

        private void Cauta_masina_Click(object sender, EventArgs e)
        {
            var projection = (from rep in dbContext.masinas 
                              join proprietarul in dbContext.proprietars on rep.fk_proprietar equals proprietarul.id
                              join tipul in dbContext.tips on rep.fk_tip equals tipul.id
                              join fabric in dbContext.fabricants on rep.fk_brand equals fabric.id
                              where rep.vin == textBox1.Text

                              select new { NumeProprietar=proprietarul.nume+proprietarul.prenume,TelefonProprietar=proprietarul.telefon,NumeFabricant=fabric.nume,NumarTelefonFabricant=fabric.nr_telefon,TipulMasinii=tipul.nume }).ToList();
            dataGridView1.DataSource = projection;
        }

        private void button13_Click(object sender, EventArgs e)
        {

            var projection = (from rep in dbContext.masinas
                              join repas in dbContext.reparaties on rep.vin equals repas.fk_masina
                              join oper in dbContext.operaties on repas.id equals oper.fk_reparatie
                              join mecan in dbContext.mecanics on oper.fk_mecanic equals mecan.id
                              where rep.vin == textBox1.Text

                              select new { IdReparatie = repas.id, NumeMecanic = mecan.nume + mecan.prenume, DescriereReparatie = repas.descriere, DescriereOperatie = oper.descriere }).ToList();
            dataGridView1.DataSource = projection;
        }

        private void descrierea_reparatiei_Click(object sender, EventArgs e)
        {
            var projection = (from repas in dbContext.reparaties
                              
                              join oper in dbContext.operaties on repas.id equals oper.fk_reparatie
                              join mecan in dbContext.mecanics on oper.fk_mecanic equals mecan.id
                              where repas.id == Int32.Parse(textBox1.Text)

                              select new { IdReparatie = repas.id, NumeMecanic = mecan.nume + mecan.prenume, DescriereReparatie = repas.descriere, DescriereOperatie = oper.descriere }).ToList();
            dataGridView1.DataSource = projection;
        }

        private void display_repairs_Click(object sender, EventArgs e)
        {
            var projection = (from rep in dbContext.masinas
                              join repas in dbContext.reparaties on rep.vin equals repas.fk_masina
                             
                            

                              select new { IdReparatie = repas.id, DescriereReparatie = repas.descriere,VinMasina = repas.fk_masina }).ToList();
            dataGridView1.DataSource = projection;
        }

        private void add_client_Click(object sender, EventArgs e)
        {
            Form2 dialog1 = new Form2(4);//vinclient
            dialog1.ShowDialog();
            variable1= dialog1.variable1;
            variable2 = dialog1.variable2;
            variable3 = dialog1.variable3;
            variable4 = dialog1.variable4;
            proprietar nou = new proprietar();
            nou.telefon = variable3;
             nou.nume = variable1;
            nou.prenume = variable2;
            nou.nrcard = variable4;
            dbContext.proprietars.InsertOnSubmit(nou);
            dbContext.SubmitChanges();
            var projection = (from pro in dbContext.proprietars
                              select pro).ToList();




             dataGridView1.DataSource = projection;

        }

        private void add_masina_Click(object sender, EventArgs e)
        {
            Form2 dialog1 = new Form2(5);//vinclient
            dialog1.ShowDialog();
            variable1 = dialog1.variable1;
            variable2 = dialog1.variable2;
            variable3 = dialog1.variable3;
            variable4 = dialog1.variable4;
            variable5 = dialog1.variable5;
           
            string a, b, c;
            var projection5 = (from rep in dbContext.masinas //verific tipul
                              where rep.vin == variable1
                              select rep.vin).ToList();
            
            if (projection5.Count() != 0)
            {
                MessageBox.Show("Insert right stuff for this to work1.");
                return;
            }
            var projection = (from rep in dbContext.tips //verific tipul
                              where rep.nume == variable3
                              select rep.id).ToList();
            if(projection.Count()==0)
            {
                MessageBox.Show("Insert right stuff for this to work3.");
                return;
            }
            var projection2 = (from rep in dbContext.fabricants//verific fabricantul
                              where rep.nume == variable4
                              select rep.id).ToList();
            if (projection2.Count() == 0)
            {
                MessageBox.Show("Insert right stuff for this to work4.");
                return;
            }
            var projection4 = (from rep in dbContext.proprietars//verific proprietarul
                               where Int32.Parse(variable5)==rep.id
                                 select rep.nume).ToList();
            if (projection4.Count() == 0)
            {
                MessageBox.Show("Insert right stuff for this to work5.");
                return;
            }
            masina nou = new masina();
            nou.vin = variable1;
            nou.culoare = variable2;
            nou.fk_tip = projection[0];
            nou.fk_brand = projection2[0];
            nou.fk_proprietar = Int32.Parse(variable5);
            dbContext.masinas.InsertOnSubmit(nou);
            dbContext.SubmitChanges();
            var projection3 = (from pro in dbContext.masinas
                              select pro).ToList();




            dataGridView1.DataSource = projection3;
        }

        private void cauta_vin_Click(object sender, EventArgs e)
        {
            var projection = (from rep in dbContext.masinas
                              join repas in dbContext.reparaties on rep.vin equals repas.fk_masina



                              select new { IdReparatie = repas.id, DescriereReparatie = repas.descriere, VinMasina = repas.fk_masina }).ToList();
            dataGridView1.DataSource = projection;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=dbContext.toate_masinile().ToList();
        }

        private void piese_disponibile_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbContext.search_piese_disponibile().ToList();
        }

        private void piese_dupa_nume_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbContext.search_piese_nume(textBox1.Text).ToList();
        }

        private void operatii_masina_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbContext.toate_operatiile_masinii(textBox1.Text).ToList();
        }

        private void adauga_client_Click(object sender, EventArgs e)
        {

            Form2 dialog1 = new Form2(1);//vinclient
            dialog1.ShowDialog();
            variable1 = dialog1.variable1;
            variable2 = dialog1.variable2;
            dataGridView1.DataSource = dbContext.cauta_dupa_nume(variable1, variable2).ToList();
        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
           

           // var projection = (db

           // /
            //                 select rep).ToList();
            //
           // dataGridView1.DataSource = projection;
        }
    }

}
