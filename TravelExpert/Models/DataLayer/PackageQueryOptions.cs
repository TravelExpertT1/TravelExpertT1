//using System.Linq;

//namespace TravelExpert.Models
//{
//    public class PackageQueryOptions : QueryOptions<Package>
//    {
//        public void SortFilter(PackagesGridBuilder builder)
//        {
//            if (builder.IsFilterByGenre) {
//                Where = b => b.PackageId == builder.CurrentRoute.PackageFilter;
//            }
//            if (builder.IsFilterByPrice) {
//                if (builder.CurrentRoute.PriceFilter == "under7")
//                    Where = b => b.PkgBasePrice < 7;
//                else if (builder.CurrentRoute.PriceFilter == "7to14")
//                    Where = b => b.PkgBasePrice >= 7 && b.PkgBasePrice <= 14;
//                else
//                    Where = b => b.PkgBasePrice > 14;
//            }
//            //if (builder.IsFilterByAuthor) {
//            //    int id = builder.CurrentRoute.AuthorFilter.ToInt();
//            //    if (id > 0)
//            //        Where = b => b.BookAuthors.Any(ba => ba.Author.AuthorId == id);
//            //}

//            //if (builder.IsSortByGenre) {
//            //    OrderBy = b => b.Genre.Name;
//            //}
//            //else if (builder.IsSortByPrice) {
//            //    OrderBy = b => b.Price;
//            //}
//            //else  {
//            //    OrderBy = b => b.Title;
//            //}
//        }
//    }
//}
