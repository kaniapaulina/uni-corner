using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examE
{
    public class MixedFieldGroup
    {
        string groupName;
        Dictionary<string, Student> students;

        public string GroupName { get => groupName; set => groupName = value; }
        public Dictionary<string, Student> Students { get => students; set => students = value; }

        public MixedFieldGroup(string name)
        {
            GroupName = name;
            Students = new Dictionary<string, Student>();
        }


        public void AddStudent(string fieldOfStudy)
        {
            EnumFieldOfStudy field;
            Enum.TryParse<EnumFieldOfStudy>(fieldOfStudy, out field);

            Student s = new Student(fieldOfStudy);
            string klucz = s.AlbumNumber;

            Students.Add(klucz, s);
        }

        public List<Student> StudentsWithHighestAverageGRade()
        {

            int count = Students.Count;
            int limit = (int)Math.Max(1, Math.Floor(count * 0.4));
;
            return Students.Values.OrderByDescending(s => s.GradesAverage()).Take(limit).ToList();
        }
    }
}
