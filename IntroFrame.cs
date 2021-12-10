using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntroDialogPager
{
    public class IntroFrame
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public Color BackgroundColor { get; set; } = Color.Transparent;
        public int BackroundResource { get; set; }
        public Action OnEndCallback { get; set; }
        public string EndButtonText { get; set; }
        /// <summary>
        /// Empty is -1
        /// </summary>
        public int ImageResource { get; set; } = -1;
        /// <summary>
        /// Hide the image so it doesn't take up space
        /// </summary>
        public bool HideImage { get; set; }
    }
}