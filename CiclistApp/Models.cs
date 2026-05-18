using System.ComponentModel;

namespace CiclistApp
{
    public class TraseuDetalii
    {
        [DisplayName("ID Traseu")]
        public int IdTraseu { get; set; }

        [DisplayName("Denumire")]
        public string Denumire { get; set; }

        [DisplayName("Distanță (km)")]
        public double DistantaKm { get; set; }

        [DisplayName("Dificultate")]
        public string Dificultate { get; set; }

        [DisplayName("Durată (minute)")]
        public int DurataMinute { get; set; }
    }
}