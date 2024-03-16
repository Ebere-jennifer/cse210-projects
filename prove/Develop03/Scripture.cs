using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        this._reference = reference;
        this._words = text.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(word => new Word(word))
                          .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        List<Word> wordsToHide = _words.Where(word => !word.IsHidden()).OrderBy(word => rand.Next()).Take(numberToHide).ToList();
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()} {string.Join(" ", _words.Select(word => word.GetDisplayText()))}.";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
