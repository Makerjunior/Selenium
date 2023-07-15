# Selenium


Este c�digo representa um conjunto de testes usando Selenium WebDriver para automatizar intera��es em uma p�gina do GitHub. Aqui est� uma vis�o geral das principais funcionalidades:

1. O c�digo usa as bibliotecas Selenium e NUnit para escrever testes automatizados.
2. Ao definir a classe `Tests`, � criada uma inst�ncia do `IWebDriver` (ChromeDriver) para controlar o navegador Chrome.
3. Dentro do m�todo `[SetUp] Setup()`, o driver � inicializado, navegando para a URL especificada (https://github.com/Makerjunior), maximizando a janela do navegador e definindo um tempo de espera impl�cito de 5 segundos.
4. O m�todo `[Test] Test()` cont�m o c�digo para obter informa��es da p�gina do GitHub, como o n�mero de reposit�rios p�blicos, nome de usu�rio, n�mero de estrelas e n�mero de seguidores.
5. Os m�todos privados `GetNumberOfPublicRepositories()`, `GetUsername()`, `GetStarsCount()` e `GetFollowersCount()` localizam os elementos desejados na p�gina usando XPath e retornam as informa��es relevantes.
6. O m�todo `PrintIfNotEmpty()` verifica se uma informa��o n�o est� vazia e a imprime no console.
7. O m�todo `ScrollPage()` usa o `IJavaScriptExecutor` para rolar a p�gina para uma posi��o espec�fica (coordenadas X e Y).
8. O m�todo `CaptureScreenshot()` captura uma screenshot da p�gina atual, salva-a como um objeto `Screenshot` e a armazena em uma pasta chamada "Prints", criada no diret�rio atual. A screenshot � salva com um nome �nico baseado na data e hora de captura.
9. O m�todo `[TearDown] TearDown()` � executado ap�s cada teste e decide se deve encerrar o driver do navegador ou n�o, com base na vari�vel `driverQuit`.

Em resumo, este c�digo automatiza a navega��o em uma p�gina do GitHub, obtendo informa��es relevantes e capturando screenshots. Pode ser usado para testar e verificar informa��es espec�ficas em diferentes perfis de usu�rio do GitHub.

