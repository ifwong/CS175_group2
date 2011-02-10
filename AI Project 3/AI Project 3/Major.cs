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
    public class Major
    {
        private ObservableCollection<String> majors;
        private ObservableCollection<String> minors;

        public Major()
        {
            majors = new ObservableCollection<string>();
            minors = new ObservableCollection<string>();
        }

        public ObservableCollection<String> Majors
        {
            get
            {
                return majors;
            }
        }

        public String GetMajor(int i)
        {
            return majors[i];
        }

        public void addMajor(String s)
        {
            majors.Add(s);
            //majors[majors.Count] = s;
        }

        public ObservableCollection<String> Minors
        {
            get
            {
                return minors;
            }
        }

        public String getMinor(int i)
        {
            return minors[i];
        }
    }
}
