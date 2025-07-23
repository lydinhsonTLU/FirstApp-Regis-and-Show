namespace webApp_show3.Models
{
    public static class Repo
    {

        private static List<Student> list = new List<Student>();

        public static List<Student> GetStudents ()
        {
            return list;
        }

        public static void AddStudent (Student student)
        {
             list.Add(student);
        }
        
        public static void RemoveAllStudent ()
        {
            list.Clear();
        }

    }
}
