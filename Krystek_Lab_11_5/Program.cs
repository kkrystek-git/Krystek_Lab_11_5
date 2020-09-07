using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Krystek_Lab_11_5
{
    // =========================================================================
    // Name:	Keith Krystek
    // Date:	09.06.2020
    // Class: SD1104-A - Full Stack C# Development - Sona Patel - 7 / 11 / 2020
    //
    // Assignment: Lab 11_5
    // =========================================================================

    // ADDITIONAL SQL CODE USED TO CLEAN UP SAKILA DATABASE.
    // =======================================================
    // USE SAKILA;
    // UPDATE film SET original_language_id = 1 WHERE original_language_id IS NULL;
    // UPDATE film SET description = '-' WHERE description IS NULL;
    // UPDATE film SET release_year = '1900' WHERE release_year IS NULL;
    // UPDATE film SET length = 1 WHERE length IS NULL;
    // UPDATE film SET rating = 'COOL' WHERE rating IS NULL;
    // UPDATE film SET special_features = 'NONE' WHERE special_features IS NULL;
    // GO


    class Program
	{
		static void Main(string[] args)
		{
            //Console.WriteLine("Hello World!");

            // Set database context to use Sakila database ().
            SakilaContext sakila = new SakilaContext();

            // Define new films to be added to Sakila database.
            Film war1917      = new Film(
                                         "1917", 
                                         "2019 War Drama By Director Sam Mendes", 
                                         "2019", 3, 5.99m, 179, 19.99m, "R"
                                         );

            Film joker        = new Film(
                                         "Joker",
                                         "Oscar-Nominated SuperHero Drama", 
                                         "2019", 3, 6.99m, 182, 23.99m, "R"
                                         );

            Film jarjarAbrams = new Film(
                                         "Star Wars: The Rise of SkyWalker",
                                         "Trash Disney Fanfic", 
                                         "2019", 3, 4.99m, 202, 21.99m, "PG-13"
                                         );

            // Using constructor to add new films to database.
            sakila.Film.Add(war1917);
            sakila.Film.Add(joker);
            sakila.Film.Add(jarjarAbrams);

            // Commit changes to database.
            sakila.SaveChanges();


            // Get entire list of films from the database to check success and show below.
            Film[] allfilms = sakila.Film.ToArray();

             // Filter to select new 2019 films.
            var newfilms = allfilms.Where(x => x.release_year == "2019");
           

            // Creation of dynamic HTML page showing new and existing films.

            StringBuilder html = new StringBuilder();
            html.Append("<html>\n");
            html.Append("  <head>");
            html.Append("    <title>Sakila Film Library</title>\n");
            html.Append("  </head>\n");
            html.Append("  <body>\n");

            // Show new films.
            html.Append("    <h1> New Films Coming Soon! </h1>\n");
            html.Append("      <ul>\n");
            foreach (var film in newfilms)
            {
                html.Append("<li>");
                html.Append(film.title + " " + film.description);
                html.Append("</li>");
            }
            html.Append("      </ul>\n");

            // Show exisiting films.
            html.Append("    <h1> Films Currently in Stock! </h1>\n");
            html.Append("      <ul>\n");
            foreach (var film in allfilms)
            {
                html.Append("<li>");
                html.Append(film.title + " " + film.description);
                html.Append("</li>");
            }
            html.Append("      </ul>\n");


            html.Append("  </body>\n");
            html.Append("</html>\n");

            // Write out dynamic HTML listing of films to .html file.
            string htmlFile = "C:\\weblogs\\newfilms.html";
            File.WriteAllText(htmlFile, html.ToString());


            //Optional opening new web page in Chrome.
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", @htmlFile);

        }
    }
}