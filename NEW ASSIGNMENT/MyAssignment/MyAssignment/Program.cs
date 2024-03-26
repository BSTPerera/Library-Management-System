using MyAssignment.Classes;
using MyAssignment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace MyAssignment
{

    internal static class Program
    {
        private static string ConnectionString => "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";
       
        private static void Main()
        {
            PrintOptions();

            Dictionary<int, Member> members = new Dictionary<int, Member>();

            while (true)
            {
                Console.Write("Enter Number: ");

                int choice = 0;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Input. Please try again. " + ex.Message);
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddMembers(members);
                        break;
                    case 2:
                        BorrowBook();
                        break;
                    case 3:
                        ReturnBook();
                        break;
                    case 4:
                        OpenGUI();
                        break;
                    case 5:
                        Console.WriteLine("Program Terminated. Thank You!");
                        return;
                    default:
                        Console.WriteLine("Invalid number. Please try again.");
                        break;
                }
            }
        }

        private static void PrintOptions()
        {
            Console.WriteLine("Welcome to the Library system");
            Console.WriteLine("1. Add Members");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. Open GUI");
            Console.WriteLine("5. Exit");
        }

        private static void AddMembers(Dictionary<int, Member> members)
        {
            Console.WriteLine("Please fill the information to add a member");

            while (true)
            {
                try
                {
                    Console.Write("Enter Full Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Member ID number: ");
                    int memberId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Add member yes/no: ");
                    string saveChange = Console.ReadLine();

                    if (saveChange.ToLower() == "yes")
                    {
                        DatabaseInputs(name, age, memberId);
                    }
                    else
                    {
                        Console.WriteLine("Member information removed");
                    }

                    Member member = new Member(memberId,name, age );
                    members.Add(members.Count, member);

                    Console.WriteLine("Member added successfully");
                    Console.Write("Do you want to continue? (yes/no): ");

                    string choice2 = Console.ReadLine().ToLower();
                    if (choice2 == "no")
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occurred: " + ex.Message);
                }
            }
        }

        private static void BorrowBook()
        { 
            int bookId = 0;
            string title = "";
            string author = "";
            int isbn = 0;
            bool availability = true;

            Book borrowbook = new Book(bookId, title, author, isbn,availability);
            borrowbook.BorrowBook();
        }

        private static void ReturnBook()
        {
            int bookId = 0;
            Book returnbook = new Book(bookId);
            returnbook.ReturnBook();
        }

        private static void OpenGUI()
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private static void DatabaseInputs(string name, int age, int memberId)
        {
            try
            {
                int borrowedbooks = 0;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Members([Member Id], Name, Age, [Borrowed Books]) VALUES (@memberId, @name, @age, @borrowedbooks)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@memberId", memberId);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@borrowedbooks", borrowedbooks);

                        int rownum = command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Added to Database successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}