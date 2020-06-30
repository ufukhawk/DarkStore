using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkStore.Model;
using DarkStore.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarkStore.View
{
    [DesignTimeVisible(false)]
    public partial class MainPage 
    {
        MainPageVM MainPageVM;
        public MainPage()
        {
            MainPageVM = new MainPageVM(Navigation);
            InitializeComponent();
            BindingContext = MainPageVM;
        }
    }
}
