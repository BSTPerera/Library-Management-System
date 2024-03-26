using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment.Classes
{
    internal class Book
    {
        private int bookId;
        private string title;
        private string author;
        private int isbn;
        private bool availability;

        public int BookId
        {
            get { return bookId; }
            set { bookId = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }


        public Book(int bookId, string title, string author, int isbn, bool availability)
        {
            this.bookId = bookId;
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.availability = availability;

        }

        public Book(int bookId)
        {
            this.bookId = bookId;

        }

        public void BorrowBook()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Book Id: ");
                    int bookId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Member Id: ");
                    int memberId = Convert.ToInt32(Console.ReadLine());

                    DateTime currentDate = DateTime.Now;
                    string borrowedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime returnDate = currentDate.AddDays(14);

                    string connectionString = "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        if (CheckMemberAvailability(memberId))
                        {
                            if (CheckBookAvailability(bookId))
                            {
                                Console.Write("Book is available. Do you wish to continue? (y/n): ");
                                string borrowChoice = Console.ReadLine().ToLower();

                                if (borrowChoice.Equals("y"))
                                {
                                    UpdateBookAvailability(bookId, connection);
                                    UpdateMemberBorrowedBooks(memberId, connection);
                                    InsertTransaction(bookId, memberId, borrowedDate, returnDate, connection);
                                    Console.WriteLine("Book borrowed and records updated successfully.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Book is unavailable.");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Member not found or maximum books borrowed reached.");
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    break;
                }
            }
        }

        private bool CheckMemberAvailability(int memberId)
        {
            bool memberAvailability = false;
            int numBorrowedBooks = 0;

            string connectionString = "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql1 = "SELECT COUNT(*) FROM Members WHERE [Member Id] = @brMemberId";
                string sql2 = "SELECT [Borrowed Books] FROM Members WHERE [Member Id] = @brMemberId";

                using (SqlCommand command = new SqlCommand(sql1, connection))
                {
                    command.Parameters.AddWithValue("@brMemberId", memberId);

                    int memberCount = Convert.ToInt32(command.ExecuteScalar());

                    if (memberCount > 0)
                    {
                        memberAvailability = true;

                        using (SqlCommand commandCheck = new SqlCommand(sql2, connection))
                        {
                            commandCheck.Parameters.AddWithValue("@brMemberId", memberId);
                            
                            numBorrowedBooks = Convert.ToInt32(commandCheck.ExecuteScalar());

                            if (numBorrowedBooks >= 6)
                            {
                                memberAvailability = false;
                            }
                        }
                    }
                }
            }

            return memberAvailability;
        }

        private bool CheckBookAvailability(int bookId)
        {
            bool availability = false;
            string connectionString = "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT Availability FROM Books WHERE BookID = @bookId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@bookId", bookId);

                    availability = Convert.ToBoolean(command.ExecuteScalar());
                }
            }

            return availability;
        }

        private void UpdateBookAvailability(int bookId, SqlConnection connection)
        {
            string sql = "UPDATE Books SET Availability = 0 WHERE BookID = @bookId";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@bookId", bookId);
                command.ExecuteNonQuery();
            }
        }

        private void UpdateMemberBorrowedBooks(int memberId, SqlConnection connection)
        {
            string sql = "UPDATE Members SET [Borrowed Books] = [Borrowed Books] + 1 WHERE [Member Id] = @brMemberId";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@brMemberId", memberId);
                command.ExecuteNonQuery();
            }
        }

        private void InsertTransaction(int bookId, int memberId, string borrowedDate, DateTime returnDate, SqlConnection connection)
        {
            string sql = "INSERT INTO Transactions ([Book Id], [Member Id], [Borrowed Date], [Return Date], [Transaction Type]) VALUES(@bookId, @brMemberId, @brDate, @dateReturn, 'Borrowed')";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@bookId", bookId);
                command.Parameters.AddWithValue("@brMemberId", memberId);
                command.Parameters.AddWithValue("@brDate", borrowedDate);
                command.Parameters.AddWithValue("@dateReturn", returnDate);
                command.ExecuteNonQuery();
            }
        }




        public void ReturnBook()
        {
            
            try
            {
                Console.Write("Enter Book Id: ");
                int bookId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Member Id: ");
                int memberId = Convert.ToInt32(Console.ReadLine());

                DateTime returnDate = DateTime.Now;
                string formattedReturnDate = returnDate.ToString("yyyy-MM-dd HH:mm:ss");

                Console.Write("Do you wish to return the book? (y/n): ");
                string returnChoice = Console.ReadLine().ToLower();
                string connectionString = "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";
                if (returnChoice.Equals("y"))
                {
                    UpdateBookAvailability(bookId);
                    UpdateMemberBorrowedBooks(memberId);
                    RecordTransaction(bookId, memberId, returnDate);

                    Console.WriteLine("Book returned and updated successfully.");
                }
                else
                {
                    Console.WriteLine("Book return cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void UpdateBookAvailability(int bookId)
        {
            string connectionString = "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Books SET Availability = 1 WHERE BookID = @BookID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@BookID", bookId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateMemberBorrowedBooks(int memberId)
        {
            string connectionString = "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Members SET [Borrowed Books] = [Borrowed Books] - 1 WHERE [Member Id] = @MemberId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void RecordTransaction(int bookId, int memberId, DateTime returnDate)
        {
            string connectionString = "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Transactions ( [Book Id],[Member Id],[Borrowed Date],[Return Date],[Transaction Type]) VALUES (@BookId, @MemberId, @BorrowedDate, @ReturnDate, 'Returned')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    command.Parameters.AddWithValue("@BorrowedDate", returnDate);
                    command.Parameters.AddWithValue("@ReturnDate", returnDate);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}




    

    






