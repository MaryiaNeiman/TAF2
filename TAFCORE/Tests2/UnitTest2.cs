using System;
using NUnit.Framework;
using FTP.BusinessObject;
using FTP.Steps;
using TAFCORE.Utility.Logger; 
namespace Tests2
{
    [TestFixture]
    class GmailTests2
    {

        private User user1 = new User("maryia.neiman@gmail.com", "14121995Mm");
        private User user2 = new User("asham1412987@gmail.com", "14121995Mm");
        private User user3 = new User("oab27041964@gmail.com", "27041964OAB");

        [TearDown]
        public void TestCleanup()
        {
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user2.Email, user2.Password);
            InBoxPageStep.ChooseSettings();
            SettingPageStep.ForwardMail();
            ForwardPageStep.RemoveForwarding();
            TrashPageStep.DeleteAllMail();
            InBoxPageStep.DeleteAllMail();

            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user3.Email, user3.Password);
            InBoxPageStep.DeleteAllMail();
            ImportantPageStep.DeleteAllMail();
            InBoxPageStep.SignOutAccount();

            Step.ClosePage();

        }

        [SetUp]
        public void TestInitialize()
        {
            Step.OpenPage();
            LoginPageStep.OpenGmail();

        }

       
        [Test]
        public void MyTestMethod2()
        {
            LoggerHandler.WriteToLog("Start MyTestMethod1NUnit");
            //1

            LoginPageStep.SignIn(user2.Email, user2.Password);
            //2
            InBoxPageStep.ChooseSettings();
            //4
            SettingPageStep.ForwardMail();
            //5
            ForwardPageStep.AddForwordingAddress(user3.Email);
            //6
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user3.Email, user3.Password);
            //7
            InBoxPageStep.ClickOnLinkInMail("forwarding-noreply@google.com");
            MessageStep.ConfirmForwarding();
            //8
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user2.Email, user2.Password);
            //9,10
            InBoxPageStep.ChooseSettings();
            SettingPageStep.ForwardMail();
            ForwardPageStep.SaveRBChange();

            //11,12
            ForwardPageStep.SetFilterSettings(user1.Email);
            //13
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user1.Email, user1.Password);
            //15
            InBoxPageStep.SendMassage(user2.Email, "Test3", "Hello");
            //14
            InBoxPageStep.SendMassageWithAttach(user2.Email, "Test4", "File", Resource1.PathToFile);
            //16
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user2.Email, user2.Password);
            //asssert
            Assert.IsTrue(TrashPageStep.CheckLetterInTrash(user1.Email, "Test4"));
            //Assert.IsTrue(ImportantPageStep.CheckLetterInImportant(user1.Email, "Test4", "Test3"));
            Assert.IsTrue(InBoxPageStep.CheckLetter(user1.Email, "Test3"));
            InBoxPageStep.SignOutAccount();
            LoginPageStep.SignIn(user3.Email, user3.Password);
            Assert.IsTrue(InBoxPageStep.CheckLetter(user1.Email, "Test3"));
       
            LoggerHandler.WriteToLog("Finish MyTestMethod1NUnit");
        }
    }
}
