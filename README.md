# mantis-automation

Projeto de amostra em **C#** de teste automatizado para aplicação **MantisBT**.


## Pacotes & Recursos

- **NUnit** para execução e parametrização dos testes;
- **Selenium.WebDriver** para comunicação com a aplicação em teste;
- **CsvHelper** para entrada de dados via arquivos CSV;
- **ExtentReports** para melhor visualização em HTML dos resultados dos testes.

> Foram encontradas versões de todas essas extensões com suporte ao **.NET Standard**, sendo assim utilizado.

## Casos de teste

Apenas 1 caso de teste foi implementado. São independentes, podendo ser executados simultaneamente.

- **Issue.T001** – "Report new issue and verify"


> Para executar em diferentes *browsers* via linha de comando do NUnit, utilize o parâmetro 
> `--tp:browser=chrome` para utilizar o Chrome ou
> `--tp:browser=firefox` para utilizar o Mozila Firefox
