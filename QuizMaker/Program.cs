using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuizMaker
{
    class Program
    {
        public class QuizStructure
        {
            public string Qs_question { get; set; }
            public string Qs_answer { get; set; }
            public int Qs_difficulty { get; set; }
        }
        static void Main(string[] args)
        {
            
            int count = 0;
            string question = "";
            string answer = "";
            string difficultyString = "";
            int difficultyInt = 0;
            string menuOption;
            string windowsusername = Environment.UserName;
            string path = "C:\\Users\\" + windowsusername + "\\Documents\\quiz.json";
            int numberofQuestions;
            string inputtedAnswer = "";
            int points = 0;
            Console.WriteLine("-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Josh's Quiz Maker");
            Console.WriteLine("-=-=-=-=-=-=-=-=-");
            List<QuizStructure> Quiz = new List<QuizStructure>();
            var questionsList = new List<string>();
            var answersList = new List<string>();
            var difficultyList = new List<int>();
            var questionslistRandomised = new List<string>();
            var answerslistRandomised = new List<string>();
            var difficultylistRandomised = new List<int>();

            while (true)
            {
                Console.WriteLine("-=-=");
                Console.WriteLine("Menu");
                Console.WriteLine("-=-=");
                Console.WriteLine("(A)dd questions and answers");
                Console.WriteLine("(P)rint all of the questions");
                Console.WriteLine("(W)rite the quiz to a JSON file");
                Console.WriteLine("(R)ead the quiz from a JSON file");
                Console.WriteLine("(C)reate a quiz from the questions and answers");
                Console.WriteLine("E(x)it the program");
                menuOption = Console.ReadLine().ToUpper();
                while (menuOption == "A")
                {
                    Console.Clear();
                    Console.WriteLine("Please enter Question " + (count + 1) + " or type 'M' to go back to the menu");
                    question = Console.ReadLine();
                    if (question == "M" || question == "m")
                    {
                        Console.Clear();
                        menuOption = "M";
                    }
                    else
                    {
                        questionsList.Add(question);
                        Console.WriteLine("Please enter Answer " + (count + 1));
                        answer = Console.ReadLine();
                        answersList.Add(answer);
                        Console.WriteLine("Please type the difficulty (number of points awarded) for Question " + (count + 1));
                        difficultyString = Console.ReadLine();
                        while (!Int32.TryParse(difficultyString, out difficultyInt)) // This while loop is triggered if the user doesn't enter an integer
                        {
                            Console.WriteLine("Please type a valid number"); // It will then ask the user to enter an integer
                            difficultyString = Console.ReadLine(); // Store this in a string
                        } // And check again if the new value is an integer
                        difficultyList.Add(difficultyInt);
                        count++;
                        Quiz.Add(new QuizStructure()
                        {
                            Qs_question = question,
                            Qs_answer = answer,
                            Qs_difficulty = difficultyInt
                        });
                    }
                    

                }
                if (menuOption == "P")
                {
                    for (int i = 0; i < questionsList.Count; i++)
                    {
                        Console.WriteLine("Question " + (i + 1) + ": " + questionsList[i]);
                        Console.WriteLine("Answer " + (i + 1) + ": " + answersList[i]);
                        Console.WriteLine("Difficulty level for Question " + (i + 1) + ": " + difficultyList[i]);
                    }
                    Console.ReadLine();
                }
                if (menuOption == "W")
                {
                    string json = JsonConvert.SerializeObject(Quiz.ToArray(), Formatting.Indented); // Converts the Quiz list to an array, converts the array to a JSON object and enables formatting
                    File.WriteAllText(path, json); // Writes the JSON string to a file
                }
                if (menuOption == "R")
                {
                    using (StreamReader readJson = new StreamReader(path))
                    {
                        string json = readJson.ReadToEnd();
                        JArray jsonFile = JArray.Parse(json);
                        foreach (JObject obj in jsonFile.Children<JObject>()) // For each JSON record, loop around
                        {
                            JsonSerializerSettings settings = new JsonSerializerSettings(); // These are the settings for the serialiser
                            var rcvdData = JsonConvert.DeserializeObject<QuizStructure>(obj.ToString(), settings); // Deserialises the JSON record
                            questionsList.Add(rcvdData.Qs_question); // Adds the question to the questionsList
                            answersList.Add(rcvdData.Qs_answer); // Adds the answer to the answersList
                            difficultyList.Add(rcvdData.Qs_difficulty); // Adds the difficulty level to the difficultyList
                        }

                    }
                    Console.ReadLine();
                }
                if (menuOption == "C")
                {
                    points = 0; // Resets the user's points
                    Random rnd = new Random(); // Creates a new random object
                    numberofQuestions = questionsList.Count; // Sets an int for the total number of questions before any are removed
                    if (numberofQuestions != 0) // If there are questions left
                    {
                        for (int i = 0; i < numberofQuestions; i++) // For every question the user has submitted
                        {
                            int rndNumber = rnd.Next(0, questionsList.Count); // Picks a random number between 0 and the number of questions remaining
                            questionslistRandomised.Add(questionsList[rndNumber]); // Adds a random question to questionslistRandomised
                            questionsList.RemoveAt(rndNumber); // Removes the original question from the question list once it has been picked so questions aren't picked multiple times
                            answerslistRandomised.Add(answersList[rndNumber]); // Adds the answer from the random question to answerslistRandomised
                            answersList.RemoveAt(rndNumber); // Removes the original answer from the answer list once it has been picked so answers aren't picked multiple times
                            difficultylistRandomised.Add(difficultyList[rndNumber]); // Adds the difficulty from the random question to difficultylistRandomised
                            difficultyList.RemoveAt(rndNumber); // Removes the original difficulty level from the difficulty list once it has been picked so difficulty levels aren't picked multiple times
                        }
                        for (int i = 0; i < questionslistRandomised.Count; i++)
                        {
                            Console.WriteLine("Question " + (i + 1) + ": " + questionslistRandomised[i]);
                            inputtedAnswer = Console.ReadLine();
                            if (inputtedAnswer == answerslistRandomised[i])
                            {
                                points = points + difficultylistRandomised[i];
                                Console.WriteLine("Congratulations, your total number of points is " + points);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect. Press enter to move on to the next question.");
                                Console.ReadLine();
                            }
                        }

                        Console.WriteLine("You scored " + points + " points. Well done. Press enter to go back to the menu.");
                        Console.ReadLine();
                    }
                    else if (numberofQuestions == 0) // If there are no questions
                    {
                        Console.WriteLine("Please enter some questions and answers to create a quiz with. You can do this by entering them manually or loading them from a JSON file.");
                        Console.ReadLine(); // Ask the user to add some
                    }
                    

                }
                if (menuOption == "X")
                {
                    Environment.Exit(9);
                }
                Console.Clear();
            }
        }

    }        
    
}


