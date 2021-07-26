using System.Collections.Generic;
using System.IO;
using CsvHelper.Configuration;

namespace EmployeeManagement.Infrastructure.Services
{
    /// <summary>
    /// Csv read and write services
    /// </summary>
    /// <typeparam name="TModel">Datatype of the mapping model</typeparam>
    public interface ICsvService<TModel> where TModel: class
    {
        /// <summary>
        /// Gets all records from stream.
        /// </summary>
        /// <param name="csvFileStream">CSV file stream.</param>
        /// <param name="classMap">Specify custom csv model mapper.</param>
        /// <returns>List of mapped records.</returns>
        IEnumerable<TModel> GetRecords(Stream csvFileStream, ClassMap<TModel> classMap = null);
    }
}