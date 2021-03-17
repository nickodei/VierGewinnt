using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VierGewinnt
{
    public class Feld
    {
        /// <summary>
        /// Aktuelle Spieler, der auf dem Feld drauf ist
        /// Ist kein Spieler drauf (NULL), dann ist dieses Feld auch noch nicht belegt
        /// </summary>
        private Spieler? Spieler = null;

        /// <summary>
        /// Neuen Spieler für dieses Feld setzen
        /// </summary>
        /// <param name="spieler"></param>
        public void SetzeSpieler(Spieler spieler)
        {
            Spieler = spieler;
        }

        /// <summary>
        /// Überprüft, ob dieses Feld von einem Spieler schon belegt ist
        /// </summary>
        /// <returns></returns>
        public bool IstBelegt()
        {
            return Spieler != null;
        }
    }
}
