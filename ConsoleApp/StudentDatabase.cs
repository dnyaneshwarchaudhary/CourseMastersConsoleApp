using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class StudentDatabase
    {
        public static void AddStudent(string sName, int sYearPass, int sCourseid)
        {
            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "Insert into Student (SName, YearOfPassing, CourseId) values (@SName, @SYear, @SCId)";

            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();
            SqlParameter p3 = new SqlParameter();

            p1.ParameterName = "@SName";
            p2.ParameterName = "@SYear";
            p3.ParameterName = "@SCId";

            p1.DbType = DbType.String;
            p2.DbType = DbType.Int32;
            p3.DbType = DbType.Int32;
            p1.Size = 100;
            p2.Size = 15;
            p3.Size = 6;

            p1.Value = sName;
            p2.Value = sYearPass;
            p3.Value = sCourseid;

            SqlCommand conCommand = new SqlCommand(sql, con);
            conCommand.Parameters.Add(p1);
            conCommand.Parameters.Add(p2);
            conCommand.Parameters.Add(p3);

            con.Open();

            int count = conCommand.ExecuteNonQuery();
            if (count == 1)
            {
                Console.WriteLine("The Student Details has been Added! ");

            }
            con.Close();
        }

        public static void RemoveStudent(string SName)
        {
            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "Delete from Student where SName = @Snm;";

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@Snm";
            p1.DbType = DbType.String;
            p1.Size = 30;
            p1.Value = SName;

            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.Add(p1);


            con.Open();
            int count = sqlCommand.ExecuteNonQuery();
            if (count == 1)
            {
                Console.WriteLine("The Student is Deleted from the Database");
            }
            con.Close();
        }

        public static void EditStudent(int sID)
        {

            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "update Student set SName = @SName, YearOfPassing = @SYear, CourseId = @CId where StudentId = @ID";

            Console.WriteLine("Enter the Updated Student Name : ");
            string updateName = Console.ReadLine();
            Console.WriteLine("Enter the Updated Student Course Passing Year (YYYY) : ");
            string updateDate = Console.ReadLine();
            Console.WriteLine("Enter the Updated Student Course ID : ");
            string updateTrainer = Console.ReadLine();

            SqlParameter p1 = new SqlParameter();
            SqlParameter p2 = new SqlParameter();
            SqlParameter p3 = new SqlParameter();
            SqlParameter p4 = new SqlParameter();

            p1.ParameterName = "@SName";
            p1.DbType = DbType.String;
            p1.Size = 100;
            p1.Value = updateName;

            p2.ParameterName = "@SYear";
            p2.Value = updateDate;
            p2.Size = 25;
            p2.DbType = DbType.String;

            p3.ParameterName = "@CId";
            p3.DbType = DbType.String;
            p3.Size = 100;
            p3.Value = updateTrainer;

            p4.ParameterName = "@ID";
            p4.DbType = DbType.Int32;
            p4.Size = 6;
            p4.Value = sID;

            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.Add(p1);
            sqlCommand.Parameters.Add(p2);
            sqlCommand.Parameters.Add(p3);
            sqlCommand.Parameters.Add(p4);

            con.Open();

            int count = sqlCommand.ExecuteNonQuery();
            if (count == 1)
            {
                Console.WriteLine("The Student Details are Updated!");
            }

            con.Close();
        }

        public static void SearchStudent()
        {
            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "select * from Student where StudentId = @Sid;";

            Console.WriteLine("Enter the Student ID to search = ");
            int studentid = Convert.ToInt32(Console.ReadLine());

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@Sid";
            p1.DbType = DbType.Int32;
            p1.Size = 5;
            p1.Value = studentid;

            SqlCommand sqlCommand = new SqlCommand(sql, con);
            sqlCommand.Parameters.Add(p1);
            con.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("Student Details are Available as \n Student Name : " + reader[1] + "\n Student Year of Passing : " + reader[2] + "\n Course ID : " + reader[3]);

            }
            else
            {
                Console.WriteLine("Student Details are Not Available! ");
            }

            con.Close();
        }

        public static void ShowStudents() 
        {

            string conString = "Data Source =DESKTOP-2MLE68C\\SQLEXPRESS;Initial Catalog = armstrong; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            string sql = "select * from Student;";
            SqlCommand sqlCommand = new SqlCommand(sql, con);
  
            con.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            Console.WriteLine("\t\t\t\t\t\tStudent Details\t\t\t\t\t\t\n");
            Console.WriteLine("\t Student ID \t" + "\t Student Name \t" + "\t Year of Passing \t" + "\t Course ID \t" );
            while (reader.Read())
            {
                Console.WriteLine("\t\t " + reader[0] + " \t\t\t"  +  reader[1] + " \t\t\t" + reader[2] + " \t\t\t\t"  + reader[3]);
                Console.WriteLine(); 
            }
      
            con.Close();

        }

    }
}
