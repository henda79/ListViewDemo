using System;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using MvvmCross.Forms.Views.Base;
using MvvmCross.ViewModels;
using Syncfusion.XForms.Backdrop;
using Xamarin.Forms;

namespace ListViewDemo.Controls
{
    public class BackdropPage : SfBackdropPage, IMvxPage, IMvxEventSourcePage
    {
        public BackdropPage()
        {
            //OpenIcon = "down.png";
            //CloseIcon = "up.png";
            BackLayerRevealOption = RevealOption.Auto;
        }

        public object DataContext
        {
            get => BindingContext.DataContext;
            set
            {
                if (value != null && !(_bindingContext != null && ReferenceEquals(DataContext, value)))
                    BindingContext = new MvxBindingContext(value);
            }
        }

        private IMvxBindingContext _bindingContext;
        public new IMvxBindingContext BindingContext
        {
            get
            {
                if (_bindingContext == null)
                    BindingContext = new MvxBindingContext(base.BindingContext);
                return _bindingContext;
            }
            set
            {
                _bindingContext = value;
                base.BindingContext = _bindingContext.DataContext;
            }
        }

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(IMvxViewModel), typeof(IMvxElement), default(MvxViewModel), BindingMode.Default, null, ViewModelChanged, null, null);

        internal static void ViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null) return;

            if (bindable is IMvxElement element)
                element.DataContext = newValue;
            else
                bindable.BindingContext = newValue;
        }

        public IMvxViewModel ViewModel
        {
            get => DataContext as IMvxViewModel;
            set
            {
                DataContext = value;
                SetValue(ViewModelProperty, value);
                OnViewModelSet();
            }
        }

        protected virtual void OnViewModelSet()
        {
            ViewModel?.ViewCreated();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AppearingCalled.Raise(this);
            ViewModel?.ViewAppearing();
            ViewModel?.ViewAppeared();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DisappearingCalled.Raise(this);
            ViewModel?.ViewDisappearing();
            ViewModel?.ViewDisappeared();
            ViewModel?.ViewDestroy();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContextChangedCalled.Raise(this);
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            ParentSetCalled.Raise(this);
        }

        public event EventHandler AppearingCalled;
        public event EventHandler DisappearingCalled;
        public event EventHandler BindingContextChangedCalled;
        public event EventHandler ParentSetCalled;
    }
}
