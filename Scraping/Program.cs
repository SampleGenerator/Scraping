using CsvHelper;
using HtmlAgilityPack;
using Scraping;
using System.Globalization;

var web = new HtmlWeb();
var doc = web.Load("https://en.wikipedia.org/wiki/Greece");
var HeaderNames = doc.DocumentNode.SelectNodes("//span[@class='toctext']");

var titles = new List<Row>();
foreach (var item in HeaderNames)
{
    titles.Add(new Row { Title = item.InnerText });
}

using var writer = new StreamWriter(@"D:\example.csv");
using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
csv.WriteRecords(titles);