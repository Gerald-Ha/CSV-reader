using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // ASCII-Art
        string asciiArt = @"
                     ⠸⣷⣦⠤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⢀⣀⣠⣤⠀⠀⠀
    ⠀                 ⠙⣿⡄⠈⠑⢄⠀⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⣀⠔⠊⠉⣿⡿⠁⠀⠀⠀
    ⠀⠀                  ⠈⠣⡀⠀⠀⠑⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠊⠁⠀⠀⣰⠟⠀⠀⠀⣀⣀
    ⠀⠀⠀                 ⠀ ⠈⠢⣄⠀⡈⠒⠊⠉⠁⠀⠈⠉⠑⠚⠀⠀⣀⠔⢊⣠⠤⠒⠊⠉⠀⡜
    ⠀⠀⠀⠀⠀⠀⠀                 ⠀⡽⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠩⡔⠊⠁⠀⠀⠀⠀⠀⠀⠇
    ⠀⠀⠀⠀⠀⠀⠀⠀                  ⡇⢠⡤⢄⠀⠀⠀⠀⠀⡠⢤⣄⠀⡇⠀⠀⠀⠀⠀⠀⠀⢰⠀
    ⠀⠀⠀⠀⠀⠀⠀                  ⢀⠇⠹⠿⠟⠀⠀⠤⠀⠀⠻⠿⠟⠀⣇⠀⠀⡀⠠⠄⠒⠊⠃⠀
    ⠀⠀⠀⠀⠀⠀⠀                  ⢸⣿⣿⡆⠀⠰⠤⠖⠦⠴⠀⢀⣶⣿⣿⠀⠙⢄⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀                  ⠀⠀⢻⣿⠃⠀⠀⠀⠀⠀⠀⠀⠈⠿⡿⠛⢄⠀⠀⠱⣄⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀⠀⠀                  ⢸⠈⠓⠦⠀⣀⣀⣀⠀⡠⠴⠊⠹⡞⣁⠤⠒⠉⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀                  ⣠⠃⠀⠀⠀⠀⡌⠉⠉⡤⠀⠀⠀⠀⢻⠿⠆⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀                  ⠰⠁⡀⠀⠀⠀⠀⢸⠀⢰⠃⠀⠀⠀⢠⠀⢣⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀                   ⠀⢶⣗⠧⡀⢳⠀⠀⠀⠀⢸⣀⣸⠀⠀⠀⢀⡜⠀⣸⢤⣶⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀                   ⠈⠻⣿⣦⣈⣧⡀⠀⠀⢸⣿⣿⠀⠀⢀⣼⡀⣨⣿⡿⠁⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀                  ⠈⠻⠿⠿⠓⠄⠤⠘⠉⠙⠤⢀⠾⠿⣿⠟⠋"
;

        // Hier wird die Farbe definiert
        Console.ForegroundColor = ConsoleColor.Yellow;

        // ASCII-Art anzeigen
        Console.WriteLine(asciiArt);

        // Farbe zurücksetzen
        Console.ResetColor();

        Console.WriteLine(); // Leerzeile
        Console.WriteLine(); // Leerzeile 2

        try
        {
            Console.WriteLine("Bitte geben Sie den vollständigen Pfad zur CSV-Datei ein:");
            string filePath = Console.ReadLine().Trim();

            if (File.Exists(filePath))
            {
                // Liest den gesamten Inhalt der CSV-Datei, den man eingibt.
                string[] lines = File.ReadAllLines(filePath);

                // Bestimme die maximale Breite jeder Spalte :D
                int numColumns = lines[0].Split(',').Length;
                int[] columnWidths = new int[numColumns];

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    // Aktualisiere die Breite jeder Spalte !
                    for (int i = 0; i < numColumns; i++)
                    {
                        if (i < parts.Length)
                        {
                            if (parts[i].Length > columnWidths[i])
                            {
                                columnWidths[i] = parts[i].Length;
                            }
                        }
                    }
                }

                // Daten Ausgabe
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    for (int i = 0; i < numColumns; i++)
                    {
                        if (i < parts.Length)
                        {
                            Console.Write(parts[i].PadRight(columnWidths[i] + 2)); // PadRight fügt Leerzeichen hinzu, um es lesbarer zu machen.
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Die angegebene Datei existiert nicht.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ein Fehler ist aufgetreten: " + ex.Message);
        }
    }
}
