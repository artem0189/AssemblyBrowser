using System.Collections.Generic;

namespace TestLibrary.Extension
{
    public static class ListExtension
    {
        public static T GetOrAdd<T>(this List<T> list, T elem)
        {
            return elem;
        }
    }
}
