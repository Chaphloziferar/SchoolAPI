using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDAL
{
    public class StudentGradeDAL : SchoolBaseDAL
    {
        public StudentGradeDAL(string connectionString) : base(connectionString)
        {
        }

        public List<StudentGrade> GetAllStudentsGradesById(int studentId)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "SP_GetAllStudentsGradesById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pStudentId", studentId);

            DataTable dt = new();
            SqlDataAdapter adapter = new(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(x => new StudentGrade
            {
                StudentId = Convert.ToInt32(x["student_id"]),
                StudentName = Convert.ToString(x["student_name"]),
                StudentLastname = Convert.ToString(x["student_lastname"]),
                ClassName = Convert.ToString(x["class_name"]),
                TeacherName = Convert.ToString(x["teacher_name"]),
                TeacherLastname = Convert.ToString(x["teacher_lastname"]),
                GradeValue = Convert.ToDecimal(x["gradeValue"])
        });

            return query.ToList();
        }
    }
}
