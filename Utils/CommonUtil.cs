using System.Windows;

namespace CourseWork.Utils
{
    public class CommonUtil
    {
        public static void OpenWindow(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.Show();
        }
    }
}
