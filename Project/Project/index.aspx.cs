using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.cs
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Map map;
        private Stack<Triangles> triangles;

        private int resolution = 100;

        Bitmap bitmap;

        // Constructor
        public WebForm1()
        {
            map = new Map();
            triangles = map.triangles;
            bitmap = new Bitmap(600, 600);
        }

        private void Setup()
        {
            int textboxWidth = 40;

            // Setup the textboxes, specifically the tooltip, width, and OnClick function which will select whole text.
            TextBoxV1x.ToolTip = "V1x";
            TextBoxV1x.Width = textboxWidth;
            TextBoxV1x.Attributes.Add("onfocus", "javascript:this.select();");

            TextBoxV1y.ToolTip = "V1y";
            TextBoxV1y.Width = textboxWidth;
            TextBoxV1y.Attributes.Add("onfocus", "javascript:this.select();");

            TextBoxV2x.ToolTip = "V2x";
            TextBoxV2x.Width = textboxWidth;
            TextBoxV2x.Attributes.Add("onfocus", "javascript:this.select();");

            TextBoxV2y.ToolTip = "V2y";
            TextBoxV2y.Width = textboxWidth;
            TextBoxV2y.Attributes.Add("onfocus", "javascript:this.select();");

            TextBoxV3x.ToolTip = "V3x";
            TextBoxV3x.Width = textboxWidth;
            TextBoxV3x.Attributes.Add("onfocus", "javascript:this.select();");

            TextBoxV3y.ToolTip = "V3y";
            TextBoxV3y.Width = textboxWidth;
            TextBoxV3y.Attributes.Add("onfocus", "javascript:this.select();");

            // Setup of label
            Result.Text = "";
            Result.Height = 20;

            // Setup of button
            ButtomSubmit.Text = "Submit";
        }

        /*
         * 
         *  ON PAGE LOAD
         *
         */

        protected void Page_Load(object sender, EventArgs e)
        {
            // Only display if page is loaded for first time (Stops duplication)
            if(!Page.IsPostBack)
            {
                Setup(); // Setup of Textboxes & label
                DrawTriangles(); // Draw Grid
            }
        }

        private void DrawTriangles()
        {
            Graphics g = Graphics.FromImage(bitmap);

            // create Colours
            Color tColor = new Color();
            tColor = Color.FromArgb(255, 249, 249, 249);

            Color bColor = new Color();
            bColor = Color.FromArgb(255, 91, 155, 213);

            // Create a pen variable for the line width of traingles
            g.Clear(bColor);
            Pen pen = new Pen(tColor, 1);

            // Plot each point
            foreach(Triangles t in triangles)
            {
                // Draw Triangle
                g.DrawLine(pen, t.point1, t.point2);
                g.DrawLine(pen, t.point2, t.point3);
                g.DrawLine(pen, t.point3, t.point1);

                // Create Font
                var fontFamily = new FontFamily("Times New Roman");
                var font = new Font(fontFamily, 12, FontStyle.Bold, GraphicsUnit.Pixel);

                // Get center of triangle
                int centerX = (t.point1.X + t.point2.X + t.point3.X) / 3;
                int centerY = (t.point1.Y + t.point2.Y + t.point3.Y) / 3;

                // Draw ID in text in center of triangle
                g.DrawString(t.ID, font, Brushes.White, centerX, centerY);
            }

            // Save & Load the bitmap for use in GUI
            string path = Server.MapPath("~/grid.jpg");
            bitmap.Save(path, ImageFormat.Jpeg);
            ImageBox.ImageUrl = "~/grid.jpg";

            // Dispose of graphics and bitmap
            g.Dispose();
            bitmap.Dispose();
        }

        /*
         * 
         *  ON BUTTON CLICK
         *
         */

        protected void ButtomSubmit_Click(object sender, EventArgs e)
        {
            string location = "";

            // Check if textbox is null
            if(TextBoxV1x.Text != String.Empty && TextBoxV1y.Text != String.Empty && TextBoxV2x.Text != String.Empty && TextBoxV2y.Text != String.Empty && TextBoxV3x.Text != String.Empty && TextBoxV3y.Text != String.Empty)
            {
                // Gather points
                Point v1 = new Point(int.Parse(TextBoxV1x.Text), int.Parse(TextBoxV1y.Text));
                Point v2 = new Point(int.Parse(TextBoxV2x.Text), int.Parse(TextBoxV2y.Text));
                Point v3 = new Point(int.Parse(TextBoxV3x.Text), int.Parse(TextBoxV3y.Text));

                // covert points to 0 - 600 scale
                v1.X *= resolution; v1.Y *= resolution;
                v2.X *= resolution; v2.Y *= resolution;
                v3.X *= resolution; v3.Y *= resolution;

                location = map.GetLocation(v1, v2, v3);
            }
            else
            {
                location = "Please fill in all textboxes.";
            }

            // Output result
            Result.Text = location;
        }
    }
}