using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.ViewPager2.Widget;
using Google.Android.Material.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntroDialogPager
{
    public class IntroDialog
    {
        private readonly AppCompatActivity _activity;
        private AndroidX.AppCompat.App.AlertDialog _dialog;
        private ViewPager2 _pager;
        private TabLayout _tabLayout;
        public Button EndButton { get; private set; }
        public IntroDialog(AppCompatActivity activity)
        {
            _activity = activity;
        }
        public IntroDialog Build(IntroFrame[] pages)
        {
            AndroidX.AppCompat.App.AlertDialog.Builder builder = new AndroidX.AppCompat.App.AlertDialog.Builder(_activity);

            var layout = CreateView();

            builder.SetView(layout);

            _pager.Adapter = new IntroViewPagerAdapter(_activity, pages, this);

            new TabLayoutMediator(_tabLayout, _pager, new MediatorConfig()).Attach();

            builder.SetCancelable(false);
            _dialog = builder.Show();
            return this;
        }
        private View CreateView()
        {
            var view = _activity.LayoutInflater.Inflate(Resource.Layout.main_layout, null);
            _pager = view.FindViewById<ViewPager2>(Resource.Id.viewpager);
            _tabLayout = view.FindViewById<TabLayout>(Resource.Id.tab_layout);
            EndButton = view.FindViewById<Button>(Resource.Id.closebtn);
            return view;
        }
        public void Dismiss()
        {
            _dialog.Dismiss();
        }

        private class MediatorConfig : Java.Lang.Object, TabLayoutMediator.ITabConfigurationStrategy
        {
            public void OnConfigureTab(TabLayout.Tab p0, int p1)
            {
                //do nothing
            }
        }
    }
}