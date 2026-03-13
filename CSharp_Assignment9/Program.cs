namespace CSharp_Assignment9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Provided Arrays ---
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            // For the dictionary tasks (replace with File.ReadAllLines if you have the file)
            // string[] dictionaryWords = File.ReadAllLines("dictionary_english.txt");
            string[] dictionaryWords = { "apple", "banana", "car", "elephant", "cat" };


            Console.WriteLine("======================================");
            Console.WriteLine(" 1. LINQ - Restriction Operators");
            Console.WriteLine("======================================");

            // 1. Find all products that are out of stock.
            var outOfStock = ListGenerator.ProductsList.Where(p => p.UnitsInStock == 0);
            Console.WriteLine("\n--- Out of Stock ---");
            foreach (var p in outOfStock) Console.WriteLine(p.ProductName);

            // 2. Find all products that are in stock and cost more than 3.00 per unit.
            var inStockExpensive = ListGenerator.ProductsList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
            Console.WriteLine("\n--- In Stock & > $3.00 ---");
            foreach (var p in inStockExpensive) Console.WriteLine($"{p.ProductName} - ${p.UnitPrice}");

            // 3. Returns digits whose name is shorter than their value.
            var shortDigits = digits.Where((name, index) => name.Length < index);
            Console.WriteLine("\n--- Digits shorter than their value ---");
            foreach (var d in shortDigits) Console.WriteLine(d);


            Console.WriteLine("\n======================================");
            Console.WriteLine(" 2. LINQ - Element Operators");
            Console.WriteLine("======================================");

            // 1. Get first Product out of Stock
            var firstOut = ListGenerator.ProductsList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine($"\nFirst out of stock: {firstOut?.ProductName}");

            // 2. Return the first product whose Price > 1000, or null
            var highPrice = ListGenerator.ProductsList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine($"Price > 1000: {(highPrice == null ? "Null" : highPrice.ProductName)}");

            // 3. Retrieve the second number greater than 5
            var secondGreater5 = numbers.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"Second number > 5: {secondGreater5}");


            Console.WriteLine("\n======================================");
            Console.WriteLine(" 3. LINQ - Aggregate Operators");
            Console.WriteLine("======================================");

            // 1. Uses Count to get the number of odd numbers in the array
            int oddCount = numbers.Count(n => n % 2 != 0);
            Console.WriteLine($"\nOdd numbers count: {oddCount}");

            // 2. Return a list of customers and how many orders each has.
            var custOrderCount = ListGenerator.CustomersList.Select(c => new { c.CustomerName, OrderCount = c.Orders.Length });
            Console.WriteLine("\n--- Customer Order Counts (First 5) ---");
            foreach (var c in custOrderCount.Take(5)) Console.WriteLine($"{c.CustomerName}: {c.OrderCount}");

            // 3. Return a list of categories and how many products each has
            var categoryCounts = ListGenerator.ProductsList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, ProductCount = g.Count() });
            Console.WriteLine("\n--- Category Product Counts ---");
            foreach (var c in categoryCounts) Console.WriteLine($"{c.Category}: {c.ProductCount}");

            // 4. Get the total of the numbers in an array.
            int total = numbers.Sum();
            Console.WriteLine($"\nTotal sum of numbers array: {total}");

            // 5. Get the total number of characters of all words in dictionary_english.txt
            int totalChars = dictionaryWords.Sum(w => w.Length);
            Console.WriteLine($"Total characters in dictionary: {totalChars}");

            // 6. Get the length of the shortest word in dictionary_english.txt
            int shortestWordLen = dictionaryWords.Min(w => w.Length);
            Console.WriteLine($"Shortest word length: {shortestWordLen}");

            // 7. Get the length of the longest word in dictionary_english.txt
            int longestWordLen = dictionaryWords.Max(w => w.Length);
            Console.WriteLine($"Longest word length: {longestWordLen}");

            // 8. Get the average length of the words in dictionary_english.txt
            double avgWordLen = dictionaryWords.Average(w => w.Length);
            Console.WriteLine($"Average word length: {avgWordLen:F2}");


            Console.WriteLine("\n======================================");
            Console.WriteLine(" 4. LINQ - Ordering Operators");
            Console.WriteLine("======================================");

            // 1. Sort a list of products by name
            var sortedNames = ListGenerator.ProductsList.OrderBy(p => p.ProductName);
            Console.WriteLine("\n--- Sorted by Name (First 3) ---");
            foreach (var p in sortedNames.Take(3)) Console.WriteLine(p.ProductName);

            // 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
            var caseInsensitiveSort = words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\n--- Case-Insensitive Sort ---");
            foreach (var w in caseInsensitiveSort) Console.WriteLine(w);

            // 3. Sort a list of products by units in stock from highest to lowest.
            var sortedStock = ListGenerator.ProductsList.OrderByDescending(p => p.UnitsInStock);
            Console.WriteLine("\n--- Sorted by Stock Descending (First 3) ---");
            foreach (var p in sortedStock.Take(3)) Console.WriteLine($"{p.ProductName} ({p.UnitsInStock})");

            // 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            var sortedDigits = digits.OrderBy(d => d.Length).ThenBy(d => d);
            Console.WriteLine("\n--- Sorted Digits ---");
            foreach (var d in sortedDigits) Console.WriteLine(d);

            // 5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            var lengthThenCaseInsensitive = words.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\n--- Sort by length then case-insensitive ---");
            foreach (var w in lengthThenCaseInsensitive) Console.WriteLine(w);

            // 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            var categoryThenPrice = ListGenerator.ProductsList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            Console.WriteLine("\n--- Sort by Category then Price Descending (First 5) ---");
            foreach (var p in categoryThenPrice.Take(5)) Console.WriteLine($"{p.Category}: {p.ProductName} - ${p.UnitPrice}");

            // 7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            var lengthThenCaseInsDesc = words.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\n--- Sort by length then case-insensitive Descending ---");
            foreach (var w in lengthThenCaseInsDesc) Console.WriteLine(w);

            // 8. Create a list of all digits in the array whose second letter is 'i' that is reversed
            var reversedIDigits = digits.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
            Console.WriteLine("\n--- Reversed Digits with 'i' as 2nd letter ---");
            foreach (var d in reversedIDigits) Console.WriteLine(d);


            Console.WriteLine("\n======================================");
            Console.WriteLine(" 5. LINQ - Transformation Operators");
            Console.WriteLine("======================================");

            // 1. Return a sequence of just the names of a list of products.
            var justNames = ListGenerator.ProductsList.Select(p => p.ProductName);
            Console.WriteLine("\n--- Just Product Names (First 3) ---");
            foreach (var n in justNames.Take(3)) Console.WriteLine(n);

            // 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array
            var upperLower = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            Console.WriteLine("\n--- Uppercase and Lowercase ---");
            foreach (var w in upperLower) Console.WriteLine($"Upper: {w.Upper}, Lower: {w.Lower}");

            // 3. Produce a sequence containing some properties of Products, including UnitPrice renamed to Price
            var renamedProps = ListGenerator.ProductsList.Select(p => new { p.ProductName, Price = p.UnitPrice });
            Console.WriteLine("\n--- Properties with Renamed Price (First 3) ---");
            foreach (var p in renamedProps.Take(3)) Console.WriteLine($"{p.ProductName} costs {p.Price}");

            // 4. Determine if the value of int in an array match their position in the array.
            var inPlace = numbers.Select((v, i) => new { Number = v, InPlace = (v == i) });
            Console.WriteLine("\n--- Number: In-place? ---");
            foreach (var item in inPlace) Console.WriteLine($"{item.Number}: {item.InPlace}");

            // 5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var pairs = numbersA.SelectMany(a => numbersB.Where(b => a < b), (a, b) => $"{a} is less than {b}");
            Console.WriteLine("\n--- Pairs where a < b ---");
            foreach (var p in pairs) Console.WriteLine(p);

            // 6. Select all orders where the order total is less than 500.00.
            var smallOrders = ListGenerator.CustomersList.SelectMany(c => c.Orders).Where(o => o.Total < 500.00M);
            Console.WriteLine("\n--- Orders < 500.00 (First 3) ---");
            foreach (var o in smallOrders.Take(3)) Console.WriteLine($"Order {o.OrderID}: ${o.Total}");

            // 7. Select all orders where the order was made in 1998 or later.
            var recentOrders = ListGenerator.CustomersList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
            Console.WriteLine("\n--- Orders 1998 or later (First 3) ---");
            foreach (var o in recentOrders.Take(3)) Console.WriteLine($"Order {o.OrderID}: {o.OrderDate.ToShortDateString()}");

            // Prevent console from closing immediately
            Console.ReadLine();
        }
    }
}
