using Catalog.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Catalog.Model
{
    static class GetConvertData
    {
        public static ObservableCollection<Person> ToObservableCollection(this DataTable dt)
        {
            var Return = new ObservableCollection<Person>();

            foreach (DataRow row in dt.Rows)
            {
                BitmapImage temp = null;

                try
                {
                    temp = ToImage((byte[])row["Photo"]);
                }
                catch (Exception)
                {
                    temp = MyResource.Unknown_Person.ToBitmapImage();
                }
                finally
                {
                    Person man = new Person
                    {
                        Name = (string)row["Name"],
                        Surname = (string)row["Surname"],
                        Date = (DateTime)row["Date"],
                        PlaceBorn = (string)row["PlaceOfBirth"],
                        PhotoPath = temp
                    };

                    Return.Add(man);
                }
            }

            return Return;
        }

        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        public static BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; 
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}