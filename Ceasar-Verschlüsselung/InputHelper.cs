using System;
using System.IO;

static class InputHelper
{ // AnzahlVersuche und Fehlversuche sind nicht Hardcoded, sondern werden als Parameter übergeben also sind Flexibel
    public static string FrageAuswahl(string prompt, string[] valid,int Fehlversuche) // Überprüft die Eingabe des Benutzers
    {
      
        int AnzahlVersuche = 0;
        while (AnzahlVersuche < Fehlversuche)
        {
            Console.Write(prompt); // Schreibt den Ersten Prompt definiert in Program.cs
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";
            foreach (var v in valid) // Es bekommt den Array wert aus Program.cs
            {
                if (input == v)
                    return input;
            }
            AnzahlVersuche++;
            Console.WriteLine($"Ungültige Eingabe. Noch {Fehlversuche - AnzahlVersuche} Versuch(e)."); // Gibt die Anzahl der Versuche zurück
        }
        return string.Empty;
    }

    public static bool FrageJaNein(string prompt, int Fehlversuche)
    {
        string Resultat = FrageAuswahl(prompt + " (ja/nein) ", new[] { "ja", "nein" }, Fehlversuche); //Rufft die Funktion FrageAuswahl auf und addiert JA NEIN gibt ein Boolean zurück
        return Resultat == "ja"; // Wenn JA zurückgegeben wird, ist es true, sonst false
    }

    public static string FrageDateiOderText(int Fehlversuche) //
    {
        bool useFile = FrageJaNein("Möchtest du eine Datei auslesen lassen?",3);
        if (useFile) // Wenn true, wird der Dateipfad abgefragt 
                    // Wenn false, wird der Text direkt abgefragt
        {
            int AnzahlVersuche = 0;
            while (AnzahlVersuche < Fehlversuche) // Ich Hardcode 3 Versuche, weil diese Funktion keine Parameter hat
            {
                Console.Write("Gib den Dateipfad und eine DateiName ein: ");
                string path = Console.ReadLine() ?? ""; // Liest den Dateipfad ein Wenn null, dann leerer String steht für aktuelle Ordner
                if (File.Exists(path)) // Überprüft ob die Datei existiert in dem Pfad
                {
                    return File.ReadAllText(path); // Liest den Inhalt der Datei und gibt ihn zurück
                }
                AnzahlVersuche++;
                Console.WriteLine($"Die Datei existiert nicht. Noch {Fehlversuche - AnzahlVersuche} Versuch(e).");
            }
            Console.WriteLine("Zu viele ungültige Eingaben. Bitte Text eingeben:"); // Test this part
            return Console.ReadLine() ?? "";
        }
        else // Wenn der Benutzer keinen Dateipfad eingeben möchte also Statement false
        {
            Console.WriteLine("Gib den Text ein:");
            return Console.ReadLine() ?? "";
        }
    }

    public static int FrageZahl(string prompt, int Fehlversuche)
    {
        int AnzahlVersuche = 0;
        while (AnzahlVersuche < Fehlversuche)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out int value) && value < 4) // Überprüft ob die Eingabe eine gültige Zahl ist mit Parse, wenn ja, wird sie zurückgegeben, 
                return value;
            AnzahlVersuche++;
            Console.WriteLine($"Ungültige Eingabe. Noch {Fehlversuche - AnzahlVersuche} Versuch(e)."); // ZEigt die Anzahl der verbleibenden Versuche an
        }
        throw new InvalidOperationException("Zu viele ungültige Eingaben für eine Zahl."); // Wenn while Statement fehlschlägt, wird eine Exception geworfen mein Eigen Error Message
    }
}
