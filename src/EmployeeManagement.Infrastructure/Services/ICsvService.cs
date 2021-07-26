using System.Collections.Generic;
using System.Threading.Tasks;
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
        /// Gets all records.
        /// </summary>
        /// <param name="csvFilePath">Path to csv file</param>
        /// <param name="classMap">Specify custom csv model mapper</param>
        /// <returns>List of mapped records</returns>
        IEnumerable<TModel> GetRecords(string csvFilePath, ClassMap<TModel> classMap = null);
    }
}