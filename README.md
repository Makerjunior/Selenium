# Selenium


Este código representa um conjunto de testes usando Selenium WebDriver para automatizar interações em uma página do GitHub. Aqui está uma visão geral das principais funcionalidades:

1. O código usa as bibliotecas Selenium e NUnit para escrever testes automatizados.
2. Ao definir a classe `Tests`, é criada uma instância do `IWebDriver` (ChromeDriver) para controlar o navegador Chrome.
3. Dentro do método `[SetUp] Setup()`, o driver é inicializado, navegando para a URL especificada (https://github.com/Makerjunior), maximizando a janela do navegador e definindo um tempo de espera implícito de 5 segundos.
4. O método `[Test] Test()` contém o código para obter informações da página do GitHub, como o número de repositórios públicos, nome de usuário, número de estrelas e número de seguidores.
5. Os métodos privados `GetNumberOfPublicRepositories()`, `GetUsername()`, `GetStarsCount()` e `GetFollowersCount()` localizam os elementos desejados na página usando XPath e retornam as informações relevantes.
6. O método `PrintIfNotEmpty()` verifica se uma informação não está vazia e a imprime no console.
7. O método `ScrollPage()` usa o `IJavaScriptExecutor` para rolar a página para uma posição específica (coordenadas X e Y).
8. O método `CaptureScreenshot()` captura uma screenshot da página atual, salva-a como um objeto `Screenshot` e a armazena em uma pasta chamada "Prints", criada no diretório atual. A screenshot é salva com um nome único baseado na data e hora de captura.
9. O método `[TearDown] TearDown()` é executado após cada teste e decide se deve encerrar o driver do navegador ou não, com base na variável `driverQuit`.

Em resumo, este código automatiza a navegação em uma página do GitHub, obtendo informações relevantes e capturando screenshots. Pode ser usado para testar e verificar informações específicas em diferentes perfis de usuário do GitHub.

