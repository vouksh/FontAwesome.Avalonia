﻿using System;
using System.Windows;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace FontAwesome.Avalonia
{
    /// <summary>
    /// Provides attached properties to set FontAwesome icons on controls.
    /// </summary>
    public class Awesome
    {
        static Awesome()
        {
            IconProperty.Changed.Subscribe(IconChanged);
        }

        /// <summary>
        /// FontAwesome FontFamily.
        /// </summary>
        public static readonly FontFamily FontAwesomeFontFamily = new FontFamily("resm:FontAwesome.Avalonia.FontAwesome.otf#FontAwesome");

        /// <summary>
        /// Identifies the FontAwesome.Avalonia.Awesome.Content attached dependency property.
        /// </summary>  
        public static readonly AttachedProperty<FontAwesomeIcon> IconProperty =
            AvaloniaProperty.RegisterAttached<Awesome, Control, FontAwesomeIcon>("Icon", FontAwesomeIcon.None);

        public static FontAwesomeIcon GetIcon(Control target)
        {
            return target.GetValue(IconProperty);
        }

        public static void SetIcon(Control target, FontAwesomeIcon value)
        {
            target.SetValue(IconProperty, value);
        }

        private static void IconChanged(AvaloniaPropertyChangedEventArgs evt)
        {
            if (!(evt.NewValue is FontAwesomeIcon)) return;
            if (!(evt.Sender is ContentControl)) return;

            FontAwesomeIcon symbolIcon = (FontAwesomeIcon)evt.NewValue;
            int symbolCode = (int)symbolIcon;
            char symbolChar = (char)symbolCode;
            var target = (evt.Sender as ContentControl);
            target.FontFamily = FontAwesomeFontFamily;
            target.Content = symbolChar;
        }
    }
}
