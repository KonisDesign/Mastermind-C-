using System;

class Mastemind
{
    static Random rand = new Random(Guid.NewGuid().GetHashCode());
    static string letters = "rybogwp";
    static string[] result = new string[] { };
    static int placed = 0;
    static int stroke = 1;

    static void Main(string[] args)
    {
        result = randomnumber();
        Console.WriteLine("Mastermind");
        Console.WriteLine("Command available: rules, exit");
        Console.WriteLine("Enter 4 colors separated by a space (You can just write the first letter if you want)");
        Console.WriteLine("Red, Yellow, Blue, Orange, Green, White, Purple");
        while (placed != 4)
        {
            string valeurs = Console.ReadLine().ToLower();
            string[] mycolors = valeurs.Split(' ');
            Console.WriteLine(check(mycolors));
        }
    }

    static string check(string[] tab)
    {
        int misplaced = 0;
        placed = 0;

        if (tab[0] == "exit") {
            Environment.Exit(0);
        }

        if (tab[0] == "rules")
        {
            return "The object of MASTERMIND is to guess a secret code consisting of a series of 4 colored pegs. Each guest results in feedback narrowing down the possibilities of the code. The winner is the player who solves his opponent's secret code with fewer guesses.";
        }

        if (tab.Length != 4)
        {
            return "Please enter 4 colors separated by a space";
        }

        for (int i = 0; i < 4; i++)
        {
            if (tab[i][0] == 'r' || tab[i][0] == 'y' || tab[i][0] == 'b' || tab[i][0] == 'o' || tab[i][0] == 'g' || tab[i][0] == 'w' || tab[i][0] == 'p')
            {
                if (result[i][0] == tab[i][0])
                {
                    placed++;
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (result[i][0] == tab[j][0])
                        {
                            misplaced++;
                            break;
                        }
                    }
                }
            }
            else
            {
                return "Please put a valid color";
            }
        }
            

        if (placed == 4)
        {
            return "Vous win !";
        }
        else if (stroke == 10)
        {
            string answer = "";
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == "r")
                {
                    answer += "Red";
                }
                else if (result[i] == "y")
                {
                    answer += "Yellow";
                }
                else if (result[i] == "b")
                {
                    answer += "Blue";
                }
                else if (result[i] == "o")
                {
                    answer += "Orange";
                }
                else if (result[i] == "g")
                {
                    answer += "Green";
                }
                else if (result[i] == "w")
                {
                    answer += "White";
                }
                else if (result[i] == "p")
                {
                    answer += "Purple";
                }

                if (i < 3)
                {
                    answer += ", ";
                }
            }
            return "You loose, the result was " + answer;
        }
        else
        {
            stroke++;
            return "You have " + placed + " well placed and " + misplaced + " misplaced";
        }
    }

    static string[] randomnumber()
    {
        string[] res = new string[4];

        for (int i = 0; i < 4; i++)
        {
            string color = letters[rand.Next(letters.Length)].ToString();
            while (Array.IndexOf(res, color) != -1)
            {
                color = letters[rand.Next(letters.Length)].ToString();
            }
            res[i] = color;
        }

        return res;
    }
}