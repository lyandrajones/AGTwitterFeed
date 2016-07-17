using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AGTwitterLikeFeed
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Twitter Feeds");


            #region Validations for file inputs

            if (args == null || args.Length < 2)
            {
                Console.WriteLine("Please specify two filenames as parameters.");
                return;
            }

            #endregion

            try
            {
                //-------------------------------------LOADING DATA FROM FILES------------------------------------------------------------------------------------------
                LoadUsers loadUsers = new LoadUsers(args[0]);
                List<User> users = loadUsers.GetUsers();

                LoadTweets loadTweets = new LoadTweets(args[1]);
                List<Tweet> tweets = loadTweets.GetTweets();

                //-------------------------------------DISPLAY DATA--------------------------------------------------------------------------------------

                var indent = new string(' ', 8);

                foreach (User currentUser in users)
                {
                    Console.WriteLine(currentUser.Name);
                    foreach (Tweet currentTweet in tweets)
                    {
                        if (currentTweet.TweetedBy == currentUser.Name || (currentUser.Following != null && currentUser.Following.Contains(currentTweet.TweetedBy)))
                        {
                            Console.WriteLine(indent + "@" + currentTweet.TweetedBy + ": " + currentTweet.Text); //This is assuming that the message. in the the instructions considered the "." to already be in the message.
                        }
                    }
                }




            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

    }
}
