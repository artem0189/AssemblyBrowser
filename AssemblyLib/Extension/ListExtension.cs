using System.Collections.Generic;

namespace AssemblyLib.Extension
{
    public static class ListExtension
    {
        public static T GetOrAdd<T>(this List<T> list, T node)
        {
            int index = list.IndexOf(node);
            if (index >= 0)
            {
                node = list[index];
            }
            else
            {
                list.Add(node);
            }
            return node;
        }
    }
}
