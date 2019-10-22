using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BurgerMonkeys.Tools
{
    public static partial class Tools
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
        {
            var collection = new ObservableCollection<T>();
            foreach (var item in list)
                collection.Add(item);
            return collection;
        }
    }
}