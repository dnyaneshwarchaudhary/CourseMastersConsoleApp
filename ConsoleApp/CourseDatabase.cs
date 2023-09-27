using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public static class CourseDatabase
    {
        public static void AddCourse(string CName, string CDate, string CTrainer)
        {
            string conString = "Data Source = DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "Insert into Course (CourseName, StartDate, Trainer) values (@CName, @CDate, @CTrainer)";

            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();
            SqlParameter p3 = new SqlParameter();

            p1.ParameterName = "@CName";
            p2.ParameterName = "@CDate";
            p3.ParameterName = "@CTrainer";

            p1.DbType = DbType.String;
            p2.DbType = DbType.String;
            p3.DbType = DbType.String;

            p1.Size = 100;
            p2.Size = 25;
            p3.Size = 100;

            p1.Value = CName;
            p2.Value = CDate;
            p3.Value = CTrainer;

            SqlCommand conCommand = new SqlCommand(sql, con);
            conCommand.Parameters.Add(p1);
            conCommand.Parameters.Add(p2);
            conCommand.Parameters.Add(p3);


            con.Open();


            int count = conCommand.ExecuteNonQuery();
            if (count == 1)
            {
                Console.WriteLine("The Course has been Added! ");

            }
            con.Close();
        }

        public static void RemoveCourse(string Trainer)
        {
            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "Delete from Course where Trainer = @CTrainer";

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@CTrainer";
            p1.DbType = DbType.String;
            p1.Size = 25;
            p1.Value = Trainer;

            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.Add(p1);


            con.Open();
            int count = sqlCommand.ExecuteNonQuery();
            if (count == 1)
            {
                Console.WriteLine("The Course is Deleted from the Database");
            }
            con.Close();
        }

        public static void EditCourse(string Trainer)
        {

            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "update Course set CourseName = @CName, StartDate = @CDate, Trainer = @CTrainer where Trainer = @ct";

            Console.WriteLine("Enter the Updated Course Name : ");
            string updateName = Console.ReadLine();
            Console.WriteLine("Enter the Updated Course Date (YYYY-MM-DD) : ");
            string updateDate = Console.ReadLine();
            Console.WriteLine("Enter the Updated Course Trainer : ");
            string updateTrainer = Console.ReadLine();

            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();
            SqlParameter p3 = new SqlParameter();
            SqlParameter p4 = new SqlParameter();

            p1.ParameterName = "@CName";
            p1.DbType = DbType.String;
            p1.Size = 100;
            p1.Value = updateName;

            p2.ParameterName = "@CDate";
            p2.Value = updateDate;
            p2.Size = 25;
            p2.DbType = DbType.String;

            p3.ParameterName = "@CTrainer";
            p3.DbType = DbType.String;
            p3.Size = 100;
            p3.Value = updateTrainer;

            p4.ParameterName = "@Ct";
            p4.DbType = DbType.String;
            p4.Size = 100;
            p4.Value = Trainer;

            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.Add(p1);
            sqlCommand.Parameters.Add(p2);
            sqlCommand.Parameters.Add(p3);
            sqlCommand.Parameters.Add(p4);

            con.Open();

            int count = sqlCommand.ExecuteNonQuery();
            if (count == 1)
            {
                Console.WriteLine("The Course is Updated!");
            }

            con.Close();
        }

        public static void SearchCourse()
        {
            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "select * from Course where Trainer = @CTrainer;";

            Console.WriteLine("Enter the Trainer to Name to Search Course = ");
            string Trainer = Console.ReadLine();

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@CTrainer";
            p1.DbType = DbType.String;
            p1.Size = 100;
            p1.Value = Trainer;

            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.Add(p1);
            con.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("Course is Available as \n Course Name : " + reader[1] + "\n Course Date : " + reader[2] + "\n Course Trainer : " + reader[3]);

            }
            else
            {
                Console.WriteLine("Course is Not Available! ");
            }

            con.Close();
        }
        public static void ShowCourses()
        {

            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "select * from Course;";
            SqlCommand sqlCommand = new SqlCommand(sql, con);

            con.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            Console.WriteLine("\t\t\t\t\t\tCourse Details\t\t\t\t\t\t\n");
            Console.WriteLine("\t Course ID \t" + "\t Course Name (Trainer) \t");
            int i = 1;
            while (reader.Read())
            {
                Console.WriteLine("\t\t " + reader[0] + " \t" + reader[1] + " \t( " + reader[3] + " )\t" );
                Console.WriteLine();
            }

            con.Close();

        }

        public static void CourseStudents(int cid)
        {
            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = con;    
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "showStudents";
            SqlParameter p1 = new SqlParameter("@Courseid",cid);
            sqlCommand.Parameters.Add(p1);

            con.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            Console.WriteLine("\t\t\t\t\t\tStudent Details\t\t\t\t\t\t\n");
            Console.WriteLine("\t Student ID \t" + "\t Student Name \t" + "\t Year of Passing \t" + "\t Course ID \t");
            while (reader.Read())
            {
                Console.WriteLine("\t\t " + reader[0] + " \t\t\t" + reader[1] + " \t\t\t" + reader[2] + " \t\t\t\t" + reader[3]);
                Console.WriteLine();
            }


            con.Close();
        }

    }
}
