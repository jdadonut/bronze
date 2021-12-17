using System;
using System.Xml;
using Microsoft.Extensions.Caching.Memory;

using Bronze.Lib.Xml;

namespace Bronze.Lib
{
    public abstract class DapiClient : IDisposable
    {
        private HttpClient Client = new();
        private XmlReader Reader = XmlReader.Create(new MemoryStream(new byte[] { 0 }));
        static XmlReaderSettings _readerSettings = new XmlReaderSettings()
        {

            DtdProcessing = DtdProcessing.Parse
        };
        private string[] tags;
        private int count;
        public abstract string BASE_URI {get;}

        public DapiClient(string[] args, int count)
        {
            this.tags = args;
            this.count = count;
            // Console.WriteLine("[WARN] DapiClient should not be used itself unless you know what you're doing. BASE_URI is unset and that WILL crash the program if you try and use this without setting it.");
        }

        ~DapiClient()
        {
            Dispose();
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                Client?.Dispose();
                Reader?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<string> GetPosts()
        {
            var posts = new List<XmlReader>();
            
            XmlReader reader = XmlReader.Create(GetXmlStream(), _readerSettings);
            var nodes = reader.GetAttrsOfTypeNode("post", "file_url");
            Services.Cache.Set<List<string>>(tags, nodes);
            return nodes;
        }
        private Stream GetXmlStream()
        {
            var url = $"{this.BASE_URI}index.php?page=dapi&s=post&q=index&tags={string.Join('+',tags)}&limit={count}";
            var response = Client.GetAsync(url).Result;

            return response.Content.ReadAsStreamAsync().Result;
        }
    }
}