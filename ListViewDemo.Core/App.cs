﻿using MvvmCross;
using MvvmCross.ViewModels;

namespace ListViewDemo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterCustomAppStart<AppStart>();
        }
    }
}