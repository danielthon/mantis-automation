using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Dados.DataObjects
{
    public class Issue : DataObject
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ViewStatus { get; set; }

        public void registrar(CsvReader csv) => csv.Configuration.RegisterClassMap<IssueMap>();
    }

    public sealed class IssueMap : ClassMap<Issue>
    {
        public IssueMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
