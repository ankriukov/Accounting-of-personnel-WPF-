using Catalog.Model;
using DataLayerSql;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Catalog.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        private DataLayer data;

        public List<Person> PeopleToSave;
        public ObservableCollection<Person> People { get; set; }

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged();
            }
        }


        public AppViewModel()
        {
            data = new DataLayer(connectionString);

            People = data.GetDataTable("select * from Person").ToObservableCollection();
            PeopleToSave = new List<Person>(People);
            
        }


        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new RelayCommand(obj =>
                    {
                        var tmp = People.Except(PeopleToSave);
                    }));
            }
        }


        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      People.Add(new Person());
                  }));
            }
        }


        private ICommand removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      People.Remove(obj as Person);
                      SelectedPerson = null;
                  }));
            }
        }

                
        private ICommand loadImage;
        public ICommand LoadImage
        {
            get
            {
                return  loadImage ??
                    (loadImage = new RelayCommand(obj =>
                    {
                        OpenFileDialog dlg = new OpenFileDialog();
                        dlg.DefaultExt = ".jpg";
                        dlg.Filter = "Фото |*.*";
                        if (dlg.ShowDialog() == true)
                            try
                            {
                                SelectedPerson.PhotoPath = GetConvertData.ToImage(File.ReadAllBytes(dlg.FileName));
                            }
                            catch (Exception)
                            { }
                        
                    }));
            }
        }

        private ICommand sortBySurname;
        public ICommand SortBySurname
        {
            get
            {
                return sortBySurname ??
                    (sortBySurname = new RelayCommand(obj =>
                    {
                        People = new ObservableCollection<Person>(People.OrderBy(x => x.Surname).ToList());
                        OnPropertyChanged("People");
                    }));
            }
        }


        private ICommand sortByDate;
        public ICommand SortByDate
        {
            get
            {
                return sortByDate ??
                    (sortByDate = new RelayCommand(obj =>
                    {
                        People = new ObservableCollection<Person>(People.OrderBy(x => x.Date).ToList());
                        OnPropertyChanged("People");
                    }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
    
}
