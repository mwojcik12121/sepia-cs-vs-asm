////////////////////////////////////////////////
//
//  Project: "Sepia"
//  Author: Marta Wójcik
//  Date: 02.02.2023, 5th term, year 2022/2023
//
///////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPIA_CS_lib
{
    public class lib_cs
    {
        public static void convert_cs(Color[,] pixels, int startRow, int endRow, int intensity)
        {           
            byte newRed = 0;              
            byte newGreen = 0;            
            byte newBlue = 0;

            for (int i = startRow; i < endRow ; i++)
            {
                for(int j = 0; j < pixels.GetLength(1); j++)
                {
                    newRed = (byte)Math.Round(
                        applyIntensity(pixels[i, j].R, outOfRangeCheck(0.393 * pixels[i, j].R +
                        0.769 * pixels[i, j].G + 0.189 * pixels[i, j].B), intensity));
                    newGreen = (byte)Math.Round(
                        applyIntensity(pixels[i, j].G, outOfRangeCheck(0.349 * pixels[i, j].R +
                        0.686 * pixels[i, j].G + 0.168 * pixels[i, j].B), intensity));
                    newBlue = (byte)Math.Round(
                        applyIntensity(pixels[i, j].B, outOfRangeCheck(0.272 * pixels[i, j].R +
                        0.534 * pixels[i, j].G + 0.131 * pixels[i, j].B), intensity));

                    pixels[i, j] = Color.FromArgb(pixels[i, j].A, newRed, newGreen, newBlue);
                }
            }
        }

        private static double outOfRangeCheck(double value)
        {
            if(value < 256)
            {
                return value;
            }
            
            return 255;
        }

        private static double applyIntensity(byte col_original, double col_new, int intensity)
        {
           return (col_original + ((col_new - col_original) * (intensity * 0.01)));
        }
    }
}
