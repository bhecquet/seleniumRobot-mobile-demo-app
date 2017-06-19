using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TestRoom
{
    public class FormList : ContentPage
    {
        List<Label> labels;
        Label labelBouton;
        Label labelSlider;
        Label labelStepper;
        Label labelSwitch;
        Label labelTap;
        Label labelPan;
        Label labelPinch;

        String value;

        Slider slider;
        Switch switcher;
        DatePicker datePicker;
        TimePicker timePicker;
        TapGestureRecognizer tapGestureRecognizer;
        PanGestureRecognizer panGestureRecognizer;
        PinchGestureRecognizer pinchGestureRecognizer;
        Image imageTap;
        Image imagePan;
        Image imagePinch;


        public FormList()
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
            labelTap = new Label
            {
                Text = value,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            labelPan = new Label
            {
                Text = value,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            labelPinch = new Label
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
            labels.Add(labelTap);
            labels.Add(labelPan);
            labels.Add(labelPinch);


            Button boutonReset = new Button
            {
                Text = "Reset",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 12,
                BorderWidth = 1,
                BorderColor = Color.Black
            };
            boutonReset.Clicked += Reset;

            Button bouton = new Button
            {
                AutomationId = "button",
                Text = "Click!",
                FontSize = 12,
                BorderWidth = 1,
                BorderColor = Color.Black
            };
            bouton.Clicked += OnButtonClicked;

            slider = new Slider
            {
                AutomationId = "slider",
                Minimum = 0,
                Maximum = 100,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            slider.ValueChanged += OnSliderValueChanged;

            Stepper stepper = new Stepper
            {
                AutomationId = "stepper",
                Minimum = 0,
                Maximum = 10,
                Increment = 0.1,
            };
            stepper.ValueChanged += OnStepperValueChanged;

            switcher = new Switch
            {
                AutomationId = "switcher",
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            switcher.Toggled += switcher_Toggled;

            datePicker = new DatePicker
            {
                AutomationId = "datePicker",
                Format = "D",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            timePicker = new TimePicker
            {
                AutomationId = "timePicker",
                Format = "T",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            imageTap = new Image
            {
                AutomationId = "imageTap",
                Source = ImageSource.FromFile("icon.png"),
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += gesture_tapped;
            imageTap.GestureRecognizers.Add(tapGestureRecognizer);

            imagePan = new Image
            {
                AutomationId = "imagePan",
                Source = ImageSource.FromFile("icon.png"),
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            panGestureRecognizer = new PanGestureRecognizer();
            panGestureRecognizer.PanUpdated += onPanUpdated;
            imagePan.GestureRecognizers.Add(panGestureRecognizer);

            imagePinch = new Image
            {
                Source = ImageSource.FromFile("iconPlusGrande.png"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            pinchGestureRecognizer = new PinchGestureRecognizer();
            pinchGestureRecognizer.PinchUpdated += onPinchUpdated;
            imagePinch.GestureRecognizers.Add(pinchGestureRecognizer);


            // Build the page.
            this.Content = new ScrollView
            {
                Content = new TableView
                {
                    HasUnevenRows = true,
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
                                    Orientation = StackOrientation.Horizontal,
                                    Children =
                                    {
                                        datePicker
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
                                        timePicker
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
                                        imageTap,
                                        new Label { Text = "Tap", HorizontalOptions = LayoutOptions.CenterAndExpand},
                                        labelTap
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
                                        imagePan,
                                        new Label { Text = "Drag", HorizontalOptions = LayoutOptions.CenterAndExpand},
                                        labelPan
                                    }
                                }
                            },
                            new ViewCell
                            {
                                Height = 300,
                                View = new StackLayout
                                {
                                    Orientation = StackOrientation.Vertical,
                                    HorizontalOptions = LayoutOptions.FillAndExpand,
                                    Children =
                                    {
                                        new Label { Text = "Pinch", HorizontalOptions = LayoutOptions.StartAndExpand},
                                        imagePinch,
                                        labelPinch
                                    }
                                }
                            }
                        }
                    }
                },
            };
        }

        private void onPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            labelPinch.Text = "Image pinched";
        }

        private void onPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            labelPan.Text = "Image dragged";
        }

        private void gesture_tapped(object sender, EventArgs e)
        {
            labelTap.Text = String.Format("Tapped");
        }

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
            labelBouton.Text = String.Format("clicked !");
        }

        private void Reset(object sender, EventArgs e)
        {
            slider.Value = 0;
            switcher.IsToggled = false;
            datePicker.Date = DateTime.Now;
            timePicker.Time = TimeSpan.Zero;
            imagePan.IsVisible = true;
            //image3.IsVisible = false;

            foreach (var label in labels)
            {
                label.Text = "";
            }
        }
    }
}