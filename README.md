# PhpSales
This project is a simple PHP example that calculates sales taxes for shopping carts.
It contains basic entity classes for items and a cart, along with services for parsing
input lines, calculating taxes and formatting the output.

## Requirements

* PHP 8.4 or later
* No additional libraries are required

## Install

Clone this repository and ensure PHP is available in your environment.
There are no extra composer packages to install.

## Run the example

For ease of use i have included a dockerfile that will run the example for you.
Execute the following command from the project root:

```bash
docker compose -f docker-compose.yml up -d
```

And you will be able to access the example at `http://localhost:8080`.

Or if you prefer using PHP directly on your machine
ensure you have PHP installed and run the following command:

```bash
php public/index.php
```

The script will parse the built‑in arrays in `public/index.php` and print the
calculated totals and taxes.

## Example Input
In the `public/index.php` file, you will find the following example input:

```php
    $inputs=[
        1=>[
            '2 book at 12.49',
            '1 music CD at 14.99',
            '1 chocolate bar at 0.85'
        ],
        2=>[
            '1 imported box of chocolates at 10.00',
            '1 imported bottle of perfume at 47.50'
        ],
        3=>[
            '1 imported bottle of perfume at 27.99',
            '1 bottle of perfume at 18.99',
            '1 packet of headache pills at 9.75',
            '3 box of imported chocolates at 11.25'
        ],
        4=>[
            '2 bottle of perfume imported at 27.99',
            '1 bottle of imported perfume at 18.99',
            '4 packet of imported headache pills at 9.75',
            '3 box of chocolates at 11.25'
        ]
    ];
```

## C# implementation

The repository also contains an early C# version located in the `csharp` folder.
You can build it with the following command:

```bash
dotnet build
```

Run the console project with:

```bash
dotnet run
```

The PHP version remains available for reference.
