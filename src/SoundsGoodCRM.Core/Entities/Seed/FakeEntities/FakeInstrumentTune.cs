using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeInstrumentTune : InstrumentTune
    {
        public FakeInstrumentTune(int index, FakeInstrumentSpecification fakeInstrumentSpecification) 
        {
            Id = index + 1;
            TuneName = fakeInstrumentSpecification.instrumentTunes[index];
        }
    }
}
