namespace Lab;

using System;
using System.Linq;
using static Lab.ListGenerators;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Out of Stock Products");
        // var Result = ProductList.Where(P => P.UnitsInStock == 0);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // Console.WriteLine("-----------------------------------------");
        // Console.WriteLine("Products that are in stock and cost more than 3.00 per unit");
        // Result = ProductList.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 3);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        // var Result2 = Arr.Where((A,i) => i > A.Length );
        // foreach (var item in Result2)
        // {
        //     Console.WriteLine(item);
        // }    

        // Console.WriteLine("First Product out of Stock");
        // var frstOut = ProductList.FirstOrDefault(P => P.UnitsInStock == 0);
        // System.Console.WriteLine(frstOut);

        // System.Console.WriteLine("the first product whose Price > 1000");
        // var frstMoreThan1000 = ProductList.FirstOrDefault(P => P.UnitPrice > 1000);
        // System.Console.WriteLine(frstMoreThan1000);

        // System.Console.WriteLine("the second number greater than 5 ");
        // int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        // var f = Arr.Where(A => A > 5).Order().ElementAt(1);
        // System.Console.WriteLine(f);


        // System.Console.WriteLine("Sort a list of products by name");
        // var Result = ProductList.OrderBy(P => P.ProductName);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "CLovEr", "cHeRrY" };

        // Console.WriteLine("Before sort:");
        // foreach (var word in Arr)
        // {
        //     Console.WriteLine(word);
        // }

        // Array.Sort(Arr, new CaseInsensitiveComparer());

        // Console.WriteLine("\nAfter case-insensitive sort:");
        // foreach (var word in Arr)
        // {
        //     Console.WriteLine(word);
        // }
        // System.Console.WriteLine("Sort a list of products by units in stock from highest to lowest.");
        // var Result = ProductList.OrderByDescending(P => P.UnitsInStock);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        // var Result = Arr.OrderBy(A => A.Length).ThenBy(A => A);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        // var Result = words.OrderBy(w => w.Length)
        //     .ThenBy(w => w, new CaseInsensitiveComparer());

        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // Console.WriteLine("Sort a list of products, first by category, and then by unit price, from highest to lowest");
        // var Result = ProductList.OrderBy(P => P.Category).ThenByDescending(P => P.UnitPrice);
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }


        // string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        // var Result = Arr.OrderBy(A => A.Length).ThenByDescending(w => w, new CaseInsensitiveComparer());
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }


        // string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        // var Result = Arr.Where(A => A[1] == 'i').Reverse();
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }


        // var productNames = ProductList.Select(p => p.ProductName);
        // foreach (var name in productNames)
        // {
        //     Console.WriteLine(name);
        // }

        // string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
        // var upperLower = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
        // foreach (var word in upperLower)
        // {
        //     Console.WriteLine(word);
        // }


        // var Result = ProductList.Select(P => new { ProdName = P.ProductName, Price = P.UnitPrice });
        // foreach (var item in Result)
        // {
        //     Console.WriteLine(item);
        // }

        // int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        // var Result = Arr.Select((N, i) => new { N, InPlace = N == i });
        // foreach (var item in Result)
        // {
        //     Console.WriteLine($"{item.N} : {item.InPlace}");
        // }

        // int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        // int[] numbersB = { 1, 3, 5, 7, 8 };

        // var pairs = numbersA.SelectMany(a => numbersB.Where(b => a < b).Select(b => new { A = a, B = b }));
        // foreach (var pair in pairs)
        // {
        //     Console.WriteLine($"{pair.A} is less than {pair.B}");
        // }

        // var lowTotalOrders = CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500);
        // Console.WriteLine("\nOrders with total < 500:");
        // foreach (var order in lowTotalOrders)
        // {
        //     Console.WriteLine(order);
        // }

        // var Result = CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
        // foreach (var order in Result)
        // {
        //     Console.WriteLine(order);
        // }


        // var uniqueCategories = ProductList.Select(p => p.Category).Distinct();
        // foreach (var c in uniqueCategories)
        //     Console.WriteLine(c);

        // var productLetters = ProductList.Select(p => p.ProductName[0]);
        // var customerLetters = CustomerList.Select(c => c.CompanyName[0]);

        // var unionLetters = productLetters.Union(customerLetters);
        // foreach (var l in unionLetters)
        //     Console.WriteLine(l);

        // var commonLetters = productLetters.Intersect(customerLetters);
        // foreach (var l in commonLetters)
        //     Console.WriteLine(l);

        // var onlyProductLetters = productLetters.Except(customerLetters);
        // foreach (var l in onlyProductLetters)
        //     Console.WriteLine(l);

        // var lastThree = ProductList.Select(p => p.ProductName[^3..])
        //                 .Concat(CustomerList.Select(c => c.CompanyName[^3..]));
        // foreach (var s in lastThree)
        //     Console.WriteLine(s);


        // int[] numbers = {5,4,1,3,9,8,6,7,2,0};

        // int oddCount = numbers.Count(n => n % 2 == 1);
        // Console.WriteLine($"Odd count: {oddCount}");

        // var customerOrders = CustomerList.Select(c => new
        // {
        //     c.CompanyName,
        //     OrderCount = c.Orders.Length
        // });

        // foreach (var c in customerOrders)
        //     Console.WriteLine($"{c.CompanyName} : {c.OrderCount}");

        // var categoryCounts = ProductList.GroupBy(p => p.Category)
        //     .Select(g => new { Category = g.Key, Count = g.Count() });

        // foreach (var c in categoryCounts)
        //     Console.WriteLine($"{c.Category} : {c.Count}");

        // Console.WriteLine($"Sum = {numbers.Sum()}");

        // var totalUnits = ProductList.GroupBy(p => p.Category)
        //     .Select(g => new { Category = g.Key, Units = g.Sum(p => p.UnitsInStock) });

        // foreach (var g in totalUnits)
        //     Console.WriteLine($"{g.Category} : {g.Units}");

        // var cheapestPerCategory = ProductList.GroupBy(p => p.Category)
        //     .Select(g => new { Category = g.Key, Cheapest = g.Min(p => p.UnitPrice) });

        // foreach (var c in cheapestPerCategory)
        //     Console.WriteLine($"{c.Category} : {c.Cheapest}");

        // var mostExpensive = ProductList.GroupBy(p => p.Category)
        //     .Select(g => new { Category = g.Key, Max = g.Max(p => p.UnitPrice) });

        // foreach (var c in mostExpensive)
        //     Console.WriteLine($"{c.Category} : {c.Max}");

        // var avgPrice = ProductList.GroupBy(p => p.Category)
        //     .Select(g => new { Category = g.Key, Avg = g.Average(p => p.UnitPrice) });

        // foreach (var c in avgPrice)
        //     Console.WriteLine($"{c.Category} : {c.Avg}");

        // var washingtonOrders = CustomerList
        //     .Where(c => c.Region == "WA")
        //     .SelectMany(c => c.Orders)
        //     .Take(3);

        // foreach (var o in washingtonOrders)
        //     Console.WriteLine(o);

        // var skip2 = CustomerList
        //     .Where(c => c.Region == "WA")
        //     .SelectMany(c => c.Orders)
        //     .Skip(2);

        // foreach (var o in skip2)
        //     Console.WriteLine(o);

        // int[] nums = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        // var untilLess = nums.TakeWhile((n, i) => n >= i);
        // foreach (var n in untilLess)
        //     Console.WriteLine(n);

        // var divisible3 = nums.SkipWhile(n => n % 3 != 0);
        // foreach (var n in divisible3)
        //     Console.WriteLine(n);

        // var lessThanPos = nums.SkipWhile((n, i) => n >= i);
        // foreach (var n in lessThanPos)
        //     Console.WriteLine(n);


        // bool anyOut = ProductList.Any(p => p.UnitsInStock == 0);
        // Console.WriteLine($"Any out of stock: {anyOut}");

        // var categoriesWithOutStock = ProductList
        //     .GroupBy(p => p.Category)
        //     .Where(g => g.Any(p => p.UnitsInStock == 0));

        // foreach (var g in categoriesWithOutStock)
        //     Console.WriteLine(g.Key);

        // var categoriesAllStock = ProductList
        //     .GroupBy(p => p.Category)
        //     .Where(g => g.All(p => p.UnitsInStock > 0));

        // foreach (var g in categoriesAllStock)
        //     Console.WriteLine(g.Key);


        // int[] nums2 = Enumerable.Range(0, 15).ToArray();

        // var remainderGroups = nums2.GroupBy(n => n % 5);

        // foreach (var g in remainderGroups)
        // {
        //     Console.WriteLine($"Remainder {g.Key}");
        //     foreach (var n in g)
        //         Console.WriteLine(n);
        // }

    }
}

public class CaseInsensitiveComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
    }
}
