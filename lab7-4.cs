﻿using System;
using System.Collections.Generic;


namespace _7_4DatingGame
{
    class DatingProfile
    {
        public string firstName;
        private string lastName;
        public int age;
        public string gender;
        public string bio;
        private List<Messages> myMessages;

        public DatingProfile(string firstName, string lastName, int age, string gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
            myMessages = new List<Messages>();
        }

        public void WriteBio(string text)
        {
            bio = text;
        }

        public void AddToInbox(Messages message)
        {
            myMessages.Add(message);

        }

        public void SendMessage(string messageTitle, string messageData, DatingProfile sentTo)
        {
            Messages message = new Messages(this, messageTitle, messageData);
            sentTo.AddToInbox(message);
        }

        public void ReadMessage()
        {
            foreach (Messages message in myMessages)
            {
                if (message.isRead == false)
                {
                    Console.WriteLine(message.messageTitle);
                    Console.WriteLine(message.messageData);
                    message.isRead = true;
                }
            }
        }
    }
    class Messages
    {
        public DatingProfile sender;
        public string messageTitle;
        public string messageData;
        public bool isRead;

        public Messages(DatingProfile sender, string messageTitle, string messageData)
        {
            this.sender = sender;
            this.messageTitle = messageTitle;
            this.messageData = messageData;
            isRead = false;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DatingProfile Ranveer = new DatingProfile("Ranveer", "Singh", 40, "Male");
            Ranveer.WriteBio("Strong outdoors type");

            DatingProfile Deepika = new DatingProfile("Deepika", "Padukoune", 35, "Female");
            Deepika.WriteBio("new to this site");

            Ranveer.SendMessage("Hello Deepika", "Want to get some coffee?", Deepika);
            Deepika.ReadMessage();
        }
    }
}
