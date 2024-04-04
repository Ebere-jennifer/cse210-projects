using System;
using System.Collections.Generic;

// Abstraction with YouTube Videos
// In this program, I was able to write a program that keeps track of YouTube videos and the comments left on them. 
// I created 4 videos and set the appropriate values, and for each one of the videos i added a list of 3-5 comments (alongside
// the commenter's name and text). Afterwards, i placed each of these videos in a list. Below is the output of one of the videos and 
// comment. 

// Title: Video 4
// Author: Author 4
// Length (seconds): 100
// Number of comments: 4
// Comments:
//        Frank: This changed my perspective!
//        Femi: Could you provide references for further reading?
//        Veekee: Nice job, keep it up!
//        Tharmara: This is lovely! I never thought this existed until i watched your video.

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("Video 1", "Author 1", 120),
            new Video("Video 2", "Author 2", 180),
            new Video("Video 3", "Author 3", 150),
            new Video("Video 4", "Author 4", 100),
        };

        videos[0].AddComment("Jane", "Great video!");
        videos[0].AddComment("John", "I learned a lot.");
        videos[0].AddComment("Sam", "Could you make more videos like this?");

        videos[1].AddComment("Jenny", "Interesting content!");
        videos[1].AddComment("Liv", "Could you explain point 2 again?");
        videos[1].AddComment("Giovanni", "Looking forward to the next one.");
        videos[1].AddComment("Best", "I hope what you showed us is exactly what you do. Sigh!!");
        videos[1].AddComment("Alexis", "You tried. You can do better!");

        videos[2].AddComment("Racheal", "This changed my perspective!");
        videos[2].AddComment("Maggie", "Could you provide references for further reading?");
        videos[2].AddComment("Cassie", "Nice job, keep it up!");

        videos[3].AddComment("Frank", "This changed my perspective!");
        videos[3].AddComment("Femi", "Could you provide references for further reading?");
        videos[3].AddComment("Veekee", "Nice job, keep it up!");
        videos[3].AddComment("Tharmara", "This is lovely! I never thought this existed until i watched your video.");

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
