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
    internal class IntroFragment : AndroidX.Fragment.App.Fragment
    {
        private readonly IntroFrame _data;
        private readonly IntroDialog _dialog;
        public static IntroFragment Instance(IntroFrame obj, IntroDialog dialog)
        {
            return new IntroFragment(obj, dialog);
        }
        public IntroFragment(IntroFrame obj, IntroDialog dialog)
        {
            _data = obj;
            _dialog = dialog;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_intro, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            var msgTxt = view.FindViewById<TextView>(Resource.Id.message);
            var titleTxt = view.FindViewById<TextView>(Resource.Id.title);
            var img = view.FindViewById<ImageView>(Resource.Id.img);
            var backgroundImg = view.FindViewById<ImageView>(Resource.Id.background);
            

            if (_data.HideImage)
            {
                img.Visibility = ViewStates.Gone;
            }
            else
            {
                img.Visibility = ViewStates.Visible;
                if (_data.ImageResource != -1)
                    img.SetImageResource(_data.ImageResource);
            }

            backgroundImg.SetImageResource(_data.BackroundResource);
            msgTxt.Text = _data.Message;
            titleTxt.Text = _data.Title;
            view.SetBackgroundColor(_data.BackgroundColor);
        }
        public override void OnResume()
        {
            if (_data.OnEndCallback != null)
            {
                _dialog.EndButton.Visibility = ViewStates.Visible;
                _dialog.EndButton.Click += (s, e) => _data.OnEndCallback();
                if(_data.EndButtonText == null || _data.EndButtonText == "")
                {
                    throw new Exception("EndButtonText must be set if OnEndCallback is not null!");
                }
                _dialog.EndButton.Text = _data.EndButtonText;
            }
            else
            {
                _dialog.EndButton.Visibility = ViewStates.Gone;
            }
            base.OnResume();
        }
    }
}