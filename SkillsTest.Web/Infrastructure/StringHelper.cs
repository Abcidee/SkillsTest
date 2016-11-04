using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillsTest.Web.Infrastructure
{
    public static class StringHelper
    {
        public static string ToEllipsis(this string text, int length)
        {
            if (text.Length <= length) return text;
            int pos = text.IndexOf(" ", length);
            if (pos >= 0)
                return text.Substring(0, pos) + "...";
            return text.Substring(0, length) + "...";
        }
    }
}