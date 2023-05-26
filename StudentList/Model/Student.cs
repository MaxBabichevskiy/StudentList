using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList.Model
{   
        public class Student : INotifyPropertyChanged
        {
            private string firstName;
            public string FirstName
            {
                get { return firstName; }
                set
                {
                    if (firstName != value)
                    {
                        firstName = value;
                        OnPropertyChanged(nameof(FirstName));
                    }
                }
            }

            private string lastName;
            public string LastName
            {
                get { return lastName; }
                set
                {
                    if (lastName != value)
                    {
                        lastName = value;
                        OnPropertyChanged(nameof(LastName));
                    }
                }
            }

            private int age;
            public int Age
            {
                get { return age; }
                set
                {
                    if (age != value)
                    {
                        age = value;
                        OnPropertyChanged(nameof(Age));
                    }
                }
            }

            private double averageGrade;
            public double AverageGrade
            {
                get { return averageGrade; }
                set
                {
                    if (averageGrade != value)
                    {
                        averageGrade = value;
                        OnPropertyChanged(nameof(AverageGrade));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
}

