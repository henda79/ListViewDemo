using System.Threading.Tasks;
using ListViewDemo.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace ListViewDemo.Core
{
    public class AppStart : MvxAppStart
    {
        public AppStart(IMvxApplication app, IMvxNavigationService navigationService)
            : base(app, navigationService)
        {
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<MainViewModel>();
        }
    }
}
