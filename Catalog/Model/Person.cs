using Catalog.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Catalog.Model
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private string surname;
        private DateTime date;
        private string placeBorn;
        private BitmapImage photoPath;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }

        public string PlaceBorn
        {
            get { return placeBorn; }
            set
            {
                placeBorn = value;
                OnPropertyChanged();
            }
        }

        public BitmapImage PhotoPath
        {
            get { return photoPath; }
            set
            {
                photoPath = value;
                OnPropertyChanged();
            }
        }

        

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Person()
        {
            this.Name = "Имя";
            this.Surname = "Фамилия";
            this.Date = new DateTime(1970, 1, 1);
            this.PlaceBorn = "Место рождения";
            this.PhotoPath = MyResource.Unknown_Person.ToBitmapImage();  
        }
    }
}
