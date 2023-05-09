////////////////////////////////////////////////
//
//  Project: "Sepia"
//  Author: Marta Wójcik
//  Date: 02.02.2023, 5th term, year 2022/2023
//
///////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPIA_CS_lib;

namespace Sepia_projekt_JA
{
    public partial class Form1 : Form
    {
        // Path to original file
        private string path = "";

        public Form1()
        {
            InitializeComponent();
            labelThreads.Text = "1";
            radioASM.Checked = true;
            btnSave.Enabled = false;
            btnApply.Enabled = false;
        }

        // Imported assembly function for sepia image conversion
        [DllImport(@"C:\Users\Medion\Desktop\Sepia\Sepia_projekt_JA\x64\Release\Sepia_ASM_lib.dll")]
        static unsafe extern void convert_asm(IntPtr orginalArray, IntPtr newArray,
            int numberOfPixels, IntPtr factors_array, int intensity);

        // Action for apply button
        private void apply_Click(object sender, EventArgs e)
        {
            if (path != "")
            {
                btnApply.Enabled = false;

                // Get the image
                Bitmap img = (Bitmap)Image.FromFile(path, true);
                Stopwatch time = new Stopwatch();

                // Values needed to divide the image for tasks
                int numberOfRows = img.Height;
                int numberOfColumns = img.Width;
                int numberOfTasks = threadsTrackbar.Value;
                int startRow = 0;
                int rowsPerThread = numberOfRows / numberOfTasks;
                int remainder = numberOfRows % numberOfTasks;
                List<Task> taskList = new List<Task>();

                if (radioASM.Checked == true)
                {
                    // Lock the bitmap's bits.  
                    Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
                    System.Drawing.Imaging.BitmapData bmpData =
                        img.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        img.PixelFormat);

                    // Get the address of the first line.
                    IntPtr ptr = bmpData.Scan0;

                    // Declare an array to hold the bytes of the bitmap.
                    int numberOfBytes = Math.Abs(bmpData.Stride) * img.Height;
                    byte[] rgbValues = new byte[numberOfBytes];

                    // Copy values from bitmap to rgbValues
                    Marshal.Copy(ptr, rgbValues, 0, numberOfBytes);

                    // Array of floats passed to asm instead of bytes / ints, because it 
                    // has to be casted anyway

                    // Array with original values
                    float[] rgbValuesFloat = new float[numberOfBytes];

                    for (int i = 0; i < numberOfBytes; i++)
                    {
                        rgbValuesFloat[i] = rgbValues[i];
                    }

                    // Array for new values
                    float[] newRgbValuesFloat = new float[numberOfBytes];

                    // Factors needed to calculate new RGB values (zero at the end to make
                    // sure we don't access not our memory in asm)
                    float[] factors = { 0.131f, 0.534f, 0.272f,
                                        0.168f, 0.686f, 0.349f,
                                        0.189f, 0.769f, 0.393f, 0f};

                    // Retrive the intensity
                    float intensity = (float)numericIntensity.Value / 100.0f;

                    int numberOfPixels = numberOfBytes / 3;

                    unsafe
                    {
                        // Process data for assembly function
                        GCHandle originalArray = GCHandle.Alloc(rgbValuesFloat[0], GCHandleType.Pinned);
                        GCHandle newArray = GCHandle.Alloc(newRgbValuesFloat[0], GCHandleType.Pinned);
                        GCHandle factors_array = GCHandle.Alloc(factors[0], GCHandleType.Pinned);
                        {

                            time.Start();

                            for(int i=0; i<numberOfTasks; i++)
                            {
                                IntPtr wsk1;
                                wsk1 = originalArray.AddrOfPinnedObject() + (startRow * numberOfColumns * 3);

                                IntPtr wsk2;
                                wsk2 = newArray.AddrOfPinnedObject() + (startRow * numberOfColumns * 3);

                                IntPtr wsk3;
                                wsk3 = factors_array.AddrOfPinnedObject();

                                if (remainder > 0)
                                {
                                    convert_asm(wsk1, wsk2, ((rowsPerThread + 1) * numberOfColumns), wsk3, (int)intensity);

                                    remainder--;
                                    startRow += rowsPerThread + 1;
                                }
                                else
                                {
                                    convert_asm(wsk1, wsk2, (rowsPerThread * numberOfColumns), wsk3, (int)intensity);

                                    startRow += rowsPerThread;
                                }
                            }

                            
                            
                        }                     

                        for (int i = 0; i < numberOfBytes; i++)
                        {
                            rgbValues[i] = (byte)newRgbValuesFloat[i];
                        }

                        Marshal.Copy(rgbValues, 0, ptr, numberOfBytes);

                        originalArray.Free();
                        newArray.Free();
                        factors_array.Free();

                        time.Stop();
                    }

                    // Unlock the bits.
                    img.UnlockBits(bmpData);
                }
                else
                {
                    // Retrieve the intensity
                    int intensity = (int)numericIntensity.Value;

                    // Retrive the pixels
                    Color[,] pixels = new Color[numberOfRows, numberOfColumns];

                    for (int i = 0; i < numberOfRows; i++)
                    {
                        for(int j = 0; j < numberOfColumns; j++)
                        {
                            pixels[i, j] = img.GetPixel(j, i);
                        }
                    }
                    
                    time.Start();

                    // Run the tasks
                    for (int i = 0; i < numberOfTasks; i++)
                    {
                        int startRowCopy = startRow;

                        if (remainder > 0)
                        {
                            taskList.Add(Task.Run(() => lib_cs.convert_cs(pixels, startRowCopy,
                                startRowCopy + rowsPerThread + 1, intensity)));

                            remainder--;
                            startRow += rowsPerThread + 1;
                        }
                        else
                        {
                            taskList.Add(Task.Run(() => lib_cs.convert_cs(pixels, startRowCopy,
                                startRowCopy + rowsPerThread, intensity)));
                            startRow += rowsPerThread;
                        }
                    }

                    Task.WaitAll(taskList.ToArray());

                    // Set the pixels
                    for (int i = 0; i < numberOfRows; i++)
                    {
                        for (int j = 0; j < numberOfColumns; j++)
                        {
                            img.SetPixel(j, i, pixels[i, j]);
                        }
                    }

                    time.Stop();
                }

                // display the conversion results
                picModified.Image = img;

                TimeSpan ts = time.Elapsed;

                if(ts.Seconds == 0)
                {
                    string elapsedTime = String.Format("{0} ms", ts.Milliseconds);
                    labelTime.Text = elapsedTime;
                }
                else
                {
                    string elapsedTime = String.Format("{0} s  {1} ms",
                    ts.Seconds, ts.Milliseconds);
                    labelTime.Text = elapsedTime;
                }

                btnSave.Enabled = true;
                btnApply.Enabled = true;
            }
            else MessageBox.Show("No image selected!");
        }

        private void choose_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files|*.jpg;*.bmp";
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    path = filePath;

                    picOriginal.ImageLocation = path;
                    picModified.Image = null;

                    btnSave.Enabled = false;
                    btnApply.Enabled = true;
                }
            }
        }

        private void threads_Scroll(object sender, EventArgs e)
        {
            labelThreads.Text = threadsTrackbar.Value.ToString();
        }

        private void save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.FileName = "*.bmp";
                saveFileDialog.Filter = "BMP files|*.bmp|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = false;
                

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picModified.Image.Save(saveFileDialog.FileName);
                }
            }
        }
    }
}
