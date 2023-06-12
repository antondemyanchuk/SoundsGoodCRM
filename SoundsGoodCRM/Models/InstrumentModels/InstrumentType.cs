namespace SoundsGoodCRM.Models.InstrumentModels
{
    public class InstrumentType : EntityWithId
    {
        public string Type { get; set; }
        public List<InstrumentModel> InstrumentModels { get; set; }
    }
}
