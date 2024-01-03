﻿using Bogus;
using Bogus.DataSets;
using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntities
{
    internal sealed class FakeInstrument : Instrument
    {
        internal FakeInstrument(int index, Faker faker, int[] randomNumbersArray, FakeInstrumentSpecification fakeInstrumentsSpecification)
        {
            Id = index + 1;
            CustomerId = randomNumbersArray[index];
            SerialNumber = faker.Random.AlphaNumeric(7);
            InstrumentTuneId = faker.Random.Number(1, fakeInstrumentsSpecification.instrumentTunes.Length);
            InstrumentTypeId = faker.Random.Number(1, fakeInstrumentsSpecification.instrumentTypes.Length);
            InstrumentBrandId = faker.Random.Number(1, fakeInstrumentsSpecification.instrumentBrands.Length);
            InstrumentModelId = faker.Random.Number(1, fakeInstrumentsSpecification.instrumentModels.Length);
        }
    }
}