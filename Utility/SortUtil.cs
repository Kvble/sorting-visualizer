using SortingVisualizer.Models;
using System.Collections.Generic;

namespace SortingVisualizer.Utility
{
    internal static class SortUtil
    {
        /// <summary>
        /// Checks if the list is not empty.
        /// </summary>
        /// <param name="list">The list that has to be checked.</param>
        /// <returns>Return true if the List is not empty, false if it's empty.</returns>
        public static bool NotEmpty(List<Height> list)
        {
            return list.Count > 0;
        }
    }
}
