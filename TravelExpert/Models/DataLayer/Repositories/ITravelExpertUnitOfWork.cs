namespace TravelExpert.Models
{
    public interface ITravelExpertUnitOfWork
    {
        Repository<Affiliation> Affiliations { get; }
        Repository<Agency> Agencies { get; }
        Repository<Agent> Agents { get; }
        Repository<Booking> Bookings { get; }
        Repository<BookingDetail> BookingDetails { get; }
        Repository<Class> Classes { get; }
        Repository<CreditCard> CreditCards { get; }
        Repository<Customer> Customers { get; }
        //Repository<CustomersReward> CustomerRewards { get; }
        Repository<Employee> Employees { get; }
        Repository<Fee> Fees { get; }
        Repository<Package> Packages { get; }
        Repository<PackagesProductsSupplier> PackagesProductsSuppliers { get; }
        Repository<Product> Products { get; }
        Repository<ProductsSupplier> ProductsSuppliers { get; }
        Repository<Region> Regions { get; }
        Repository<Reward> Rewards { get; }
        Repository<Supplier> Suppliers { get; }
        Repository<SupplierContact> SupplierContacts { get; }
        Repository<TripType> TripTypes { get; }


        //void DeleteCurrentBookAuthors(Book book);
        //void LoadNewBookAuthors(Book book, int[] authorids);

        void Save();
    }
}
