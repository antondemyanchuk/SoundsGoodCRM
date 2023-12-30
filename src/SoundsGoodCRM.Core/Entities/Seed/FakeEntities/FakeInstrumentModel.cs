using SoundsGoodCRM.Core.Entities.Instruments;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeInstrumentModel : InstrumentModel
    {
        public FakeInstrumentModel(int index, FakeInstrumentsSpecification fis) 
        {
            Id = index + 1;
            ModelName = fis.instrumentModels[index];
        }
    }
}
