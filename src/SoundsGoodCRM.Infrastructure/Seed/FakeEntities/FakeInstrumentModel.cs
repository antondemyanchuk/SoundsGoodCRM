using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeInstrumentModel : InstrumentModel
    {
        public FakeInstrumentModel(int index, FakeInstrumentSpecification fis) 
        {
            Id = index + 1;
            ModelName = fis.instrumentModels[index];
        }
    }
}
