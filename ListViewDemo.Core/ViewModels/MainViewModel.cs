using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using Syncfusion.DataSource;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.UI.Views;
using Contact = ListViewDemo.Core.Models.Contact;

namespace ListViewDemo.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private LayoutState _currentLayout;
        public LayoutState CurrentState
        {
            get => _currentLayout;
            set => SetProperty(ref _currentLayout, value);
        }

        private IEnumerable<Contact> GetContacts()
        {
            yield return new Contact("Alan", "Smith");
            yield return new Contact("Cynthia", "Johnson");
            yield return new Contact("Dwayne", "Dibley");
            yield return new Contact("John", "Smith");
        }

        public DataSource ContactDataSource { get; set; }

        public Command ChangeStateCommand => new Command<LayoutState>(x =>
        {
            CurrentState = x;
        });

        public MainViewModel()
        {
            ContactDataSource = new DataSource();
        }

        public override async Task Initialize()
        {
            ContactDataSource.Source = GetContacts();
            ContactDataSource.SourceType = typeof(Contact);

            CurrentState = LayoutState.Success;

            await base.Initialize();
        }
    }
}
