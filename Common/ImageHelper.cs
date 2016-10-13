using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;


namespace Common
{

    public static class ImageHelper
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        /// <summary> 
        /// 按照比例缩小图片 
        /// </summary> 
        /// <param name="srcImage">要缩小的图片</param> 
        /// <param name="percent">缩小比例</param> 
        /// <returns>缩小后的结果</returns> 
        public static Bitmap PercentImage(Image srcImage, double percent)
        {
            // 缩小后的高度 
            int newH = int.Parse(Math.Round(srcImage.Height * percent).ToString());
            // 缩小后的宽度 
            int newW = int.Parse(Math.Round(srcImage.Width * percent).ToString());
            try
            {
                // 要保存到的图片 
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量 
                g.InterpolationMode = InterpolationMode.Default;
                g.DrawImage(srcImage, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary> 
        /// 按照指定大小缩放图片 
        /// </summary> 
        /// <param name="srcImage"></param> 
        /// <param name="iWidth"></param> 
        /// <param name="iHeight"></param> 
        /// <returns></returns> 
        public static Bitmap SizeImage(Image srcImage, int iWidth, int iHeight)
        {
            try
            {
                // 要保存到的图片 
                Bitmap b = new Bitmap(iWidth, iHeight);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量 
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(srcImage, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary> 
        /// 按照指定大小缩放图片，但是为了保证图片宽高比自动截取 
        /// </summary> 
        /// <param name="srcImage"></param> 
        /// <param name="iWidth"></param> 
        /// <param name="iHeight"></param> 
        /// <returns></returns> 
        public static Bitmap SizeImageWithOldPercent(Image srcImage, int iWidth, int iHeight)
        {
            try
            {
                // 要截取图片的宽度（临时图片） 
                int newW = srcImage.Width;
                // 要截取图片的高度（临时图片） 
                int newH = srcImage.Height;
                // 截取开始横坐标（临时图片） 
                int newX = 0;
                // 截取开始纵坐标（临时图片） 
                int newY = 0;
                // 截取比例（临时图片） 
                double whPercent = 1;
                whPercent = ((double)iWidth / (double)iHeight) * ((double)srcImage.Height / (double)srcImage.Width);
                if (whPercent > 1)
                {
                    // 当前图片宽度对于要截取比例过大时 
                    newW = int.Parse(Math.Round(srcImage.Width / whPercent).ToString());
                }
                else if (whPercent < 1)
                {
                    // 当前图片高度对于要截取比例过大时 
                    newH = int.Parse(Math.Round(srcImage.Height * whPercent).ToString());
                }
                if (newW != srcImage.Width)
                {
                    // 宽度有变化时，调整开始截取的横坐标 
                    newX = Math.Abs(int.Parse(Math.Round(((double)srcImage.Width - newW) / 2).ToString()));
                }
                else if (newH == srcImage.Height)
                {
                    // 高度有变化时，调整开始截取的纵坐标 
                    newY = Math.Abs(int.Parse(Math.Round(((double)srcImage.Height - (double)newH) / 2).ToString()));
                }
                // 取得符合比例的临时文件 
                Bitmap cutedImage = CutImage(srcImage, newX, newY, newW, newH);
                // 保存到的文件 
                Bitmap b = new Bitmap(iWidth, iHeight);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量 
                g.InterpolationMode = InterpolationMode.Default;
                g.DrawImage(cutedImage, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(0, 0, cutedImage.Width, cutedImage.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式,HW:指定高宽缩放（可能变形）, W:指定宽，高按比例,H:指定高，宽按比例,Cut:指定高宽裁减（不变形）,DB:等比缩放（不变形，如果高大按高，宽大按宽缩放）   </param> 
        public static bool MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode = "W")
        {
            System.Drawing.Image originalImage = null;
            System.Drawing.Image bitmap = null;
            System.Drawing.Graphics g = null;

            string error = "";
            try
            {

                if (File.Exists(originalImagePath) == true)
                {
                    Tool.CreateFolder(thumbnailPath);
                    originalImage = System.Drawing.Image.FromFile(originalImagePath);
                    int towidth = width;
                    int toheight = height;

                    int x = 0;
                    int y = 0;
                    int ow = originalImage.Width;
                    int oh = originalImage.Height;
                    string type = Tool.GetPicType(originalImagePath).ToUpper();
                    switch (mode)
                    {
                        case "HW"://指定高宽缩放（可能变形） 
                            break;
                        case "W"://指定宽，高按比例 
                            toheight = originalImage.Height * width / originalImage.Width;
                            break;
                        case "H"://指定高，宽按比例
                            towidth = originalImage.Width * height / originalImage.Height;
                            break;
                        case "Cut"://指定高宽裁减（不变形） 
                            if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                            {
                                oh = originalImage.Height;
                                ow = originalImage.Height * towidth / toheight;
                                y = 0;
                                x = (originalImage.Width - ow) / 2;
                            }
                            else
                            {
                                ow = originalImage.Width;
                                oh = originalImage.Width * height / towidth;
                                x = 0;
                                y = (originalImage.Height - oh) / 2;
                            }
                            break;
                        case "DB"://等比缩放（不变形，如果高大按高，宽大按宽缩放） 
                            if ((double)originalImage.Width / (double)towidth < (double)originalImage.Height / (double)toheight)
                            {
                                toheight = height;
                                towidth = originalImage.Width * height / originalImage.Height;
                            }
                            else
                            {
                                towidth = width;
                                toheight = originalImage.Height * width / originalImage.Width;
                            }
                            break;
                        default:
                            break;
                    }

                    //新建一个bmp图片
                    bitmap = new System.Drawing.Bitmap(towidth, toheight);

                    //新建一个画板
                    g = System.Drawing.Graphics.FromImage(bitmap);

                    //设置高质量插值法
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                    //设置高质量,低速度呈现平滑程度
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    //清空画布并以透明背景色填充
                    g.Clear(System.Drawing.Color.Transparent);

                    //在指定位置并且按指定大小绘制原图片的指定部分
                    g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                    new System.Drawing.Rectangle(x, y, ow, oh),
                    System.Drawing.GraphicsUnit.Pixel);
                    //保存缩略图
                    switch (type)
                    {
                        case ".JPG":
                            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".BMP":
                            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case ".GIF":
                            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case ".PNG":
                            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }
                }
                error = "正常";
            }
            catch (Exception ex)
            { error = ex.Message; }
            finally
            {
                if (originalImage != null) originalImage.Dispose();
                if (bitmap != null) bitmap.Dispose();
                if (g != null) g.Dispose();
            }
            if (error == "正常")
            {
                return true;
            }
            else
                return false;
        }
        ///   <summary> 
        ///   从图片中截取部分生成新图 
        ///   </summary> 
        ///   <param   name= "sFromFilePath "> 原始图片 </param> 
        ///   <param   name= "saveFilePath "> 生成新图 </param> 
        ///   <param   name= "width "> 截取图片宽度 </param> 
        ///   <param   name= "height "> 截取图片高度 </param> 
        ///   <param   name= "spaceX "> 截图图片X坐标 </param> 
        ///   <param   name= "spaceY "> 截取图片Y坐标 </param> 
        public static void CaptureImage(string FromFilePath, string saveFilePath)
        {

            //创建新图位图 
            Bitmap bitmap = new Bitmap(FromFilePath);
            //创建作图区域 
            //Graphics graphic = Graphics.FromImage(bitmap);
            ////截取原图相应区域写入作图区 
            //graphic.DrawImage(fromImage, 0, 0, new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            ////从作图区生成新图 

            var hBitmap = bitmap.GetHbitmap();
            System.Drawing.Image saveImage = System.Drawing.Image.FromHbitmap(hBitmap);
            DeleteObject(hBitmap);

            saveImage.Save(saveFilePath);
            saveImage.Dispose();
            bitmap.Dispose();


        }
        /// <summary> 
        /// jpeg图片压缩 
        /// </summary> 
        /// <param name="sFile"></param> 
        /// <param name="outPath"></param> 
        /// <param name="flag"></param> 
        /// <returns></returns> 
        public static bool GetPicThumbnail(string sFile, string outPath, int flag)
        {
            try
            {
                Bitmap bitmap = new Bitmap(sFile);
                var hBitmap = bitmap.GetHbitmap();
                System.Drawing.Image iSource = System.Drawing.Image.FromHbitmap(hBitmap);
                DeleteObject(hBitmap);
                bitmap.Dispose();
                ImageFormat tFormat = iSource.RawFormat;
                //以下代码为保存图片时，设置压缩质量 
                EncoderParameters ep = new EncoderParameters();
                long[] qy = new long[1];
                qy[0] = flag;//设置压缩的比例1-100 
                EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
                ep.Param[0] = eParam;
                try
                {
                    ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo jpegICIinfo = null;
                    for (int x = 0; x < arrayICI.Length; x++)
                    {
                        if (arrayICI[x].FormatDescription.Equals("JPEG"))
                        {
                            jpegICIinfo = arrayICI[x];
                            break;
                        }
                    }
                    if (jpegICIinfo != null)
                    {
                        iSource.Save(outPath, jpegICIinfo, ep);//dFile是压缩后的新路径 
                    }
                    else
                    {
                        iSource.Save(outPath, tFormat);
                    }
                    iSource.Dispose();
                    return true;
                }
                catch
                {
                    iSource.Dispose();
                    return false;
                }
                finally
                {
                    iSource.Dispose();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary> 
        /// 剪裁 -- 用GDI+ 
        /// </summary> 
        /// <param name="b">原始Bitmap</param> 
        /// <param name="StartX">开始坐标X</param> 
        /// <param name="StartY">开始坐标Y</param> 
        /// <param name="iWidth">宽度</param> 
        /// <param name="iHeight">高度</param> 
        /// <returns>剪裁后的Bitmap</returns> 
        public static Bitmap CutImage(Image b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                // 开始截取坐标过大时，结束处理 
                return null;
            }
            if (StartX + iWidth > w)
            {
                // 宽度过大时只截取到最大大小 
                iWidth = w - StartX;
            }
            if (StartY + iHeight > h)
            {
                // 高度过大时只截取到最大大小 
                iHeight = h - StartY;
            }
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }

    }
}
