using StoreItems;
using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Security;
using System.Linq;



//In this project I will  create and read a CSV file in C# from a list or collection using the open source CsvHelper .NET Standard library. 

public class Program
{
    static void Main(string[] args)
    {
        List<Items> items = Items.GetItems();
        //Serialization
        var csvPath = Path.Combine(Environment.CurrentDirectory, $"storeItems-{DateTime.Now.ToFileTime()}.csv");
        using (var streamWriter = new StreamWriter(csvPath))
        {
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {

                var csvItems = Items.GetItems();
                csvWriter.Context.RegisterClassMap<ItemsInfoClassMap>();
                csvWriter.WriteRecords(csvItems);
            }
        }


        // deserialization
        using (var streamReader = new StreamReader(@"Write here you file name path"))
        {
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<dynamic>().ToList();
            }
        }
    }
}
