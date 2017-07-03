using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.IO;
using System.Threading.Tasks;
using Plugin.Permissions;
using Android.Util;
using Android.Support.V4.View;
using Android.Graphics;
using Android.Webkit;

namespace TestRoom.Droid
{
    [Activity(Label = "TestRoom", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Button boutonReset;
        Button boutonClick;
        SeekBar seekbar;
        Switch boutonSwitch;
        Button boutonDate;
        Button boutonTime;
        ImageView imageTap;
        ImageView imagePan;
        ImageView imagePinch;

        TextView labelClick;
        TextView labelSeekbar;
        TextView labelSwitch;
        TextView labelDate;
        TextView labelTime;
        TextView labelTap;
        TextView labelPan;
        TextView labelPinch;

        private int hour;
        private int minute;

        const int TIME_DIALOG_ID = 0;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.FormList);


            ///---------------- Gestion de la page ----------------------///
            boutonReset     = FindViewById<Button>(Resource.Id.button_reset);

            boutonClick     = FindViewById<Button>(Resource.Id.button_click);
            boutonDate      = FindViewById<Button>(Resource.Id.button_datepicker);
            boutonTime      = FindViewById<Button>(Resource.Id.button_timepicker);
            boutonSwitch    = FindViewById<Switch>(Resource.Id.button_switch);
            seekbar         = FindViewById<SeekBar>(Resource.Id.seekBar);
            imageTap        = FindViewById<ImageView>(Resource.Id.imageTap);
            imagePan        = FindViewById<ImageView>(Resource.Id.imagePan);
            imagePinch      = FindViewById<ImageView>(Resource.Id.imagePinch);

            WebView localWebView = FindViewById<WebView>(Resource.Id.webView1);
            localWebView.Settings.JavaScriptEnabled = true;
            localWebView.Settings.DomStorageEnabled = true;
            localWebView.SetWebChromeClient(new WebChromeClient());
            localWebView.LoadUrl("file:///android_asset/Content/test.html");

            labelClick = FindViewById<TextView>(Resource.Id.checkedTextView_click);
            labelSeekbar    = FindViewById<TextView>(Resource.Id.checkedTextView_seekBar);
            labelSwitch     = FindViewById<TextView>(Resource.Id.checkedTextView_switch);
            labelDate       = FindViewById<TextView>(Resource.Id.datePicker);
            labelTime       = FindViewById<TextView>(Resource.Id.timePicker);
            labelTap        = FindViewById<TextView>(Resource.Id.checkedTextView_tap);
            labelPan        = FindViewById<TextView>(Resource.Id.checkedTextView_pan);
            labelPinch      = FindViewById<TextView>(Resource.Id.checkedTextView_pinch);


            boutonReset.Click += delegate
            {
                labelClick.Text = "";

                seekbar.Progress = 0;
                labelSeekbar.Text = "";

                boutonSwitch.Checked = false;
                labelSwitch.Text = "";

                labelDate.Text = "";
                labelTime.Text = "";

                labelTap.Text = "Tap";
                labelPan.Text = "Pan";
                labelPinch.Text = "Pinch";
            };

            boutonClick.Click += delegate
            {
                labelClick.Text = "Clicked!";
            };

            seekbar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
            {
                labelSeekbar.Text = string.Format("{0}", e.Progress);
            };

            boutonSwitch.Click += (o, e) =>
            {
                if (boutonSwitch.Checked)
                    labelSwitch.Text = "ON";
                else
                    labelSwitch.Text = "OFF";
            };

            boutonDate.Click += DateSelect_OnClick;

            boutonTime.Click += (o, e) => ShowDialog(TIME_DIALOG_ID);
            
            imageTap.Touch += ImageTap_Touch;
            imagePan.Touch += ImagePan_Touch;
            imagePinch.Touch += ImagePinch_Touch;
            
        }

        private void ImagePan_Touch(object sender, View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Move)
            {
                labelPan.Text = "Image panned !";
            }
        }

        private void ImagePinch_Touch(object sender, View.TouchEventArgs e)
        {
            ///We just check if there is two finger that taps on the image
            if (e.Event.Action == MotionEventActions.Pointer2Down)
            {
                labelPinch.Text = "Image pinched !";
            }
        }

        private void ImageTap_Touch(object sender, View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                labelTap.Text = "Image tapped !";
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                labelDate.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        // Updates the time we display in the TextView
        private void UpdateDisplay()
        {
            string time = string.Format("{0}:{1}", hour, minute.ToString().PadLeft(2, '0'));
            labelTime.Text = time;
        }

        private void TimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            hour = e.HourOfDay;
            minute = e.Minute;
            UpdateDisplay();
        }

        protected override Dialog OnCreateDialog(int id)
        {
            if (id == TIME_DIALOG_ID)
                return new TimePickerDialog(this, TimePickerCallback, hour, minute, false);

            return null;
        }
    }

    public class DatePickerFragment : DialogFragment,
                                  DatePickerDialog.IOnDateSetListener
    {
        // TAG can be any string of your choice.
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();

        // Initialize this value to prevent NullReferenceExceptions.
        Action<DateTime> _dateSelectedHandler = delegate { };

        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            DatePickerFragment frag = new DatePickerFragment();
            frag._dateSelectedHandler = onDateSelected;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = DateTime.Now;
            DatePickerDialog dialog = new DatePickerDialog(Activity,
                                                           this,
                                                           currently.Year,
                                                           currently.Month,
                                                           currently.Day);
            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            Log.Debug(TAG, selectedDate.ToLongDateString());
            _dateSelectedHandler(selectedDate);
        }
    }
}