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

        public LoadUsers(string fileName)
        {
            file = fileName;
        }

        public List<User> GetUsers()
        {
            //Create list that will be populated from text file
            List<User> users = new List<User>();

            String line;
            StreamReader sr = new StreamReader(file);

            //Read the first line of text
            line = sr.ReadLine();

            //Seperators -> to be used below
            string[] stringSeparators = new string[] { " follows " };
            string[] commaSeparators = new string[] { ", " };

            //Continue to read until you reach end of file
            while (line != null)
            {
                //Create user to track who is the main user in the line and add to who they are following
                User currentUser = new User();

                string[] nameArray = line.Split(stringSeparators, StringSplitOptions.None);
                
                //First item in array will always be single user                
                //Check if they are already in the list
                if (!users.Any(u => u.Name == nameArray[0]))
                {
                    User tempUser = new User();
                    tempUser.Name = nameArray[0];
                    //If not, then add them.
                    users.Add(tempUser);
                }


                //Second item in array will always be one or more users -> need to split on ','
                string[] potentialNewUsers = nameArray[1].Split(commaSeparators, StringSplitOptions.None);

                //loop through other users
                foreach (string userName in potentialNewUsers)
                {
                    //Check if they are already in the list
                    if (!users.Any(u => u.Name == userName))
                    {
                        //If not, then add them.
                        User tempUser = new User();
                        tempUser.Name = userName;
                        users.Add(tempUser);
                    }

                    //Check if the main user in the line has them in their following list
                    currentUser = users.Where(u => u.Name == nameArray[0]).First();

                    //Console.WriteLine("current user is " + currentUser.Name);

                    //If the list does not exist yet, then create it.
                    if (currentUser.Following == null)
                    {
                        currentUser.Following = new List<string>();
                    }
                        if(!currentUser.Following.Contains(userName))
                    {
                        //if they don't, then add them to the list
                        currentUser.Following.Add(userName);
                        //Console.WriteLine("in if");
                    }
                }
                line = sr.ReadLine();
            }

            //close the file
            sr.Close();


            users.Sort();

            return users;
        }


    }
}
