using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace n64TexConverterCI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        String fileName;
        String directory;

        int imageX;
        int imageY;

        private void convertToCI()
        {
            uint[] colors;
            uint[] pixelImg = new uint[1];

            if (filePathTxt.Text != null)
            {
                // defines
                Bitmap image = new Bitmap(filePathTxt.Text);
                if (Convert.ToInt16(paletteSizeCmb.Text) == 16)
                {
                    pixelImg = null;
                    pixelImg = new uint[2];
                }
                else if (Convert.ToInt16(paletteSizeCmb.Text) == 256)
                {
                    pixelImg = null;
                    pixelImg = new uint[1];
                }
                
                
                StreamWriter imageOutput = new StreamWriter(directory + fileName + ".h");
                colors = new uint[Convert.ToInt16(paletteSizeCmb.Text)];
                String pixelHex = "";

                imageOutput.WriteLine("/*\n * this image was converted using the CI converter\n * this image is {0} pixels wide by {1} pixels tall, and has a bit depth of {2} bits\n */", imageX, imageY, Math.Sqrt(Convert.ToInt16(paletteSizeCmb.Text)));
                imageOutput.Write("unsigned char " + fileName.Replace(" ", String.Empty) + "[] = {\n");

                uint r, g, b, a;

                // loop x and y coords and fill picture size with pixel colors
                for (int j = 0; j < imageY; j++)
                {
                    imageOutput.Write("\t");
                    for (int i = 0; i < imageX; i++)
                    {
                        // getting raw data
                        for (int arrayposition = 0; arrayposition < pixelImg.Length; arrayposition++)
                        {
                            // TODO fix this, it crashes on odd numbers-------------------------------------------------------------------------------------------------!!!!!
                            try
                            {
                                pixelImg[arrayposition] = (uint)image.GetPixel(i+arrayposition, j).ToArgb();
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (j < imageY - 1)
                                {
                                    pixelImg[arrayposition] = (uint)image.GetPixel(0, j+arrayposition).ToArgb();
                                }
                                else 
                                {
                                    pixelImg[arrayposition] = (uint)0;
                                }
                            }
                            
                            // compare with colors array
                            for (int k = 0; k < colors.Length; k++)
                            {
                                if (colors[k] == 0)
                                {
                                    // add color to array
                                    colors[k] = pixelImg[arrayposition];
                                    pixelImg[arrayposition] = (uint)k;

                                    // break loop
                                    k = colors.Length;
                                }
                                else
                                {
                                    // compare colors
                                    if (pixelImg[arrayposition].Equals(colors[k]))
                                    {
                                        pixelImg[arrayposition] = (uint)k;
                                        k = colors.Length;
                                    }
                                }
                            }
                        }

                        // convert to hex
                        if (Convert.ToInt16(paletteSizeCmb.Text).Equals(256))
                        {
                            pixelHex = String.Format("\t0x{0:X2}", pixelImg[0]);
                        }

                        else if (Convert.ToInt16(paletteSizeCmb.Text).Equals(16))
                        {
                            // ?? TODO check this
                            byte tempByte = Convert.ToByte(pixelImg[0] << 4);
                            i++;
                            tempByte += Convert.ToByte(pixelImg[1]);
                            pixelHex = String.Format("\t0x{0:X}", tempByte);
                        }

                        if (i != imageX - 1 || j != imageY - 1)
                        {
                            pixelHex = pixelHex + ", ";
                        }
                        metadataLbl.Text = pixelHex;

                        // write to file
                        imageOutput.Write(pixelHex);
                    }
                    // new line
                    imageOutput.WriteLine();
                }
                pixelHex = "0";
                imageOutput.WriteLine("};");

                // print color palette
                imageOutput.WriteLine("\nunsigned short " + fileName.Replace(" ", String.Empty) + "Palette[] = {");
                for (int i = 0; i < colors.Length; i++)
                {
                    // set up for bitshifts
                    r = colors[i];
                    g = colors[i];
                    b = colors[i];
                    a = colors[i];

                    colors[i] = compressPixel(r, g, b, a, 16);

                    imageOutput.Write("\t0x{0:X}", colors[i]);

                    // feels like this could be optimized, its messy
                    if (i < colors.Length - 1)
                    {
                        imageOutput.WriteLine(",");
                    }
                    else
                    {
                        imageOutput.WriteLine();
                    }
                }
                imageOutput.WriteLine("};");

                // REMEMBER TO CLOSE THE FILE IDIOT
                imageOutput.Close();
            }
            pixelImg = null;
            colors = null;
        }

        private void filePathBtn_Click(object sender, EventArgs e)
        {
            FileDialog textureDialog = new OpenFileDialog();

            if (textureDialog.ShowDialog() == DialogResult.OK)
            {
                // display image, show url in textbar
                directory = Path.GetDirectoryName(textureDialog.FileName) + "\\";
                fileName = Path.GetFileNameWithoutExtension(textureDialog.FileName);

                Bitmap image = new Bitmap(textureDialog.FileName);
                imageX = image.Width;
                imageY = image.Height;
                metadataLbl.Text = (imageX + ", " + imageY);

                // removes space
                fileName.Replace(" ", String.Empty);
                filePathTxt.Text = textureDialog.FileName;
                texturePic.Image = Image.FromFile(filePathTxt.Text);
            }
        }
        
		private void convertBtn_Click(object sender, EventArgs e)
		{
            try
            {
                convertToCI();
            }
            catch (IOException)
            {
                MessageBox.Show("Make sure you have an image selected", "ERROR");
            }
		}

        private void exitBtn_Click(object sender, EventArgs e)
        {
            // close application, this should be obvious
            Close();
        }

        private uint compressPixel(uint r, uint g, uint b, uint a, int size)
        {
            uint pixel = 0;
            switch (size)
            {
                case 32:
                    // bitshift to 32 bits
                    r = r >> 16 << 24;
                    g = g >> 8 << 16;
                    b = b << 8;
                    a = a >> 24;
                    break;

                case 16:
                    // bitshift to 16 bits
                    r = r << 8 >> 27 << 11;
                    g = g << 16 >> 27 << 6;
                    b = b << 24 >> 27 << 1;
                    a = a >> 31;
                    break;

                case 8:
                    // bitshift to 8 bits
                    r = r;
                    g = g;
                    b = b;
                    a = a;
                    break;

                case 4:
                    // bitshift to 4 bits
                    r = r;
                    g = g;
                    b = b;
                    a = a;
                    break;

                default:
                    break;
            }
            pixel = r + b + g + a;
            return pixel;
        }
    }
}
