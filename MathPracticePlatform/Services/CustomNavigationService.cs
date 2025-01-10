using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MathPracticePlatform.Services
{
    public class CustomNavigationService
    {
        // Singleton instance property
        private static CustomNavigationService _instance;

        // Singleton instance
        public static CustomNavigationService Instance => _instance ??= new CustomNavigationService();

        private Frame _navigationFrame;

        public void Initialize(Frame navigationFrame)
        {
            _navigationFrame = navigationFrame ?? throw new ArgumentNullException(nameof(navigationFrame));
        }

        public void Navigate(Page page)
        {
            if (_navigationFrame == null)
                throw new InvalidOperationException("Navigation frame is not initialized.");

            _navigationFrame.Navigate(page);
        }

        public void GoBack()
        {
            if (_navigationFrame?.CanGoBack == true)
            {
                _navigationFrame.GoBack();
            }
        }
    }
}
