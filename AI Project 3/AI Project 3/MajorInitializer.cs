﻿using System;
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

            for (int i = 0; i < 15; i++)
            {
                string s = "a";
                for (int j = 0; j < i; j++)
                    s += "a";
                listOfClassesTaken.Add(new Class("dat" + s, ClassStatus.Completed));
            }

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
       // public ObservableCollection<Class> getYear1Fall
       // {
       //     get
       //     {
       //         return scheduleOfClasses[0].getQuarter(0).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear2Fall
       // {
       //     get
       //     {
       //         return scheduleOfClasses[1].getQuarter(0).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear3Fall
       // {
       //     get
       //     {
       //         return scheduleOfClasses[2].getQuarter(0).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear4Fall
       // {
       //     get
       //     {
       //         return scheduleOfClasses[3].getQuarter(0).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear1Winter
       // {
       //     get
       //     {
       //         return scheduleOfClasses[0].getQuarter(1).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear2Winter
       // {
       //     get
       //     {
       //         return scheduleOfClasses[1].getQuarter(1).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear3Winter
       // {
       //     get
       //     {
       //         return scheduleOfClasses[2].getQuarter(1).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear4Winter
       // {
       //     get
       //     {
       //         return scheduleOfClasses[3].getQuarter(1).getClasses;
       //     }
       // }
       // public ObservableCollection<Class> getYear1Spring
       // {
       //     get
       //     {
       //         return scheduleOfClasses[0].getQuarter(2).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear2Spring
       // {
       //     get
       //     {
       //         return scheduleOfClasses[1].getQuarter(2).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear3Spring
       // {
       //     get
       //     {
       //         return scheduleOfClasses[2].getQuarter(2).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear4Spring
       // {
       //     get
       //     {
       //         return scheduleOfClasses[3].getQuarter(2).getClasses;
       //     }
       // }
       // public ObservableCollection<Class> getYear1Summer
       // {
       //     get
       //     {
       //         return scheduleOfClasses[0].getQuarter(3).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear2Summer
       // {
       //     get
       //     {
       //         return scheduleOfClasses[1].getQuarter(3).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear3Summer
       // {
       //     get
       //     {
       //         return scheduleOfClasses[2].getQuarter(3).getClasses;
       //     }
       // }

       // public ObservableCollection<Class> getYear4Summer
       // {
       //     get
       //     {
       //         return scheduleOfClasses[3].getQuarter(3).getClasses;
       //     }
       // }
       #endregion

        #region classes taken
        /// <summary>
        /// Removes the class at specified index from the list of classes taken
        /// </summary>
        /// <param name="index">int index</param>
        public void removeClassesTakenAt(int index)
        {
            listOfClassesTaken.RemoveAt(index);
        }
        #endregion

#region Get scheduler stuff improved

        /// <summary>
        /// Gets the first year
        /// </summary>
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
    }
}
