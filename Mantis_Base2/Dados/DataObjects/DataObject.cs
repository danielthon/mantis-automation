using CsvHelper;

namespace Dados.DataObjects
{
    public interface DataObject
    {
        void registrar(CsvReader csv);
    }
}
