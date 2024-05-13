using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace curdOperation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = "server=localhost;uid=root;pwd=root;database=student_db";
            //string conn = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(conn);

            try
            {
                connection.Open();

                // Display a message indicating successful connection
                //Response.Write("Connection to the database established successfully.<br>");

                string sql = "SELECT * FROM student";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                //Console.WriteLine( reader.ToString());
                //Response.Write(reader.HasRows);
                int rowIndex = 0;



                while (reader.Read())
                {
                    // Create a new row for each record
                    TableRow row = new TableRow();

                    // Add cells for each column in the record
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        TableCell cell = new TableCell();
                        cell.Text = reader[i].ToString();
                        row.Cells.Add(cell);
                    }

                    // Add the row to the table
                    Table1.Rows.Add(row);

                    rowIndex++;
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // For example, you can display an error message
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                // Make sure to close the connection
                connection.Close();
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string conn = "server=localhost;uid=root;pwd=root;database=student_db";
            MySqlConnection connection = new MySqlConnection(conn);

            try
            {
                connection.Open();

                string sql = "INSERT INTO student (Id, SName, Email, Phone, Age, Gender) VALUES (@Id, @Name, @Email, @Phone, @Age, @Gender)";
                MySqlCommand command = new MySqlCommand(sql, connection);

                // Set parameter values from input fields
                command.Parameters.AddWithValue("@Id", IdBox.Text);
                command.Parameters.AddWithValue("@Name", NameBox.Text);
                command.Parameters.AddWithValue("@Email", EmailBox.Text);
                command.Parameters.AddWithValue("@Phone", PhoneBox.Text);
                command.Parameters.AddWithValue("@Age", AgeBox.Text);
                command.Parameters.AddWithValue("@Gender", GenderBox.Text);

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                // Check if data was successfully inserted
                if (rowsAffected > 0)
                {
                    // Data inserted successfully
                    Response.Redirect(Request.Url.AbsoluteUri); // Redirect to the same page to prevent form resubmission
                                                                // Or you can redirect to another page
                                                                // Response.Redirect("SuccessPage.aspx");
                }
                else
                {
                    // Data insertion failed
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Failed to add data.');", true);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error: " + ex.Message + "');", true);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string conn = "server=localhost;uid=root;pwd=root;database=student_db";
            MySqlConnection connection = new MySqlConnection(conn);

            try
            {
                connection.Open();

                string sql = "UPDATE student SET SName = @Name, Email = @Email, Phone = @Phone, Age = @Age, Gender = @Gender WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);

                // Set parameter values from input fields
                command.Parameters.AddWithValue("@Id", IdBox.Text);
                command.Parameters.AddWithValue("@Name", NameBox.Text);
                command.Parameters.AddWithValue("@Email", EmailBox.Text);
                command.Parameters.AddWithValue("@Phone", PhoneBox.Text);
                command.Parameters.AddWithValue("@Age", AgeBox.Text);
                command.Parameters.AddWithValue("@Gender", GenderBox.Text);

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                // Check if data was successfully updated
                if (rowsAffected > 0)
                {
                    // Data updated successfully
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data updated successfully.');", true);
                    //Response.Redirect(Request.Url.AbsoluteUri);

                    IdBox.Text = "";
                    NameBox.Text = "";
                    EmailBox.Text = "";
                    PhoneBox.Text = "";
                    AgeBox.Text = "";
                    GenderBox.Text = "";
                }
                else
                {
                    // No rows affected - perhaps the ID doesn't exist
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No data found with the provided ID.');", true);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error: " + ex.Message + "');", true);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string conn = "server=localhost;uid=root;pwd=root;database=student_db";
            MySqlConnection connection = new MySqlConnection(conn);

            try
            {
                connection.Open();

                string sql = "DELETE FROM student WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);

                // Set parameter value for ID
                command.Parameters.AddWithValue("@Id", DeleteIdBox.Text);

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                // Check if data was successfully deleted
                if (rowsAffected > 0)
                {
                    // Data deleted successfully
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data deleted successfully.');", true);
                }
                else
                {
                    // No rows affected - perhaps the ID doesn't exist
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No data found with the provided ID.');", true);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error: " + ex.Message + "');", true);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }
        }
    }
}