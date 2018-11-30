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

        private void convertToCI()
        {
            uint[] colors;
            uint pixelImg;

            if (filePathTxt.Text != null)
            {
                // defines
                Bitmap image = new Bitmap(filePathTxt.Text);
                int imageX = image.Width;
                int imageY = image.Height;
                pixelImg = new uint();
                
                StreamWriter imageOutput = new StreamWriter(directory + fileName + ".h");
                colors = new uint[Convert.ToInt16(paletteSizeCmb.Text)];
                String pixelHex;

                imageOutput.WriteLine("/*\n * this image was converted using the CI converter\n * this image is {0} pixels wide by {1} pixels tall\n */", imageX, imageY);
                imageOutput.Write("unsigned char " + fileName.Replace(" ", String.Empty) + "[] = {\n");

                uint r, g, b, a;

                // loop x and y coords and fill picture size with pixel colors
                for (int j = 0; j < imageY; j++)
                {
                    imageOutput.Write("\t");
                    for (int i = 0; i < imageX; i++)
                    {
                        // getting raw data
                        pixelImg = (uint)image.GetPixel(i, j).ToArgb();

                        // compare with colors array
                        for (int k = 0; k < colors.Length; k++)
                        {
                            if (colors[k] == 0)
                            {
                                // add color to array
                                colors[k] = pixelImg;
                                pixelImg = (uint)k;

                                // break loop
                                k = colors.Length;   
                            }
                            else
                            {
                                // compare colors
                                if (pixelImg.Equals(colors[k])) 
                                {
                                    pixelImg = (uint)k;
                                    k = colors.Length;
                                }
                            }
                        }

                        // convert to hex
                        pixelHex = String.Format("0x{0:X}", pixelImg);
                        if (i != imageX - 1 || j != imageY - 1)
                        {
                            pixelHex = pixelHex + ", ";
                        }
                        //TODO re enable
                        //metadataLbl.Text = pixelHex;

                        // write to file
                        imageOutput.Write(pixelHex);
                    }
                    // new line
                    imageOutput.WriteLine("");
                }
                pixelHex = null;
                //metadataLbl.Text = pixelHex;
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

                    // bitshift
                    r = r << 8 >> 27 << 11;
                    g = g << 16 >> 27 << 6;
                    b = b << 24 >> 27 << 1;
                    a = a >> 31;

                    //String test = ("0x{0:X}", r);

                    //metadataLbl.Text = ("0x{0:X}", r);

                    colors[i] = r+b+g+a;

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
                    //metadataLbl.Text = ("0x{0:X}", colors[i]);
                }
                imageOutput.WriteLine("};");

                // REMEMBER TO CLOSE THE FILE IDIOT
                imageOutput.Close();
            }
            pixelImg = 0;
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
    }
}
