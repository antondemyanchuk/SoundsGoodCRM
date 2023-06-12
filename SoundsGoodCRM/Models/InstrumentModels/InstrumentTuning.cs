namespace SoundsGoodCRM.Models.InstrumentModels
{
    public class InstrumentTuning : EntityWithId
    {
        public string Tune { get; set; }
        public List<Instrument> Instruments { get; set; }
    }
}
