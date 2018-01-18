using DevExpress.XtraPrinting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F1MOTORS
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DataTable dt = null;
        Thread myThread;
        public Boolean p = false;
        public ChromeDriver driver = null;
        ChromeOptions options = new ChromeOptions();
        StreamWriter sw1 = null;
        public int y = 0;
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;
            driver = new ChromeDriver();
            dt = new DataTable();
            dt.Columns.Add("URL",
            System.Type.GetType("System.String"));
            dt.Columns.Add("Name",
            System.Type.GetType("System.String"));
            gridControl1.DataSource = dt;


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        public void mobileff()
        {


            try
            {
                if (p == false)
                {
                    Console.WriteLine("Opening the page...");

                    string dis = "";
                    string tras = "";



                    try
                    {
                        driver.Navigate().GoToUrl("https://m.facebook.com");
                        Thread.Sleep(100);
                        var email = driver.FindElement(By.Name("email"));
                        var pass = driver.FindElement(By.Name("pass"));
                        var btn = driver.FindElement(By.Name("login"));
                        email.SendKeys(textEdit1.Text);
                        pass.SendKeys(textEdit2.Text);
                        btn.Submit();
                    }
                    catch (Exception eee)
                    {
                        driver.Navigate().GoToUrl("https://m.facebook.com");
                        Thread.Sleep(100);
                        var email = driver.FindElement(By.Name("email"));
                        email.SendKeys(textEdit1.Text);
                        var btbt = driver.FindElement(By.TagName("input"));
                        btbt.Submit();
                        var pass = driver.FindElement(By.Name("pass"));
                        var btn = driver.FindElement(By.Name("login"));

                        pass.SendKeys(textEdit2.Text);
                        btn.Submit();



                    }


                    Thread.Sleep(300);
                    driver.Navigate().GoToUrl("https://mobile.facebook.com");
                    Thread.Sleep(300);
                }
                string key = textEdit3.Text;


                try
                {
                    var checklogin = driver.FindElement(By.Name("email"));
                    MessageBox.Show("check username and password");
                    p = false;
                }
                catch (Exception ee)
                {
                    p = true;


                }
                if (p == true)
                {



                    driver.Navigate().GoToUrl("https://mobile.facebook.com/search/people/?q=" + textEdit3.Text + "&filters_city=%7B%22name%22%3A%22users_location%22%2C%22args%22%3A%22" + textEdit4.Text + "%22%7D");


                    int X = 0;
                    var elemm = driver.FindElement(By.TagName("body"));


                    while (X == 0)
                    {
                        var elem = driver.FindElement(By.Id("page"));
                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                        try
                        {
                            if (elem.FindElement(By.ClassName("_55sr")).Text.Contains("Give Feedback About Search"))
                                X = 1;

                        }
                        catch (Exception er)
                        { }

                    }
                    string tt = "";






                    Stopwatch stopwatch1 = new Stopwatch();
                    stopwatch1.Start();


                    var data = driver.FindElements(By.ClassName("bd"));
                    stopwatch1.Stop();

                    Console.WriteLine("Time elapsed: {0}", stopwatch1.Elapsed);

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    foreach (var link in data)
                    {
                        tt = link.Text;
                        string h = link.GetAttribute("href");
                        this.gridControl1.BeginInvoke(new MethodInvoker(delegate
                        {
                            DataRow row = dt.NewRow();
                            row[0] = h;
                            row[1] = tt;
                            dt.Rows.Add(row);
                            gridControl1.DataSource = null;
                            gridControl1.DataSource = dt;

                        }));


                    }
                    stopwatch.Stop();


                    Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

                    MessageBox.Show("end scrap");


                }
            }
            catch (Exception cc)
            { }



        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (textEdit1.Text == "")
            {
                MessageBox.Show("Please check your emaill");
                return;
            }
            if (textEdit2.Text == "")
            {
                MessageBox.Show("Please check your password");
                return;
            }

            if (textEdit3.Text == "")
            {
                MessageBox.Show("Please check keyword");
                return;
            }
            if (textEdit4.Text == "")
            {
                MessageBox.Show("Please check city");
                return;
            }

            gridControl1.DataSource = null;
            dt.Clear();
            if (myThread != null)
            {
                myThread.Abort();
                myThread = new Thread(new ThreadStart(mobileff));
                myThread.Start();

            }
            else
            {
                myThread = new Thread(new ThreadStart(mobileff));
                myThread.Start();
            }


        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (textEdit5.Text == "")
            {
                MessageBox.Show("Please entry file name");
                return;
            }
            FolderBrowserDialog browser = new FolderBrowserDialog();
            string tempPath = "";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                tempPath = browser.SelectedPath; // prints path

                gridControl1.ExportToCsv(tempPath + "\\" + textEdit5.Text + ".csv");
            }

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            myThread.Abort();
            Thread th = new Thread(mobf);

            th.Start();


        }


        public void mobf()
        {

            try
            {
                string tt = "";
                Stopwatch stopwatch1 = new Stopwatch();
                stopwatch1.Start();
                var data = driver.FindElements(By.ClassName("bd"));

                stopwatch1.Stop();

                Console.WriteLine("Time elapsed: {0}", stopwatch1.Elapsed);

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                foreach (var link in data)
                {


                    tt = link.Text;
                    string h = link.GetAttribute("href");

                    this.gridControl1.BeginInvoke(new MethodInvoker(delegate
                    {
                        DataRow row = dt.NewRow();
                        row[0] = h;
                        row[1] = tt;
                        dt.Rows.Add(row);
                        gridControl1.DataSource = null;
                        gridControl1.DataSource = dt;

                    }));


                }
                stopwatch.Stop();


                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

                MessageBox.Show("end scrap");
            }
            catch (Exception e)
            { }
        }


        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        private void barButtonItem6_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            gridControl1.DataSource = dt;
        }
    }
}
