

namespace Bronze.Lib
{
    public class Safebooru : DapiClient
    {

        public override string BASE_URI {get {return "https://safebooru.org/";}}

        public Safebooru(string[] args, int count) : base(args, count) {}
        
    }
}