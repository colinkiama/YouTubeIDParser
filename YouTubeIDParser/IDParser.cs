using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeIDParser
{
    public sealed class YTIDParser
    {

        private string GetVideoIDFromUrl(string url)
        {

            string videoID = "";


            if (url.Contains("http"))
            {
                if (url.Contains("https"))
                {
                    url = url = url.Replace("https://", "");
                }
                else
                {
                    url = url.Replace("http://", "");
                }
            }


            if (url.Contains("www"))
            {
                url = url.Replace("www.", "");
            }


            if (url.Contains("m.youtube.com"))
            {
                if (url.Contains("m.youtube.com/embed"))
                {
                    videoID = url.Replace("m.youtube.com/embed/", "");
                }
                else
                {
                    videoID = url.Replace("m.youtube.com/watch?v=", "");
                }
            }

            else if (url.Contains("youtube.com"))
            {
                if (url.Contains("youtube.com/embed"))
                {
                    videoID = url.Replace("youtube.com/embed/", "");
                }
                else
                {
                    videoID = url.Replace("youtube.com/watch?v=", "");
                }

            }


            else if (url.Contains("youtu.be"))
            {
                videoID = url.Replace("youtu.be/", "");

            }

            else videoID = $"{url} is invalid.";

            byte videoIDLength = (byte)videoID.Length;
            if (videoID[videoIDLength - 2] == '?' && videoID[videoIDLength - 1] == 'a')
            {
                videoID = videoID.Remove(videoIDLength - 2, 2);
            }

            if (videoID.Contains("?autoplay"))
            {
                int startOfRemoval = videoID.LastIndexOf("?autoplay");
                videoID = videoID.Remove(startOfRemoval);
            }

            return videoID;
        }
    }
}
