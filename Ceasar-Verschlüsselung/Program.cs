using System;
using System.IO;

Console.WriteLine("Ceasarverschlüsselung");

string auswahl = InputHelper.FrageAuswahl("Möchtest du verschlüsseln oder entschlüsseln? ", new[] { "verschlüsseln", "entschlüsseln" },3);
if (string.IsNullOrEmpty(auswahl))
{
    Console.WriteLine("Zu viele ungültige Eingaben. Das Programm wird beendet.");
    return;
}

if (auswahl == "verschlüsseln")
{
    string text = InputHelper.FrageDateiOderText(3);
    int methode = InputHelper.FrageZahl("Gib die Verschlüsselungsmethode ein\n (1) Um 3 vorwärts in der Alphabet verschieben\n (2) Um 13 vorwärts Buchstaben in der Alphabet verschieben\n (3) Um 5 Buchstaben rückewärts in der Alphabet: ",3 );
    string result = Crypto.VerschluesselnNachMethode(text, methode);
    Console.Write("Der verschlüsselte Text lautet: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(result);
    Console.ResetColor();
     
    if (InputHelper.FrageJaNein("Möchtest du den verschlüsselten Text in eine Datei speichern?",3)) // Das ist Boolean Check ob true oder false wenn, false es beendet den Programm
    {
        Console.Write("Gib den Dateipfad zum Speichern ein (oder Enter für 'verschluesselt.txt'): ");
        string SpeicherPath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(SpeicherPath))
            SpeicherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "verschluesselt.txt");
        try
        {
            FileHelper.DateiSchreibenSicher(SpeicherPath, result);
            Console.WriteLine($"Verschlüsselter Text in '{SpeicherPath}' gespeichert.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Speichern fehlgeschlagen: " + ex.Message);
        }
    }



}
else if (auswahl == "entschlüsseln")
{
    string text = InputHelper.FrageDateiOderText(3);
    int methode = InputHelper.FrageZahl("Gib die Verschlüsselungsmethode ein\n (1) Um 3 vorwärts in der Alphabet verschieben\n (2) Um 13 vorwärts Buchstaben in der Alphabet verschieben\n (3) Um 5 Buchstaben rückewärts in der Alphabet: ",3);
    
    string result = Crypto.EntschluesselnNachMethode(text, methode);
    Console.Write("\nDer entschlüsselte Text lautet: ");
    Console.ForegroundColor = ConsoleColor.Green;  // Es wechselte die Console-Farbe zu Grün
    Console.WriteLine(result); // Der entschlüsselte Text wird angezeigt
    Console.ResetColor(); // Die Console-Farbe wird zurückgesetzt
    if (InputHelper.FrageJaNein("Möchtest du den verschlüsselten Text in eine Datei speichern?",3))
    {
        Console.Write("Gib den Dateipfad zum Speichern ein (oder Enter für 'entschluesselt.txt'): ");
        string SpeicherPath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(SpeicherPath))
            SpeicherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "verschluesselt.txt");
        try
        {
            FileHelper.DateiSchreibenSicher(SpeicherPath, result);
            Console.WriteLine($"Verschlüsselter Text in '{SpeicherPath}' gespeichert.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Speichern fehlgeschlagen: " + ex.Message);
        }
    }
}
else
{
    Console.WriteLine("Ungültige Eingabe");
}