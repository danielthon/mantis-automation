# mantis-automation

Projeto de amostra em **C#** de teste automatizado para aplicação **MantisBT** 🦗


## Pacotes & Recursos

- **NUnit** para execução e parametrização dos testes;
- **Selenium.WebDriver** para comunicação com a aplicação em teste;
- **CsvHelper** para entrada de dados via arquivos CSV;
- **ExtentReports** para melhor visualização em HTML dos resultados dos testes.

> Foram encontradas versões de todas essas extensões com suporte ao **.NET Standard**, sendo assim utilizado.

## Casos de teste

Apenas 2 casos de teste foram implementados. São independentes, podendo ser executados simultaneamente.

- **Issue.T001** – "Report new issue and verify"
- **Issue.T002** – "Add, edit and delete note from issue"


> Para executar em diferentes *browsers* via linha de comando do NUnit, utilize os parâmetros
>
>> `--tp:browser=chrome` para utilizar o Chrome ou
>>
>> `--tp:browser=firefox` para utilizar o Mozila Firefox
