
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DarkStore.Model;
using DarkStore.View;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DarkStore.ViewModel
{
    public class MainPageVM : BaseVM
    {
        public MainPageVM(INavigation navigation)
        {

            Navigation = navigation;
            GetCategores();
            GetItems();
            GetToyItems();
            SelectGroupCommand = new Command<CategoryModel>((model) => ExecuteSelectGroupCommand(model));
            NavigateToDetailPageCommand = new Command<ItemModel>(async (model) => await ExecuteNavigateToDetailPageCommand(model));

        }

        public Command NavigateToDetailPageCommand { get; }
        public Command SelectGroupCommand { get; }
        private ObservableCollection<ItemModel> itemModelList;
        public ObservableCollection<ItemModel> ItemModelList
        {
            get => itemModelList;
            set
            {
                itemModelList = value;
                OnPropertyChanged(nameof(ItemModelList));

            }
        }
        private ObservableCollection<ItemModel> itemToyModelList;
        public ObservableCollection<ItemModel> ItemToyModelList
        {
            get => itemToyModelList;
            set
            {
                itemToyModelList = value;
                OnPropertyChanged(nameof(ItemToyModelList));
            }
        }
        private ObservableCollection<CategoryModel> categoryModelList;
        public ObservableCollection<CategoryModel> CategoryModelList
        {
            get => categoryModelList;
            set
            {
                categoryModelList = value;
                OnPropertyChanged(nameof(CategoryModelList));
            }
        }
        public void GetCategores()
        {
            categoryModelList = new ObservableCollection<CategoryModel>();
            categoryModelList.Add(new CategoryModel { Name = "All Product", Select = true });
            categoryModelList.Add(new CategoryModel { Name = "Apparel", Select = false });
            categoryModelList.Add(new CategoryModel { Name = "Accessories", Select = false });
            categoryModelList.Add(new CategoryModel { Name = "Collection", Select = false });
        }
        public void GetItems()
        {
            itemModelList = new ObservableCollection<ItemModel>();
            itemModelList.Add(new ItemModel { Name = "POLEX Watch ", Image = "luxury_clock" , ItemType = Enum.ItemType.Other,Price = "$150"});
            itemModelList.Add(new ItemModel { Name = "Silver Linked Bracelet", Image = "silver_inked" ,ItemType = Enum.ItemType.Other, Price = "$250"  });
            itemModelList.Add(new ItemModel { Name = "Brain Rubik's Cube", Image= "brain_color", ItemType = Enum.ItemType.Toy, Price = "$10" });
            itemModelList.Add(new ItemModel { Name = "Beyblade", Image= "childhood", ItemType = Enum.ItemType.Toy, Price = "$15" });
            itemModelList.Add(new ItemModel { Name = "Robot", Image = "rock_n_roll_monkey.png", ItemType = Enum.ItemType.Toy, Price = "$70" });

        }
        public void GetToyItems()
        {
            itemToyModelList = new ObservableCollection<ItemModel>(itemModelList.Where(x => x.ItemType == Enum.ItemType.Toy).ToList());
        }
        private void ExecuteSelectGroupCommand(CategoryModel model)
        {
            CategoryModelList.ForEach((item) =>
            {
                if(item == model)
                item.Select = true;
                else item.Select = false;
            });
             OnPropertyChanged(nameof(CategoryModelList));
        }
        private async Task ExecuteNavigateToDetailPageCommand(ItemModel model)
        {
            await Navigation.PushAsync(new DetailPage(model));
        }
    }
}
