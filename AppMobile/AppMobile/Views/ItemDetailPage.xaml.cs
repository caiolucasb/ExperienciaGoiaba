using AppMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}