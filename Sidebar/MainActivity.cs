using Android.App;
using Android.OS;
using Java.Lang;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Views;
using System;

namespace Sidebar
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.DesignDemo", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerlayout;
        NavigationView navigationView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
               drawerlayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
                var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
                SetSupportActionBar(toolbar);
                var drawerToggle = new ActionBarDrawerToggle(this, drawerlayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
                drawerlayout.AddDrawerListener(drawerToggle);
                drawerToggle.SyncState();
                navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
                setupDrawerContent(navigationView);
        }
        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                drawerlayout.CloseDrawers();
            };
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            navigationView.InflateMenu(Resource.Menu.menu1);
            return true;
        }
       
    }
}