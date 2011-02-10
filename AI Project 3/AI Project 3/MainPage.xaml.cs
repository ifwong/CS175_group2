﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;


using System.Collections.ObjectModel;

namespace AI_Project_3
{
    public partial class MainPage : UserControl
    {
        //public Major major { get; set; }
        public MajorInitializer majorinit { get; set; }
        public Year years { get; set; }
        public MainPage()
        {
            InitializeComponent();
            majorinit = new MajorInitializer();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            #region adding 'remove' to remove buttons
            String r = "Remove";
            this.Year1FallRemove.Content = r;
            this.Year1WinterRemove.Content = r;
            this.Year1SpringRemove.Content = r;
            this.Year1SummerRemove.Content = r;

            this.Year2FallRemove.Content = r;
            this.Year2WinterRemove.Content = r;
            this.Year2SpringRemove.Content = r;
            this.Year2SummerRemove.Content = r;
            #endregion

            #region setting remove button min & max width
            int h = 25;
            int w = 75;

            this.Year1FallRemove.MinHeight = h;
            this.Year1WinterRemove.MinHeight = h;
            this.Year1SpringRemove.MinHeight = h;
            this.Year1SummerRemove.MinHeight = h;
            this.Year1FallRemove.MinWidth = w;
            this.Year1WinterRemove.MinWidth = w;
            this.Year1SpringRemove.MinWidth = w;
            this.Year1WinterRemove.MinWidth = w;

            this.Year2FallRemove.MinHeight = h;
            this.Year2WinterRemove.MinHeight = h;
            this.Year2SpringRemove.MinHeight = h;
            this.Year2SummerRemove.MinHeight = h;
            this.Year2FallRemove.MinWidth = w;
            this.Year2SummerRemove.MinWidth = w;
            this.Year2WinterRemove.MinWidth = w;
            this.Year2SummerRemove.MinWidth = w;

            


            #endregion



        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            majorinit.AddToListOfAddedMajors((majorinit.Majors.Majors[this.MajorList.SelectedIndex]));

            String a ="";
            foreach(string s in majorinit.listOfAddedMajors)
            {
                a=s+ " " + a;
            }

            if (majorinit.listOfAddedMajors.Count > 0)
            {
                this.MajorButton1.Content = "[X]  " + majorinit.listOfAddedMajors[0] ;
                this.MajorButton1.Visibility = Visibility.Visible;

                if (majorinit.listOfAddedMajors.Count > 1)
                {
                    this.MajorButton2.Content = "[X]  " + majorinit.listOfAddedMajors[1];
                    this.MajorButton2.Visibility = Visibility.Visible;
                }
            }
        }

        // if this button clicked, then remove the first major
        private void MajorButton1_Click(object sender, RoutedEventArgs e)
        {
            majorinit.listOfAddedMajors.RemoveAt(0);
            if (majorinit.listOfAddedMajors.Count > 0)
            {
                this.MajorButton1.Content = "[X]  " + majorinit.listOfAddedMajors[0];
                this.MajorButton1.Visibility = Visibility.Visible;
            }
            else
                this.MajorButton1.Visibility = Visibility.Collapsed;

            this.MajorButton2.Visibility = Visibility.Collapsed;
        }

        // delete the second major
        private void MajorButton2_Click(object sender, RoutedEventArgs e)
        {
            majorinit.listOfAddedMajors.RemoveAt(1);

            this.MajorButton2.Visibility = Visibility.Collapsed;
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            majorinit.importString = this.ImportTextBox.Text;

            this.ImportTextBox.Text = "";
        }

    }
}