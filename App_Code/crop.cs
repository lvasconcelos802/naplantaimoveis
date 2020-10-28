using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Globalization;

namespace quartoesuite.App_Code
{
    public class cropImage
    {
        /// <summary>
        /// crop imagem
        /// scrPath = path da imagem original              
        /// </summary>

        public static bool CropImg(string srcPath, int x, int y, int w, int h)
        {
            bool retorno = false;
            
            // Crop Image Here & Save 

            if (File.Exists(srcPath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(srcPath);
                Rectangle CropArea = new Rectangle(x, y, w, h);
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }

                    bitMap.Save(srcPath);

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                finally
                {
                    retorno = true;
                }
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        
    }
}
