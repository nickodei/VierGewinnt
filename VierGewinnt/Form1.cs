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
            // Größe des Fensters einstellen
            this.Size = new Size(717, 740);

            // Das Spielfeld (Oberfläche) muss erstmal erstellt werden
            // 1. Die Größe des Spielfelds muss die Größe des Fenster sein
            Spielfeld_GUI.Size = new Size(700, 700);

            // Die Anzahl der Spalten und Zeilen muss gesetzt werden
            Spielfeld_GUI.RowCount = 7;
            Spielfeld_GUI.ColumnCount = 7;

            // Damit die Selektion nicht farblich dargestellt wird
            Spielfeld_GUI.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;

            // Die Header sollen nicht sichbar sein
            Spielfeld_GUI.RowHeadersVisible = false;
            Spielfeld_GUI.ColumnHeadersVisible = false;

            // Keine Scrollbars
            Spielfeld_GUI.ScrollBars = ScrollBars.None;
           
            // Für jede Zeile im Spielfeldn
            for (int row = 0; row < 7; row++)
            {
                // Höhe der Zeile auf 100 setzen (gleich groß wie Spalten)
                Spielfeld_GUI.Rows[row].Height = 100;

                // Für jede Spalte in der aktuellen Zeile
                for (int column = 0; column < 7; column++)
                {
                    // Jedes Feld wird durch einen Button repräsentiert
                    DataGridViewButtonCell cellButton = new DataGridViewButtonCell();
                    cellButton.FlatStyle = FlatStyle.Flat;

                    Spielfeld_GUI[column, row] = cellButton;
                }
            }

            // Beim Button-Klick wird die Logik ausgeführt (z.B. überprüfen ob gewonnen, etc.)
            Spielfeld_GUI.CellContentClick += Spielfeld_GUI_CellContentClick;

            // Füge dem Fenster das Spielfeld hinzu
            this.Controls.Add(Spielfeld_GUI);
        }

        private void Spielfeld_GUI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {             
            var senderGrid = (DataGridView)sender;

            if (senderGrid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell && e.RowIndex >= 0)
            {
                // Ein Button wurde im Spielfeld angeklickt
                senderGrid[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
                
                // Beende die Selektion
                senderGrid.ClearSelection();
            }
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
