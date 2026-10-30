using Minitask.Console.Models;

namespace Minitask.Console.Services;

public class AccountQueryService
{
  private readonly IReadOnlyCollection<Account> _accounts;

  public AccountQueryService(IReadOnlyCollection<Account> accounts)
  {
    _accounts = accounts;
  }

  public async Task<Account?> findAccountAsync(string Id)
  {
    await Task.Delay(300);

    return _accounts.FirstOrDefault(account => account.Id == Id);
  }
}