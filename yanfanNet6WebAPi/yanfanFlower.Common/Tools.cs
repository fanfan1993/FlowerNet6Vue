using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanfanFlower.Common
{
    public class Tools
    {
        public static string CreateValidateString()
        {
            //准备一组供验证码展示的数据
            string chars = "abcdefghijkimnopqrstuvwxyz";
            Random r = new(DateTime.Now.Millisecond);
            string validateString = "";
            int length = 4;
            for (int i = 0; i < length; i++)
            {
                validateString += chars[r.Next(chars.Length)];
            }
            return validateString;
        }

        public static Byte[] CreateValidateCodeBuffer(string validateCode)
        {
            //bmp->位图
            //1.创建画布，设直画布的长宽
            using Bitmap bitmap = new(200, 60);

            //2.创建画笔，告诉画笔在哪个画市上画画
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);//用白色覆盖画布，并清除画布上所有的内容

            //设置字体的参数（设字体的名称，大小，粗细以及斜体
            Font font = new("微软雅黑", 12, FontStyle.Bold | FontStyle.Italic);
            //通退graphics，MeasureString方法舒算字符串的长度
            var size = graphics.MeasureString(validateCode, font);
            //通遇长度生成新的布
            //1.98 Convert.ToInt32(1.98)= 1
            //向上取整：天花板函数：向下取整：地板函数
            using Bitmap bitmapText = new(Convert.ToInt32(Math.Ceiling(size.Width)), Convert.ToInt32(Math.Ceiling(size.Height)));
            //将文字烹入，生成固片
            Graphics graphicsText = Graphics.FromImage(bitmapText);


            //3.配置画图参数
            //（/3.1设置颜色刷范围参数
            RectangleF rf = new(0, 0, bitmap.Width, bitmap.Height);
            //3.2设置刷子的颜色（设百为渐变）
            LinearGradientBrush brush = new(rf, Color.Red, Color.DarkBlue, 1.2f, true);

            //4.将字符串绘制到场景中
            graphicsText.DrawString(validateCode, font, brush, 0, 0);

            graphics.DrawImage(bitmapText, 10, 10, 190, 50);
  
            //5.1创建一个用于保存图片的缓冲器
            MemoryStream memoryStream = new();
            //5.2把图片保存到缓冲区
            bitmap.Save(memoryStream, ImageFormat.Jpeg);
            //6.这个时候图片已经在缓冲区了，bitmap对象自然就没有用了，卸磨杀驴之
            bitmap.Dispose();
            return memoryStream.ToArray();
        }
    }

}
