using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List musterilistesi = new List();
        private void Form1_Load(object sender, EventArgs e)
        {

            //List list = new List();
            //list.InsertPos(0, (new Musteri { Ad="ramazan", Soyad="Bozkir", KoltukNo=12}));
            //MessageBox.Show(list.GetElement(0).Data.KoltukNo.ToString());

        }
        protected void KisiSayisi()
        {
            txtKisiSayisi.Text = musterilistesi.Size.ToString();
        }
        private void btnSatis(object sender, EventArgs e)
        {
            int koltukno = Convert.ToInt32(txtKoltukNo.Text);
            if (musterilistesi.Head == null)
            {
                musterilistesi.InsertPos(0, (new Musteri { KoltukNo = koltukno, Ad = txtAd.Text, Soyad = txtSoyad.Text }));
                MessageBox.Show("Bilet Alindi");
            }
            else
            {
                bool temp = false;
                for (int i = 0; i < musterilistesi.Size; i++)
                {
                    if (koltukno == musterilistesi.GetElement(i).Data.KoltukNo)
                        temp = true;
                }
                if (temp == false)
                {
                    musterilistesi.InsertPos(0, (new Musteri { KoltukNo = koltukno, Ad = txtAd.Text, Soyad = txtSoyad.Text }));
                    MessageBox.Show("Bilet Alindi");
                }
                else if (temp == true)
                    MessageBox.Show("Koltuk Dolu baska bir koltuk seciniz.");
            }
            KisiSayisi();
        }

        private void button(object sender, EventArgs e)
        {
            
            if (((Button)sender).BackColor == Color.DeepSkyBlue)
            {
                txtKoltukNo.Text = ((Button)sender).Text;
            }
           

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            int koltukiptalno = Convert.ToInt32(txtKoltukIptalNo.Text);
            bool temp = false;
            int indis=0;
            for (int i = 0; i < musterilistesi.Size; i++)
            {
                if (musterilistesi.GetElement(i).Data.KoltukNo == koltukiptalno)
                {
                    indis = i;
                    temp = true;
                }
                
            }
            if (temp == false)
                MessageBox.Show("Biletinize ait bilgiler bulunamadi.");
            else if(temp==true)
            {
                musterilistesi.DeletePos(indis);
                MessageBox.Show("Biletiniz iptal edildi.");
            }
            KisiSayisi();
        }

        private void btnKoltukListele(object sender, EventArgs e)
        {
            string bos = "";
            string dolu= "";
            for(int i=1; i<=60; i++)
            {
                bool temp = false;
                for (int j=0; j<musterilistesi.Size; j++)
                {
                    if (musterilistesi.GetElement(j).Data.KoltukNo == i)
                    {
                        dolu += i.ToString() + Environment.NewLine;
                        temp = true;
                    }
                        
                }
                if(temp==false)
                    bos += i.ToString() + Environment.NewLine;
            }
            txtDolu.Text = dolu;
            txtBos.Text = bos;
           
        }
    }
}
