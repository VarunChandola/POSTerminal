# Point of Sales Terminal

This solution includes code and tests for a point-of-sale scanning system library that accepts an arbitrary ordering of
products, similar to what would happen at an actual checkout line, then returns the correct total
price for an entire shopping cart based on per-unit or volume prices as applicable.

The library targets .NET Standard 2.0 and can be used by any implementation targeting .NET Standard 2.0.

## Building

### IDE
Open the solution file POSTerminal.sln in a .NET IDE of your choice and build.

### Command line
Run the following command in the solution folder from the command line,

```c#
dotnet build
```

## Running Tests

Run the following command in the solution folder from the command line,
```c#
dotnet test
```

## Usage

The entry point for the library is the PointOfSalesTerminal class which expects an IProductRepository instance to be passed in during initialization.
This is used by the library to asynchronously get data on products on scan (product code, prices etc.). 

An instance of the included class SimpleProductRepository can be used to create a repository from a list of Products.

The following code snippet can be used as a starting point

```c#
// Create a simple repository from a list of products
var productRepository = new SimpleProductRepository(new List<Product>
{
    new Product(Code: "A", UnitPrice: 1.25, new BulkPricing(3, 3)),
    new Product(Code: "B", UnitPrice: 4.25),
    new Product(Code: "C", UnitPrice: 1, new BulkPricing(6, 5)),
    new Product(Code: "D", UnitPrice: 0.75)
});

var terminal = new PointOfSalesTerminal(productRepository);

foreach (var productCode in new[] {"A", "B", "C", "D"})
{
    await terminal.ScanProductAsync(productCode);
}

var calculatedTotal = terminal.CalculateTotal();
```

