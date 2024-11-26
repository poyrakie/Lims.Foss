# Lims.Utils

`Lims.Utils` is a modular solution designed to host a collection of utilities and services for managing laboratory information. The goal of the solution is to provide a suite of reusable, lightweight and effective tools for handling lab-related data and workflows, with minimal dependencys.

## `NirResultService`

The `NirResultService` is a specialized service for parsing and processing `.csv` files containing lab result data from FOSS DS3 NIR equipment. Successfully parsed files are moved to a backup storage for archiving. The service is designed to be modular and extensible.

---
## Features

- **Equipment**: FOSS DS3 NIR.
- **CSV Parsing**: Processes `.csv` files containing lab results using the [CsvHelper](https://github.com/poyrakie/Lims.Utils/blob/master/NirResult/Models/Helpers/CsvHelpers.cs) methods.
- **Expected Output**: List of objects with succesfully processed files, unsucessful operators will end up as an object with error value set to true.
- **Error Handling**: Skips ~~and logs~~ errors during parsing to ensure robustness.
- **Backup Storage**: Succesfully processed files are moved to a desginated backup storage location.
- **Extensibility**: The service currently supports all products with the right .csv strukture.

## Installation
Nuget package coming soon

## Usage Example

This is only one quick example on how to test `NirResultService`
More detailed instructions with Nuget package coming soon
```
class Program()
{
    static void Main()
    {
        INirResultService service = new NirResultService();

        var filePath = @"Source directory here";
        var backupPath = @"Backup directory here";
        var myResultList = service.GetResultSummary(filePath, backupPath);

    }
}
```

## Expected .csv Strukture

To inspect closer please visit [Assets folder](https://github.com/poyrakie/Lims.Utils/tree/master/NirResult/Assets)

|Analysis Time      |Product Name|Product Code|Sample Type|Sample Number|Sample Comment|Instrument Name|Instrument Serial Number|Test värde 1|Global H Avfall|Neighbourhood H Avfall|t-statistics Avfall|Test värde 2|Global H Fett|Neighbourhood H Fett|t-statistics Fett|Test värde 3|Global H FFA|Neighbourhood H FFA|t-statistics FFA|Test värde 4|Global H Glukosinolater|Neighbourhood H Glukosinolater|t-statistics Glukosinolater|Test värde 5|Global H Klorofyll|Neighbourhood H Klorofyll|t-statistics Klorofyll|Test värde 6|Global H Protein|Neighbourhood H Protein|t-statistics Protein|Test värde 7|Global H Vatten|Neighbourhood H Vatten|t-statistics Vatten|Test värde 8|Test limit1|Test limit 2|Test limit 3|Cup id|Cup type|
|-------------------|------------|------------|-----------|-------------|--------------|---------------|------------------------|------------|---------------|----------------------|-------------------|------------|-------------|--------------------|-----------------|------------|------------|-------------------|----------------|------------|-----------------------|------------------------------|---------------------------|------------|------------------|-------------------------|----------------------|------------|----------------|-----------------------|--------------------|------------|---------------|----------------------|-------------------|------------|-----------|------------|------------|------|--------|
|2024-11-20 11:53:45|Test        |RF          |Normal     |3516085      |              |NIRS DS3       |91930938                |0,47        |0,49           |0,22                  |-1,19              |46,44       |0,49         |0,22                |0,30             |1,02        |0,67        |0,13               |1,17            |27,41       |0,49                   |0,22                          |0,32                       |7,62        |0,49              |0,22                     |-0,53                 |38,18       |0,67            |0,13                   |1,05                |6,88        |0,67           |0,13                  |0,05               |-1,32       |3          |5.3         |-0.1        |101563|2501    |
