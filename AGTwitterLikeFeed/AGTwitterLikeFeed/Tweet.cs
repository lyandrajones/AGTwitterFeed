using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGTwitterLikeFeed
{
    public class Tweet
    {
        public Tweet(string userName, string text)
        {
            TweetedBy = userName;
            Text = text;
        }
        public string TweetedBy { get; set; }

        public string Text { get; set; }


    }
}
