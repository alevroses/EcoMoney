using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EcomoneyRecolector.Conexiones;
using Plugin.CurrentActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Application(Debuggable = true)]
[MetaData("com.google.android.maps.v2.API_KEY",
    Value =Constantes.GoogleMapsApiKey)]
    public class Activitymaps:Application
    {
    public Activitymaps(IntPtr handle, JniHandleOwnership transer)
        :base(handle, transer)
    {

    }
    public override void OnCreate()
    {
        base.OnCreate();
        CrossCurrentActivity.Current.Init(this);
    }
}
