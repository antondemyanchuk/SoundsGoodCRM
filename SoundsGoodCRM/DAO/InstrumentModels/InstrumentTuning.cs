namespace SoundsGoodCRM.DAO.InstrumentModels
{
    public class InstrumentTuning : EntityWithId
    {
        public string Tune { get; set; }
        public List<Instrument> Instruments { get; set; }
    }
}
