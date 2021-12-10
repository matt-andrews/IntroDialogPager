using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.ViewPager2.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntroDialogPager
{
    internal class IntroViewPagerAdapter : FragmentStateAdapter
    {
        private readonly IntroFrame[] _list;
        private readonly IntroDialog _dialog;

        public IntroViewPagerAdapter(AppCompatActivity activity, IntroFrame[] tbl, IntroDialog dialog) : base(activity)
        {
            _list = tbl;
            _dialog = dialog;
        }

        public override int ItemCount => _list.Length;

        public override AndroidX.Fragment.App.Fragment CreateFragment(int p0)
        {
            return IntroFragment.Instance(_list[p0], _dialog);
        }
    }
}