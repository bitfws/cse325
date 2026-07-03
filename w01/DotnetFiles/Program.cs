using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

// Write totals file
File.AppendAllText(
    Path.Combine(salesTotalDir, "totals.txt"),
    $"{salesTotal}{Environment.NewLine}"
);

// NEW: Generate summary report
var summary = GenerateSalesSummary(salesFiles);

File.WriteAllText(
    Path.Combine(salesTotalDir, "summary.txt"),
    summary
);

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(
        folderName,
        "*",
        SearchOption.AllDirectories
    );

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);

        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    foreach (var file in salesFiles)
    {
        string salesJson = File.ReadAllText(file);

        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

// NEW FUNCTION: Sales Summary Report
string GenerateSalesSummary(IEnumerable<string> salesFiles)
{
    var report = new StringBuilder();
    double total = 0;

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine();

    foreach (var file in salesFiles)
    {
        string json = File.ReadAllText(file);
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(json);

        double amount = data?.Total ?? 0;
        total += amount;

        report.AppendLine($"{Path.GetFileName(file)}: {amount.ToString("C")}");
    }

    report.AppendLine();
    report.AppendLine($"Total Sales: {total.ToString("C")}");

    return report.ToString();
}

record SalesData(double Total);