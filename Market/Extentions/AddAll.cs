using System.Collections.ObjectModel;

namespace Market.Extentions;

public static class AddAll
{
    public static void AddRange<T>(this ObservableCollection<T> collection, List<T> list)
    {
        foreach (var item in list)
        {
            collection.Add(item);
        }
    }
}