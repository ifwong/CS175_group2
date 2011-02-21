using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AI_Project_3
{
    public class MajorInitializer : INotifyPropertyChanged
    {
        public Major Majors { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Year> scheduleOfClasses { get; set; }

        public ObservableCollection<String> listOfAddedMajors { get; set; }

        public string importString { get; set; }

        public ObservableCollection<Class> listOfClassesTaken { get; set; }
        public ObservableCollection<Class> listOfAllClasses { get; set; }
        public ObservableCollection<Class> listOfPrefferedClasses { get; set; }

        private string _SelectedMajor;

        public string SelectedMajor
        {
            get { return _SelectedMajor; }
            set
            {
                if (_SelectedMajor != value)
                {
                    _SelectedMajor = value;
                    OnPropertyChanged("SelectedMajor");
                    // Insert any methods you want to be activated when the selected major changes here
                }
            }
        }

        public void AddToListOfAddedMajors(String s)
        {
            if (listOfAddedMajors.Count >= 2)
                return;
            bool t = false;
            foreach (string s1 in listOfAddedMajors)
            {
                if (s1.Equals(s))
                {
                    t = true;
                }
            }

            if (t)
                return;

            listOfAddedMajors.Add(s);
        }

        public MajorInitializer()
        {
            Majors = new Major();
            Majors.addMajor("ICS");
            Majors.addMajor("CSE");
            Majors.addMajor("STATS");
            Majors.addMajor("COMPSCI");
            Majors.addMajor("IN4MATX");
            Majors.addMajor("BIM");
            Majors.addMajor("BMC");


            // initialize the list of added majors
            listOfAddedMajors = new ObservableCollection<string>();
            listOfClassesTaken = new ObservableCollection<Class>();
            listOfAllClasses = new ObservableCollection<Class>();
            listOfPrefferedClasses = new ObservableCollection<Class>();

            //create the list of years
            scheduleOfClasses = new ObservableCollection<Year>();

            initiateSchedleOfClasses();

            // initialize the importString
            importString = "";
        }

        private void initiateSchedleOfClasses()
        {
            #region year1

            Year year1 = new Year(1);
            Year year2 = new Year(2);
            Year year3 = new Year(3);
            Year year4 = new Year(4);
            scheduleOfClasses.Add(year1);
            scheduleOfClasses.Add(year2);
            scheduleOfClasses.Add(year3);
            scheduleOfClasses.Add(year4);

            #endregion

            #region Mock Schedule Data
            int mockS = 1;
            foreach (Year y in scheduleOfClasses)
            {
                foreach (Quarter q in y.Quarters)
                {
                    Class c = new Class("class " + mockS, ClassStatus.CanBeTaken);
                    q.addClass(c);
                    listOfAllClasses.Add(c);
                    mockS++;
                    c = new Class("class " + mockS, ClassStatus.CanBeTaken);
                    q.addClass(c);
                    listOfAllClasses.Add(c);
                    mockS++;
                }
            }
            #endregion
        }

        protected void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, 
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Get scheduler stuff improved

        public Year getYear1
        {
            get
            {
                return scheduleOfClasses[0];
            }
        }

        public Year getYear2
        {
            get
            {
                return scheduleOfClasses[1];
            }
        }

        public Year getYear3
        {
            get
            {
                return scheduleOfClasses[2];
            }
        }

        public Year getYear4
        {
            get
            {
                return scheduleOfClasses[3];
            }
        }
        #endregion


        #region UI year and quarter selected

        public int uiYearSelected
        {
            get;
            set;
        }

        public int uiQuarterSelected
        {
            get;set;
        }

        #endregion UI year and quarter selected

        public String toString()
        {
            String toBeReturned = "Hello Nurse";

            foreach (var major in listOfAddedMajors)
            {
                toBeReturned += "&\t" + major + "\n";
            }
            toBeReturned += "\n";
            foreach (var year in scheduleOfClasses)
            {
                toBeReturned += year.toString();
            }
            toBeReturned += "\n*****\n";
            foreach (var prevClass in listOfClassesTaken)
            {
                toBeReturned += prevClass.toString();
            }
            return toBeReturned;
        }
    }
}
