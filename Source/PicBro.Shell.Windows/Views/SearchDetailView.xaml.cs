﻿using PicBro.Shell.Windows.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PicBro.Shell.Windows.Views
{
    /// <summary>
    /// Interaction logic for SearchDetailView.xaml
    /// </summary>
    public partial class SearchDetailView : UserControl
    {
        public SearchDetailView()
        {
            InitializeComponent();
        }

        public SearchDetailView(SearchDetailViewModel viewmodel)
            : this()
        {
            this.DataContext = viewmodel;
        }
    }
}
