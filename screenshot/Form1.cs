using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace screenshot
{
    public partial class Form1 : Form
    {
        int i = 0, imax = 10;
        Bitmap bmp;
        Graphics graph = null;
        Random rnd = new Random();
        Timer t = new Timer();

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            // make unique folder to save screens
            string dir;
            do {
                dir = rnd.Next(65536).ToString("X4");
            } while(Directory.Exists(dir));
            Directory.CreateDirectory(dir);
            Directory.SetCurrentDirectory(dir);
            // change max screens count if required
            uint max;
            if (Program.args.Length >= 1 && UInt32.TryParse(Program.args[0], out max))
            {
                imax = (int)max;
            }
            // start timer
            t.Tick += new EventHandler(TickTimer);
            t.Interval = 5000;
            t.Start();
        }

        private void TickTimer(object sender, EventArgs ev)
        {
            try
            {
                graph = Graphics.FromImage(bmp);
                graph.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                bmp.Save("screen" + (i++) + ".png", ImageFormat.Png);
                if (i >= imax)
                    Application.Exit();
            }
            catch (Exception e)
            {
                // ignore all exceptions
                Console.WriteLine(e.Message);
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Enabled = false;
        }
    }
}
