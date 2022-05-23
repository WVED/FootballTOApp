using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace FootballTicketApp
{
    public class Team
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }

        public ImageSource Photo
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(Image));
            }
        }
    }
}
