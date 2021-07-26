using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using EmployeeManagement.Infrastructure.Maps;

namespace EmployeeManagement.Infrastructure.Services
{
    public class CsvService<TModel> : ICsvService<TModel> where TModel: class
    {
        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">Throws if csv file path is null.</exception>
        /// <exception cref="InvalidOperationException">Throws if Could not find file <paramref name="csvFilePath"/></exception>
        public IEnumerable<TModel> GetRecords(string csvFilePath, ClassMap<TModel> classMap = null)
        {
            if (string.IsNullOrWhiteSpace(csvFilePath))
                throw new ArgumentNullException(csvFilePath);

            if (File.Exists(csvFilePath))
                throw new InvalidOperationException($"Could not find file {csvFilePath}");

            using var reader = new StreamReader(csvFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            
            if (classMap != null)
                csv.Context.RegisterClassMap<EmployeeMap>();

            var records = csv.GetRecords<TModel>();
            return records;
        }
    }
}