using System;
using System.IO;
using System.Linq;

namespace ImageCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("../upload");
            
            using (var context = new Context())
            {
                var blogImgs = string.Join(' ', context.Blogs.Select(p => p.EnglishContent), context.Blogs.Select(p => p.EnglishCover), context.Blogs.Select(p => p.ChineseContent), context.Blogs.Select(p => p.ChineseCover));
                var eventImgs = string.Join(' ', context.Events.Select(p => p.EnglishDetails), context.Events.Select(p => p.EnglishCover), context.Events.Select(p => p.ChineseDetails), context.Events.Select(p => p.ChineseCover));
                var newsImgs = string.Join(' ', context.News.Select(p => p.EnglishCover), context.News.Select(p => p.ChineseCover));
                var CandidateLogo = string.Join(' ', context.Candidates.Select(p => p.Logo));
                foreach (var file in files)
                {
                    var img = file.Split('\\').Reverse().ToArray()[0];
                    if (blogImgs.Contains(img)) continue;
                    if (eventImgs.Contains(img)) continue;
                    if (newsImgs.Contains(img)) continue;
                    if (CandidateLogo.Contains(img)) continue;
                    File.Delete(file);
                    Console.WriteLine($"已删除{img}");
                }
            }
            Console.WriteLine($"已完成");
            Console.ReadLine();
        }
    }
}
