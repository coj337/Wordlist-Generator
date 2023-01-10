namespace WordlistGenerator;

internal class Program
{
    static void Main(string[] args)
    {
        var allWords = new List<string>();
        var baseWords = new List<string>()
        {
            "Password", "Welcome", "Covid", // Dumb Passwords
            "Winter", "Autumn", "Fall", "Summer", "Spring", // Seasons
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", // Months
            //"Master", "Dragon", "Monkey", "Shadow", "Qwerty", "Iloveyou", "Thankyou", "Baseball", "Football", "Letmein", // Common Words
            //"Mustang", "Access", "Superman", "Batman", "Qwertyuiop", "Jesus", "Ninja", "God", // More common words
            "Richmond", "Collingwood", "Essendon", "Carlton", "Geelong", "Swans", "Lions", "Saints", // AFL Teams
            "Dockers", "Bulldogs", "Eagles", "Hawthorn", "Hawks", "Kangaroos", "Giants", "Suns", // AFL Teams
            "Melbourne", "Sydney", "Perth", "Adelaide", "Brisbane", "Fremantle" // Cities
        };

        foreach(var word in baseWords)
        {
            // Add a word for the last 3 years
            var year = DateTime.Now.Year;
            allWords.Add(word + (year-1));
            allWords.Add(word + year);
            allWords.Add(word + year + "!");
            allWords.Add(word + "@" + year);
            allWords.Add(word + "_" + year);

            // Another for each of them with only last 2 numbers for the year
            allWords.Add(word + (year - 1).ToString()[2..]);
            allWords.Add(word + year.ToString()[2..]);

            // Replace s's with $'s and o's with 0's
            allWords.Add(word.Replace('s', '$').Replace('S', '$').Replace('o', '0').Replace('O', '0'));
            allWords.Add(word.Replace('s', '$').Replace('S', '$'));
            allWords.Add(word.Replace('o', '0').Replace('O', '0'));
            allWords.Add(word.Replace('a', '@').Replace('A', '@'));

            // Add basic numbers
            allWords.Add(word + "1");
            allWords.Add(word + "2");
            allWords.Add(word + "3");
            allWords.Add(word + "123");

            // Add exclamation marks
            allWords.Add(word + "!");

            // Add numbers and special chars
            allWords.Add(word + "1!");
            allWords.Add(word + "123!");
            allWords.Add(word + "@1");
            allWords.Add(word + "_1");
        }

        // Filter invalid passwords (Less than 8 chars)
        allWords = allWords.Where(w => w.Length >= 8).ToList();

        Console.WriteLine("Done :)");
        File.WriteAllLines("custom_wordlist.txt", allWords);
    }
}