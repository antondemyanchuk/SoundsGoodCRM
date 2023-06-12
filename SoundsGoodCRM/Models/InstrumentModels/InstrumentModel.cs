namespace SoundsGoodCRM.Models.InstrumentModels
{
    public class InstrumentModel : EntityWithId
    {
        public string ModelName { get; set; }
        public int TypeId { get; set; }
        public int BrandId { get; set; }
        public InstrumentType Type { get; set; }
        public InstrumentBrand Brand { get; set; }
        public List<Instrument> Instuments { get; set; }
    }
}
