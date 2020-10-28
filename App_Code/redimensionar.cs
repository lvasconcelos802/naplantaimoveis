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
    public class resize
    {
        /// <summary>
        /// Redimensiona imagem
        /// scrPath = path da imagem original
        /// destPath = path para a nova imagem
        /// caso o destPath seja igual ao scrPath, a nova imagem substitui a anterior
        /// </summary>

        public static bool Resize(string srcPath, string destPath, int nWidth, int nHeight)
        {
            bool retorno = false;
            string temp;

            try
            {

                // abre arquivo original
                System.Drawing.Image img = System.Drawing.Image.FromFile(srcPath);

                int oWidth = img.Width; // largura original
                int oHeight = img.Height; // altura original

                // redimensiona se necessario
                if (oWidth > nWidth || oHeight > nHeight)
                {
                    if (oWidth > oHeight)
                    {
                        // imagem horizontal
                        nHeight = (oHeight * nWidth) / oWidth;
                    }
                    else
                    {
                        // imagem vertical
                        nWidth = (oWidth * nHeight) / oHeight;
                    }
                }

                // cria a copia da imagem
                System.Drawing.Image imgThumb = img.GetThumbnailImage(nWidth, nHeight, null, new System.IntPtr(0));

                if (srcPath == destPath)
                {
                    temp = destPath + ".tmp";
                    imgThumb.Save(temp, ImageFormat.Jpeg);
                    img.Dispose();
                    imgThumb.Dispose();

                    File.Delete(srcPath); // deleta arquivo original
                    File.Copy(temp, srcPath); // copia a nova imagem
                    File.Delete(temp); // deleta temporário
                }
                else
                {
                    imgThumb.Save(destPath, ImageFormat.Jpeg); // salva nova imagem no destino
                    imgThumb.Dispose(); // libera memoria
                    img.Dispose(); // libera memória
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                retorno = false;
            }
            finally {

                retorno = true;
            }

            return retorno;
        }
    }
}
