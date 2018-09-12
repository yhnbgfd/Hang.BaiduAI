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
        private Face _face;

        public void Init(string apiKey, string secretKey)
        {
            _face = new Face(apiKey, secretKey)
            {
                Timeout = 5000,// 修改超时时间
            };
        }

        public DetectResult Detect(string imageBase64)
        {
            // 如果有可选参数
            var options = new Dictionary<string, object>
            {
                {"face_field", "age,beauty,expression,faceshape,gender,glasses,landmark,race,quality,facetype"},
                {"max_face_num", 1},
                {"face_type", "LIVE"}
            };

            // 带参数调用人脸检测
            var imageType = "BASE64";
            var jsonRet = _face.Detect(imageBase64, imageType, options);
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
                    {"face_type", "LIVE"},//人脸的类型 LIVE表示生活照：通常为手机、相机拍摄的人像图片、或从网络获取的人像图片等，IDCARD表示身份证芯片照：二代身份证内置芯片中的人像照片， WATERMARK表示带水印证件照：一般为带水印的小图，如公安网小图 CERT表示证件照片：如拍摄的身份证、工卡、护照、学生证等证件图片 默认LIVE
                    {"quality_control", "NORMAL"},//图片质量控制 NONE: 不进行控制 LOW:较低的质量要求 NORMAL: 一般的质量要求 HIGH: 较高的质量要求 默认 NONE
                    {"liveness_control", "NORMAL"},//活体检测控制 NONE: 不进行控制 LOW:较低的活体要求(高通过率 低攻击拒绝率) NORMAL: 一般的活体要求(平衡的攻击拒绝率, 通过率) HIGH: 较高的活体要求(高攻击拒绝率 低通过率) 默认NONE
                },
                new JObject
                {
                    {"image", idCardImageBase64},
                    {"image_type", "BASE64"},
                    {"face_type", "IDCARD"},
                    {"quality_control", "LOW"},
                    {"liveness_control", "NONE"},
                }
            };

            var jsonRet = _face.Match(faces);
            return JsonConvert.DeserializeObject<MatchResult>(jsonRet.ToString());
        }

        public string ReadImg(string img)
        {
            return Convert.ToBase64String(File.ReadAllBytes(img));
        }

    }
}
