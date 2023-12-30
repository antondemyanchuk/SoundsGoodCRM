using Bogus;
using SoundsGoodCRM.Core.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundsGoodCRM.Core.Entities.Seed.FakeEntitieCreators
{
    internal sealed class FakePost : Post
    {
        string[] _postProvider = ["Nova Poshta", "UkrPoshta", "Meest", "Delivery"];
        string[] _city = ["Kiev", "Dnipro", "Lviv", "Chernigiv", "Cherkassy", "Symu", "Rivne", "Lutsk", "Ternopil", "Chernivtsi", "Odesa", "Kropivnitski", "Zytomir"];

        internal FakePost(int index, Faker faker) 
        {
            Id = index + 1;
            PostProvider = _postProvider[faker.Random.Number(0, _postProvider.Length - 1)];
            City = _city[faker.Random.Number(0, _city.Length - 1)];
            PostCentreId = faker.Random.Number(1, 300);
        }
        internal FakePost(int index, Faker faker, string[] postProvider, string[] city)
        {
            Id = index + 1;
            PostProvider = postProvider[faker.Random.Number(0, postProvider.Length - 1)];
            City = city[faker.Random.Number(0, city.Length - 1)];
            PostCentreId = faker.Random.Number(1, 300);
        }
    }
}
