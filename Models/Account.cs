namespace Minitask.Console.Models;

public abstract class Account{
  public string Id { get; set;}
  public string Type {get; set;}
  public string Name {get; set;}
  public decimal Balance {get; set;}
  public bool IsActive {get; set;}

  public Account(string id, string type, string name, bool isActive, decimal balance)
  {
    if (string.IsNullOrWhiteSpace("id"))
    {
      throw new ArgumentException("Id must present");
    }

    if (string.IsNullOrWhiteSpace("name"))
    {
      throw new ArgumentException("Name must be present");
    }

    if(balance < 0)
    {
      throw new ArgumentException("Balance cannot be lower than 0");
    }

    Id = id;
    Type = type;
    Name = name;
    Balance = balance;
    IsActive = isActive;
  }

  public void AddBalance(decimal amount)
  {
    if(amount < 0)
    {
      throw new ArgumentException("Amount should not negative");
    }

    Balance += amount;
  }

  public void DeductBalance(decimal amount)
  {
    if(amount < 0)
    {
      throw new ArgumentException("Amount should not negative");
    }

    if(Balance < amount)
    {
      throw new InvalidOperationException("Insufficient balance");
    }

    Balance -= amount;
  }

  public virtual string GetInformation()
  {
    return $"[{Type}] {Id} - {Name} \nActive: {IsActive} \nBalance : {Balance:N0}\n\n";
  }

}