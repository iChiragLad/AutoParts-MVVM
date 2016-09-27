﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoParts.Model;

namespace AutoParts.MainApplication.Extensions
{
    static class ToObservableCollectionExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in coll)
                c.Add(e);
            return c;
        }
    }
}
