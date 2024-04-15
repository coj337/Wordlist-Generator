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

            // Replace s with $, o with 0 and a with @
            allWords.Add(word.Replace('s', '$').Replace('S', '$').Replace('o', '0').Replace('O', '0').Replace('a', '@').Replace('A', '@'));
            allWords.Add(word.Replace('s', '$').Replace('S', '$'));
            allWords.Add(word.Replace('o', '0').Replace('O', '0'));
            allWords.Add(word.Replace('a', '@').Replace('A', '@'));

            // Add basic numbers (up to 12 because it's common to use months in passwords)
            foreach(var num in Enumerable.Range(0, 12))
            {
                allWords.Add(word + num);

                // Also include 0 padded version for single digit numbers
                if (num < 10)
                {
                    allWords.Add(word + "0" + num);
                }

                // People will commonly use a number after some special chars
                allWords.Add(word + "@" + num);
                allWords.Add(word + "_" + num);
                allWords.Add(word + "!" + num);
                allWords.Add(word + "#" + num);
            }

            // Some common number combos
            allWords.Add(word + "123");
            allWords.Add(word + "456");
            allWords.Add(word + "420"); // Some people think they're funny
            allWords.Add(word + "69"); // Some are

            // Add special chars
            allWords.Add(word + "!");
            allWords.Add(word + "@");
            allWords.Add(word + "_");
            allWords.Add(word + "#");
        }

        // Add some extra permutations for all generated words with special chars after
        foreach(var word in allWords.ToList())
        {
            allWords.Add(word + "!");
            allWords.Add(word + "@");
            allWords.Add(word + "_");
            allWords.Add(word + "#");
        }

        // Filter invalid passwords (Less than 8 chars)
        allWords = allWords.Where(w => w.Length >= 8).Distinct().ToList();

        // Make sure there's no double ups
        allWords = allWords.Distinct().ToList();

        Console.WriteLine("Done :)");
        File.WriteAllLines("custom_wordlist.txt", allWords);
    }
}