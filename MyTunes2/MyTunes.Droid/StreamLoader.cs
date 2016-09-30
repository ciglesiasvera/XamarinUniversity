using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace MyTunes
{
    public class StreamLoader : IStreamLoader
    {
        private readonly Context context;

        public StreamLoader(Context context)
        {
            this.context = context;
        }
        public Stream GetStreamForFilename(string filename)
        {
            return context.Assets.Open(filename);
        }
    }
}