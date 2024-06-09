using Microsoft.AspNetCore.Identity;

namespace Invetker;

public class UserModel: IdentityUser<int>
{
  // For Personal Page use, example: invetker.com/user/{hashId}
  public string? HashId { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;

  public bool IsValid(UserModel NewUser)
  {
    bool valid = true;

    if (NewUser.UserName == null || NewUser.Email == null || NewUser.PasswordHash == null)
    {
      //Base validation to check if the fields are entered.
      valid = false;
    }

    return valid;
  }
}
