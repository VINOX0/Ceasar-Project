using System;

static class Crypto
{
    public static char VerschiebeBuchstabe(char c, int shift)
    {
        if (!char.IsLetter(c))
            return c;
        if (char.IsUpper(c))
        {
            return (char)('A' + (c - 'A' + shift + 26) % 26);
        }
        else
        {
            return (char)('a' + (c - 'a' + shift + 26) % 26);
        }
    }

    public static string CaesarVerschluesseln(string text, int shift)
    {
        var result = new System.Text.StringBuilder(text.Length);
        foreach (char c in text)
            result.Append(VerschiebeBuchstabe(c, shift));
        return result.ToString();
    }

    public static string Rot13(string text) => CaesarVerschluesseln(text, 13);

    public static string VerschluesselnNachMethode(string text, int method, int customShift = 0)
    {
        return method switch
        {
            1 => CaesarVerschluesseln(text, 3),
            2 => Rot13(text),
            3 => CaesarVerschluesseln(text, -5),
            _ => CaesarVerschluesseln(text, customShift)
        };
    }

    public static string EntschluesselnNachMethode(string text, int method, int customShift = 0)
    {
        return method switch
        {
            1 => CaesarVerschluesseln(text, -3),
            2 => Rot13(text),
            3 => CaesarVerschluesseln(text, 5),
            _ => CaesarVerschluesseln(text, -customShift)
        };
    }
}
