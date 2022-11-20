using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcomoneyCliente.Droid.Controles;
using EcomoneyCliente.VistaModelo;
using Xamarin.Forms;
using Plugin.CurrentActivity;

[assembly:Dependency(typeof(StatusBar))]

namespace EcomoneyCliente.Droid.Controles
{
    internal class StatusBar : VMstatusbar
    {
        public void MostrarStatusBar()
        {
            
        }

        public void OcultarStatusBar()
        {
            
        }

        public void TransparentarStatusbar()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var currentWindow = GetCurrentWindow();
                currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutFullscreen;
                currentWindow.SetStatusBarColor(Android.Graphics.Color.Transparent);
            });
        }

        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }
    }
}