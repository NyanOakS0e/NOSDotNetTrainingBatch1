using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace NOS_MVC.Controllers
{
    public class WalletController : Controller
    {
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MiniWallet",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };


        [ActionName("Index")]
        public async Task<IActionResult> WalletIndexAsync()
        {


            IDbConnection db = new SqlConnection(stringBuilder.ConnectionString);
            db.Open();
            var data = await db.QueryAsync<WalletModel>("SELECT * FROM Tbl_Wallet");



            return View("WalletIndex", data.ToList());
        }

        [ActionName("Create")]

        public IActionResult WalletCreate()
        {
            return View("WalletCreate");
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> WalletCreateAsync(WalletModel requestModel)
        {

            IDbConnection db = new SqlConnection(stringBuilder.ConnectionString);


            #region Check Duplicate Validation
            string validationQuery = @"
                SELECT * FROM Tbl_Wallet
                WHERE WalletUserName = @WalletUserName AND MobileNo = @MobileNo";

            db.Open();

            var data = await db.QueryAsync(validationQuery, requestModel);

            if (data.ToList().Count > 0)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "This wallet user already exist";

                return RedirectToAction("Create");
            }
            #endregion

            //=================================================================================

            #region negative balance Validation
            if (Convert.ToDecimal(requestModel.Balance) <= 0)
            {
                TempData["isSuccess"] = false;
                TempData["message"] = "The balance must be greater than 0";

                return RedirectToAction("Create");
            }
            #endregion

            //==================================================================================
            #region Create New Wallet User
            string query = @"INSERT INTO Tbl_Wallet
                            (WalletUserName,FullName, MobileNo, Balance) VALUES 
                            (@WalletUserName, @FullName, @MobileNo, @Balance)";


            var result = await db.ExecuteAsync(query, requestModel);

            bool isSuccess = result > 0;
            string message = isSuccess ? "Success" : "Fail";

            TempData["isSuccess"] = isSuccess;
            TempData["message"] = message;
            return RedirectToAction("Index");
            #endregion
        }

        [ActionName("History")]
        public async Task<IActionResult> WalletHistory()
        {
            IDbConnection db = new SqlConnection(stringBuilder.ConnectionString);
            db.Open();
            string query = "SELECT * FROM Tbl_WalletHistory";

            var result = await db.QueryAsync<WalletHistoryModel>(query);


            return View("WalletHistory", result.ToList());
        }


        
        [ActionName("Deposit")]
        public IActionResult WalletDepositView()
        {
           
            return View("WalletDeposit");
        }

        [HttpPost]
        [ActionName("Deposit")]
        public async Task<IActionResult> WalletDeposit(WalletDepositModel requestModel)
        {
            IDbConnection db = new SqlConnection(stringBuilder.ConnectionString);

            db.Open();

            

            var data = await db.QueryAsync<WalletModel>(
                "SELECT * FROM Tbl_Wallet WHERE MobileNo = @MobileNo", new WalletModel
                {
                    MobileNo = requestModel.MobileNo


                });

            if (data.ToList().Count <= 0)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = "Mobile number doesn't exist";

                return RedirectToAction("Deposit");
            }



            string query = @"
                INSERT INTO Tbl_WalletHistory
                (TransactionType, Amount, MobileNo, DateTime)
                VALUES (@TransactionType, @Amount, @MobileNo, @DateTime)";

            var result = await db.ExecuteAsync(query, new WalletDepositModel
            {
                TransactionType = "Deposit",
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo,
                DateTime = DateTime.Now
            });

            await db.ExecuteAsync("UPDATE Tbl_Wallet SET Balance = Balance + @Amount WHERE MobileNo = @MobileNo", new
            {
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo
            });

            if (result > 0)
            {
                TempData["isSuccess"] = true;
                TempData["message"] = "Deposit successful";
            }
            return RedirectToAction("History");
        }




        //==============================================================================

        [ActionName("Withdraw")]
        public IActionResult WalletWithdrawView()
        {

            return View("WalletWithdraw");
        }

        [HttpPost]
        [ActionName("Withdraw")]
        public async Task<IActionResult> WalletWithdraw(WalletWithdrawModel requestModel)
        {
            IDbConnection db = new SqlConnection(stringBuilder.ConnectionString);

            db.Open();



            var data = await db.QueryAsync<WalletModel>(
                "SELECT * FROM Tbl_Wallet WHERE MobileNo = @MobileNo", new WalletModel
                {
                    MobileNo = requestModel.MobileNo


                });

            if (data.ToList().Count <= 0)
            {
                TempData["isSuccess"] = false;
                TempData["Message"] = "Mobile number doesn't exist";

                return RedirectToAction("Withdraw");
            }



            string query = @"
                INSERT INTO Tbl_WalletHistory
                (TransactionType, Amount, MobileNo, DateTime)
                VALUES (@TransactionType, @Amount, @MobileNo, @DateTime)";

            var result = await db.ExecuteAsync(query, new WalletWithdrawModel
            {
                TransactionType = "Withdraw",
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo,
                DateTime = DateTime.Now
            });

            await db.ExecuteAsync("UPDATE Tbl_Wallet SET Balance = Balance - @Amount WHERE MobileNo = @MobileNo", new
            {
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo
            });

            if (result > 0)
            {
                TempData["isSuccess"] = true;
                TempData["message"] = "Withdraw successful";
            }
            return RedirectToAction("History");
        }
    }


    public class WalletModel
    {
        public int WalletId { get; set; }
        public string WalletUserName { get; set; }
        public decimal Balance { get; set; }
        public string MobileNo { get; set; }
        public string FullName { get; set; }

    }

    public class WalletHistoryModel
    {
        public int WalletHistoryId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class WalletDepositModel
    {
        public int WalletHistoryId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateTime { get; set; }
    }
    public class WalletWithdrawModel
    {
        public int WalletHistoryId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateTime { get; set; }
    }
}
