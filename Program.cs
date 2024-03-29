using StoreItems;
using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Security;

//In this project I will  create a CSV file in C# from a list or collection using the open source CsvHelper .NET Standard library. 

public class Program
{
    static void Main(string[] args)
    {
        List<Items> items = Items.GetItems();
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
    }
}
