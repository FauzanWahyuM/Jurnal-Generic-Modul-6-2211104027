using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul6_2211104027
{
    class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            if (title == null) throw new ArgumentNullException("Title tidak boleh null.");
            if (title.Length > 200) throw new ArgumentException("Title tidak boleh lebih dari 200 karakter.");

            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            if (count < 0) throw new ArgumentException("Play count tidak boleh negatif.");
            if (count > 25000000) throw new ArgumentException("Play count maksimal 25.000.000 per panggilan.");

            checked
            {
                try
                {
                    playCount += count;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: Play count melebihi batas maksimum integer.");
                }
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Play Count: {playCount}\n");
        }

        public int GetPlayCount()
        {
            return playCount;
        }

        public string GetTitle()
        {
            return title;
        }
    }

    class SayaTubeUser
    {
        private int id;
        private string Username;
        private List<SayaTubeVideo> uploadedVideos;

        public SayaTubeUser(string username)
        {
            if (username == null) throw new ArgumentNullException("Username tidak boleh null.");
            if (username.Length > 100) throw new ArgumentException("Username tidak boleh lebih dari 100 karakter.");

            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.Username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public void AddVideo(SayaTubeVideo video)
        {
            if (video == null) throw new ArgumentNullException("Video tidak boleh null.");
            if (video.GetPlayCount() >= int.MaxValue) throw new ArgumentException("Play count video terlalu besar.");

            uploadedVideos.Add(video);
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var video in uploadedVideos)
            {
                total += video.GetPlayCount();
            }
            return total;
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {Username}");
            for (int i = 0; i < Math.Min(uploadedVideos.Count, 8); i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                SayaTubeUser user = new SayaTubeUser("Fauzan Wahyu M");

                List<string> filmTitles = new List<string>
                {
                    "Review Film Black Panther oleh Fauzan Wahyu M",
                    "Review Film Avengers: Endgame oleh Fauzan Wahyu M",
                    "Review Film Iron Man oleh Fauzan Wahyu M",
                    "Review Film Thor: Ragnarok oleh Fauzan Wahyu M",
                    "Review Film Spider-Man: No Way Home oleh Fauzan Wahyu M",
                    "Review Film Spider-Man: Homecoming oleh Fauzan Wahyu M",
                    "Review Film Guardians of the Galaxy oleh Fauzan Wahyu M",
                    "Review Film Spider-Man: Far from Home oleh Fauzan Wahyu M",
                    "Review Film Marvel's the Avengers oleh Fauzan Wahyu M",
                    "Review Film Shang-Chi and the Legend of the Ten Rings oleh Fauzan Wahyu M"
                };

                foreach (var title in filmTitles)
                {
                    SayaTubeVideo video = new SayaTubeVideo(title);
                    user.AddVideo(video);
                    try
                    {
                        video.IncreasePlayCount(25000000);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }

                user.PrintAllVideoPlaycount();
                Console.WriteLine($"Total play count: {user.GetTotalVideoPlayCount()}");

                // Uji overflow
                SayaTubeVideo testVideo = new SayaTubeVideo("Test Overflow Video");
                try
                {
                    for (int i = 0; i < 100; i++)
                    {
                        testVideo.IncreasePlayCount(int.MaxValue / 10);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unhandled Exception: {e.Message}");
            }
        }
    }
}
