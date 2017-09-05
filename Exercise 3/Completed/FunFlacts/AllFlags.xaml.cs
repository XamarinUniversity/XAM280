using FlagData;
using System;
using Xamarin.Forms;

namespace FunFlacts
{
    public partial class AllFlags : ContentPage
    {
        bool isEditing;
        ToolbarItem cancelEditButton;

        public AllFlags()
        {
            BindingContext = DependencyService.Get<FunFlactsViewModel>();
            InitializeComponent();

            cancelEditButton = (ToolbarItem)Resources[nameof(cancelEditButton)];
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!isEditing)
            {
                await this.Navigation.PushAsync(new FlagDetailsPage());
            }
            else
            {
                var flag = (Flag)e.Item;
                if (flag != null && await this.DisplayAlert("Confirm",
                        $"Are you sure you want to delete {flag.Country}?", "Yes", "No"))
                {
                    DependencyService.Get<FunFlactsViewModel>()
                        .Flags.Remove(flag);
                }
                // Reset the edit button
                OnEdit(cancelEditButton, EventArgs.Empty);
            }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            var tbItem = sender as ToolbarItem;
            isEditing = (tbItem == editButton);

            ToolbarItems.Remove(tbItem);
            ToolbarItems.Add(isEditing ? cancelEditButton : editButton);
        }
    }
}