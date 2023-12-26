using Bogus;
using SoundsGoodCRM.Core.Entities.Customers;
using SoundsGoodCRM.Core.Entities.DataModels;
using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Core.Entities.Orders;
using SoundsGoodCRM.Entities.Employees;

namespace SoundsGoodCRM.Core.Entities.Seed
{
    internal class FakeDBDataGenerator
    {
        public List<Customer> FakeCustomers { get; set; }
        public List<CustomerAuthorization> FakeCustomerAuthorisation { get; set; }
        public List<Contact> FakeContacts { get; set; }
        public List<Post> FakePosts { get; set; }
        public List<Instrument> FakeInstruments { get; set; }
        public List<InstrumentBrand> InstrumentBrands { get; set; }
        public List<InstrumentModel> InstrumentModels { get; set; }
        public List<InstrumentTune> InstrumentTunes { get; set; }
        public List<InstrumentType> InstrumentTypes { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderStatus> OrderStatuses { get; set; }
        public List<OrderStatusTimeLog> OrderStatusTimeLogs { get; set; }
        public List<OrderTask> OrderTasks { get; set; }
        public List<Employee> Employees { get; set; }
        public List<EmployeeAuthorization> EmployeeAuthorizations { get; set; }
        public List<EmployeePermission> EmployeePermissions { get; set; }


        public FakeDBDataGenerator(int count)
        {

        }


        //TODO: Divide GenereteFakeData to separate classes or methods
        private void GenerateFakeData(int count, int employeeCounter, Faker faker)
        {
            if (count < 5 || employeeCounter < count)
            {
                throw new ArgumentOutOfRangeException();
            }

            string[] postProvider = ["Nova Poshta", "UkrPoshta", "Meest", "Delivery"];
            string[] city = ["Kiev", "Dnipro", "Lviv", "Chernigiv", "Cherkassy", "Symu", "Rivne", "Lutsk", "Ternopil", "Chernivtsi", "Odesa", "Kropivnitski", "Zytomir"];
            string[] instrumentTunes = ["in C", "in D", "in Es", "in F", "in G", "in A", "in B"];
            string[] instrumentTypes = ["Flute", "Oboe", "Clarinet", "Bassoon", "Saxophone", "Trumpet", "Trombone", "Tuba", "French Horn"];
            string[] instrumentBrands = ["Selmer", "Buffet", "Muramatsu", "Yanagisawa", "Miazawa", "Yamaha", "Alexander", "Bach", "Holton", "SML", "Noblet"];
            string[] instrumentModels = ["Prestige", "Festival", "56", "112", "Signature", "Privilege", "901", "2001", "2016", "910", "Artist", "II", "III", "Mark VI", "Mark VII"];
            string[] orderStatuses = ["Received", "On diagnostic", "Pending", "Waiting for repair parts", "Canceled", "Done", "Ready for sending", "Send"];
            string[] orderTasks = ["Soldering",
                "Repadding",
                "Flat spring removing/installing",
                "Needle spring removing/installing",
                "Oiling",
                "Chemical cleaning",
                "Foot join cork removing/installing",
                "Cracks fixing",
                "Carbon rings installing",
                "Dent removing"];
            string[] employeePermissions = ["Admin", "Technician", "Supervisor"];
            int[] firstRandomNumbersArray = Enumerable.Range(1, count).OrderBy(x => Guid.NewGuid()).ToArray();
            int[] secondRandomNumbersArray = Enumerable.Range(1, count).OrderBy(x => Guid.NewGuid()).ToArray();

            for (int i = 0; i < count; i++)
            {

                var customer = new Customer
                {
                    Id = i + 1,
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    ContactId = i + 1,
                    PostId = firstRandomNumbersArray[i],
                    CustomerAuthorizationId = i + 1
                };
                FakeCustomers.Add(customer);

                var contact = new Contact
                {
                    Id = i + 1,
                    PhoneNumberPrimary = faker.Phone.PhoneNumber("+380 ## ### ## ##"),
                    PhoneNumberSecondary = faker.Phone.PhoneNumber("+380 ## ### ## ##"),
                    Email = faker.Internet.Email(customer.FirstName, customer.LastName)
                };
                FakeContacts.Add(contact);

                var customerAuthorization = new CustomerAuthorization
                {
                    Id = i + 1,
                    Login = contact.Email,
                    //TODO: Add hashing to the password
                    PasswordHash = faker.Internet.Password()
                };
                FakeCustomerAuthorisation.Add(customerAuthorization);

                var post = new Post
                {
                    Id = i + 1,
                    PostProvider = postProvider[faker.Random.Number(0, postProvider.Length - 1)],
                    City = city[faker.Random.Number(0, city.Length - 1)],
                    PostCentreId = faker.Random.Number(1, 300)
                };
                FakePosts.Add(post);

                var instrument = new Instrument
                {
                    Id = i + 1,
                    CustomerId = secondRandomNumbersArray[i],
                    SerialNumber = faker.Random.AlphaNumeric(7),
                    InstrumentTuneId = faker.Random.Number(1, instrumentTunes.Length),
                    InstrumentTypeId = faker.Random.Number(1, instrumentTypes.Length),
                    InstrumentBrandId = faker.Random.Number(1, instrumentBrands.Length),
                    InstrumentModelId = faker.Random.Number(1, instrumentModels.Length)
                };
                FakeInstruments.Add(instrument);

                if (i < instrumentBrands.Length)
                {
                    var instrumentBrand = new InstrumentBrand
                    {
                        Id = i + 1,
                        BrandName = instrumentBrands[i]
                    };
                    InstrumentBrands.Add(instrumentBrand);
                }

                if (i < instrumentModels.Length)
                {

                    var instrumentModel = new InstrumentModel
                    {
                        Id = i + 1,
                        ModelName = instrumentModels[i]
                    };
                    InstrumentModels.Add(instrumentModel);
                }

                if (i < instrumentTunes.Length)
                {
                    var instrumentTune = new InstrumentTune
                    {
                        Id = i + 1,
                        TuneName = instrumentTunes[i]
                    };
                    InstrumentTunes.Add(instrumentTune);
                }

                if (i < instrumentTypes.Length)
                {
                    var instrumentType = new InstrumentType
                    {
                        Id = i + 1,
                        TypeName = instrumentTypes[i]
                    };
                    InstrumentTypes.Add(instrumentType);
                }

                var order = new Order
                {
                    Id = i + 1,
                    CustomerId = faker.Random.Number(1, 100),
                    InstrumentId = faker.Random.Number(1, 100),
                    CreatedAt = faker.Date.Recent(365),
                    OrderStatusId = faker.Random.Number(1, orderStatuses.Length),
                    Description = faker.Commerce.ProductDescription(),
                    //TODO: Create a function to count Amount
                    TotalAmount = faker.Commerce.Price(1, 15000, 2, "₴"),
                    EmployeeId = faker.Random.Number(1, employeeCounter)
                };
                for (int j = 0; j < 5; j++)
                {
                    order.OrderTaskId.Add(faker.Random.Number(1, orderTasks.Length));
                }
                order.ComplitedAt = faker.Date.Soon(14, order.CreatedAt);
                Orders.Add(order);

                if (i < orderStatuses.Length)
                {
                    var orderStatus = new OrderStatus { Id = order.Id, StatusName = orderStatuses[i] };
                    OrderStatuses.Add(orderStatus);
                }

                if (i < orderTasks.Length)
                {
                    var orderTask = new OrderTask { Id = i + 1, TaskName = orderTasks[i], Value = faker.Random.Decimal(250.00m, 10000.00m) };
                    OrderTasks.Add(orderTask);
                }

            }
            for (int i = count; i < count + employeeCounter; i++)
            {
                int j = 0;
                var employee = new Employee
                {
                    Id = count + 1,
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    EmployeeAuthorizationId = count + 1,
                    EmployeePermissionId = faker.Random.Number(1, employeePermissions.Length),
                    ContactId = count + 1
                };
                Employees.Add(employee);

                var contact = new Contact
                {
                    Id = count + 1,
                    PhoneNumberPrimary = faker.Phone.PhoneNumber("+380 ## ### ## ##"),
                    PhoneNumberSecondary = faker.Phone.PhoneNumber("+380 ## ### ## ##"),
                    Email = faker.Internet.Email(employee.FirstName, employee.LastName)
                };
                FakeContacts.Add(contact);

                var employeeAuthorization = new EmployeeAuthorization
                {
                    Id = count + 1,
                    Login = contact.Email,
                    //TODO: Add hashing to the password
                    PasswordHash = faker.Internet.Password()
                };

                if (j < employeePermissions.Length)
                {
                    var employeePermission = new EmployeePermission
                    {
                        Id = j + 1,
                        PermissionName = employeePermissions[j]
                    };
                    j++;
                }
            }


            // TODO: Create a function to create fake OrderStatusTimeLog

            //    for(int l = 0; l<5; l++)
            //    {
            //        var orderStatusTimeLog = new OrderStatusTimeLog
            //        {
            //            OrderId = faker.Random.Number(i, count),
            //            OrderStatusId = faker.Random.Number(1, orderStatuses.Length)
            //            OrderStatusId = faker.Random.Number(1, orderStatuses.Length)
            //        };
            //            //orderStatusTimeLog.DateTime = faker.Date.Between
            //    }

        }

    }
}
