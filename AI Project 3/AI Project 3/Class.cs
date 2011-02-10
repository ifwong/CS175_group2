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

namespace AI_Project_3
{
    public enum ClassStatus{ Completed, CanBeTaken, CannotBeTaken }; 

    public class Class
    {
        private ClassStatus status;
        private String name;

        public String displayString
        {
            get
            {
                return name;
            }
        }

        public Class(string name, ClassStatus status)
        {
            this.name = name;
            this.status = status;
        }

        public String Name
        {
            get
            { return name; }
            set
            { name = value; }
        }

        public ClassStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public Color getStatusColor
        {
            get
            {
                if (Status == ClassStatus.CanBeTaken)
                    return Color.FromArgb(0, 0, 255, 255);
                else if (status == ClassStatus.CannotBeTaken)
                    return Color.FromArgb(0, 255, 0, 0);
                else
                    return Color.FromArgb(0, 50, 205, 50);
            }
        }

        public override bool Equals(object obj)
        {
            if (name.Equals(((Class)obj).name))
            {
                return true;
            }
            else return false;
        }

    }
}
