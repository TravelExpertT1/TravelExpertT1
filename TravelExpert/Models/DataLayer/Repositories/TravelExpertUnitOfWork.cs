using System.Linq;

namespace TravelExpert.Models
{
    public class TravelExpertUnitOfWork : ITravelExpertUnitOfWork
    {
        private TravelExpertsContext context { get; set; }
        public TravelExpertUnitOfWork(TravelExpertsContext ctx) => context = ctx;



        private Repository<Affiliation> affiliationData;
        public Repository<Affiliation> Affiliations {
            get {
                if (affiliationData == null)
                    affiliationData = new Repository<Affiliation>(context);
                return affiliationData;
            }
        }

        private Repository<Agency> agencyData;
        public Repository<Agency> Agencies {
            get {
                if (agencyData == null)
                    agencyData = new Repository<Agency>(context);
                return agencyData;
            }
        }

        private Repository<Agent> agentData;
        public Repository<Agent> Agents
        {
            get {
                if (agentData == null)
                    agentData = new Repository<Agent>(context);
                return agentData;
            }
        }

        private Repository<Booking> bookingData;
        public Repository<Booking> Bookings
        {
            get
            {
                if (bookingData == null)
                    bookingData = new Repository<Booking>(context);
                return bookingData;
            }
        }

        private Repository<BookingDetail> bookingDetailData;
        public Repository<BookingDetail> BookingDetails
        {
            get
            {
                if (bookingDetailData == null)
                    bookingDetailData = new Repository<BookingDetail>(context);
                return bookingDetailData;
            }
        }



        private Repository<Class> classData;
        public Repository<Class> Classes
        {
            get
            {
                if (classData == null)
                    classData = new Repository<Class>(context);
                return classData;
            }
        }

        private Repository<CreditCard> creditCardData;
        public Repository<CreditCard> CreditCards
        {
            get
            {
                if (creditCardData == null)
                    creditCardData = new Repository<CreditCard>(context);
                return creditCardData;
            }
        }

        private Repository<Customer> customerData;
        public Repository<Customer> Customers
        {
            get
            {
                if (customerData == null)
                    customerData = new Repository<Customer>(context);
                return customerData;
            }
        }

        //private Repository<CustomersReward> customersRewardData;
        //public Repository<CustomersReward> CustomersRewards
        //{
        //    get
        //    {
        //        if (customersRewardData == null)
        //            customersRewardData = new Repository<CustomersReward>(context);
        //        return customersRewardData;
        //    }
        //}


        private Repository<Employee> employeeData;
        public Repository<Employee> Employees
        {
            get
            {
                if (employeeData == null)
                    employeeData = new Repository<Employee>(context);
                return employeeData;
            }
        }

        private Repository<Fee> feeData;
        public Repository<Fee> Fees
        {
            get
            {
                if (feeData == null)
                    feeData = new Repository<Fee>(context);
                return feeData;
            }
        }


        private Repository<Package> packageData;
        public Repository<Package> Packages
        {
            get
            {
                if (packageData == null)
                    packageData = new Repository<Package>(context);
                return packageData;
            }
        }

        private Repository<PackagesProductsSupplier> packagesProductsSupplierData;
        public Repository<PackagesProductsSupplier> PackagesProductsSuppliers
        {
            get
            {
                if (packagesProductsSupplierData == null)
                    packagesProductsSupplierData = new Repository<PackagesProductsSupplier>(context);
                return packagesProductsSupplierData;
            }
        }

        private Repository<Product> productData;
        public Repository<Product> Products
        {
            get
            {
                if (productData == null)
                    productData = new Repository<Product>(context);
                return productData;
            }
        }

        private Repository<ProductsSupplier> productsSupplierData;
        public Repository<ProductsSupplier> ProductsSuppliers
        {
            get
            {
                if (productsSupplierData == null)
                    productsSupplierData = new Repository<ProductsSupplier>(context);
                return productsSupplierData;
            }
        }

        private Repository<Region> regionData;
        public Repository<Region> Regions
        {
            get
            {
                if (regionData == null)
                    regionData = new Repository<Region>(context);
                return regionData;
            }
        }

        private Repository<Reward> rewardData;
        public Repository<Reward> Rewards
        {
            get
            {
                if (rewardData == null)
                    rewardData = new Repository<Reward>(context);
                return rewardData;
            }
        }
        private Repository<Supplier> supplierData;
        public Repository<Supplier> Suppliers
        {
            get
            {
                if (supplierData == null)
                    supplierData = new Repository<Supplier>(context);
                return supplierData;
            }
        }

        private Repository<SupplierContact> supplierContactData;
        public Repository<SupplierContact> SupplierContacts
        {
            get
            {
                if (supplierContactData == null)
                    supplierContactData = new Repository<SupplierContact>(context);
                return supplierContactData;
            }
        }

        private Repository<TripType> tripTypeData;
        public Repository<TripType> TripTypes
        {
            get
            {
                if (tripTypeData == null)
                    tripTypeData = new Repository<TripType>(context);
                return tripTypeData;
            }
        }


        //public void DeleteCurrentBookAuthors(Book book)
        //{
        //    var currentAuthors = BookAuthors.List(new QueryOptions<BookAuthor> {
        //        Where = ba => ba.BookId == book.BookId
        //    });
        //    foreach (BookAuthor ba in currentAuthors) {
        //        BookAuthors.Delete(ba);
        //    }
        //}

        //public void LoadNewBookAuthors(Book book, int[] authorids)
        //{
        //    book.BookAuthors = authorids.Select(i =>
        //        new BookAuthor { Book = book, AuthorId = i })
        //        .ToList();
        //}

        public void Save() => context.SaveChanges();
    }
}