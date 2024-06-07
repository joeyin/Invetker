using System.ComponentModel.DataAnnotations;

namespace Invetker;

public class UserModel
{
  [Key]
  public int Id { get; set; }

  // For Personal Page use, example: invetker.com/user/{hashId}
  public string hashId { get; set; }

  public string Name { get; set; }

  [DataType(DataType.EmailAddress)]
  public string Email { get; set; }

  public string Password { get; set; }

  public DateTime CreatedAt { get; set; }
}
