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
            // Validate number of parameters which contain file names and locations
            // --------------------------------------------------------------------

            if (args == null || args.Length < 2)
            {
                Console.WriteLine("Please specify two filenames as parameters.");
                return;
            }

            try
            {
                // Load user and tweet data from files into lists
                // ----------------------------------------------

                LoadUsers loadUsers = new LoadUsers(args[0]);
                List<User> users = loadUsers.GetUsers();

                LoadTweets loadTweets = new LoadTweets(args[1]);
                List<Tweet> tweets = loadTweets.GetTweets();


                // Output Twitter feed for all users to Console
                // --------------------------------------------

                var indent = new string(' ', 8);

                foreach (User currentUser in users)
                {
                    Console.WriteLine(currentUser.Name);
                    foreach (Tweet currentTweet in tweets)
                    {
                        // If the tweet is by the current user or someone the user is following, output it to the console.

                        if (currentTweet.TweetedBy == currentUser.Name || (currentUser.Following != null && currentUser.Following.Contains(currentTweet.TweetedBy)))
                        {
                            Console.WriteLine(indent + "@" + currentTweet.TweetedBy + ": " + currentTweet.Text); 
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(" Program ended abnormally. Exception: " + e.Message);
            }
            finally
            {
            }

        }
    }
}
