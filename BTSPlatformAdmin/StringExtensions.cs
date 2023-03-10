﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTSPlatformAdmin
{
    public static class StringExtensions
    {
        public static string ReplaceEx(this string original, string pattern, string replacement)
        {
            int count = 0;
            int position0 = 0;
            int position1 = 0;
            
            string upperString = original.ToUpper();
            string upperPattern = pattern.ToUpper();

            int inc = (original.Length / pattern.Length) * (replacement.Length - pattern.Length);
            char[] chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern, position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                for (int i = 0; i < replacement.Length; ++i)
                    chars[count++] = replacement[i];
                position0 = position1 + pattern.Length;
            }

            if (position0 == 0) return original;
            
            for (int i = position0; i < original.Length; ++i)
                chars[count++] = original[i];
            
            return new string(chars, 0, count);
        }
    }
}
