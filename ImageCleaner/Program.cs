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
                var blogImgs = string.Join(' ', context.Blogs.Select(p => p.Content));
                var eventImgs = string.Join(' ', context.Events.Select(p => p.Details));
                var eventCovers = string.Join(' ', context.Events.Select(p => p.Cover));
                var CandidateLogo = string.Join(' ', context.Candidates.Select(p => p.Logo));
                foreach (var file in files)
                {
                    var img = file.Split('\\').Reverse().ToArray()[0];
                    if (blogImgs.Contains(img)) continue;
                    if (eventImgs.Contains(img)) continue;
                    if (eventCovers.Contains(img)) continue;
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
