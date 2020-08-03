using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.IO;
using System.Globalization;
using Dados.DataObjects;

namespace Dados
{
    public class Conexao
    {
        public static List<T> getDadosCsv<T>() where T : new()
        {
            string endereco = AppContext.BaseDirectory + $@"\Entradas\ArquivosCsv\{typeof(T).Name}.csv";

            using (var reader = new StreamReader(endereco))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                ((DataObject)(new T())).registrar(csv);
                csv.Configuration.Delimiter = ";";
                var registros = csv.GetRecords<T>();
                return registros.ToList();
            }
        }
    }
}
