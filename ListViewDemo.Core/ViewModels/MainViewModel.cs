using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using Contact = ListViewDemo.Core.Models.Contact;

namespace ListViewDemo.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MvxObservableCollection<Contact> ContactCollection { get; }

        private IEnumerable<Contact> GetContacts()
        {
            yield return new Contact("Alan", "Smith");
            yield return new Contact("Cynthia", "Johnson");
            yield return new Contact("Dwayne", "Dibley");
            yield return new Contact("John", "Smith");
        }

        public MainViewModel()
        {
            ContactCollection = new MvxObservableCollection<Contact>();
        }

        public override async Task Initialize()
        { 
            RefreshCollection();
            await base.Initialize();
        }

        public void RefreshCollection()
        {
            ContactCollection.Clear();
            ContactCollection.AddRange(GetContacts());
        }
    }
}
