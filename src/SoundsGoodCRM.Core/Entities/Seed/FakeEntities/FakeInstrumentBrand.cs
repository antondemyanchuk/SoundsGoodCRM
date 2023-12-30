using SoundsGoodCRM.Core.Entities.Instruments;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeInstrumentBrand : InstrumentBrand
    {
        public FakeInstrumentBrand(int index, FakeInstrumentsSpecification fis)
        {
            Id = index + 1;
            BrandName = fis.instrumentBrands[index];
        }
    }
}
