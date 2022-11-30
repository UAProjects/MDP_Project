    public MySqlConnection GetConnection()
    {
      string conStr = "datasource=localhost;port=3306;username=root;password=admin;database=mdb_project";
      MySqlConnection con = new MySqlConnection(conStr);
      try
      {
        con.Open();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }

      return con;
    }

    public void SaveToDB(string firstName, string lastName, string serial, string dob, bool english, bool french, Byte[] image)
    {
      string sqlQuery = "INSERT INTO entries VALUES (NULL, @FirstName, @LastName, @Serial, @Dob, @English, @French, @Image)";
      MySqlConnection con = GetConnection();
      MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
      cmd.CommandType = CommandType.Text;
      cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = firstName;
      cmd.Parameters.Add("@LastName", MySqlDbType.VarChar).Value = lastName;
      cmd.Parameters.Add("@Serial", MySqlDbType.VarChar).Value = serial;
      cmd.Parameters.Add("@Dob", MySqlDbType.VarChar).Value = dob;
      cmd.Parameters.Add("@English", MySqlDbType.Int16).Value = english ? 1 : 0;
      cmd.Parameters.Add("@French", MySqlDbType.Int16).Value = french ? 1 : 0;;
      cmd.Parameters.Add("@Image", MySqlDbType.MediumBlob).Value = image;
      try
      {
        cmd.ExecuteNonQuery();
        Console.WriteLine("Entry Saved");
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    } 
