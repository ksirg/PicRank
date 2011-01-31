using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PicRank.Logic.Helpers
{
    public class PictureHelpers
    {

        public static bool IsValidImage(string filename)
        {
            Stream imageStream = null;
            bool isImageHeader = false;
            try
            {
                imageStream = new FileStream(filename, FileMode.Open);

                isImageHeader = IsValidImage(imageStream);

            }
            catch { return false; }
            finally
            {
                if (imageStream != null)
                {
                    imageStream.Close();
                    imageStream.Dispose();
                }
            }
            return isImageHeader;
        }

        public static bool IsValidImage(Stream imageStream)
        {
            bool isImageHeader=false;
            if (imageStream.Length > 0)
            {
                byte[] header = new byte[30]; // Change size if needed.
                string[] imageHeaders = new[] {
                                         "BM",       // BMP
                                         "GIF",      // GIF
                                        Encoding.ASCII.GetString(new byte[]{137, 80, 78, 71}),// PNG
                                        "MM\x00\x2a", // TIFF
                                        "II\x2a\x00" // TIFF
                };

                imageStream.Read(header, 0, header.Length);

                isImageHeader = imageHeaders.Count(str => Encoding.ASCII.GetString(header).StartsWith(str)) > 0;
                //if (imageStream != null)
                //{
                //    imageStream.Close();
                //    imageStream.Dispose();
                //    imageStream = null;
                //}

                if (isImageHeader == false)
                {
                    imageStream.Seek(0, SeekOrigin.Begin);
                    //Verify if is jpeg
                    using (BinaryReader br = new BinaryReader(imageStream))// File.Open(filename, FileMode.Open)))
                    {
                        UInt16 soi = br.ReadUInt16();  // Start of Image (SOI) marker (FFD8)
                        UInt16 jfif = br.ReadUInt16(); // JFIF marker

                        isImageHeader = (soi == 0xd8ff && (jfif == 0xe0ff || jfif == 57855));
                    }
                }


            }
            return isImageHeader;
        }
    }
}
