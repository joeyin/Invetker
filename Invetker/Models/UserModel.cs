using System.ComponentModel.DataAnnotations;
using System;
using MySql.Data.MySqlClient;
using Invetker.Models;

namespace Invetker;

public class UserModel
{

  // The database context class which allows us to access our MySQL Database.
  private MySqlConnection MySql = new InvetkerDbContext().AccessDatabase();

  [Key]
  public int Id { get; set; }

  // For Personal Page use, example: invetker.com/user/{hashId}
  public string hashId { get; set; }

  public string Name { get; set; }

  [DataType(DataType.EmailAddress)]
  public string Email { get; set; }

  public string Password { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;

  public bool IsValid(UserModel NewUser)
  {
    bool valid = true;

    if (NewUser.Name == null || NewUser.Email == null || NewUser.Password == null)
    {
      //Base validation to check if the fields are entered.
      valid = false;
    }

    return valid;
  }

  public (bool success, string? message) Create(UserModel NewUser)
  {
    //Exit method if model fields are not included.
    if (!IsValid(NewUser))
    {
      //Console.WriteLine("Incomplete data.");
      return (false, "Incomplete data.");
      // throw new ApplicationException("Incomplete data.");
    }

    try
    {
      //Open the connection between the web server and database
      MySql.Open();
      //Establish a new command (query) for our database
      MySqlCommand cmd = MySql.CreateCommand();

      cmd.CommandText = "INSERT INTO USERS (name, email, password) VALUES (@Name, @Email, @Password)";
      cmd.Parameters.AddWithValue("@Name", NewUser.Name);
      cmd.Parameters.AddWithValue("@Email", NewUser.Email);
      cmd.Parameters.AddWithValue("@Password", NewUser.Password);

      cmd.Prepare();
      cmd.ExecuteNonQuery();
      MySql.Close();

      return (true, "");
    }
    catch (MySqlException ex)
    {
      //Catches issues with MySQL.
      return (false, ex.ToString());
    }
    catch (Exception ex)
    {
      return (false, ex.ToString());
    }
    finally
    {
      //Close the connection between the MySQL Database and the WebServer
      MySql.Close();
    }

  }
}
