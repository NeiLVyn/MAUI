using Android.Content;
using Android.App;
using Android.App.Job;

namespace NeilvynApp.Platforms.Android
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class BootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            ScheduleJob(context);
        }

        private void ScheduleJob(Context context)
        {
            var jobScheduler = (JobScheduler)context.GetSystemService(Context.JobSchedulerService);

            var jobInfo = new JobInfo.Builder(1, new ComponentName(context, Java.Lang.Class.FromType(typeof(MyJobService))))
                .SetRequiredNetworkType(NetworkType.Any)
                .SetPersisted(true)
                .SetPeriodic(1 * 60 * 1000)
                .Build();

            jobScheduler.Schedule(jobInfo);
        }
    }
}
