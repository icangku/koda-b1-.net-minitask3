// See https://aka.ms/new-console-template for more information
using Minitask.Console.Interface;
using Minitask.Console.Models;
using Minitask.Console.Services;

Console.WriteLine("==========KOPERASI KODA ACADEMY===============");
Account savingAcc = new SavingAccount("S01", "Saving", "Alvin Corwin", true, 5_000_000_000);
Account currAcc = new CurrentAccount("C01", "Current", "Chandra ", true, 1_000_000);
Account alvAcc = new CurrentAccount("A02", "Saving", "Alvon", true, 2_500_000);
Account budAcc = new CurrentAccount("B01", "Current", "Budi", false, 2_540_000);
Account cubAcc = new CurrentAccount("C02", "Saving", "Cubit", true, 2_500_000);

List<Account> listAccounts =
[
  savingAcc, currAcc, alvAcc, budAcc, cubAcc
];



System.Console.WriteLine("====== FIND ACTIVE ========");
var activeAccounts = listAccounts.Where(account => account.IsActive).ToList();
foreach(var account in activeAccounts)
{
  System.Console.WriteLine(account.Name);
}

System.Console.WriteLine("====== ORDER BY BALANCE DESC ========");
var sortedAccountsDesc = listAccounts.OrderByDescending(account => account.Balance).ToList();
foreach(var account in sortedAccountsDesc)
{
  System.Console.WriteLine($"{account.Name} Rp {account.Balance:N0}");
}

System.Console.WriteLine("====== SHOW ALL NAME ONLY ========");
var accNameOnly = listAccounts.Select(account => account.Name).ToList();
foreach(var acc in accNameOnly){
  Console.WriteLine(acc);
}

System.Console.WriteLine("====== TOTAL BALANCE ==========");
decimal totalBalance = listAccounts.Sum(account => account.Balance);
System.Console.WriteLine($"Total Balance: Rp {totalBalance:N0}");

System.Console.WriteLine("====== FIND ACCOUNT B01 =======");
var accountService = new AccountQueryService(listAccounts);
Task<Account> findAcc = accountService.findAccountAsync("B01");
Account?[] results = await Task.WhenAll(findAcc);
foreach(var acc in results)
{
  System.Console.WriteLine(acc?.GetInformation() ?? "Account not found");
}

