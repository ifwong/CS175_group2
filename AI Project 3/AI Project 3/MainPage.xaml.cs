using System;
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
using System.IO;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Collections.ObjectModel;

namespace AI_Project_3
{
    public partial class MainPage : UserControl
    {
        public MajorInitializer majorinit { get; set; }
        public Year years { get; set; }
        string SAVEFILENAME = "no-name";
        private System.Windows.Controls.ListBox _SelectedQuarter;
        private ObservableCollection<Class> _CollectionOfClassesForSelectedQuarter;

        public MainPage()
        {
            InitializeComponent();
            majorinit = new MajorInitializer();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
            saveName.Text = "no-name";
            loadName.Text = "no-name";
        }

        //This runs when the page is loaded
        void Page_Loaded(object sender, RoutedEventArgs e)
        {

            #region Initializing Selected Quarter to Year 1 Fall
            makeRemoveButtonsInvisible();
            _SelectedQuarter = this.Year1Fall;
            _CollectionOfClassesForSelectedQuarter = majorinit.getYear1.getFall.getClasses;
            this.Year1FallRemove.Visibility = Visibility.Visible;
            #endregion

            #region Settings for the add  buttons in navigation pane
            this.AddtoSchedule.Content = "Add";
            this.AddtoSchedule.MinHeight = 13;
            this.AddtoSchedule.MaxWidth = 50;
            this.AddtoClassesTaken.Content = "Add as 'Taken'";
            this.AddtoClassesTaken.MinHeight = 13;
            this.AddtoClassesTaken.MaxWidth = 125;
            #endregion

            #region Settings for all 'Remove' buttons
            String r = "Remove";
            int h = 13;
            int w = 50;

            this.RemovefromTaken.Content = r;
            this.RemovefromTaken.MinHeight = h;
            this.RemovefromTaken.MaxWidth = w;

            this.Year1FallRemove.Content = r;
            this.Year1FallRemove.MinHeight = h;
            this.Year1FallRemove.MaxWidth = w;

            this.Year1WinterRemove.Content = r;
            this.Year1WinterRemove.MinHeight = h;
            this.Year1WinterRemove.MaxWidth = w;
            
            this.Year1SpringRemove.Content = r;
            this.Year1SpringRemove.MinHeight = h;
            this.Year1SpringRemove.MaxWidth = w;
            
            this.Year1SummerRemove.Content = r;
            this.Year1SummerRemove.MinHeight = h;
            this.Year1SummerRemove.MaxWidth = w;

            this.Year2FallRemove.Content = r;
            this.Year2FallRemove.MinHeight = h;
            this.Year2FallRemove.MaxWidth = w;

            this.Year2WinterRemove.Content = r;
            this.Year2WinterRemove.MinHeight = h;
            this.Year2WinterRemove.MaxWidth = w;

            this.Year2SpringRemove.Content = r;
            this.Year2SpringRemove.MinHeight = h;
            this.Year2SpringRemove.MaxWidth = w;

            this.Year2SummerRemove.Content = r;
            this.Year2SummerRemove.MinHeight = h;
            this.Year2SummerRemove.MaxWidth = w;

            this.Year3FallRemove.Content = r;
            this.Year3FallRemove.MinHeight = h;
            this.Year3FallRemove.MaxWidth = w;

            this.Year3WinterRemove.Content = r;
            this.Year3WinterRemove.MinHeight = h;
            this.Year3WinterRemove.MaxWidth = w;

            this.Year3SpringRemove.Content = r;
            this.Year3SpringRemove.MinHeight = h;
            this.Year3SpringRemove.MaxWidth = w;

            this.Year3SummerRemove.Content = r;
            this.Year3SummerRemove.MinHeight = h;
            this.Year3SummerRemove.MaxWidth = w;

            this.Year4FallRemove.Content = r;
            this.Year4FallRemove.MinHeight = h;
            this.Year4FallRemove.MaxWidth = w;

            this.Year4WinterRemove.Content = r;
            this.Year4WinterRemove.MinHeight = h;
            this.Year4WinterRemove.MaxWidth = w;

            this.Year4SpringRemove.Content = r;
            this.Year4SpringRemove.MinHeight = h;
            this.Year4SpringRemove.MaxWidth = w;

            this.Year4SummerRemove.Content = r;
            this.Year4SummerRemove.MinHeight = h;
            this.Year4SummerRemove.MaxWidth = w;
            #endregion
        }

//METHODS RELATED TO SCHEDULER

        private void Autofill_Click(object sender, RoutedEventArgs e)
        {
            //Do all necessary work
        }
        
        private void AddtoSchedule_Click(object sender, RoutedEventArgs e)
        {
            int selectedItem = this.AllClasses.SelectedIndex;

            if (selectedItem >= 0)
            {
                Class c = majorinit.listOfAllClasses.ElementAt(selectedItem);

                //Checks if the class is currently in the schedule, if found, remove it
                foreach (Year y in majorinit.scheduleOfClasses)
                {
                    foreach (Quarter q in y.Quarters)
                    {
                        if (q.getClasses.Contains(c))
                            q.getClasses.Remove(c);
                    }
                }

                //Adds class to the selected quarter and updates
                _CollectionOfClassesForSelectedQuarter.Add(c);
                _SelectedQuarter.ItemsSource = _CollectionOfClassesForSelectedQuarter;
            }
        }

        private void RemoveFromSchedule_Click(object sender, RoutedEventArgs e)
        {
            int selectedItem = _SelectedQuarter.SelectedIndex;

            if (selectedItem >= 0)
            {
                _CollectionOfClassesForSelectedQuarter.RemoveAt(selectedItem);
                _SelectedQuarter.ItemsSource = _CollectionOfClassesForSelectedQuarter;
            }
        }

        private void AddtoClassesTaken_Click(object sender, RoutedEventArgs e)
        {
            int selectedItem = this.AllClasses.SelectedIndex;
            if (selectedItem >= 0)
            {
                Class c = majorinit.listOfAllClasses.ElementAt(selectedItem);
                if (!majorinit.listOfClassesTaken.Contains(c))
                {
                    //The 'if' above checks for duplicates, below, we add it to the list, and change the class status to 'completed', then update
                    c.Status = ClassStatus.Completed;
                    majorinit.listOfClassesTaken.Add(c);
                    this.TakenClasses.ItemsSource = majorinit.listOfClassesTaken;
                }
            }
        }

        private void RemovefromTaken_Click(object sender, RoutedEventArgs e)
        {
            int selectedItem = this.TakenClasses.SelectedIndex;

            if (selectedItem >= 0)
            {
                Class c = majorinit.listOfClassesTaken.ElementAt(selectedItem);
                majorinit.listOfClassesTaken.Remove(c);
                this.TakenClasses.ItemsSource = majorinit.listOfClassesTaken;
            }
        }

//FUNCTION TO SELECT QUARTER

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            #region Change all backgrounds to white
            String name = ((System.Windows.Controls.Grid)sender).Name;
            SolidColorBrush white = new SolidColorBrush(Colors.White);
            SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);

            this.GridYear1Fall.Background = white;
            this.GridYear1Winter.Background = white;
            this.GridYear1Spring.Background = white;
            this.GridYear1Summer.Background = white;

            this.GridYear2Fall.Background = white;
            this.GridYear2Winter.Background = white;
            this.GridYear2Spring.Background = white;
            this.GridYear2Summer.Background = white;

            this.GridYear3Fall.Background = white;
            this.GridYear3Winter.Background = white;
            this.GridYear3Spring.Background = white;
            this.GridYear3Summer.Background = white;

            this.GridYear4Fall.Background = white;
            this.GridYear4Winter.Background = white;
            this.GridYear4Spring.Background = white;
            this.GridYear4Summer.Background = white;
            #endregion Change all backgrounds to white

            makeRemoveButtonsInvisible();
            
            if (name == "GridYear1Fall")
            {
                GridYear1Fall.Background = yellow;
                _SelectedQuarter = this.Year1Fall;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear1.getFall.getClasses;
                this.Year1FallRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear1Winter")
            {
                GridYear1Winter.Background = yellow;
                _SelectedQuarter = this.Year1Winter;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear1.getWinter.getClasses;
                this.Year1WinterRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear1Spring")
            {
                GridYear1Spring.Background = yellow;
                _SelectedQuarter = this.Year1Spring;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear1.getSpring.getClasses;
                this.Year1SpringRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear1Summer")
            {
                GridYear1Summer.Background = yellow;
                _SelectedQuarter = this.Year1Summer;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear1.getSummer.getClasses;
                this.Year1SummerRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear2Fall")
            {
                GridYear2Fall.Background = yellow;
                _SelectedQuarter = this.Year2Fall;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear2.getFall.getClasses;
                this.Year2FallRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear2Winter")
            {
                GridYear2Winter.Background = yellow;
                _SelectedQuarter = this.Year2Winter;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear2.getWinter.getClasses;
                this.Year2WinterRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear2Spring")
            {
                GridYear2Spring.Background = yellow;
                _SelectedQuarter = this.Year2Spring;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear2.getSpring.getClasses;
                this.Year2SpringRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear2Summer")
            {
                GridYear2Summer.Background = yellow;
                _SelectedQuarter = this.Year2Summer;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear2.getSummer.getClasses;
                this.Year2SummerRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear3Fall")
            {
                GridYear3Fall.Background = yellow;
                _SelectedQuarter = this.Year3Fall;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear3.getFall.getClasses;
                this.Year3FallRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear3Winter")
            {
                GridYear3Winter.Background = yellow;
                _SelectedQuarter = this.Year3Winter;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear3.getWinter.getClasses;
                this.Year3WinterRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear3Spring")
            {
                GridYear3Spring.Background = yellow;
                _SelectedQuarter = this.Year3Spring;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear3.getSpring.getClasses;
                this.Year3SpringRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear3Summer")
            {
                GridYear3Summer.Background = yellow;
                _SelectedQuarter = this.Year3Summer;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear3.getSummer.getClasses;
                this.Year3SummerRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear4Fall")
            {
                GridYear4Fall.Background = yellow;
                _SelectedQuarter = this.Year3Fall;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear4.getFall.getClasses;
                this.Year4FallRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear4Winter")
            {
                GridYear4Winter.Background = yellow;
                _SelectedQuarter = this.Year4Winter;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear4.getWinter.getClasses;
                this.Year4WinterRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear4Spring")
            {
                GridYear4Spring.Background = yellow;
                _SelectedQuarter = this.Year4Spring;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear4.getSpring.getClasses;
                this.Year4SpringRemove.Visibility = Visibility.Visible;
            }
            else if (name == "GridYear4Summer")
            {
                GridYear4Summer.Background = yellow;
                _SelectedQuarter = this.Year4Summer;
                _CollectionOfClassesForSelectedQuarter = majorinit.getYear4.getSummer.getClasses;
                this.Year4SummerRemove.Visibility = Visibility.Visible;
            }
        }

        private void makeRemoveButtonsInvisible()
        {
            this.Year1FallRemove.Visibility = Visibility.Collapsed;
            this.Year1WinterRemove.Visibility = Visibility.Collapsed;
            this.Year1SpringRemove.Visibility = Visibility.Collapsed;
            this.Year1SummerRemove.Visibility = Visibility.Collapsed;
            this.Year2FallRemove.Visibility = Visibility.Collapsed;
            this.Year2WinterRemove.Visibility = Visibility.Collapsed;
            this.Year2SpringRemove.Visibility = Visibility.Collapsed;
            this.Year2SummerRemove.Visibility = Visibility.Collapsed;
            this.Year3FallRemove.Visibility = Visibility.Collapsed;
            this.Year3WinterRemove.Visibility = Visibility.Collapsed;
            this.Year3SpringRemove.Visibility = Visibility.Collapsed;
            this.Year3SummerRemove.Visibility = Visibility.Collapsed;
            this.Year4FallRemove.Visibility = Visibility.Collapsed;
            this.Year4WinterRemove.Visibility = Visibility.Collapsed;
            this.Year4SpringRemove.Visibility = Visibility.Collapsed;
            this.Year4SummerRemove.Visibility = Visibility.Collapsed;
        }

//METHODS FOR THE SETTINGS PAGE

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            majorinit.AddToListOfAddedMajors((majorinit.Majors.Majors[this.MajorList.SelectedIndex]));

            String a = "";
            foreach (string s in majorinit.listOfAddedMajors)
            {
                a = s + " " + a;
            }

            if (majorinit.listOfAddedMajors.Count > 0)
            {
                this.MajorButton1.Content = "[X]  " + majorinit.listOfAddedMajors[0];
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

        private void save_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (saveName.Text != null)
                {
                    SAVEFILENAME = saveName.Text;
                }

                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(SAVEFILENAME, FileMode.Create, iso);

                StreamWriter writer = new StreamWriter(isoStream);
                string data = majorinit.toString();
                writer.Write(data);
                writer.Close();

            }
            catch (Exception bException)
            {
                saveLabel.Text = bException.Message;
            }


            //Process.Start(@"C:\trial.txt");
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            //TODO write parser for load
            try
            {
                if (loadName.Text != null)
                {
                    SAVEFILENAME = loadName.Text;
                }
                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(SAVEFILENAME, FileMode.Open, iso))
                {
                    using (StreamReader reader = new StreamReader(isoStream))
                    {
                        //do something with it
                        loadLabel.Text = reader.ReadLine();
                    }
                }
            }
            catch (Exception bException)
            {
                loadLabel.Text = bException.Message;
            }
        }
    }
}
