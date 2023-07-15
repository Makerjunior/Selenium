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


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://github.com/Makerjunior");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driverQuit = false;
        }

        [Test]
        public void Test()
        {

            var labelRes = "/html/body/div[1]/div[4]/main/div[1]/div/div/div[2]/div/nav/a[2]/span";
            var resultado = driver.FindElement(By.XPath(labelRes));
            var numR = "Numero de repositorios publicos :" + resultado.Text;

            var usernameXp = "/html/body/div[1]/div[4]/main/div[2]/div/div[1]/div/div[2]/div[1]/div[2]/h1/span[1]";
            var user = driver.FindElement(By.XPath(usernameXp));
            var userName = "Usuario :" + user.Text;


            var stars = "/html/body/div[1]/div[4]/main/div[1]/div/div/div[2]/div/nav/a[5]/span";
            var starsNum = driver.FindElement(By.XPath(stars));
            var magStars = "Estrelas :" + starsNum.Text;


            var followersXp = "/html/body/div[1]/div[4]/main/div[2]/div/div[1]/div/div[2]/div[3]/div[2]/div[2]/div/a[1]/span";
            var followersNum = driver.FindElement(By.XPath(followersXp));
            var msgFollowers = "Followers :" + followersNum.Text;

            if ((user != null) && (user.Text != " "))
            {
                Console.WriteLine(userName);

            }
            if ((starsNum != null) && (starsNum.Text != " "))
            {
                Console.WriteLine(magStars);

            }
            // 
            if ((followersNum != null) && (followersNum.Text != " "))
            {
                Console.WriteLine(msgFollowers);

            }

            if ((resultado != null) && (resultado.Text != " "))
            {
                Console.WriteLine(numR);

            }

            // Role a p�gina para a posi��o desejada (x, y) usando JavaScript Executor
            int scrollX = 0;
            int scrollY = 720;
            ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollTo({scrollX}, {scrollY});");

            // Capture a screenshot como um objeto do tipo Screenshot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string dateTimeFormat = "yyyyMMdd_HHmmss";
            string fileName = "screenshot_" + DateTime.Now.ToString(dateTimeFormat) + ".png";
            string currentDirectory = Environment.CurrentDirectory;
            string folderPath = Path.Combine(currentDirectory, "Prints");


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string path = Path.Combine(folderPath, fileName);
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            // Os Screenshot s�o salvos na pasta bootselenium\bootselenium\bin\Debug\net5.0\Prints

            Assert.Pass();
        }



        [TearDown]
        public void TearDown()
        {
            driver.Quit();

            if (driverQuit)
            {
                driver.Quit();
            }
        }
    }
}