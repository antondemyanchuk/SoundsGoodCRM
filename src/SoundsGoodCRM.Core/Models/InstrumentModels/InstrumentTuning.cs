namespace SoundsGoodCRM.DAO.InstrumentModels
{
    public class InstrumentTuning : EntityWithId
    {
        public string Tune { get; set; }
        public List<Instrument> Instruments { get; set; }
        public InstrumentTuning() { }
        public InstrumentTuning(InstrumentTuning tuning) 
        {
            Id = tuning.Id;
            Tune = tuning.Tune;
        }
    }
}
