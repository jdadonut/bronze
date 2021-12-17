

namespace Bronze.Lib
{
    public class Gelbooru : DapiClient
    {

        public override string BASE_URI {get {return "https://gelbooru.com/";}}
        public Gelbooru(string[] args, int count) : base(args, count) {}
    }
}