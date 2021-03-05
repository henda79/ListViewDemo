using System;
using Xamarin.Forms;

namespace ListViewDemo.Controls
{
    public partial class MenuButton
    {
        public static readonly BindableProperty PopupTemplateProperty = BindableProperty.Create(nameof(PopupTemplate), typeof(DataTemplate), typeof(MenuButton));

        public DataTemplate PopupTemplate
        {
            get => (DataTemplate) GetValue(PopupTemplateProperty);
            set => SetValue(PopupTemplateProperty, value);
        }

        public MenuButton()
        {
            InitializeComponent();
        }

        private void SfButton_OnClicked(object sender, EventArgs e)
        {
            MenuPopup.ShowAtTouchPoint();
        }
    }
}