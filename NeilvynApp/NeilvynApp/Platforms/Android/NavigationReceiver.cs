using Android.App;
using Android.Content;

namespace NeilvynApp.Platforms.Android
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { "com.neilvyn.ACTION_NAVIGATE" })]
    public class NavigationReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var activityIntent = new Intent(context, typeof(MainActivity));
            activityIntent.PutExtra("navigateTo", "MainPage");

            activityIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTop);
            context.StartActivity(activityIntent);
        }
    }
}
