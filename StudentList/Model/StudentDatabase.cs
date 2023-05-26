using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StudentList.Model
{
    public class StudentDatabase
    {
        public ObservableCollection<Student> Students { get; } = new ObservableCollection<Student>();

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        public void UpdateStudent(Student studentToUpdate, Student updatedStudent)
        {
            if (Students.Contains(studentToUpdate))
            {
                int index = Students.IndexOf(studentToUpdate);
                Students[index] = updatedStudent;
            }
        }
    }
}
