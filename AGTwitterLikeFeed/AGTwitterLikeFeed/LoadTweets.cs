using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AGTwitterLikeFeed
{
    public class LoadTweets
    {
        string file;

        public LoadTweets(string fileName)
        {
            file = fileName;
        }

        public List<Tweet> GetTweets()
        {
            //Create list that will be populated from text file
            List<Tweet> tweets = new List<Tweet>();

            StreamReader sr = new StreamReader(file);
            String line;

            //Read the first line of text
            line = sr.ReadLine();

            //Continue to read until you reach end of file
            while (line != null)
            {
                //Separate tweet from user
                string[] tweetSeparators = new string[] { "> " };
                string[] tweetArray = line.Split(tweetSeparators, StringSplitOptions.None);

                // If the tweet line contains text
                if (tweetArray.Length > 1)
                {
                    string tweetText;
                    if (tweetArray[1].Length > 140)
                    {
                        tweetText = tweetArray[1].Substring(0, 140);
                    }
                    else
                    {
                        tweetText = tweetArray[1];
                    }

                    //create the tweet for the user
                    Tweet tweet = new Tweet(tweetArray[0], tweetText);
                    tweets.Add(tweet);
                }

                //Read the next line
                line = sr.ReadLine();
            }

            //close the file
            sr.Close();

            return tweets;
        }
    }
}
