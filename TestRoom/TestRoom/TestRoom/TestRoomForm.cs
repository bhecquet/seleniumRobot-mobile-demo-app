using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TestRoom
{
    public class TestRoomForm : ContentPage
    {
        Label labelBouton;
        Label labelSlider;
        Label labelStepper;
        Label labelSwitch;
        Label labelDate;
        Label labelTimePicker;

        String value;
        int clickedNumber = 0;

        public TestRoomForm()
        {
            value = "";

            labelBouton = new Label
            {
                Text = value,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            labelSlider = new Label
            {
                Text = value,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            labelStepper = new Label
            {
                Text = value,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            labelSwitch = new Label
            {
                Text = value,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            //labelDate = new Label
            //{
            //    Text = value,
            //    TextColor = Color.Black,
            //    HorizontalOptions = LayoutOptions.EndAndExpand
            //};
            //labelTimePicker = new Label
            //{
            //    Text = value,
            //    TextColor = Color.Black,
            //    HorizontalOptions = LayoutOptions.EndAndExpand
            //};




            Button bouton = new Button {Text = "Click!", FontSize = 12};
            bouton.Clicked += OnButtonClicked;

            Slider slider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            slider.ValueChanged += OnSliderValueChanged;

            Stepper stepper = new Stepper
            {
                Minimum = 0,
                Maximum = 10,
                Increment = 0.1,
            };
            stepper.ValueChanged += OnStepperValueChanged;

            Switch switcher = new Switch
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            switcher.Toggled += switcher_Toggled;
            
            DatePicker datePicker = new DatePicker
            {
                Format = "D",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            //datePicker.DateSelected += date_selected;
            
            TimePicker timePicker = new TimePicker
            {
                Format = "T",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };


            // Build the page.
            this.Content = new ScrollView
            {
                Content = new TableView
                {
                    Intent = TableIntent.Settings,
                    Root = new TableRoot
                    {                        
                        new TableSection("Form list")
                        {
                            new ViewCell
                            {
                                View = new StackLayout
                                {
                                    Padding = new Thickness(0, 5),
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        bouton,
                                        labelBouton
                                    }
                                }
                            },
                            new ViewCell
                            {
                                View = new StackLayout
                                {
                                    Padding = new Thickness(0, 5),
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        slider,
                                        labelSlider
                                    }
                                }
                            },
                            new ViewCell
                            {
                                View = new StackLayout
                                {
                                    Padding = new Thickness(0, 5),
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        stepper,
                                        labelStepper
                                    }
                                }
                            },
                            new ViewCell
                            {
                                View = new StackLayout
                                {
                                    Padding = new Thickness(0, 5),
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        switcher,
                                        labelSwitch
                                    }
                                }
                            },
                            new ViewCell
                            {
                                View = new StackLayout
                                {
                                    //Padding = new Thickness(0, 5),
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        datePicker,
                                        //labelDate
                                    }
                                }
                            },
                            new ViewCell
                            {
                                View = new StackLayout
                                {
                                    //Padding = new Thickness(0, 5),
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        timePicker,
                                        //labelTimePicker
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        //private void date_selected(object sender, DateChangedEventArgs e)
        //{
        //    labelDate.Text = String.Format("switch {0}", e.NewDate);
        //}

        private void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            labelSwitch.Text = String.Format("switch {0}", e.Value);
        }

        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            labelStepper.Text = String.Format("value : {0:F1}", e.NewValue);
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            labelSlider.Text = String.Format("value : {0:F1}", e.NewValue);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            clickedNumber += 1;
            labelBouton.Text = String.Format("clicked : {0}", clickedNumber);
        }
    }
}