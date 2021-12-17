// See https://aka.ms/new-console-template for more information
using Bronze.Lib;
using Galaxy;

GalaxyServer server = new(8080);
Gelbooru sb = new Gelbooru(new string[]{"slime_girl", "rating:safe"}, 1000);
// HttpClient cl = new();
// server.Get("/", (httpContext) => {
//     if (!httpContext.TryWriteBuffer(cl.GetByteArrayAsync(Bronze.Lib.Random.From<string>(sb.GetPosts())).Result))
//     System.Console.WriteLine("Issue: Buffer not written.");
// });
// server.Start();
ParallelDownloadPool dl = new(8);
foreach(string uri in sb.GetPosts())
{
    dl.AddToQueue(uri, Path.Join("out", Path.GetFileName(uri)));
}
dl.WaitToFinish().GetAwaiter().GetResult();
Console.WriteLine("");