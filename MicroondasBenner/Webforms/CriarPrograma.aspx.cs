using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MicroondasBenner.Entidades;

namespace MicroondasBenner.Webforms {
    public partial class CriarPrograma : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ButtonCriar_Click(object sender, EventArgs e) {
            try {
                Programa programa = new Programa();
                programa.DefinirNome(textNomeProg.Value);
                programa.DefinirInstrucoes(textInstrucoesProg.Text);
                programa.DefinirTempo(new TimeSpan(00,
                    int.Parse(textTempoProg.Text.Split(':')[0]),
                    int.Parse(textTempoProg.Text.Split(':')[1])
                    )
                );
                programa.DefinirPotencia(int.Parse(DropDownPotencia.SelectedValue));
                programa.DefinirCaractere(char.Parse(textCaractereProg.Value));

                Microondas microondas = new Microondas();
                microondas.AdicionarPrograma(programa);

                Response.Redirect("./MicroondasMain.aspx");
            } catch (ArgumentException ex) {
                MessageBox.Show("Validação de dados: " + ex.Message);
            } catch (Exception ex) {
                MessageBox.Show("Um erro inesperado aconteceu: " + ex.Message);
            }

        }

        protected void ButtonCancelar_Click(object sender, EventArgs e) {
            Response.Redirect("./MicroondasMain.aspx");
        }
    }
}