namespace WordlistGenerator;

internal class Program
{
    static void Main(string[] args)
    {
        var allWords = new List<string>();
        var baseWords = File.ReadAllLines("base_words.txt");

        foreach(var word in baseWords)
        {
            // Add a word for last, this and next year
            var year = DateTime.Now.Year;
            allWords.Add(word + (year-1));
            allWords.Add(word + year);
            allWords.Add(word + (year+1));
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