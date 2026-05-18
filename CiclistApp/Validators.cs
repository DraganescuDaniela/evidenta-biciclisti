using System.Windows.Forms;

namespace CiclistApp
{
    public static class Validators
    {
        public static bool ValidateCnp(string cnp)
        {
            if (cnp.Length != 13)
            {
                ShowError("CNP-ul trebuie să conțină exact 13 caractere!");
                return false;
            }
            return true;
        }

        public static bool ValidateNume(string nume)
        {
            if (string.IsNullOrWhiteSpace(nume))
            {
                ShowError("Numele nu poate fi gol!");
                return false;
            }
            return true;
        }

        public static bool ValidateDistanta(string text, out double distanta)
        {
            if (!double.TryParse(text.Trim(), out distanta) || distanta <= 0)
            {
                ShowError("Distanța traseului trebuie să fie mai mare decât 0!");
                return false;
            }
            return true;
        }

        public static bool ValidateDurata(string text, out int durata)
        {
            if (!int.TryParse(text.Trim(), out durata) || durata <= 0)
            {
                ShowError("Durata traseului trebuie să fie mai mare decât 0!");
                return false;
            }
            return true;
        }

        public static void ShowError(string mesaj)
        {
            MessageBox.Show(mesaj, "Eroare validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}