using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    public struct FakeInstrumentsSpecification
    {
        internal string[] instrumentTunes = ["in C", "in D", "in Es", "in F", "in G", "in A", "in B"];
        internal string[] instrumentTypes = ["Flute", "Oboe", "Clarinet", "Bassoon", "Saxophone", "Trumpet", "Trombone", "Tuba", "French Horn"];
        internal string[] instrumentBrands = ["Selmer", "Buffet", "Muramatsu", "Yanagisawa", "Miazawa", "Yamaha", "Alexander", "Bach", "Holton", "SML", "Noblet"];
        internal string[] instrumentModels = ["Prestige", "Festival", "56", "112", "Signature", "Privilege", "901", "2001", "2016", "910", "Artist", "II", "III", "Mark VI", "Mark VII"];

        public FakeInstrumentsSpecification()
        {
        }
        public FakeInstrumentsSpecification(string[] instrumentTunes, string[] instrumentTypes, string[] instrumentBrands, string[] instrumentModels)
        {
            this.instrumentTunes = instrumentTunes;
            this.instrumentTypes = instrumentTypes;
            this.instrumentBrands = instrumentBrands;   
            this.instrumentModels = instrumentModels;
        }
    }
}
