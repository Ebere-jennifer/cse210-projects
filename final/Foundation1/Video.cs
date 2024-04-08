using System;
using System.Collections.Generic;

class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comment;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comment = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        _comment.Add(new Comment(commenterName, text));
    }

    public int GetNumberOfComments()
    {
        return _comment.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Title: " + _title);
        Console.WriteLine("Author: " + _author);
        Console.WriteLine("Length (seconds): " + _length);
        Console.WriteLine("Number of comments: " + GetNumberOfComments());
        Console.WriteLine("Comments:");
        foreach (var comment in _comment)
        {
            Console.WriteLine($"\t{comment._commenterName}: {comment._text}");
        }
        Console.WriteLine();
    }
}