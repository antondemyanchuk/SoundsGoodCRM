using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeInstrumentBrand : InstrumentBrand
    {
        public FakeInstrumentBrand(int index, FakeInstrumentSpecification fis)
        {
            Id = index + 1;
            BrandName = fis.instrumentBrands[index];
        }
    }
}
