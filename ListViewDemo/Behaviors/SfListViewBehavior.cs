using Syncfusion.ListView.XForms;

namespace ListViewDemo.Behaviors
{
    public class SfListViewBehavior : BehaviorBase<SfListView>
    {
        private object _bindingContext;

        protected override void OnAttachedTo(SfListView bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject.Loaded += Loaded;
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            bindable.Loaded -= Loaded;
            base.OnDetachingFrom(bindable);
        }

        private void Loaded(object sender, ListViewLoadedEventArgs e)
        {
            if (!(sender is SfListView listView)) return;

            _bindingContext = listView.BindingContext;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null) return;

            //This will set the ViewModel as Binding Context and then this method will be recalled.
            //DataSource Source and SourceType will be automatically set on second call.
            AssociatedObject.BindingContext ??= _bindingContext;
        }
    }
}
