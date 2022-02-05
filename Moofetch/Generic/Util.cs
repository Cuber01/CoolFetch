using System;

public static class Util
{
    public static string getTextBetweenStrings(string fullText, string startPoint, string endPoint)
    {
        int from = fullText.IndexOf(startPoint) + startPoint.Length;
        int to = fullText.LastIndexOf(endPoint);

        return fullText.Substring(from, to - from);
    }
}