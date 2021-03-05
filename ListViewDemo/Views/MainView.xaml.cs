using System;
using System.Threading.Tasks;
using Syncfusion.DataSource;
using Syncfusion.XForms.Buttons;

namespace ListViewDemo.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            ListView.Loaded += ListView_Loaded;
        }

        private void ListView_Loaded(object sender, Syncfusion.ListView.XForms.ListViewLoadedEventArgs e)
        {
            RefreshSorting();
            RefreshGroups();
        }

        private async void SfPullToRefresh_OnRefreshing(object sender, EventArgs e)
        {
            PullToRefresh.IsRefreshing = true;

            await Task.Delay(2000);
            ListView.DataSource.Refresh();

            PullToRefresh.IsRefreshing = false;
        }

        private void RefreshGroups()
        {
            ListView.DataSource.GroupDescriptors.Clear();
            ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "LastName"
            });
        }

        private void RefreshSorting()
        {
            ListView.DataSource.SortDescriptors.Clear();

            ListView.DataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "FirstName",
                Direction = ItemSortSegmentedControl.SelectedIndex == 0 ? ListSortDirection.Ascending : ListSortDirection.Descending
            });
        }

        private void ItemSortSegmentedControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshSorting();
        }
    }
}
