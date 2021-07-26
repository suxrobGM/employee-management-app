using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// CRUD model for operations in grid
    /// </summary>
    /// <typeparam name="T">Datatype of the model</typeparam>
    public class CrudModel<T> where T : class
    {
        public string Action { get; set; }

        public string Table { get; set; }

        public string KeyColumn { get; set; }

        public object Key { get; set; }

        public T Value { get; set; }

        public IList<T> Added { get; set; }

        public IList<T> Changed { get; set; }

        public IList<T> Deleted { get; set; }

        public IDictionary<string, object> Params { get; set; }
    }
}