using System;
using System.Collections.Generic;

namespace ForumApplication
{
    public class ForumMain
    {
        public static void Main(string[] args)
        {
            LinkedList<Topics> listOfTopics = new LinkedList<Topics>();
            
            listOfTopics.AddFirst(new Topics()
            {
                TopicTitle = "First Topic",
                MessageContent = "Test of first message!",
            });

            listOfTopics.AddLast(new Topics()
            {
                TopicTitle = "Topic 2",
                MessageContent = "Test of second message",
            });

            foreach(Topics t in listOfTopics)
            {
                t.PrintTopic();
                Console.WriteLine();
            }
        }
    }

    public class Topics
    {
        public string TopicTitle{get; set;}

        public string MessageContent{get; set;}

        public void PrintTopic()
        {
            Console.WriteLine(TopicTitle);
            Console.WriteLine(MessageContent);
        }
    }
}
