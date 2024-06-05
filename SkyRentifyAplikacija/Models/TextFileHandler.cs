using System.IO;
using System;

namespace SkyRentifyAplikacija.Models
{
    public class TextFileHandler
    {
        public string ReadFromFile(string filePath)
        {
            string sadrzaj = "";
            try
            {              
                sadrzaj = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                // Upravljanje greškom
                Console.WriteLine("Greška prilikom čitanja datoteke: " + ex.Message);
            }
            return sadrzaj;
        }
        public void WriteToFile(string putanja,string sadrzaj)
        {
            try
            {
                File.WriteAllText(putanja, "");
                File.WriteAllText(putanja, sadrzaj);
            }
            catch (Exception ex)
            {
                // Upravljanje greškom
                Console.WriteLine("Greška prilikom pisanja u datoteku: " + ex.Message);
            }
        }
    }
}
