

using EfCore.Model;

var context = new BikeStoreV2Context();

foreach (var brand in context.Brands)
{
    Console.WriteLine(brand.Name);
}
