using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examE
{
    public enum EnumFieldOfStudy
    {
        Z,
        ZiIP,
        IiE
    }

    public class Student
    {
        EnumFieldOfStudy fieldOfStudy;
        string albumNumber;
        List<float> grades;
        static long counter;
        static float[] gradeScale;

        public string AlbumNumber { get => albumNumber; protected set => albumNumber = value; }

        static Student()
        {
            counter = 400000;
            gradeScale = new float[] { 2.0f, 2.5f, 3.0f, 3.5f, 4.0f, 4.5f, 5.0f };
        }

        public Student(string kierunek)
        {
            Enum.TryParse<EnumFieldOfStudy>(kierunek, out this.fieldOfStudy);
            this.albumNumber = $"{kierunek}/{counter}";
            counter++;
            this.grades = new List<float>();
        }

        public void AddGrade()
        {
            if(grades.Count<5)
            {
                Random rand = new Random();
                int element = rand.Next(0, 6);
                grades.Add(gradeScale[element]);
            } 
        }

        public float GradesAverage()
        {
            if (grades == null || grades.Count == 0) return 0;
            return grades.Average();
        }

        public string FullName()
        {
            switch(fieldOfStudy)
            {
                case EnumFieldOfStudy.Z: return "Zarządzanie";
                case EnumFieldOfStudy.ZiIP: return "Zarządzanie i Inżynieria Produkcji";
                case EnumFieldOfStudy.IiE: return "Informatyka i Ekonometria";
                default: return null;
            }
        }

        public override string ToString()
        {
            return $"{albumNumber}: {FullName()}, grades average: {GradesAverage():F2} ({string.Join(",", grades)})";
        }
    }
}
  