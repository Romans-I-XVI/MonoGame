using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace $safeprojectname$
{
    [Activity(Label = "$projectname$"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState=true
        , LaunchMode=Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.FullUser
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize | ConfigChanges.ScreenLayout)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        private static Game1 Game = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            View view;
            if (Game == null)
            {
                Game = new Game1();
                view = (View)Game.Services.GetService(typeof(View));
                Game.Run();
            }
            else
            {
                view = (View)Game.Services.GetService(typeof(View));
                ViewGroup parent = (ViewGroup)view.Parent;
                if (parent != null)
                {
                    parent.RemoveView(view);
                }
            }

            SetContentView(view);
        }

        protected override void OnDestroy()
        {
            Game = null;
            base.OnDestroy();
        }
    }
}

