using GalaSoft.MvvmLight.Command;
using StudentList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentList.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student student;
        private StudentDatabase studentDatabase;

        public string FirstName
        {
            get { return student.FirstName; }
            set
            {
                if (student.FirstName != value)
                {
                    student.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return student.LastName; }
            set
            {
                if (student.LastName != value)
                {
                    student.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public int Age
        {
            get { return student.Age; }
            set
            {
                if (student.Age != value)
                {
                    student.Age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public double AverageGrade
        {
            get { return student.AverageGrade; }
            set
            {
                if (student.AverageGrade != value)
                {
                    student.AverageGrade = value;
                    OnPropertyChanged(nameof(AverageGrade));
                }
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public StudentViewModel()
        {
            // Инициализация объекта StudentViewModel
        }


        public StudentViewModel(Student student, StudentDatabase studentDatabase)
        {
            this.student = student;
            this.studentDatabase = studentDatabase;

            SaveCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void Save(object parameter)
        {
            studentDatabase.UpdateStudent(student, new Student
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                AverageGrade = AverageGrade
            });
        }


        private void Delete(object parameter)
        {
            studentDatabase.RemoveStudent(student);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
