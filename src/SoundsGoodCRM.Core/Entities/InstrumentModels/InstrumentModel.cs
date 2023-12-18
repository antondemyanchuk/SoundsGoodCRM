namespace SoundsGoodCRM.Core.Entities.Instruments
{
    public class InstrumentModel : EntityWithId
    {
        public string ModelName { get; set; }

        public List<Instrument> Instuments { get; set; }
        public InstrumentModel() { }
        public InstrumentModel(string modelName) 
        {
            ModelName = modelName;
        }
    }
}
