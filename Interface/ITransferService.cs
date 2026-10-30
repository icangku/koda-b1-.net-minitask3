
using Minitask.Console.Models;

namespace Minitask.Console.Interface;

public interface ITransferService
{
  void Transfer(Account source, Account destination, decimal amount);
}