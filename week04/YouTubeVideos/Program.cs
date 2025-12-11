class Program
{
    static void Main(string[] args)
    {
        // Create list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Steak", "Chef Gordon", 480);
        video1.AddComment(new Comment("Alice", "This helped so much!"));
        video1.AddComment(new Comment("Bob", "Looks delicious."));
        video1.AddComment(new Comment("Clara", "Trying this tonight."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Japan Travel Guide", "Wanderer TV", 720);
        video2.AddComment(new Comment("Evan", "Beautiful!"));
        video2.AddComment(new Comment("Diana", "Adding Japan to my list."));
        video2.AddComment(new Comment("Mark", "I miss Tokyo."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Learn C# in 10 Minutes", "Ivan Akena", 600);
        video3.AddComment(new Comment("Sam", "Very clear explanation."));
        video3.AddComment(new Comment("Rachel", "Thanks for this video!"));
        video3.AddComment(new Comment("Tom", "Learning so much."));
        videos.Add(video3);

        // Display all videos
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
