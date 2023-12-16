namespace SoundsGoodCRM.DAO.InstrumentModels
{
    public class InstrumentBrand : EntityWithId
    {
        public string BrandName { get; set; }
        public List<InstrumentModel> InstrumentModels { get; set; }
        public InstrumentBrand() { }
        public InstrumentBrand(InstrumentBrand instrument)
        {
            Id = instrument.Id;
            BrandName = instrument.BrandName;
        }
    }
}
