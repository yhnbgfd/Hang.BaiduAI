using System;
using System.Runtime.InteropServices;

namespace Hang.BaiduAI.Face
{
    public class OfflineSDKWrapper
    {
        private const string dll = @"BaiduFaceApi.dll";

        /// <summary>
        /// 获取设备指纹
        /// </summary>
        /// <returns></returns>
        [DllImport(dll, EntryPoint = "get_device_id", CallingConvention = CallingConvention.StdCall)]
        public static extern string get_device_id();
        /// <summary>
        /// 人脸对比接口（本接口中的image_type为1表示base64图片编码，为2表示文件路径，为3表示face_token）
        /// </summary>
        /// <param name="image1">需要对比的第一张图片，小于10M</param>
        /// <param name="img_type1">图片1类型，必选择以下三种形式之一
        /// BASE64：图片的base64值；
        /// FACE_FILE：图片的本地文件路径地址；
        /// FACE_TOKEN：face_token 人脸标识；</param>
        /// <param name="image2">需要对比的第二张图片，小于10M</param>
        /// <param name="img_type2">图片2类型，必选择以下三种形式之一
        /// BASE64：图片的base64值；
        /// FACE_FILE：图片的本地文件路径地址；
        /// FACE_TOKEN：face_token 人脸标识；</param>
        /// <returns></returns>
        [DllImport(dll, EntryPoint = "match")]
        public static extern IntPtr match(string image1, int img_type1, string image2, int img_type2);
        /// <summary>
        /// 人脸识别，提供1：N查找 (本接口中的image_type为1表示base64图片编码，为2表示文件路径，为3表示face_token)
        /// </summary>
        /// <param name="image"></param>
        /// <param name="img_type"></param>
        /// <param name="group_id_list"></param>
        /// <param name="user_id"></param>
        /// <param name="user_top_num"></param>
        /// <returns></returns>
        [DllImport(dll, EntryPoint = "identify")]
        public static extern IntPtr identify([In][MarshalAs(UnmanagedType.LPStr)]string image, int img_type, [In][MarshalAs(UnmanagedType.LPStr)]string group_id_list, [In][MarshalAs(UnmanagedType.LPStr)]string user_id, int user_top_num);
        /// <summary>
        /// 提取人脸特征值，为512个浮点值，已加密 (本接口 image_type 为1表示base64图片编码，为2表示文件路径)
        /// </summary>
        /// <param name="image">图片信息，数据大小小于10M</param>
        /// <param name="img_type">图片类型，必选择以下2种形式之一(image_type值为1或2，分别对应 BASE64：图片的base64值； FACE_FILE：图片的本地文件路径地址；)</param>
        /// <param name="feature">提取特征值，通过传入const float*指针的引用，来返回提取的人脸特征值</param>
        /// <returns></returns>
        [DllImport(dll, EntryPoint = "get_face_feature")]
        public static extern int get_face_feature([In()] [MarshalAs(UnmanagedType.LPStr)] string image, int img_type, ref float feature);
        /// <summary>
        /// 近红外(NIR)活体检测接口（通过传入图片）
        /// </summary>
        /// <param name="image">需要检测的图片，小于10M, 图片类型根据image_type参数定</param>
        /// <param name="img_type">图片类型，必选择以下2种形式之一。image_type为1代表BASE64为2代表FACE_FILE。
        /// BASE64：图片的base64值；
        /// FACE_FILE：图片的本地文件路径地址</param>
        /// <returns></returns>
        [DllImport(dll, EntryPoint = "ir_liveness_check")]
        public static extern IntPtr ir_liveness_check([In][MarshalAs(UnmanagedType.LPStr)]string image, int img_type);
        /// <summary>
        /// 可见光(RGB)活体检测接口（通过传入图片）
        /// </summary>
        /// <param name="image">需要检测的图片，小于10M,图片类型根据image_type参数定</param>
        /// <param name="img_type">图片类型，必选择以下2种形式之一。Image_type为1代表BASE64为2代表FACE_FILE。
        /// BASE64：图片的base64值；
        /// FACE_FILE：图片的本地文件路径地址；</param>
        /// <returns></returns>
        [DllImport(dll, EntryPoint = "rgb_liveness_check")]
        public static extern IntPtr rgb_liveness_check([In][MarshalAs(UnmanagedType.LPStr)]string image, int img_type);


        [StructLayout(LayoutKind.Sequential)]
        public struct FaceInfo
        {
            /// <summary>
            /// rectangle width
            /// </summary>
            public float mWidth;
            /// <summary>
            /// rectangle tilt angle [-45 45] in degrees
            /// </summary>
            public float mAngle;
            /// <summary>
            /// rectangle center y
            /// </summary>
            public float mCenter_y;
            /// <summary>
            /// rectangle center x
            /// </summary>
            public float mCenter_x;
            public float mConf;
        }
    }
}
