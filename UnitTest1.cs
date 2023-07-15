// Importando as bibliotecas necessárias
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.IO;

namespace Selenium
{
    public class Tests
    {
        public IWebDriver driver;
        public bool driverQuit = true;

        // Método de configuração para executar antes de cada teste
        [SetUp]
        public void Setup()
        {
            // Inicializa o driver do Chrome
            driver = new ChromeDriver();

            // Navega para o URL especificado
            driver.Navigate().GoToUrl("https://github.com/Makerjunior");

            // Maximiza a janela do navegador
            driver.Manage().Window.Maximize();

            // Define um tempo de espera implícito de 5 segundos
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Define driverQuit como falso, indicando que o driver não deve ser encerrado após cada teste
            driverQuit = false;
        }

        // Método de teste
        [Test]
        public void Test()
        {
            // Localiza e obtém informações da página do GitHub

            // Obtém o número de repositórios públicos
            var numR = GetNumberOfPublicRepositories();

            // Obtém o nome de usuário
            var userName = GetUsername();

            // Obtém o número de estrelas
            var magStars = GetStarsCount();

            // Obtém o número de seguidores
            var msgFollowers = GetFollowersCount();

            // Imprime as informações obtidas se os elementos existirem e não estiverem vazios
            PrintIfNotEmpty(userName);
            PrintIfNotEmpty(magStars);
            PrintIfNotEmpty(msgFollowers);
            PrintIfNotEmpty(numR);

            // Role a página para uma posição específica
            ScrollPage(0, 720);

            // Capture uma screenshot da página
            CaptureScreenshot();

            // Indica que o teste passou com sucesso
            Assert.Pass();
        }

        // Método para obter o número de repositórios públicos
        private string GetNumberOfPublicRepositories()
        {
            var labelRes = "/html/body/div[1]/div[4]/main/div[1]/div/div/div[2]/div/nav/a[2]/span";
            var resultado = driver.FindElement(By.XPath(labelRes));
            return "Numero de repositorios publicos: " + resultado.Text;
        }

        // Método para obter o nome de usuário
        private string GetUsername()
        {
            var usernameXp = "/html/body/div[1]/div[4]/main/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/h1/span[1]";
            var user = driver.FindElement(By.XPath(usernameXp));
            return "Usuario: " + user.Text;
        }

        // Método para obter o número de estrelas
        private string GetStarsCount()
        {
            var stars = "/html/body/div[1]/div[4]/main/div[1]/div/div/div[2]/div/nav/a[5]/span";
            var starsNum = driver.FindElement(By.XPath(stars));
            return "Estrelas: " + starsNum.Text;
        }

        // Método para obter o número de seguidores
        private string GetFollowersCount()
        {
            var followersXp = "/html/body/div[1]/div[4]/main/div[2]/div/div[1]/div/div[2]/div[3]/div[2]/div[2]/div/a[1]/span";
            var followersNum = driver.FindElement(By.XPath(followersXp));
            return "Followers: " + followersNum.Text;
        }

        // Método para imprimir uma informação se ela não estiver vazia
        private void PrintIfNotEmpty(string info)
        {
            if (!string.IsNullOrWhiteSpace(info))
            {
                Console.WriteLine(info);
            }
        }

        // Método para rolar a página para uma posição específica
        private void ScrollPage(int scrollX, int scrollY)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollTo({scrollX}, {scrollY});");
        }

        // Método para capturar uma screenshot da página atual
        private void CaptureScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string dateTimeFormat = "yyyyMMdd_HHmmss";
            string fileName = "screenshot_" + DateTime.Now.ToString(dateTimeFormat) + ".png";
            string currentDirectory = Environment.CurrentDirectory;
            string folderPath = Path.Combine(currentDirectory, "Prints");


            // Cria a pasta "Prints" se ela não existir
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Combina o caminho da pasta com o nome do arquivo
            string path = Path.Combine(folderPath, fileName);

            // Salva a screenshot no diretório especificado
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }

        // Método de limpeza para executar após cada teste
        [TearDown]
        public void TearDown()
        {
            // Verifica se o driver deve ser encerrado
            if (driverQuit)
            {
               
                driver.Dispose();
            }
            driver.Quit();
        }
    }

}

