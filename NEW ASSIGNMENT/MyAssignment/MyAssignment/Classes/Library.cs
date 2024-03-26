using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment.Classes
{
    internal class Library
    {
        public List<Book> books;
        internal void AddBook(Book book)
        {
            int bookId = book.BookId;
            string title = book.Title;
            string author = book.Author;
            int isbn = book.Isbn;
            bool availability = book.Availability;

            string addQuery = "INSERT INTO Books (BookID, Title, Author, ISBN, Availability) VALUES (@BookID, @Title, @Author, @Isbn, @Availability)";

            using (SqlConnection connection = new SqlConnection("Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False"))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(addQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", bookId);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Author", author);
                        command.Parameters.AddWithValue("@isbn", isbn);
                        command.Parameters.AddWithValue("@availability", availability);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Book added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding book: " + ex.Message);
                }
            }
        }



        internal void RemoveBook(Book book)
        {
            int bookId = book.BookId;

            string sql = "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";

            using (SqlConnection connection = new SqlConnection(sql))
            {
                string deleteQuery = "DELETE FROM Books WHERE BookID = @bookId";
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@BookId", bookId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book removed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No book found with that ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing book: " + ex.Message);
                }
            }
        }

    }
}
