using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObject;
using Facade;
using FirstIslandBankCorporation.Models;
using FirstIslandBankCorporation.CurrencyService;

namespace FirstIslandBankCorporation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MiniStatementModel model = new MiniStatementModel();

            if (Session["UID"] != null)
            {
                PrepareModel(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult ConversionRate(string fromCurrency, string toCurrency)
        {
            var rate = double.NaN;
            try
            {
                if (!string.IsNullOrEmpty(fromCurrency) && !string.IsNullOrEmpty(toCurrency))
                {
                    Currency fromCur = (Currency)(Enum.Parse(typeof(Currency), fromCurrency));
                    Currency toCur = (Currency)(Enum.Parse(typeof(Currency), toCurrency));

                    CurrencyConvertorSoapClient client = new CurrencyConvertorSoapClient("CurrencyConvertorSoap");
                    rate = client.ConversionRate(fromCur, toCur);
                }
            }
            catch (Exception)
            {
            }
            return Json(new { Result = rate });
        }

        #region Utilities

        private void PrepareModel(MiniStatementModel model)
        {
            MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();

            int accountId;
            string accountNumber;
            var userId = (Int32)Session["UID"];
            var userEmail = Convert.ToString(Session["Email"]);
            var userTransactions = _miniStatementFacade.GetUserTransactionsByUserId(userId);
            var userAccounts = _miniStatementFacade.GeUsertAccountsByUserId(userId);

            var totalAvaialbeBalance = _miniStatementFacade.GetCurrentAvailableBalance(userTransactions);
            var savingActBalance = _miniStatementFacade.GetBalanceByAccount("Savings Account", userTransactions);
            var currentActBalance = _miniStatementFacade.GetBalanceByAccount("Current Account", userTransactions);
            var seniorCitizenActBalance = _miniStatementFacade.GetBalanceByAccount("Senior Citizen Account", userTransactions);

            model.UserId = userId;
            model.TotalAvaialbeBalance = totalAvaialbeBalance;
            model.SavingAccountBalance = savingActBalance;
            model.CurrentAccountBalance = currentActBalance;
            model.SeniorCitizenAccountBalance = seniorCitizenActBalance;
            model.SavingAccountTransactionCount = userTransactions.Where(x => x.Account.AccountName == "Savings Account").Count();
            model.CurrentAccountTransactionCount = userTransactions.Where(x => x.Account.AccountName == "Current Account").Count();
            model.SeniorCitizenTransactionCount = userTransactions.Where(x => x.Account.AccountName == "Senior Citizen Account").Count();
            model.HasSavingsAccount = _miniStatementFacade.HasUserHadAccount(userAccounts, "Savings Account");
            model.HasCurrentAccount = _miniStatementFacade.HasUserHadAccount(userAccounts, "Current Account");
            model.HasSeniorCitizenAccount = _miniStatementFacade.HasUserHadAccount(userAccounts, "Senior Citizen Account");

            _miniStatementFacade.GetUserAccount(userAccounts, "Savings Account", out accountId, out accountNumber);
            model.SavingsAccountId = accountId;
            model.SavingsAccountNumber = accountNumber;
            accountId = 0;
            accountNumber = string.Empty;
            _miniStatementFacade.GetUserAccount(userAccounts, "Current Account", out accountId, out accountNumber);
            model.CurrentAccountId = accountId;
            model.CurrentAccountNumber = accountNumber;
            accountId = 0;
            accountNumber = string.Empty;
            _miniStatementFacade.GetUserAccount(userAccounts, "Senior Citizen Account", out accountId, out accountNumber);
            model.SeniorCitizenAccountId = accountId;
            model.SeniorCitizenAccountNumber = accountNumber;

            IList<SelectListItem> countryList = new List<SelectListItem>()
            {
                 new SelectListItem() {Text="Indian Rupee", Value="INR"},
                 new SelectListItem() {Text="U.S. Dollar", Value="USD"},
                 new SelectListItem() {Text="Australian Dollar", Value="AUD"},
                 new SelectListItem() {Text="Bahraini Dinar", Value="BHD"},
                 new SelectListItem() {Text="Euro", Value="EUR"},
                 new SelectListItem() {Text="Nicaragua Cordoba", Value="NIO"},
                 new SelectListItem() {Text="Pacific Franc", Value="XPF"},
                 new SelectListItem() {Text="Singapore Dollar", Value="SGD"},
                 new SelectListItem() {Text="Qatar Rial", Value="QAR"},
                 new SelectListItem() {Text="Romanian Leu", Value="ROL"},
            };

            model.CountryList = countryList;
        }


        #endregion
    }
}