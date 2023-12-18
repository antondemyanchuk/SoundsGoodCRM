namespace SoundsGoodCRM.Core.Entities.Instruments
{
    public class InstrumentType : EntityWithId
    {
        public string TypeName { get; set; }
        public List<Instrument> Instruments { get; set; }
    }
}
