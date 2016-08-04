using System;
using NUnit.Framework;
using FTP.BusinessObject;
using FTP.Steps;
using TAFCORE.Utility.Logger;
using System.IO;
namespace Tests2
{
    [TestFixture]
    public class GmailTests
    {
        private User user1 = new User("maryia.neiman@gmail.com", "14121995Mm");
        private User user3 = new User("asham1412987@gmail.com", " 14121995Mm");
        private User user2 = new User("oab27041964@gmail.com", "27041964OAB");



        

        [TearDown]
        public void TestCleanup()
        {
            LoggerHandler.WriteToLog("Start TestCleanup");
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user1.Email, user1.Password);
            InBoxPageStep.GoToSpam();
            InBoxPageStep.MoveMailFromSpam(user1.Email);
            InBoxPageStep.DeleteAllMail();
            InBoxPageStep.SignOutAccount();
            /*LoginPageStep.SignIn(user2.Email, user2.Password);
            InBoxPageStep.DeleteAllMail();
            LoginPageStep.SignIn(user3.Email, user3.Password);
            InBoxPageStep.DeleteAllMail();
            InBoxPageStep.SignOutAccount();*/

            Step.ClosePage();
        }
        [TestFixtureTearDown]
        public static void ClassCleanup()
        {
            Step.ClosePage();
        }

        [SetUp]
        public void TestInitialize()
        {
            Step.OpenPage();
            LoginPageStep.OpenGmail();
        }

      
        [Test]
        public void MyTestMethod1NUnit()
        {
            LoggerHandler.WriteToLog("Start MyTestMethod1NUnit");
            //1

            LoginPageStep.SignIn(user2.Email, user2.Password);
            //2
            InBoxPageStep.SendMassage(user1.Email, "Test", Serves.GetCountry());
            //3
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user1.Email, user1.Password);
            //4
            InBoxPageStep.MoveMailIntoSpam(user2.Email);
            //5
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user2.Email, user2.Password);
            //6
            InBoxPageStep.SendMassage(user1.Email, "Test2", "Hello");
            //7
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user1.Email, user1.Password);
            //8
            InBoxPageStep.GoToSpam();
            //assert
            Assert.IsTrue(InBoxPageStep.CheckLetter(user2.Email, "Test2"));
            //clear
            LoggerHandler.WriteToLog("Finish MyTestMethod1NUnit");


        }
       
        [Test]
        public void TestLogger()
        {
            Step st = new Step();
            st.PrintMessage();

        }
        
        [Test]
        public void MyTestMethod3NUnit()
        {
            //var path = Environment.CurrentDirectory;
            //string path2 = $@"{path}\1.rar";
            LoggerHandler.WriteToLog("Start MyTestMethod3NUnit");
            //1           
            LoginPageStep.SignIn(user1.Email, user1.Password);
            //2,3,4
            InBoxPageStep.SendMassageWithAttach(user2.Email, "Test5", "File", Resource1.PathToBigFile);
            //InBoxPageStep.SendMassageWithAttach(user2.Email, "Test5", "File", path2);
            //allert
            Assert.IsTrue(InBoxPageStep.AlertIsPresent());
            //clear
            InBoxPageStep.CancelAlert();
            LoggerHandler.WriteToLog("Finish MyTestMethod2NUnit");

        }
        
        [Test]
        public void MyTestMethod4NUnit()
        {
            string Path = TestContext.CurrentContext.TestDirectory;
            LoggerHandler.WriteToLog("Start MyTestMethod4NUnit");
            //1           
            LoginPageStep.SignIn(user2.Email, user2.Password);
            InBoxPageStep.ChooseSettings();
            //2
            SettingPageStep.GoToThemes();
            //ThemePageStep.SetTheme(Resource1.Theme);
            ThemePageStep.SetTheme(Path+"\\log.jpg");
            //assert
            Assert.IsTrue(ThemePageStep.CheckMessageIsPresent());
            //clear
            ThemePageStep.CloseWindow();
            LoggerHandler.WriteToLog("Finish MyTestMethod4NUnit");
        }
        [Ignore("")]
        [Test]
        public void MyTestMethod11NUnit()
        {
           
            LoggerHandler.WriteToLog("Start MyTestMethod11NUnit");
            LoginPageStep.SignIn(user2.Email, user2.Password);
            //2
            InBoxPageStep.SendMassage(user1.Email, "Test6", "Hello");
            //3
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user1.Email, user1.Password);
            //4
            InBoxPageStep.MoveMailIntoSpam(user2.Email);
            InBoxPageStep.GoToSpam();
            InBoxPageStep.MoveMailFromSpam(user2.Email);
            InBoxPageStep.GoToInBoxPage();
            Assert.IsTrue(InBoxPageStep.CheckLetter(user2.Email, "Test6"));
            LoggerHandler.WriteToLog("Finish MyTestMethod11NUnit");
        }

    
        [Test]
        public void MyTestMethod12NUnit()
        {
            LoggerHandler.WriteToLog("Start MyTestMethod12NUnit");
            string signature = Resource1.Signature;
            LoginPageStep.SignIn(user2.Email, user2.Password);
            InBoxPageStep.ChooseSettings();
            GeneralPageStep.InputSignature(signature);
            Assert.AreEqual(signature, InBoxPageStep.GetSignature());
            //clear
            InBoxPageStep.CloseFormForMail();
            InBoxPageStep.ChooseSettings();
            GeneralPageStep.DeleteSignature();
            LoggerHandler.WriteToLog("Finish MyTestMethod12NUnit");
        }

        
        [Test]
        public void MyTestMethod5NUnit()
        {
            LoggerHandler.WriteToLog("Start MyTestMethod12NUnit");
            LoginPageStep.SignIn(user3.Email, user3.Password);
            InBoxPageStep.AddEmoticons(user1.Email, "Emoticons");
            Assert.IsTrue(InBoxPageStep.EmoticonsIsPresent());
            InBoxPageStep.ChooseEmotionsIcons(Int32.Parse(Resource1.CountOfEmoticons));
            InBoxPageStep.GoToInBoxPage();
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user1.Email, user1.Password);
            InBoxPageStep.ClickOnLinkInMail(user3.Email);
            Assert.IsTrue(InBoxPageStep.EmoticonsIsPresentInMail());
            LoggerHandler.WriteToLog("Finish MyTestMethod5NUnit");
        }

    }
}
