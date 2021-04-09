using System;
using ListViewDemo.Core.ViewModels;
using Syncfusion.DataSource;
using Xamarin.CommunityToolkit.UI.Views;
using SelectionChangedEventArgs = Syncfusion.XForms.Buttons.SelectionChangedEventArgs;

namespace ListViewDemo.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            ListView.BindingContextChanged += (sender, e) =>
            {
                if (ListView.DataSource.GroupDescriptors.Count == 0)
                {
                    RefreshSorting();
                    RefreshGroups();
                }
            };

            ListView.DataSource.AutoExpandGroups = false;
            StateLayout.SetCurrentState(LayoutView, LayoutState.Success);
        }

        private void SfPullToRefresh_OnRefreshing(object sender, EventArgs e)
        {
            if (PullToRefresh.IsRefreshing) return;

            PullToRefresh.IsRefreshing = true;

            //await Task.Delay(2000);
            ((MainViewModel) DataContext).RefreshCollection();

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
