namespace SoundsGoodCRM.DAO.InstrumentModels
{
    public class InstrumentModel : EntityWithId
    {
        public string ModelName { get; set; }
        public int TypeId { get; set; }
        public int BrandId { get; set; }
        public InstrumentType Type { get; set; }
        public InstrumentBrand Brand { get; set; }
        public List<Instrument> Instuments { get; set; }
        public InstrumentModel( int id, string modelName, int typeId, int brandId) 
        {
            Id = id;
            ModelName = modelName;
            TypeId = typeId;
            BrandId = brandId;
        }
    }
}
