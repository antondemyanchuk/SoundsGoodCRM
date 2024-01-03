using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeInstrumentType :InstrumentType
    {
        public FakeInstrumentType(int index, FakeInstrumentSpecification fis) 
        {
            Id = index+1;
            TypeName = fis.instrumentTypes[index];
        }
    }
}
