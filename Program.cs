using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using System.Xml.Linq;
namespace assignment1
{
    public class Program
    {

        static IWebDriver driver = new ChromeDriver();
        static IWebElement radioButton;
        private static IWebElement element;
        private static IWebElement element1;
        private static readonly string option3;

        static void Main(string[] args)
        {
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");

            excercise();
            exercice2();
            exercice3();
            switchTab();
            switchwindow();
            exercice4();
            exercice8();
            exercice9();


            //Console.WriteLine("Hello World!");
        }
        public static void excercise()
        {
            string[] option = { "1", "2", "3" };
            int i = 0;


            //while(i<3)
            do

            {
                radioButton = driver.FindElement(By.XPath("//input[@value='radio" + option[i] + "']"));
                radioButton.Click();

                if (radioButton.GetAttribute("checked") == "true")
                {
                    Console.WriteLine("The  radio button" + (i + 1) + " is checked!");
                }
                else
                {
                    Console.WriteLine("This is one of the unchecked radio buttons!");
                }
                i++;
                Thread.Sleep(3000);
            } while (i < 3);

        }



        public static void exercice2()
        {
            IWebElement selection = driver.FindElement(By.Id("autocomplete"));
            selection.SendKeys("united");
            IList<IWebElement> sbox = (IList<IWebElement>)driver.FindElement(By.XPath("//input[@id='autocomplete']"));

            foreach (var uelement in sbox)
            {
                if (uelement.Text.Contains("united states (USA)"))
                {
                    uelement.Click();
                }
            }
        }

        public static string GetOption3()
        {
            return option3;
        }

        public static void exercice3()
        {
            string option = "1";

            IWebElement Checkbox1 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + option + "\"]"));
            Checkbox1.Click();
            Thread.Sleep(2000);
            Checkbox1.Click();

            Thread.Sleep(2000);

            Console.WriteLine(Checkbox1.GetAttribute("value"));
            string option2 = "2";

            IWebElement Checkbox2 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + option2 + "\"]"));
            Checkbox2.Click();
            Thread.Sleep(2000);
            Checkbox2.Click();

            string option3 = "3";
            IWebElement Checkbox3 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + option3 + "\"]"));
            Checkbox3.Click();
            Thread.Sleep(2000);
            Checkbox3.Click();
            Thread.Sleep(2000);

            for(int i = 1; i <= 3; i++)
            {
                IWebElement Checkall = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + i + "\"]"));
                Checkall.Click();
                Thread.Sleep(2000);
            }

             driver.Quit();
        }

        public static void switchTab()
        {
            IWebElement switchtab = driver.FindElement(By.Id("opentab"));
            switchtab.Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            
        }

        public static void switchwindow()
        {
            IWebElement switchwind = driver.FindElement(By.Id("openwindow"));
            switchwind.Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        public static void exercice4()
        {
            IWebElement down = driver.FindElement(By.Id("dropdown-class-example"));
            for(int i=2; i<5; i++)
            {
                IWebElement down1 = driver.FindElement(By.CssSelector("#dropdown-class-example"));
                down1.Click();
                Thread.Sleep(2000);
                down1.Click();
                Thread.Sleep(2000);
            }
        }

        public static void exercice8()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(System.String.Format("window.scrollTo({0}, {1})", 500, 648));
            Thread.Sleep(2000);
        }

        public static void exercice9()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)(driver);
            js.ExecuteScript(System.String.Format("window.scrollTo({0}, {1})", 400, 1000));
            Thread.Sleep(2000);
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Actions action = new Actions(driver);
            element = driver.FindElement(By.XPath("//*[@id=\"mousehover\"]"));
            element1 = driver.FindElement(By.XPath("/html/body/div[4]/div/fieldset/div/div/a[1]"));
            action.MoveToElement(element).Perform();
            action.MoveToElement(element1).Perform();
            element1.Click();

        }






    }


}

