namespace Hang.BaiduAI.FaceWeb
{
    public class MatchResult
    {
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public Result result { get; set; }


        public class Result
        {
            public float score { get; set; }
        }
    }
}
