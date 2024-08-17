using Android.App.Job;
using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;

namespace NeilvynApp.Platforms.Android
{
    [Service(Name = "com.neilvyn.jobservice", Permission = "android.permission.BIND_JOB_SERVICE")]
    public class MyJobService : JobService
    {
        public override bool OnStartJob(JobParameters @params)
        {
            var intent = new Intent("com.neilvyn.ACTION_NAVIGATE");
            SendBroadcast(intent);

            return false;
        }

        public override bool OnStopJob(JobParameters @params)
        {
            return false;
        }
    }
}
