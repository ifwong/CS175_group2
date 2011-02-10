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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;


namespace AI_Project_3
{
    public enum QuarterType { Fall, Winter, Spring, Summer }; //I wrote this enum with three different kinds of summer

    public class Quarter : INotifyPropertyChanged
    {
        private int yearNum;
        private QuarterType quarterType;
        
        ObservableCollection<Class> classes;

        /// <summary>
        /// Quarters house a yearNum, quarterType, and as well as a list of classes
        /// </summary>
        /// <param name="yN"></param>
        /// <param name="qT"></param>
        /// 
        public Quarter(int yN, QuarterType qT)
        {
            classes = new ObservableCollection<Class>();
            yearNum = yN;
            quarterType = qT;
        }

        public void addClass(Class c)
        {
            classes.Add(c);
        }

        public void removeCLass(Class c)
        {
            foreach (Class s in classes)
            {
                if (s.Equals(c))
                {
                    classes.Remove(s);
                }
            }
        }

        public void removeClass(String displayString)
        {
            foreach (Class s in classes)
            {
                if (s.displayString == displayString)
                {
                    classes.Remove(s);
                }
            }
        }

        public void removeClass(int index)
        {
            classes.RemoveAt(index);
        }
        public int size()
        {
            return classes.Count;
        }


        public Class getClass(int i)
        {
            return classes[i];
        }

        public ObservableCollection<Class> getClasses
        {
            get
            {
                return classes;
            }
        }

        #region -= get & set methods =-

        public int YearNum
        {
            get
            {
                return yearNum;
            }
        }

        public QuarterType QuarterType
        {
            get
            {
                return quarterType;
            }
        }

        #endregion 

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
              // trigger a recalc?
            }
        }

    }
}
