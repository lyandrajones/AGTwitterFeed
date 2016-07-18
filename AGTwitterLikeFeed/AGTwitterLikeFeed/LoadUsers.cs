using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace AGTwitterLikeFeed
{
    public class LoadUsers
    {

        string file;

        // Create list that will be populated from text file
        List<User> users = new List<User>();
        
        public LoadUsers(string fileName)
        {
            file = fileName;
        }

        public List<User> GetUsers()
        {
            StreamReader sr = new StreamReader(file);
            String line;

            // Read the first line of text
            line = sr.ReadLine();

            // Seperators that are used below
            string[] followsSeparator = new string[] { " follows " };
            string[] commaSeparators = new string[] { ", " };

            // Loop through each line in user file
            while (line != null)
            {
                // Seperate the user and who they may be following
                string[] nameArray = line.Split(followsSeparator, StringSplitOptions.None);

                // Call common method to add the user to the list if they're not already in the list
                AddUser(nameArray[0]);

                // If the user is following anyone
                if (nameArray.Length > 1)
                {
                    // Seperate who is being followed
                    string[] followedUsers = nameArray[1].Split(commaSeparators, StringSplitOptions.None);

                    // Loop through the users being followed
                    foreach (string userName in followedUsers)
                    {
                        // Call common method to add the user to the list of users if they're not already in the list
                        AddUser(userName);

                        // Find the current user in the list
                        User currentUser = new User();
                        currentUser = users.Where(u => u.Name == nameArray[0]).First();

                        // If a list of people being followed does not yet exist for this user, create one
                        if (currentUser.Following == null)
                        {
                            currentUser.Following = new List<string>();
                        }

                        // If the user being followed is not yet in the following list, add them to the list
                        if (!currentUser.Following.Contains(userName))
                        {
                            currentUser.Following.Add(userName);
                        }
                    }
                }

                // Read next line in user file
                line = sr.ReadLine();
            }

            // Close the file
            sr.Close();

            // Sort the users into alphabetical order
            users.Sort();

            return users;
        }
        private void AddUser(string Name)
        {
            // Check if the user is already in the list of users
            if (!users.Any(u => u.Name == Name))
            {
                // If not, then add them
                User tempUser = new User();
                tempUser.Name = Name;
                users.Add(tempUser);
            }
        }
    }
   }
