using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Dados.DataObjects
{
    public class Login : DataObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProjetoId { get; set; }

        public void registrar(CsvReader csv) => csv.Configuration.RegisterClassMap<LoginMap>();
    }

    public sealed class LoginMap : ClassMap<Login>
    {
        public LoginMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
