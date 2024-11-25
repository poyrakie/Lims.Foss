# Lims.Utils

`Lims.Utils` is a modular solution designed to host a collection of utilities and services for managing laboratory information. The goal of the solution is to provide a suite of reusable, lightweight and effective tools for handling lab-related data and workflows, with minimal dependencys.

## Current Projekt: `NirResultService`

The `NirResultService` is a specialized service for parsing and processing `.csv` files containing lab result data. Successfully parsed files are moved to a backup storage for archiving. The service is designed to be somewhat modular and extensible, allowing it to integrate with future projects within the `Lims.Utils` solution.

---
## Features

- **CSV Parsing**: Processes `.csv` files containing lab results using the [CsvHelper](https://github.com/poyrakie/Lims.Utils/blob/master/NirResult/Models/Helpers/CsvHelpers.cs) methods.
- **Error Handling**: Skips ~~and logs~~ errors during parsing to ensure robustness.
- **Backup Storage**: Succesfully processed files are moved to a desginated backup storage location.
- **Extensibility**: The Service is designed to support additional result types in the future with some modification to the code.

## Installation
Coming soon
