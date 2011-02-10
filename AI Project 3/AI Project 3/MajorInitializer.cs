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

        public string _SelectedMajor;

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
            scheduleOfClasses.Add(year1);
            #region quarter1

            Quarter quarter1 = year1.getQuarter(0);
            quarter1.addClass(new Class("ICS 21", ClassStatus.Completed));
            quarter1.addClass(new Class("ICS 22", ClassStatus.Completed));

            #endregion

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


        #region GetSchedulerStuffs

        public ObservableCollection<Class> getYear1Fall
        {
            get
            {
                return scheduleOfClasses[0].getQuarter(0).getClasses;
            }

            set
            {
            }
        }

        #endregion

    }
}
