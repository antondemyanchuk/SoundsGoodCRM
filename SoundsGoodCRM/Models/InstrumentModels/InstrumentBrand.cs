namespace SoundsGoodCRM.Models.InstrumentModels
{
    public class InstrumentBrand : EntityWithId
    {
        public string BrandName { get; set; }
        public List<InstrumentModel> InstrumentModels { get; set; }
    }
}
