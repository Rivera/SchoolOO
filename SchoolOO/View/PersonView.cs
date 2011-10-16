using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchoolOO.Controller;
using System.Collections;

namespace SchoolOO.View
{
    public partial class PersonView : Form
    {
        public PersonView()
        {
            InitializeComponent();
        }

        private void PersonView_Load(object sender, EventArgs e)
        {
            PersonCtrl perconCtrl = new PersonCtrl();
            grdPerson.DataSource = perconCtrl.Consultar();
            grdPerson.Columns["PersonID"].Visible = false;
            grdPerson.Columns["OfficeAssignment"].Visible = false;
            grdPerson.Columns["StudentGrades"].Visible = false;
            grdPerson.Columns["Courses"].Visible = false;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            PersonDetail personDatail = new PersonDetail("incluir");
            personDatail.ShowDialog();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ArrayList arrPerson = new ArrayList();
            arrPerson.Add(grdPerson.CurrentRow.Cells[0].Value);
            arrPerson.Add(grdPerson.CurrentRow.Cells[1].Value);
            arrPerson.Add(grdPerson.CurrentRow.Cells[2].Value);
            arrPerson.Add(grdPerson.CurrentRow.Cells[3].Value);
            arrPerson.Add(grdPerson.CurrentRow.Cells[4].Value);
            PersonDetail personDetail = new PersonDetail(arrPerson, "alterar");
            personDetail.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PersonCtrl personCtrl = new PersonCtrl();
            ArrayList arrPerson = new ArrayList();
            arrPerson.Add(grdPerson.CurrentRow.Cells[0].Value);
            arrPerson.Add(grdPerson.CurrentRow.Cells[1].Value);
            arrPerson.Add(grdPerson.CurrentRow.Cells[2].Value);
            arrPerson.Add(grdPerson.CurrentRow.Cells[3].Value);
            arrPerson.Add(grdPerson.CurrentRow.Cells[4].Value);
            personCtrl.Salvar(arrPerson, "excluir");
        }
    }
}
