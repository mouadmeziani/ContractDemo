# ContractDemo

A C# console application that flattens overlapping contract periods based on priority.

## What It Does

Takes contracts with date ranges, prices, and priorities, then splits overlapping periods so that each time segment is covered by exactly one contract. Higher priority contracts cut through lower priority ones.

**Input:**
```
Start;Ende;Preis;Priorität
01.01.2020;01.03.2020;20,4;1
01.02.2020;31.12.2020;18;2
```

**Output:** Non-overlapping date ranges where contract #1 takes precedence in February-March, then contract #2 continues alone.

## Core Algorithm

The `DateRange.CutAll()` method handles the interval arithmetic:
- Detects overlaps between date ranges
- Splits ranges into non-overlapping segments
- Preserves the original contract's price and priority for each segment

Time complexity: O(n+m) where n is the number of contracts and m is the resulting segments.

## Tech Stack

- C# / .NET
- Autofac (dependency injection)
- xUnit (testing)

## Usage

```bash
dotnet run <path-to-csv-file>
```

Input CSV format: `Start;Ende;Preis;Priorität`
