using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LotoClassNS;

namespace ExamenLoto
{
    public partial class Examen2EVGAGAG2223 : Form
    {
        private const CANTIDAD_NUMEROS = 6;
        private loto miGanadora;
        private TextBox[] combinacion = new TextBox[CANTIDAD_NUMEROS]; // Estos arrays se usan para recorrer de manera más sencilla los controles
        private TextBox[] ganadora = new TextBox[CANTIDAD_NUMEROS];
        private loto miLoto;

        public loto MiLoto { get => miLoto; set => miLoto = value; }
        public loto MiGanadora { get => miGanadora; set => miGanadora = value; }

        public Examen2EVGAGAG2223()
        {
            InitializeComponent();
            combinacion[0] = txtNumero1; ganadora[0] = txtGanadora1;
            combinacion[1] = txtNumero2; ganadora[1] = txtGanadora2;
            combinacion[2] = txtNumero3; ganadora[2] = txtGanadora3;
            combinacion[3] = txtNumero4; ganadora[3] = txtGanadora4;
            combinacion[4] = txtNumero5; ganadora[4] = txtGanadora5;
            combinacion[5] = txtNumero6; ganadora[5] = txtGanadora6;
            MiGanadora = new loto(); // generamos la combinación ganadora
            for (int i = 0; i < CANTIDAD_NUMEROS; i++)
                ganadora[i].Text = Convert.ToString(MiGanadora.Nums[i]);

        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            MiLoto = new loto(); // usamos constructor vacío, se genera combinación aleatoria
            for (int i = 0; i < CANTIDAD_NUMEROS; i++)
                combinacion[i].Text = Convert.ToString(MiLoto.Nums[i]);
        }

        private void btValidar_Click(object sender, EventArgs e)
        {
            int[] arrayNumeros = new int[CANTIDAD_NUMEROS];
            for (int i = 0; i < CANTIDAD_NUMEROS; i++)
                arrayNumeros[i] = Convert.ToInt32(combinacion[i].Text);
            MiLoto = new loto(arrayNumeros);
            if (MiLoto.ok)
                MessageBox.Show("Combinación válida");
            else
                MessageBox.Show("Combinación no válida");
        }

        private void btComprobar_Click(object sender, EventArgs e)
        {
            int[] arrayNumeros = new int[CANTIDAD_NUMEROS];
            for (int i = 0; i < CANTIDAD_NUMEROS; i++)
                arrayNumeros[i] = Convert.ToInt32(combinacion[i].Text);
            MiLoto = new loto(arrayNumeros);
            if (MiLoto.ok)
            {
                arrayNumeros = new int[CANTIDAD_NUMEROS];
                for (int i = 0; i < CANTIDAD_NUMEROS; i++)
                    arrayNumeros[i] = Convert.ToInt32(combinacion[i].Text);
                int aciertos = MiGanadora.comprobar(arrayNumeros);
                if (aciertos < 3)
                    MessageBox.Show("No ha resultado premiada");
                else
                    MessageBox.Show("¡Enhorabuena! Tiene una combinación con " + Convert.ToString(aciertos) + " aciertos");
            }
            else
                MessageBox.Show("La combinación introducida no es válida");
        }
    }
}
