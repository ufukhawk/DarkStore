
using System;
using System.Collections.Generic;
using DarkStore.View;
using DarkStore.ViewModel;
using Xamarin.Forms;

namespace DarkStore.Model
{
    public class CategoryModel : BaseVM
    {
        public string Name { get; set; }
        private bool select;
        public bool Select
        {
            get { return select; }
            set { SetProperty(ref select, value); }
        }

    }
}
