using System;
using System.Collections.Generic;
using DarkStore.Model;
using Xamarin.Forms;

namespace DarkStore.View
{
    public partial class DetailPage 
    {
        public DetailPage(ItemModel itemModel)
        {
            InitializeComponent();
            BindingContext = itemModel;
        }

        void Back(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
