using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServisOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FormGetir(Form frm)
        {
            panelAna.Controls.Clear();
            frm.MdiParent = null;
            frm.TopLevel = false;     
            frm.FormBorderStyle = FormBorderStyle.None; 
            frm.Dock = DockStyle.Fill; 
            panelAna.Controls.Add(frm); 
            frm.Show(); 
        }

       
        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            FormMusteri frm = new FormMusteri();
            FormGetir(frm); 
        }

        
        private void btnAriza_Click(object sender, EventArgs e)
        {
            FormAriza frm = new FormAriza();
            FormGetir(frm);
        }

        
        private void btnServis_Click(object sender, EventArgs e)
        {
            FormServis frm = new FormServis();
            FormGetir(frm);
        }

    
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panelAna_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
