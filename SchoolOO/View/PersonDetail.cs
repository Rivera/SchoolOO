using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SchoolOO.Controller;

namespace SchoolOO.View
{
    public partial class PersonDetail : Form
    {
        string operacao;
        ArrayList arrPerson = new ArrayList();

        public PersonDetail()
        {
            InitializeComponent();
        }

        public PersonDetail(string operacao)
        {
            InitializeComponent();
            this.operacao = operacao;
        }
        
        public PersonDetail(ArrayList arrPerson, string operacao)
        {
            InitializeComponent();
            txtLastName.Text = Convert.ToString(arrPerson[1]);
            txtFirstName.Text = Convert.ToString(arrPerson[2]);
            dtpHireDate.Value = Convert.ToDateTime("2011-10-01");
            dtpEnrollmentDate.Value = Convert.ToDateTime(arrPerson[4]);
            this.arrPerson = arrPerson;
            this.operacao = operacao;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            PersonCtrl personCtrl = new PersonCtrl();
            if (this.operacao == "incluir")
            {
                ArrayList arrPerson = new ArrayList();
                arrPerson.Add(txtFirstName.Text);
                arrPerson.Add(txtLastName.Text);
                arrPerson.Add(Convert.ToString(dtpHireDate.Value));
                arrPerson.Add(Convert.ToString(dtpEnrollmentDate.Value));
                personCtrl.Salvar(arrPerson, this.operacao);
            }
            else
            {
                this.arrPerson[1] = txtFirstName.Text;
                this.arrPerson[2] = txtLastName.Text;
                this.arrPerson[3] = Convert.ToString(dtpHireDate.Value);
                this.arrPerson[4] = Convert.ToString(dtpEnrollmentDate.Value);
                personCtrl.Salvar(this.arrPerson, this.operacao);
            }
        }
    }
}
