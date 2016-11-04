using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillsTest.Domain.Helpers
{
    public static class Pager
    {
        public static Page<TSource> ToPage<TSource>(this IEnumerable<TSource> source, int currentPage, int pageSize, bool descending, string propertyName)
        {
            currentPage = currentPage < 1 ? 1 : currentPage;

            var totalPageCount = Math.Ceiling(source.Count() / (decimal)pageSize);

            if (totalPageCount > 0)
            {
                return new Page<TSource>()
                {
                    Descending = descending,
                    PropertyName = propertyName,
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalPageCount = (int)totalPageCount,
                    Data = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                };
            }

            return new Page<TSource>()
            {
                Descending = false,
                PropertyName = "",
                CurrentPage = 0,
                PageSize = 0,
                TotalPageCount = 0,
                Data = null
            };
        }
    }

    public class Page<T>
    {
        public int TotalPageCount { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public List<T> Data { get; set; }

        public bool Descending { get; set; }

        public string PropertyName { get; set; }
    }
}
