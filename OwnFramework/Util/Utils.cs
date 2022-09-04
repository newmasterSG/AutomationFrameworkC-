﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwnFramework.Utilities
{
    public class Utils // нужен чтобы добавлять метода которые могут повторяться в разных классах и чтобы убрать повторение он создан
    {
        public static string GetRandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray() );

            return result;
        }
    }
}
