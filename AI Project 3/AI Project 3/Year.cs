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
    public class Year : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Quarter> quarters;
        private int yearNum;

        public Year(int year)
        {
            yearNum = year;
            quarters = new ObservableCollection<Quarter>();
            BuildQuarters();
        }

        private void BuildQuarters()
        {
            quarters.Add(new Quarter(yearNum, QuarterType.Fall));
            quarters.Add(new Quarter(yearNum, QuarterType.Spring));
            quarters.Add(new Quarter(yearNum, QuarterType.Summer));
            quarters.Add(new Quarter(yearNum, QuarterType.Winter));


        }

        public ObservableCollection<Quarter> Quarters
        {
            get
            {
                return quarters;
            }
        }

        public Quarter getQuarter(int i)
        {
            return quarters[i];
        }

        #region gets for all 4 quarters

        /// <summary>
        /// Returns fall quarter
        /// </summary>
        public Quarter getFall
        {
            get
            {
                return quarters[0];
            }
        }

        /// <summary>
        /// Gets winter quarter
        /// </summary>
        public Quarter getWinter
        {
            get
            {
                return quarters[1];
            }
        }

        /// <summary>
        /// Gets spring quarter
        /// </summary>
        public Quarter getSpring
        {
            get
            {
                return quarters[2];
            }
        }

        /// <summary>
        /// Gets Summer Quarter
        /// </summary>
        public Quarter getSummer
        {
            get
            {
                return quarters[3];
            }
        }

        #endregion


        // return null if no quarter of this type exists
        public Quarter getQuarter(QuarterType qT)
        {
            foreach (Quarter q in quarters)
            {
                if (q.QuarterType.Equals(qT))
                    return q;
            }
            return null;
        }

        #region get & set methods

        public int YearNum
        {
            get
            {
                return yearNum;
            }
        }

        #endregion

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public String toString()
        {
            String toReturn = "$" + yearNum + "\n";

            foreach (var quarter in quarters)
            {
                toReturn += quarter.toString();
                toReturn += "\n";
            }

            return toReturn;
        }

    }

}
