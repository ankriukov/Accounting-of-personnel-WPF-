using Catalog.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Catalog.Model
{
    public static class AppConfiguration
    {
        //public static bool IsSaved { get; set; } = true;

        //public static BitmapImage StateSavedImage
        //{
        //    get
        //    {
        //        if (IsSaved == false)
        //            return MyResource.not.ToBitmapImage();

        //        return MyResource.yes.ToBitmapImage();
        //    }
        //}
        //public static string StateSavedString
        //{
        //    get
        //    {
        //        if (IsSaved == false)
        //            return "Не сохранено";

        //        return "Сохранено";
        //    }
        //}


        public static Point GetStartUpPosition(double height, double width)
        {
            double workHeight = SystemParameters.WorkArea.Height;
            double workWidth = SystemParameters.WorkArea.Width;
            double Top = (workHeight - height) / 2;
            double Left = (workWidth - width) / 2;
           
            return new Point(Left, Top);
        }


    }
}
