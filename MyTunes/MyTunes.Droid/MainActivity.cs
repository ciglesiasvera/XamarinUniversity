using Android.App;
using Android.OS;
using System.Collections.Generic;
using MyTunes.Shared;
using System.Linq;
using System.IO;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            //ListAdapter = new ListAdapter<string>() {                
            //	DataSource = new[] { "One", "Two", "Three" }
            //};

            var _songs = await SongLoader.Load();

            ListAdapter = new ListAdapter<Song>()
            {   
                DataSource = _songs.ToList(),
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " - " + s.Album
            };

        }
    }
}


