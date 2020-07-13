using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace Lab7_4
{    
    class Program
    {
        class DatingProfile 
        { 
            public string firstName;
            private string _lastName;
            public int age;
            public string gender;
            public string bio;
            private List<Messages> myMessages;

            public DatingProfile(string firstName, string _lastName, int age, string gender)
            {
                this.firstName = firstName;
                this._lastName = _lastName;
                this.age = age;
                this.gender = gender;
                myMessages = new List<Messages>();
            }

            public void WriteBio(string description)
            {
                bio = description;
            }

            public void Mailbox(Messages message)
            {
                myMessages.Add(message);
            }

            public void SendMessage(string messageTitle, string messageData, DatingProfile sentTo)
            {
                
                Messages message = new Messages(this, messageTitle, messageData);
                sentTo.Mailbox(message);
            }

            public void ReadMessage()
            { 
                foreach (Messages message in myMessages) 
                { 
                    if(message.isRead == false)
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

        static void Main(string[] args)
        {
            DatingProfile supes = new DatingProfile("Clark", "Kent", 24, "Male");
            supes.WriteBio("Mild mannered reporter for a major metropolitan newspaper");

            DatingProfile babe = new DatingProfile("Lois", "Lane", 22, "Female");
            babe.WriteBio("Hot headed damsel in distress");

            supes.SendMessage("Hello Lois", "You know you are my kryptonite", babe);
            babe.ReadMessage();
        }
    }
}
