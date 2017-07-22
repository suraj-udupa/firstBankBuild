using Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using FirstIslandBankCorporation.Controllers;
using System.Web.Mvc;
using System.Text;
using FirstIslandBankCorporation.Models;
using System.Web;

namespace FirstIslandBankCorporationIntegrationTest
{
    [Binding]
    public class MiniStatementSteps
    {
        public string response = string.Empty;
        public int UserId;
        ActionResult result;
        AccountController controller;
        LoginViewModel loginViewModel;
        public string expected;
        public int AccountId;
        public string AccountName;
        public string AccountNumber;
        

        [When(@"the user goes to the login user screen")]
        public void WhenTheUserGoesToTheRegisterUserScreen()
        {
            controller = new AccountController();
            result = controller.Login("");
        }

        [Then(@"the login user view should be displayed")]
        public void ThenTheRegisterUserViewShouldBeDisplayed()
        {
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual("Log in",
                   controller.ViewData["Title"]);
        }

        [Given(@"The user has entered all the information")]
        public void GivenTheUserHasEnteredAllTheInformation()
        {
            loginViewModel = new LoginViewModel
            {
                Email = "ram@gmail.com",
                Password = "Password@123"
            };
            controller = new AccountController();
        }

        [When(@"He clicks on login button")]
        public void WhenHeClicksOnLoginButton()
        {
            result = controller.Login(loginViewModel,"");
        }

        [Then(@"He should be redirected to the home page")]
        public void ThenHeShouldBeRedirectedToTheHomePage()
        {
            expected = "Index";
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var tresults = result as RedirectToRouteResult;
            Assert.AreEqual(expected, tresults.RouteValues["action"]);
        }

        [When(@"He clicks on viewministatement")]
        public void WhenHeClicksOnViewMiniStatement()
        {
            MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();
            UserId = _miniStatementFacade.FindUserByEmail("ram@gmail.com").UserId;
            var userAccount = _miniStatementFacade.GeUsertAccountsByUserId(UserId).FirstOrDefault();
            AccountId = userAccount.AccountId;
            AccountNumber = userAccount.AccountNumber;
            AccountName = userAccount.Account.AccountName;
            MiniStatementController miniStatementcontroller = new MiniStatementController();
            result = miniStatementcontroller.ViewMiniStatement(UserId, AccountId);
        }

        [Then(@"He should be redirected to the ministatement page")]
        public void ThenHeShouldBeRedirectedToTheMiniStatementPage()
        {
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var tresults = result as ViewResult;
            var model = (UserTransactionsModel)tresults.Model;
            Assert.AreEqual(AccountId, model.AccountId);
            Assert.AreEqual(AccountNumber, model.AccountNumber);
            Assert.AreEqual(AccountName, model.AccountType);
            Assert.AreEqual(UserId, model.UserId);
        }

        


    }
}
