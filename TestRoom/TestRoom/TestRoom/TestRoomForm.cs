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
        List<Label> labels;
        Label labelBouton;
        Label labelSlider;
        Label labelStepper;
        Label labelSwitch;

        String value;
        //int clickedNumber = 0;

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
            labels = new List<Label>();
            labels.Add(labelBouton);
            labels.Add(labelSlider);
            labels.Add(labelStepper);
            labels.Add(labelSwitch);


            Button boutonReset = new Button
            {
                Text = "Reset",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 12
            };
            boutonReset.Clicked += Reset;

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
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //datePicker.DateSelected += date_selected;
            
            TimePicker timePicker = new TimePicker
            {
                Format = "T",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Image image = new Image
            {
                Source = ImageSource.FromFile("icon.png"),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };


            // Build the page.
            this.Content = new ScrollView
            {
                Content = new TableView
                {
                    Intent = TableIntent.Settings,
                    Root = new TableRoot
                    {                    
                        new TableSection("Reset")
                        {
                            new ViewCell
                            {
                                View = boutonReset
                            }
                        },
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
                            },
                            new ViewCell
                            {
                                View = new StackLayout
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        image
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

        private void OnButtonClicked(object sender, EventArgs e)
        {
            //clickedNumber += 1;
            labelBouton.Text = String.Format("clicked !");//: {0}", clickedNumber);
        }

        private void Reset(object sender, EventArgs e)
        {
            foreach(var label in labels)
            {
                label.Text = "";
            }
        }
    }
}