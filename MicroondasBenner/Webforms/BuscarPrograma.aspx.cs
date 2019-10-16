using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MicroondasBenner.Entidades;

namespace MicroondasBenner.Webforms {
    public partial class BuscarPrograma : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Microondas microondas = new Microondas();
                IEnumerable<Programa> programas = microondas.BuscarProgramas("");
                foreach (var item in programas) {

                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    TableCell cell5 = new TableCell();
                    cell1.Text = item.Nome;
                    row.Cells.Add(cell1);
                    cell2.Text = item.Instrucoes;
                    row.Cells.Add(cell2);
                    cell3.Text = item.Tempo.ToString("mm") + ":" + item.Tempo.ToString("ss");
                    row.Cells.Add(cell3);
                    cell4.Text = item.Potencia.ToString();
                    row.Cells.Add(cell4);
                    cell5.Text = item.Caractere.ToString();
                    row.Cells.Add(cell5);
                    Table1.Rows.Add(row);
                }
            }
            
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e) {
            Microondas microondas = new Microondas();
            IEnumerable<Programa> programas = microondas.BuscarProgramas(TextBox1.Text);
            
            foreach (var item in programas) {

                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();
                cell1.Text = item.Nome;
                row.Cells.Add(cell1);
                cell2.Text = item.Instrucoes;
                row.Cells.Add(cell2);
                cell3.Text = item.Tempo.ToString("mm") + ":" + item.Tempo.ToString("ss");
                row.Cells.Add(cell3);
                cell4.Text = item.Potencia.ToString();
                row.Cells.Add(cell4);
                cell5.Text = item.Caractere.ToString();
                row.Cells.Add(cell5);
                Table1.Rows.Add(row);
            }
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e) {
            Response.Redirect("./MicroondasMain.aspx");
        }
    }
}