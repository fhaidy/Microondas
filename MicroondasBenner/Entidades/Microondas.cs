using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace MicroondasBenner.Entidades {
    public class Microondas : MicroondasBasico{
        public string Entrada { get; private set; }
        public bool Arquivo { get; set; }
        public string Saida { get; set; }
        private string caminhoProgramas = @"C:\Users\Fhaidy Keruaq\source\repos\MicroondasBenner\MicroondasBenner\Entidades\Programas.txt";
        public List<Programa> Programas { get; set; } = new List<Programa>();

        public Microondas() {
            AdicionaProgramasPadrao();
            Programas = GetProgramas();
            Arquivo = false;
        }

        public Microondas(TimeSpan tempo, int potencia, char caractere) {
            Tempo = tempo;
            Potencia = potencia;
            Caractere = caractere;
        }

        public override void Aquecer() {
            if (!Arquivo) {
                int segundos = (int)Tempo.TotalSeconds;
                string saida = Entrada;
                for (int i = 0; i < segundos; i++) {
                    for (int j = 0; j < Potencia; j++) {
                        saida += ".";
                    }
                }
                Saida = saida;
            } else {
                int segundos = (int)Tempo.TotalSeconds;
                using (StreamWriter sw = File.AppendText(Entrada)) {
                    for (int i = 0; i < segundos; i++) {
                        for (int j = 0; j < Potencia; j++) {
                            sw.Write(Caractere.ToString());
                        }
                    }
                }

                using (StreamReader sr = new StreamReader(Entrada, Encoding.UTF8)) {
                    string s = "";
                    while ((s = sr.ReadLine()) != null) {
                        Saida += s;
                    }
                }

            }
        }

        public void Aquecer(Programa programa) {
            if (!Arquivo) {
                int segundos = (int)programa.Tempo.TotalSeconds;
                string saida = Entrada;

                for (int i = 0; i < segundos; i++) {
                    for (int j = 0; j < programa.Potencia; j++) {
                        saida += programa.Caractere.ToString();
                    }
                }
                Saida = saida;
            } else {
                int segundos = (int)programa.Tempo.TotalSeconds;
                using (StreamWriter sw = File.AppendText(Entrada)) {
                    for (int i = 0; i < segundos; i++) {
                        for (int j = 0; j < programa.Potencia; j++) {
                            sw.Write(programa.Caractere.ToString());
                        }
                    }
                }

                using (StreamReader sr = new StreamReader(Entrada, Encoding.UTF8)) {
                    string s = "";
                    while ((s = sr.ReadLine()) != null) {
                        Saida += s;
                    }
                }
            }
            
        }

        public void AquecerRapido() {
            if (!Arquivo) {
                string saida = Entrada;
                for (int i = 0; i < 30; i++) {
                    for (int j = 0; j < 8; j++) {
                        saida += '.'.ToString();
                    }
                }
                Saida = saida;
            } else {
                using (StreamWriter sw = File.AppendText(Entrada)) {
                    for (int i = 0; i < 30; i++) {
                        for (int j = 0; j < 8; j++) {
                            sw.Write('.'.ToString());
                        }
                    }
                }

                using (StreamReader sr = new StreamReader(Entrada, Encoding.UTF8)) {
                    string s = "";
                    while ((s = sr.ReadLine()) != null) {
                        Saida += s;
                    }
                }
            }
        }

        public void DefinirEntrada(string entrada) {
            if(entrada.Trim() == "" || entrada == null) {
                throw new ArgumentException("Por favor, digite o que deseja esquentar");
            } else {
                if (VerificaArquivo(entrada)){
                    Arquivo = true;
                    Entrada = entrada;
                } else {
                    Entrada = entrada;
                }
            }            
        }

        public bool VerificaArquivo(string caminho) {
            if (File.Exists(caminho)){
                return true;
            }
            return false;
        }


        public void AdicionarPrograma(Programa programa) {
            Programas.Add(programa);
            using (StreamWriter writer = new StreamWriter(caminhoProgramas, true)) {
                writer.WriteLine(programa.ToString());
            }
        }

        public IEnumerable<Programa> BuscarProgramas(string nome) {
            List<Programa> programas = GetProgramas();
            return programas.Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
        }

        public Programa BuscarPrograma(string nome) {
            List<Programa> programas = GetProgramas();
            return programas.Where(p => p.Nome == nome).FirstOrDefault();
        }

        private void AdicionaProgramasPadrao() {
            Programas.Add(new Programa("Pipoca", "A entrada Pipoca será aquecida por 30s na potência 3", new TimeSpan(00, 00, 30), 3, '#'));
            Programas.Add(new Programa("Frango", "A entrada Frango será aquecida por 50s na potência 5", new TimeSpan(00, 00, 50), 5, '%'));
            Programas.Add(new Programa("Carne", "A entrada Carne será aquecida por 60s na potência 6", new TimeSpan(00, 01, 00), 6, '^'));
            Programas.Add(new Programa("Pudim", "A entrada Pudim será aquecida por 20s na potência 2", new TimeSpan(00, 00, 20), 2, '@'));
            Programas.Add(new Programa("Macarrão", "A entrada Macarrão será aquecida por 40s na potência 4", new TimeSpan(00, 00, 40), 4, '$'));

            string[] lines = File.ReadAllLines(caminhoProgramas);
            if(lines.Length == 0){
                foreach (Programa prog in Programas) {
                    using (StreamWriter writer = new StreamWriter(caminhoProgramas, true)) {
                        writer.WriteLine(prog.ToString());
                    }
                }
            }
        }

        public List<Programa> GetProgramas() {
            string[] lines = File.ReadAllLines(caminhoProgramas);
            string[] separador = { "$_$" };
            List<Programa> lista = new List<Programa>();
            foreach (string line in lines) {
                lista.Add(new Programa(
                        line.Split(separador, StringSplitOptions.RemoveEmptyEntries)[0],
                        line.Split(separador, StringSplitOptions.RemoveEmptyEntries)[1],
                        TimeSpan.Parse(line.Split(separador, StringSplitOptions.RemoveEmptyEntries)[2]),
                        int.Parse(line.Split(separador, StringSplitOptions.RemoveEmptyEntries)[3]),
                        char.Parse(line.Split(separador, StringSplitOptions.RemoveEmptyEntries)[4])
                    ));
            }
            return lista;
        }

    }
}