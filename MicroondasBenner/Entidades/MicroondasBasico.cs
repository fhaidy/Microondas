using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroondasBenner.Entidades {
    public abstract class MicroondasBasico {
        public TimeSpan Tempo { get; set; }
        public int Potencia { get; set; }
        public char Caractere { get; set; }

        public abstract void Aquecer();
        public void DefinirTempo(TimeSpan tempo) {
            if (tempo != null) {
                if (tempo.TotalSeconds > 120) {
                    throw new ArgumentException("O tempo não pode ser maior que 2 minutos.");
                } else if (tempo.TotalSeconds <= 0) {
                    throw new ArgumentException("O tempo mínimo é 1 segundo.");
                }
                Tempo = new TimeSpan(00, tempo.Minutes, tempo.Seconds);
            } else {
                throw new ArgumentException("É obrigatório informar o tempo para aquecimento.");
            }
        }
        public void DefinirPotencia(int potencia) {
            if (potencia <= 0) {
                throw new ArgumentException("A potência deve ser maior que 0.");
            } else if (potencia > 10) {
                throw new ArgumentException("A potência não pode ser maior que 10");
            }
            Potencia = potencia;
        }
        public  void DefinirCaractere(char caractere) {
            if (!caractere.ToString().Equals("")) {
                Caractere = caractere;
            } else {
                throw new ArgumentException("Informe o caracter de aquecimento do programa.");
            }
        }
    }
}