using System.Collections.Generic;

namespace Hang.BaiduAI.FaceWeb
{
    public class DetectResult
    {
        public int face_num { get; set; }
        public IEnumerable<DetectFace> face_list { get; set; }
    }

    public class DetectFace
    {
        public string face_token { get; set; }
    }
}
