using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YouTubeIDParser
{
    public sealed class YTIDParser
    {
        const string videoIDMatchRegexString = "(?:youtube\\.com\\/(?:[^\\/]+\\/.+\\/|(?:v|e(?:mbed)?)\\/|.*[?&]v=)|youtu\\.be\\/)([^\" &?\\/ ]{11})";

        const string notFoundVideoID = "noVideoFound";
        static Regex regularExpression = new Regex(videoIDMatchRegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        
        /// <summary>
        /// Will return the video ID if a video ID is found from the URL. Else, the method will return "noVideoFound".
        /// </summary>
        /// <param name="videoUrl"></param>
        /// <returns></returns>
        public static string Parse(string videoUrl)
        {
            string videoIDToReturn = notFoundVideoID;

            MatchCollection matches = regularExpression.Matches(videoUrl);

            if (matches.Count > 0)
            {
                if (matches[0].Groups.Count > 1)
                {
                    // Because of the nature of the regex string
                    // the video ID will always be in the second group (Index 1).
                    videoIDToReturn = matches[0].Groups[1].Value;

                }
            }

            return videoIDToReturn;
        }

    }
}
