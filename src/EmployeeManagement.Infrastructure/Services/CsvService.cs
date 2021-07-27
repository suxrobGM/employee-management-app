using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using EmployeeManagement.Infrastructure.Maps;

namespace EmployeeManagement.Infrastructure.Services
{
    public class CsvService<TModel> : ICsvService<TModel> where TModel: class
    {
        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">Throws if csv file path is null.</exception>
        /// <exception cref="InvalidOperationException">Throws if could not find file <paramref name="csvFilePath"/>.</exception>
        public IEnumerable<TModel> GetRecords(Stream csvFileStream, ClassMap<TModel> classMap = null)
        {
            if (csvFileStream is null)
                throw new ArgumentNullException(nameof(csvFileStream));

            using var reader = new StreamReader(csvFileStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            if (classMap != null)
                csv.Context.RegisterClassMap<EmployeeMap>();

            var records = csv.GetRecords<TModel>().ToList();
            return records;
        }
    }
}