using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace OfficeCoreExer
{
    public class ItunesService : ISongsFetchingService
    {
        public itunesSong[] Fetch10RndSongs(string artist)
        {
            try
            {
                var wc = new WebClient();
                var s = wc.DownloadString(new Uri("https://itunes.apple.com/search?term=" + artist));

                var json= JsonConvert.DeserializeObject<itunesSrvsRetSongs>(s);

                var ret=json.results.Shuffle(new Random()).Take(10).ToArray();

                FixEmptytrackName(ret);

                return ret;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        private itunesSong[] FixEmptytrackName(itunesSong[] tracks)
        {
            tracks.ToList().ForEach(t =>
            {
                if(string.IsNullOrEmpty(t.trackName))// (t.trackName == null || t.trackName.Trim() == "")
                {
                    t.trackName = "{NoName}";
                }
            });

            return tracks.ToArray();
        }
    }


    public static class ExtMethods
    {
        // gg : taken from - https://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm
        //public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        public static IEnumerable<T> Shuffle<T>(this T[] elements, Random rng)
        {
            //T[] elements = source.ToArray();
            for (int i = elements.Length - 1; i >= 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                // ... except we don't really need to swap it fully, as we can
                // return it immediately, and afterwards it's irrelevant.
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }
    }
}
