using Bogus;
using SoundsGoodCRM.Core.Entities.Customers;
using SoundsGoodCRM.Core.Entities.DataModels;
using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Core.Entities.Orders;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeData;
using SoundsGoodCRM.Core.Entities.Seed.FakeEntities.AdditionalFakeDataHelpers;
using SoundsGoodCRM.Entities.Employees;

namespace SoundsGoodCRM.Core.Entities.Seed
{
    internal class FakeDBDataGenerator
    {
        private readonly int _quantity = 5;
        private readonly int _employeCounter = 5;

        public List<Customer> Customers { get; set; }
        public List<CustomerAuthorization> CustomerAuthorization { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Post> Posts { get; set; }
        public List<Instrument> Instruments { get; set; }
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


        public FakeDBDataGenerator(int quantity, int employeeCounter)
        {
            if (quantity > _quantity) _quantity = quantity;
            if (employeeCounter > _employeCounter) _employeCounter = employeeCounter;

            GenerateFakeData(_quantity, _employeCounter, new Faker());
            GenerateFakeOrderStatusTimeLog();
        }

        private void GenerateFakeData(int quantity, int employeCounter, Faker faker)
        {
            int employeeCreateIndex = 0;
            var fakeInstrumentSpecification = new FakeInstrumentSpecification();
            var fakeOrderSpecification = new FakeOrderSpecification();
            var fakeEmployeePermission = new FakeEmployeePermissionSpecification();
            int[] firstRandomNumbersArray = [.. Enumerable.Range(1, quantity).OrderBy(x => Guid.NewGuid())];
            int[] secondRandomNumbersArray = [.. Enumerable.Range(1, quantity).OrderBy(x => Guid.NewGuid())];

            for (int i = 0; i < quantity; i++)
            {

                var customer = new FakeCustomer(i, faker, firstRandomNumbersArray);
                Customers.Add(customer);

                var contact = new FakeContact(i, faker, customer);
                Contacts.Add(contact);

                var customerAuthorization = new FakeCustomerAuthorization(i, contact, faker);
                CustomerAuthorization.Add(customerAuthorization);

                var post = new FakePost(i, faker);
                Posts.Add(post);

                var instrument = new FakeInstrument(i, faker, secondRandomNumbersArray, fakeInstrumentSpecification);
                Instruments.Add(instrument);

                if (i < fakeInstrumentSpecification.instrumentBrands.Length)
                {
                    var instrumentBrand = new FakeInstrumentBrand(i, fakeInstrumentSpecification);
                    InstrumentBrands.Add(instrumentBrand);
                }

                if (i < fakeInstrumentSpecification.instrumentModels.Length)
                {

                    var instrumentModel = new FakeInstrumentModel(i, fakeInstrumentSpecification);
                    InstrumentModels.Add(instrumentModel);
                }

                if (i < fakeInstrumentSpecification.instrumentTunes.Length)
                {
                    var instrumentTune = new FakeInstrumentTune(i, fakeInstrumentSpecification);
                    InstrumentTunes.Add(instrumentTune);
                }

                if (i < fakeInstrumentSpecification.instrumentTypes.Length)
                {
                    var instrumentType = new FakeInstrumentType(i, fakeInstrumentSpecification);
                    InstrumentTypes.Add(instrumentType);
                }

                if (i < fakeOrderSpecification.orderStatuses.Length)
                {
                    var orderStatus = new FakeOrderStatus(i, fakeOrderSpecification);
                    OrderStatuses.Add(orderStatus);
                }

                if (i < fakeOrderSpecification.orderTasks.Length)
                {
                    var orderTask = new FakeOrderTask(i, fakeOrderSpecification, faker);
                    OrderTasks.Add(orderTask);
                }
            }

            for (int i = 0; i < quantity * 2; i++)
            {
                var order = new FakeOrder(i, quantity, employeCounter, fakeOrderSpecification, faker);
                Orders.Add(order);
            }

            for (int i = quantity; i < quantity + employeCounter; i++)
            {
                var employee = new FakeEmployee(employeeCreateIndex, i,fakeEmployeePermission.employeePermissions, faker);
                Employees.Add(employee);
                
                var contact = new FakeContact(i, faker, employee);
                Contacts.Add(contact);

                var employeeAuthorization = new FakeEmployeeAuthorization(employeeCreateIndex, contact, faker);
                EmployeeAuthorizations.Add(employeeAuthorization);

                if (employeeCreateIndex < fakeEmployeePermission.employeePermissions.Length)
                {
                    var employeePermission = new FakeEmployeePermission(employeeCreateIndex, fakeEmployeePermission);
                    EmployeePermissions.Add(employeePermission);
                }
                    employeeCreateIndex++;
            }

        }
           
        private void GenerateFakeOrderStatusTimeLog()
        {
            var fakeOrderSpecification = new FakeOrderSpecification();
            var faker = new Faker();
            foreach (var order in Orders)
            {
                for(int i = 0; i< faker.Random.Number(3, 7); i++)
                {
                    var orderStatusTimeLog = new FakeOrderStatusTimeLog(order, fakeOrderSpecification,faker);
                    OrderStatusTimeLogs.Add(orderStatusTimeLog);
                }
            }
        }
    }
}
