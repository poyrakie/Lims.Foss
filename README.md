# Lims.Utils

`Lims.Utils` is a modular solution designed to host a collection of utilities and services for managing laboratory information. The goal of the solution is to provide a suite of reusable, lightweight and effective tools for handling lab-related data and workflows, with minimal dependencys.

## `NirResultService`

The `NirResultService` is a specialized service for parsing and processing `.csv` files containing lab result data from FOSS DS3 NIR equipment. Successfully parsed files are moved to a backup storage for archiving. The service is designed to be somewhat modular and extensible.

---
## Features

- **Equipment**: FOSS DS3 NIR.
- **CSV Parsing**: Processes `.csv` files containing lab results using the [CsvHelper](https://github.com/poyrakie/Lims.Utils/blob/master/NirResult/Models/Helpers/CsvHelpers.cs) methods.
- **Expected Output**: List of objects with succesfully processed files, unsucessful operators will end up as an object with error value set to true.
- **Error Handling**: Skips ~~and logs~~ errors during parsing to ensure robustness.
- **Backup Storage**: Succesfully processed files are moved to a desginated backup storage location.
- **Extensibility**: The service currently supports rapsfrö, rapsmjöl and rapspresskaka. It is prepared to support more products with some minor additions to the code.

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
<div hidden>
```
@startuml
title NirResultService
start
:User enters source and backup directory;
:List is made of all files in source directory;
repeat :List of files;
:Parse .csv file to object;
if(Parse was successfull) then (Yes)
:Add object to list;
:Move .csv file to backup directory;
else (No)
:Add empty object with filename and Error: true to list;
endif
repeat while (More files) is (Yes) not (No)
:Returns list with created objects;
stop
@enduml
```
</div>  
