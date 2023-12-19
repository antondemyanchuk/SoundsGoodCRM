namespace SoundsGoodCRM.Core.Entities.Instruments
{
    public class InstrumentBrand : EntityWithId
    {
        public string BrandName { get; set; }
        public List<Instrument> Instruments { get; set; }
    }
}
