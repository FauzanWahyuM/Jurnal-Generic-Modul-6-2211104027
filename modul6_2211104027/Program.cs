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
            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            playCount += count;
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
            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.Username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public void AddVideo(SayaTubeVideo video)
        {
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
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            }
        }
    }

    class Program
    {
        static void Main()
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
                video.IncreasePlayCount(new Random().Next(1000, 5000));
            }

            user.PrintAllVideoPlaycount();
            Console.WriteLine($"Total play count: {user.GetTotalVideoPlayCount()}");
        }
    }
}
