namespace webApp_show3.Models
{
    public  class Student
    {
        public  string msv { get; set; }
        public  string name { get; set; }
        public  string birthday { get; set; }
        public  string gender { get; set; }
        public  bool hasGraduated { get; set; }


        public Student ()
        {
            msv =name = birthday= gender = "...";
            hasGraduated = false;
        }

        public Student (string msv, string name, string birthday, string gender, bool hasGraduated)
        {
            this.msv = msv;
            this.name = name;
            this.birthday = birthday;
            this.gender = gender;
            this.hasGraduated = hasGraduated;
        }

    }
}
