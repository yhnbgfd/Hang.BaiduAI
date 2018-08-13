using System.Collections.Generic;

namespace Hang.BaiduAI.FaceWeb
{
    public class DetectResult
    {
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public Result result { get; set; }

        public class Result
        {
            public int face_num { get; set; }
            public IEnumerable<DetectFace> face_list { get; set; }

            public class DetectFace
            {
                public Location location { get; set; }

                public class Location
                {
                    public float left { get; set; }
                    public float top { get; set; }
                    public int width { get; set; }
                    public int height { get; set; }
                    public int rotation { get; set; }
                }
            }
        }
    }
}
