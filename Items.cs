using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace StoreItems
{
    public class Items
    {
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }

        public static List<Items> GetItems(){
            return new List<Items>{ // Collection of items
                new Items{

                Quantity = 15,
                Name = "Chocolate Bar",
                Date = DateTime.Now,
                },
                new Items{

                Quantity = 65,
                Name = "Water Bottle",
                Date = DateTime.Now,
                },
                new Items{

                Quantity = 20,
                Name = "NoteBoosk",
                Date = DateTime.Now,
                },new Items{

                Quantity = 50,
                Name = "Tissue Pack",
                Date = DateTime.Now,
                },
                new Items{

                Quantity = 10,
                Name = "Soda Can",
                Date = DateTime.Now,
                },

            };


        }
    }
    public class ItemsInfoClassMap : ClassMap<Items> // inherited form Items to nameing the columns
    {
        public ItemsInfoClassMap()
        {
            Map(r => r.Quantity).Name("quantity");
            Map(r => r.Name).Name("name");
            Map(r => r.Date).Name("date").TypeConverterOption.Format("s");
        }
    }
}