namespace Quiz_Game
{
    internal class Program
    {
        static string[] questions = new string[]
        {
            "What keyword is used to create an object?",
            "Which type stores whole numbers?",
            "What access modifier allows inheritance only?",
            "What keyword is used to handle exceptions?",
            "Which interface supports iteration?",
            "What collection stores key-value pairs?",
            "What keyword prevents inheritance?",
            "Which type represents true or false?",
            "What keyword is used to exit a loop?",
            "Which method converts string to integer?"
        };

        static string[] modelAnswers = new string[]
        {
            "new",
            "int",
            "protected",
            "try",
            "IEnumerable",
            "Dictionary",
            "sealed",
            "bool",
            "break",
            "Parse"
        };

        static string[] userAnswers = new string[modelAnswers.Length];



        static void Main(string[] args)
        {


            quizGameStart();

        }

        static void quizGameStart()
        {
            Console.WriteLine("Quiz Game");
            Console.WriteLine("Please, Answer the following questions one by one");
            getUserAnswers();
            DisplayResults();
        }

        static void getUserAnswers()
        {
            for (int i = 0; i < questions.Length; i++)
            {

                Console.WriteLine($"Q{i+1}. {questions[i]}");
                Console.Write("Enter Your answer: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    userAnswers[i] = "No Answer";
                }
                else {
                    userAnswers[i] = input.Trim();
                }
                Console.WriteLine();
            }
            

        }

        static void DisplayResults()
        {
            double correctedAnswers = 0;
            double totalAnswers = modelAnswers.Length;

            for (int i = 0; i < userAnswers.Length; i++)
            {

                if (userAnswers[i].Equals(modelAnswers[i], StringComparison.OrdinalIgnoreCase))
                {
                    correctedAnswers++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Q{i+1}. Correct!");
                    Console.ResetColor();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Q{i+1}. Wrong!");
                    Console.ResetColor();

                    Console.WriteLine($"Your answer is: {userAnswers[i]}");
                    Console.WriteLine($"Correct Answer is: {modelAnswers[i]}");
                }
                Console.WriteLine("-------------------");
            }
            Console.WriteLine("=========================");

            Console.WriteLine($"Your corrected answer are {correctedAnswers} of {totalAnswers}");
            Console.WriteLine($"Your Final Grade: {(correctedAnswers / totalAnswers) * 100:F2}%");
        }

        
    }
}
