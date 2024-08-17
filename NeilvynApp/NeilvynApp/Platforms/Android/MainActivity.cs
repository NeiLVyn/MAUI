using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace NeilvynApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        const int RequestLocationId = 0;

        readonly string[] LocationPermissions =
        {
            Android.Manifest.Permission.AccessFineLocation,
            Android.Manifest.Permission.AccessCoarseLocation
        };

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestLocationPermissions();

            if (Intent.HasExtra("navigateTo"))
            {
                var screenToNavigate = Intent.GetStringExtra("navigateTo");

                NavigateToScreen(screenToNavigate);
            }
        }

        private void NavigateToScreen(string screenName)
        {
            // Example navigation logic
            if (screenName == "TargetScreen")
            {
                Microsoft.Maui.Controls.Shell.Current.GoToAsync("//MainPage");
            }
        }

        void RequestLocationPermissions()
        {
            if ((int)Build.VERSION.SdkInt >= 23) // Marshmallow and above requires runtime permissions
            {
                if (CheckSelfPermission(LocationPermissions[0]) == (int)Permission.Granted &&
                    CheckSelfPermission(LocationPermissions[1]) == (int)Permission.Granted)
                {
                    // Permissions are already granted
                }
                else
                {
                    // Permissions are not granted, request them
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                        {
                            // Permission granted
                        }
                        else
                        {
                            // Permission denied
                        }
                    }
                    break;
            }

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
