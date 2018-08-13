using Baidu.Aip.Face;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Hang.BaiduAI.FaceWeb
{
    public class FaceApi
    {
        Face face;

        public void Init(string apiKey, string secretKey)
        {
            face = new Face(apiKey, secretKey)
            {
                Timeout = 5000,// 修改超时时间
            };
        }

        public DetectResult Detect(string imageBase64)
        {
            var imageType = "BASE64";

            // 如果有可选参数
            var options = new Dictionary<string, object>
            {
                {"face_field", "age,beauty,expression,faceshape,gender,glasses,landmark,race,quality,facetype"},
                {"max_face_num", 1},
                {"face_type", "LIVE"}
            };

            // 带参数调用人脸检测
            var jsonRet = face.Detect(imageBase64, imageType, options);
            return JsonConvert.DeserializeObject<DetectResult>(jsonRet.ToString());
        }

        public MatchResult Match(string cameraImageBase64, string idCardImageBase64)
        {
            var faces = new JArray
            {
                new JObject
                {
                    {"image", cameraImageBase64},
                    {"image_type", "BASE64"},
                    {"face_type", "LIVE"},
                    {"quality_control", "NORMAL"},
                    {"liveness_control", "NORMAL"},
                },
                new JObject
                {
                    {"image", idCardImageBase64},
                    {"image_type", "BASE64"},
                    {"face_type", "LIVE"},
                    {"quality_control", "LOW"},
                    {"liveness_control", "NONE"},
                }
            };

            var jsonRet = face.Match(faces);
            return JsonConvert.DeserializeObject<MatchResult>(jsonRet.ToString());
        }

        public string ReadImg(string img)
        {
            return Convert.ToBase64String(File.ReadAllBytes(img));
        }


    }
}
