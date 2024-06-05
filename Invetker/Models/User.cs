namespace Invetker.Models;

using System;
using System.Data;
using System.Web;
using MySql.Data.MySqlClient;

public class User
{
  public int Id { get; } = 0;
  public string UserId { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public string Created_at { get; } = string.Empty;

  // The database context class which allows us to access our MySQL Database.
  private MySqlConnection MySql = new InvetkerDbContext().AccessDatabase();

  public bool IsValid(User NewUser)
  {
    bool valid = true;

    if (NewUser.Name == null || NewUser.Email == null || NewUser.Password == null)
    {
      //Base validation to check if the fields are entered.
      valid = false;
    }

    return valid;
  }

  public (bool success, string? message) Create(User NewUser)
  {
    //Exit method if model fields are not included.
    if (!IsValid(NewUser)) {
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
    catch (Exception ex) {
      return (false, ex.ToString());
    }
    finally
    {
      //Close the connection between the MySQL Database and the WebServer
      MySql.Close();
    }

  }
}
