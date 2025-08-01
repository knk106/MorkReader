﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4n6MorkReader
{
    public static class StringHelper
    {
        public static string SubstringSpecial(this string self, int start, int end)
        {
            return self.Substring(start, end - start);
        }
        public static bool StartsWith(this string self, string prefix, int toffset)
        {
            return self.IndexOf(prefix, toffset, System.StringComparison.Ordinal) == toffset;
        }

        public static string[] Split(this string self, string regexDelimiter, bool trimTrailingEmptyStrings)
        {
            string[] splitArray = System.Text.RegularExpressions.Regex.Split(self, regexDelimiter);

            if (trimTrailingEmptyStrings)
            {
                if (splitArray.Length > 1)
                {
                    for (int i = splitArray.Length; i > 0; i--)
                    {
                        if (splitArray[i - 1].Length > 0)
                        {
                            if (i < splitArray.Length)
                                System.Array.Resize(ref splitArray, i);

                            break;
                        }
                    }
                }
            }

            return splitArray;
        }

        public static string NewString(sbyte[] bytes)
        {
            return NewString(bytes, 0, bytes.Length);
        }
        public static string NewString(sbyte[] bytes, int index, int count)
        {
            return System.Text.Encoding.UTF8.GetString((byte[])(object)bytes, index, count);
        }
        public static string NewString(sbyte[] bytes, string encoding)
        {
            return NewString(bytes, 0, bytes.Length, encoding);
        }
        public static string NewString(sbyte[] bytes, int index, int count, string encoding)
        {
            return System.Text.Encoding.GetEncoding(encoding).GetString((byte[])(object)bytes, index, count);
        }

        public static sbyte[] GetBytes(this string self)
        {
            return GetSBytesForEncoding(System.Text.Encoding.UTF8, self);
        }
        public static sbyte[] GetBytes(this string self, System.Text.Encoding encoding)
        {
            return GetSBytesForEncoding(encoding, self);
        }
        public static sbyte[] GetBytes(this string self, string encoding)
        {
            return GetSBytesForEncoding(System.Text.Encoding.GetEncoding(encoding), self);
        }
        private static sbyte[] GetSBytesForEncoding(System.Text.Encoding encoding, string s)
        {
            sbyte[] sbytes = new sbyte[encoding.GetByteCount(s)];
            encoding.GetBytes(s, 0, s.Length, (byte[])(object)sbytes, 0);
            return sbytes;
        }

    }
}
