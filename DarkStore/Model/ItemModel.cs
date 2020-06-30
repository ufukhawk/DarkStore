using System;
using DarkStore.Enum;

namespace DarkStore.Model
{
    public class ItemModel
    {
        public string Name { get; set; }
        public String Image { get; set; }
        public string Price { get; set; }
        public ItemType ItemType { get;set; } 
    }
}
