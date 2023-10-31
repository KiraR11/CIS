﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Models
{
    internal class Hall
    {
        public Hall(int[,] layout,int number,string screen) 
        {
            Layout = layout;
            Number = number;
            Screen = screen;
        }
        public int[,] Layout { get; }
        public int Number { get; }
        public string Screen { get; } // строка или отдельный класс?
        public int CountPlase { get { return Layout.Length; } }
        public int CountPows { get { return Layout.GetLength(0); } }

    }
}
