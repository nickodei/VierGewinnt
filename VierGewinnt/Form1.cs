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





            // pos_x, pos_y des Buttons
            // Achtung: Index fängt ab 1 an zu zählen. Array-(Felder-)zugriffe fangen ab 0 an.
            int zeile = e.RowIndex;
            int spalte = e.ColumnIndex;
            Feld angeklicktesFeld = Spielfeld[spalte - 1, zeile - 1];

            // Kann ich dieses Feld überhaupt anklicken, bzw. kann mein Stein draufgelegt werden
            bool kannGesetztWerden = UeberpruefeObSteinGesetztWerdenKann(zeile, spalte, angeklicktesFeld);
            if(kannGesetztWerden == true)
            {
                // Holde das Feld aus der Spielfeld-Logik heraus und setze dann das Feld mit meinem Stein
                SetzeSpielersteinAufFeld();

                // Färbe das Feld in der Oberfläche mit meiner Farbe 
                FaerbeFeldInOberflaeche(zeile, spalte);
            }
            else
            {
                // nichts machen oder ausgabe: Feld ungültig
                return;
            }


            // Optimierung: Erst nach dem 4. mal prüfen (als wenn der Spieler 4 mal gesetzt hat)
            bool hatSchonVierMalGesetzt = UeberpfuefeObSchonVierMalGesetzt();
            if(hatSchonVierMalGesetzt == false)
            {
                // Rundenwechsel (Falls man noch nicht gewonne hat)
                Spielerwechsel();
            }

            // Überprüfe ob man gewonnen hat
            bool hatGewonnen = UeberpruefeObGewonnen();
            if(hatGewonnen == true)
            {
                // Falls zutrifft => Man hat gewonnen und ruft die Gewonnen Funktion auf 
                Gewonnen();
                return;
            }
            else
            {
                // Was ist wenn alle Felder belegt sind, aber kein Spieler gewonnen hat
                bool alleFelderBelegt = SindAlleFelderBelegt();
                if(alleFelderBelegt == true)
                {
                    // Ausgabe: Unentschieden
                    // Neustart!
                    // SpielNeustarten();
                }
                else
                {                 
                    // Rundenwechsel (Falls man noch nicht gewonne hat)
                    Spielerwechsel();
                }
            }

            // Zusatz:
                // Spielfeldgröße in der Oberfläche einstellbar
                // Rundenausgabe, Counter Gewinne
        }

        /// <summary>
        /// Macht Dominik
        /// </summary>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        /// <param name="angeklicktesFeld"></param>
        /// <returns></returns>
        public bool UeberpruefeObSteinGesetztWerdenKann(int zeile, int spalte, Feld angeklicktesFeld)
        {
            // Ist es schon vergeben ?
            // Ist das Feld drunter belegt
            // Das erste Feld in der Spalte kann nur gesetzt werden, wenn des die unterste ist (Physik)

            return true;
        }

        /// <summary>
        /// Macht Konstantin
        /// </summary>
        /// <param name="zeile"></param>
        /// <param name="spalte"></param>
        public void FaerbeFeldInOberflaeche(int zeile, int spalte)
        {
            // Beispielcode
            if (Spielfeld_GUI[spalte, zeile] is DataGridViewButtonCell && zeile >= 0)
            {
                // Ein Button wurde im Spielfeld angeklickt
                Spielfeld_GUI[spalte, zeile].Style.BackColor = Color.Red;

                // Beende die Selektion
                Spielfeld_GUI.ClearSelection();
            }
        }

        /// <summary>
        /// Macht Konstantin
        /// </summary>
        public void SetzeSpielersteinAufFeld()
        {

        }

        /// <summary>
        /// Macht Tobi
        /// </summary>
        /// <returns></returns>
        public bool UeberpruefeObGewonnen()
        {
            // Untersuche, ob sich eine Reihe gebildet hat, die aus 4 seinen Steinen beseht (um ihn herum)
            return false;
        }

        /// <summary>
        /// Macht Lukas
        /// </summary>
        public void Gewonnen()
        {
            MessageBoxButtons okButton = MessageBoxButtons.OK;
            MessageBox.Show("Spieler 1 hat gewonnen", "Resultat", okButton);

            // Spiel neustarten?
            // SpielNeustarten();
        }

        /// <summary>
        /// Macht Lukas
        /// </summary>
        /// <returns></returns>
        public bool SindAlleFelderBelegt()
        {
            return false;
        }

        /// <summary>
        /// Macht Lukas
        /// </summary>
        public void Unentschieden()
        {
            // Ausgabe Unentschieden
        }

        /// <summary>
        /// Macht Dominik
        /// </summary>
        public void Spielerwechsel()
        {
            // Wechsel des aktuellen Spielers
            // Wechsel der Farbe
        }

        /// <summary>
        /// Macht (Nick), wird neu vergeben, falls jemand zu wenig hat oder mehr machen will
        /// </summary>
        public void SpielNeustarten()
        {
            // Sielneustart
            // Felder müssen alle geleert werden
            // Spieler 1 ist wieder drann
            // Oberfläche muss auch "geleert" werden => ursprüngliche Stand
        }

        /// <summary>
        /// Macht Konstantin
        /// </summary>
        /// <returns></returns>
        public bool UeberpfuefeObSchonVierMalGesetzt()
        {
            return false;
        }
    }
}
