using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MicroondasBenner.Entidades;
using System.Windows.Forms;

namespace MicroondasBenner.Webforms {
    public partial class MicroondasMain : System.Web.UI.Page {
        private Microondas microondas = new Microondas();
        
    protected void Page_Load(object sender, EventArgs e) {

            List<Programa> progs = microondas.GetProgramas();
            if (!IsPostBack) {
                TextBox2.Text = "00:00";
            }
                
            foreach (var item in progs) {

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
                cell3.Text = item.Tempo.ToString("mm")+":"+ item.Tempo.ToString("ss"); 
                row.Cells.Add(cell3);
                cell4.Text = item.Potencia.ToString();
                row.Cells.Add(cell4);
                cell5.Text = item.Caractere.ToString();
                row.Cells.Add(cell5);
                Table1.Rows.Add(row);
                if (!IsPostBack) {
                    DropDownList1.DataSource = progs;
                    DropDownList1.DataValueField = "Nome";
                    DropDownList1.DataTextField = "Nome";
                    DropDownList1.DataBind();

                    //Items.Insert(0, item.Nome);
                }
            }
            if (!IsPostBack) {
                DropDownList1.Items.Insert(0, new ListItem("Selecione", ""));
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            alteraValorTempo(Button1.Text.ToString());

        }

        protected void alteraValorTempo(string valor) {
            int lengthText = TextBox2.Text.Length;
            if (lengthText == 0) {
                TextBox2.Text = "00:0" + valor;
            } else {
                if (TextBox2.Text[0] == '0') {
                    if (TextBox2.Text[0] == '0') {
                        TextBox2.Text = TextBox2.Text[1].ToString() + TextBox2.Text[3].ToString() + ":" + TextBox2.Text[4].ToString() + valor;
                    } else if (TextBox2.Text[1] == '0') {
                        TextBox2.Text = "0" + TextBox2.Text[3].ToString() + ":" + TextBox2.Text[4].ToString() + valor;
                    } else if (TextBox2.Text[3] == '0') {
                        TextBox2.Text = "00:" + TextBox2.Text[4].ToString() + valor;
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e) {
            alteraValorTempo(Button2.Text.ToString());
        }

        protected void Button3_Click(object sender, EventArgs e) {
            alteraValorTempo(Button3.Text.ToString());
        }

        protected void Button4_Click(object sender, EventArgs e) {
            alteraValorTempo(Button4.Text.ToString());
        }

        protected void Button5_Click(object sender, EventArgs e) {
            alteraValorTempo(Button5.Text.ToString());
        }

        protected void Button6_Click(object sender, EventArgs e) {
            alteraValorTempo(Button6.Text.ToString());
        }

        protected void Button7_Click(object sender, EventArgs e) {
            alteraValorTempo(Button7.Text.ToString());
        }

        protected void Button8_Click(object sender, EventArgs e) {
            alteraValorTempo(Button8.Text.ToString());
        }

        protected void Button9_Click(object sender, EventArgs e) {
            alteraValorTempo(Button9.Text.ToString());
        }

        protected void ButtonAquecerRapido_Click(object sender, EventArgs e) {
            TextBox3.Text = "";
            try {
                microondas.DefinirEntrada(TextBox1.Text);
                TextBox2.Text = "00:30";
                DropDownList2.SelectedValue = "8";
                microondas.AquecerRapido();
                Session["SAIDA"] = microondas.Saida;
                Session["Caractere"] = '.';
                Timer1.Enabled = true;
            } catch (ArgumentException ex) {
                MessageBox.Show("Validação de dados: " + ex.Message);
            } catch (Exception ex) {
                MessageBox.Show("Um erro inesperado aconteceu: " + ex.Message);
            }
        }

        protected void Button0_Click(object sender, EventArgs e) {
            alteraValorTempo(Button0.Text.ToString());
        }

        protected void ButtonAquecer_Click(object sender, EventArgs e) {
            TextBox3.Text = "";
            try {

                if (DropDownList1.SelectedValue != "") {
                    if (TextBox1.Text.ToLower().Contains(DropDownList1.SelectedValue.ToLower())) {
                        bool programaCompativel = false;
                        foreach (Programa prog in microondas.Programas) {
                            programaCompativel = prog.VerificaCompatibilidade(TextBox1.Text.ToString());
                            if (programaCompativel) {
                                microondas.DefinirEntrada(TextBox1.Text.ToString());
                                microondas.DefinirTempo(prog.Tempo);
                                microondas.DefinirPotencia(prog.Potencia);
                                microondas.Caractere = prog.Caractere;
                                Session["Caractere"] = microondas.Caractere;
                                microondas.Aquecer(prog);
                                Session["SAIDA"] = microondas.Saida;
                                Timer1.Enabled = true;
                                break;
                            }

                        }
                        if (!programaCompativel) {
                            MessageBox.Show("Alimento incompatível com o programa.");
                        }
                    } else if (microondas.VerificaArquivo(TextBox1.Text)) {
                        bool programaCompativel = false;
                        foreach (Programa prog in microondas.Programas) {
                            programaCompativel = prog.VerificaCompatibilidade(TextBox1.Text.ToString(), DropDownList1.SelectedValue.ToString());
                            if (programaCompativel) {
                                microondas.DefinirEntrada(TextBox1.Text.ToString());
                                microondas.DefinirTempo(prog.Tempo);
                                microondas.DefinirPotencia(prog.Potencia);
                                microondas.Caractere = prog.Caractere;
                                Session["Caractere"] = microondas.Caractere;
                                microondas.Aquecer(prog);
                                Session["SAIDA"] = microondas.Saida;
                                Timer1.Enabled = true;
                                break;
                            }

                        }
                        if (!programaCompativel) {
                            MessageBox.Show("Alimento incompatível com o programa.");
                        }
                    } else {
                        MessageBox.Show("Alimento incompatível com o programa.");
                    }
                } else {
                    microondas.DefinirEntrada(TextBox1.Text.ToString());

                    int minutos = int.Parse(TextBox2.Text.ToString().Split(':')[0]);
                    int segundos = int.Parse(TextBox2.Text.ToString().Split(':')[1]);
                    microondas.DefinirTempo(new TimeSpan(00, minutos, segundos));
                    microondas.DefinirPotencia(int.Parse(DropDownList2.SelectedValue));
                    microondas.Caractere = '.';
                    Session["Caractere"] = '.';
                    microondas.Aquecer();
                    Session["SAIDA"] = microondas.Saida;
                    Timer1.Enabled = true;
                }

            } catch (ArgumentException ex) {
                MessageBox.Show("Validação de dados: " + ex.Message);
            } catch (Exception ex) {
                MessageBox.Show("Um erro inesperado aconteceu: " + ex.Message);
            }


        }

        protected void LimparCancelar_Click(object sender, EventArgs e) {
            TextBox2.Text = "00:00";
            Timer1.Enabled = false;
            TextBox3.Text = "";
            DropDownList1.ClearSelection();
            DropDownList1.Items.FindByText("Selecione").Selected = true;
            DropDownList2.SelectedValue = "10";
        }

        protected void Timer1_Tick(object sender, EventArgs e) {
            if (TextBox2.Text != "00:00") {

                TimeSpan tempo = new TimeSpan(00,
                    int.Parse(TextBox2.Text.Split(':')[0]),
                    int.Parse(TextBox2.Text.Split(':')[1]));
                TimeSpan result = tempo.Subtract(new TimeSpan(00, 00, 01));

                TextBox2.Text = result.ToString("mm") + ":" + result.ToString("ss");
                for(int i = 0; i<int.Parse(DropDownList2.SelectedValue); i++) {
                    TextBox1.Text += Session["Caractere"].ToString();
                }
                
            } else {
                TextBox3.Text = Session["SAIDA"].ToString();
                Session.Remove("SAIDA");
                Timer1.Enabled = false;
            }

        }

        protected void ButtonNovoPrograma_Click(object sender, EventArgs e) {
            Response.Redirect("./CriarPrograma.aspx");
        }

        protected void ButtonBuscarPrograma_Click(object sender, EventArgs e) {
            Response.Redirect("./BuscarPrograma.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                Programa prog = microondas.BuscarPrograma(DropDownList1.SelectedValue);

                TextBox2.Text = prog.Tempo.ToString("mm") + ":" + prog.Tempo.ToString("ss");
                DropDownList2.SelectedValue = prog.Potencia.ToString();
            } catch (ArgumentException) {
                TextBox2.Text = "00:00";
                DropDownList2.SelectedValue = "10";
                DropDownList2.SelectedValue = "";
            }  catch (Exception ex) {
                MessageBox.Show("Um erro inesperado aconteceu: " + ex.Message);
            }
            
        }

        protected void ButtonPausarRetomar_Click(object sender, EventArgs e) {
            if (Timer1.Enabled) {
                Timer1.Enabled = false;
            }else if(Session["SAIDA"] != null) {
                Timer1.Enabled = true;
            }
        }
    }
}