using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.models
{
    public class CycleData
    {
        public CycleData(DateTime date_Time, int tijdsduur, int gemiddeldeWattage, int maximumWattage, int gemiddeldeCadans, int maximumCadans, string trainingsType, string commentaar, int klantNummer)
        {
            Date_Time = date_Time;
            Tijdsduur = tijdsduur;
            GemiddeldeWattage = gemiddeldeWattage;
            MaximumWattage = maximumWattage;
            GemiddeldeCadans = gemiddeldeCadans;
            MaximumCadans = maximumCadans;
            TrainingsType = trainingsType;
            Commentaar = commentaar;
            KlantNummer = klantNummer;
        }

        public DateTime Date_Time { get; set; }
        public int Tijdsduur { get; set; }
        public int GemiddeldeWattage { get; set; }
        public int MaximumWattage { get; set; }
        public int GemiddeldeCadans { get; set; }
        public int MaximumCadans { get; set; }
        public string TrainingsType { get; set; } = "";
        public string Commentaar { get; set; } = "";
        public int KlantNummer { get; set; }

        public override string ToString()
        {
            return 
                $"Date & Time : {Date_Time} \n" +
                $"Tijdsduur : {Tijdsduur} \n" +
                $"GemiddeldeWattage : {GemiddeldeWattage} \n" +
                $"MaximumWattage : {MaximumWattage} \n" +
                $"GemiddeldeCadans : {GemiddeldeCadans} \n" +
                $"MaximumCadans : {MaximumCadans} \n" +
                $"TrainingsType : {TrainingsType} \n" +
                $"Commentaar : {Commentaar} \n" +
                $"KlantNummer : {KlantNummer} \n";
        }
    }
}
