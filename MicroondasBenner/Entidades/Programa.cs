using System;
using System.IO;
using System.Text;
namespace MicroondasBenner.Entidades{
    public class Programa : Microondas{
        public string Nome { get; private set; }
        public string Instrucoes { get; private set; }
        public Programa() {
        }

        public Programa(string nome, string instrucoes, TimeSpan tempo, int potencia, char caractere): base(tempo, potencia, caractere) {
            Nome = nome;
            Instrucoes = instrucoes;
        }

        public void DefinirNome(string nome) {
            if(nome.Trim() != ""){
                Nome = nome;
            }else {
                throw new ArgumentException("Informe o nome do Programa.");
            }
        }

        public void DefinirInstrucoes(string instrucoes) {
            if (instrucoes.Trim() != "") {
                Instrucoes = instrucoes;
            } else {
                throw new ArgumentException("Informe as instruções para o Programa.");
            }
        }

        public bool VerificaCompatibilidade (string entrada) {
             
            if (entrada.ToLower().Contains(Nome.ToLower())) {
                return true;
            }
            return false;
        }

        public bool VerificaCompatibilidade(string caminho, string nomePrograma) {

            if (File.Exists(caminho)) {
                using (StreamReader sr = new StreamReader(caminho, Encoding.UTF8)) {
                    string s = "";
                    while ((s = sr.ReadLine()) != null) {
                        if (s.ToLower().Contains(nomePrograma.ToLower()) && Nome.Equals(nomePrograma)) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override string ToString() {
            return Nome + "$_$" +
                Instrucoes + "$_$" +
                Tempo + "$_$" +
                Potencia + "$_$" +
                Caractere;
        }
    }
}
 