using FlagData;
using System;
using System.Threading.Tasks;
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
                await DeleteFlag((Flag)e.Item);

                // Reset the edit button
                OnEdit(cancelEditButton, EventArgs.Empty);
            }
        }

        private async Task DeleteFlag(Flag flag)
        {
            if (flag != null && await this.DisplayAlert("Confirm",
                    $"Are you sure you want to delete {flag.Country}?", "Yes", "No"))
            {
                DependencyService.Get<FunFlactsViewModel>()
                    .Flags.Remove(flag);
            }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            var tbItem = sender as ToolbarItem;
            isEditing = (tbItem == editButton);

            ToolbarItems.Remove(tbItem);
            ToolbarItems.Add(isEditing ? cancelEditButton : editButton);
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var flag = item.BindingContext as Flag;
            if (flag != null)
            {
                await DeleteFlag(flag);
            }
        }

        private async void OnRefreshing(object sender, EventArgs e)
        {
            try
            {
                var collection = DependencyService.Get<FunFlactsViewModel>().Flags;
                int i = collection.Count - 1, j = 0;
                while (i > j)
                {
                    var temp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = temp;
                    i--; j++;
                    await System.Threading.Tasks.Task.Delay(200); // make it take some time.
                }
            }
            finally
            {
                // Turn off the refresh.
                ((ListView)sender).IsRefreshing = false;
            }
        }
    }
}