namespace SoundsGoodCRM.Core.Entities.Instruments
{
    public class InstrumentTune : EntityWithId
    {
        public string TuneName { get; set; }
        public List<Instrument> Instruments { get; set; }

    }
}
