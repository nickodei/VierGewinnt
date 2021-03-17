using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VierGewinnt
{
    public partial class Form1 : Form
    {
        public enum Spieler
        {
            Spieler1 = 0,
            Spieler2 = 0
        }

        public enum Feld
        {
            NichtBelegt = 0,
            BelegtSpieler1 = 1,
            BelegtSpieler2 = 2
        }

        /// <summary>
        /// Das ist der Spieler, der akuell am Zug ist
        /// </summary>
        private Spieler AktuellerSpieler = Spieler.Spieler1;

        /// <summary>
        /// Repräsentiert unser Spielfeld im Code
        /// Hier wird die Logik überprüft und auch angepasst
        /// </summary>
        private Feld[,] Spielfeld = new Feld[7,7];

        /// <summary>
        /// Repräsentiert unser Spielfeld in der Oberfläche
        /// Ein Button in der Oberfläche (Feld) wird gedrückt
        /// 1. Button muss gefärbt werden
        /// 2. Überprüfe ob Spieler gewonnen hat
        /// </summary>
        private DataGridView Spielfeld_GUI = new DataGridView();

        public Form1()
        {
            InitializeComponent();

            // Das Spielfeld (Oberfläche) muss erstmal erstellt werden
            // 1. Die Größe des Spielfelds muss die Größe des Fenster sein
            Spielfeld_GUI.Size = new Size(600, 500);

            // Die Anzahl der Spalten und Zeilen muss gesetzt werden
            Spielfeld_GUI.RowCount = 7;
            Spielfeld_GUI.ColumnCount = 7;           

            // Jedes Feld muss ein Button haben

            // Beim Button-Klick wird die Logik ausgeführt (z.B. überprüfen ob gewonnen, etc.)
        }

        public void UeberpruefeObGewonnen()
        {

        }

        public void Gewonnen()
        {
            // Ausgabe, wer gewonnen hat
        }

        public void SpielNeustarten()
        {
            // Hierbei müssen alle Felder im Spielfeld auf Feld.KeinSpieler gesetzt werden
            // Achtung: Oberfläche muss auch gefärbt werden
        }
    }
}
