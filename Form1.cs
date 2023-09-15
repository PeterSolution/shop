using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Diagnostics;

namespace sklep
{
    public partial class Form1 : Form
    {

        const int duration = 4000; // czas trwania animacji w milisekundach
        const int steps = 50; // liczba kroków animacji
        async void AnimatepanelColor(Panel panel, Color startColor, Color endColor)
        {

            for (int i = 0; i <= steps; i++)
            {
                float ratio = (float)i / steps;
                Color interpolatedColor = InterpolateColor(startColor, endColor, ratio);
                panel.BackColor = interpolatedColor;
                await Task.Delay(duration / steps);
            }
        }
        async void AnimateLabelColor(Label label, Color startColor, Color endColor)
        {

            for (int i = 0; i <= steps; i++)
            {
                float ratio = (float)i / steps;
                Color interpolatedColor = InterpolateColor(startColor, endColor, ratio);
                label.BackColor = interpolatedColor;
                await Task.Delay(duration / steps);
            }
        }

        Color InterpolateColor(Color startColor, Color endColor, float ratio)
        {
            int red = (int)(startColor.R + (endColor.R - startColor.R) * ratio);
            int green = (int)(startColor.G + (endColor.G - startColor.G) * ratio);
            int blue = (int)(startColor.B + (endColor.B - startColor.B) * ratio);
            return Color.FromArgb(red, green, blue);
        }
        public Form1()
        {

            int a1=0;
            bool help=false;
            
            InitializeComponent();

            SqlConnection connection = new SqlConnection("write your sql database");
            connection.Open();
            string query = "Select * from magazynn";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            /*Panel mainpanel = new Panel();
            mainpanel.Height = this.ClientSize.Width;
            mainpanel.Width = this.ClientSize.Width;
            mainpanel.AutoScroll = true;
            mainpanel.Visible = true;*/

            /*Form1 firstwindow = new Form1();
            Form2 secondwindow = new Form2();
            firstwindow.Show();*/
            while (reader.Read())
            {
                Panel panel = new Panel();
                if (help == false)
                {
                    panel.Location = new Point(5, 10);
                    panel.Width = this.ClientSize.Width - 20;
                    panel.Height = 60;
                    panel.Name = "panel" + a1;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    help = true;
                }
                else
                {
                    panel.Location = new Point(5, 10+(60 * a1));
                    panel.Width = this.ClientSize.Width - 20;
                    panel.Height = 60;
                    panel.Name = "panel" + a1;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                }

                

                Label label1 = new Label();
                label1.Text = reader.GetString(1);
                label1.Name = "label1" + a1;
                Debug.WriteLine(label1.Text);
                label1.Location = new Point(15 , 25 + (60 * a1));
                label1.TextAlign = ContentAlignment.MiddleLeft;
                label1.BorderStyle = BorderStyle.FixedSingle;
                label1.BackColor = Color.AliceBlue;

                Label label3 = new Label();
                label3.Text = reader.GetValue(3).ToString();
                label3.Name = "label3" + a1;
                label3.Location = new Point(this.Right-140, 25 + (60 * a1));
                label3.TextAlign = ContentAlignment.MiddleLeft;
                label3.BorderStyle = BorderStyle.FixedSingle;
                label3.BackColor = Color.AliceBlue;

                Label label2 = new Label();
                label2.Text = reader.GetValue(2).ToString();
                label2.Width = label3.Left - label1.Right - 20;
                label2.Location = new Point(label1.Right+10, 25 + (60 * a1));
                label2.TextAlign = ContentAlignment.MiddleCenter;
                label2.BorderStyle = BorderStyle.FixedSingle;
                label2.Name = "label2" + a1;
                label2.Padding = new Padding(5);
                label2.BackColor = Color.AliceBlue;
                panel.MouseHover += (sender, e) =>
                {
                    AnimatepanelColor(panel, Color.AliceBlue, Color.WhiteSmoke);

                };
                panel.MouseLeave += (sender, e) =>
                {
                    AnimatepanelColor(panel, Color.WhiteSmoke, Color.AliceBlue);
                };


                label1.MouseEnter += (sender, e) =>
                {
                    AnimateLabelColor(label1, Color.AliceBlue, Color.WhiteSmoke);
                };
                
                label2.MouseEnter += (sender, e) =>
                {
                    AnimateLabelColor(label2, Color.AliceBlue, Color.WhiteSmoke);
                };

                label3.MouseEnter += (sender, e) =>
                {
                    AnimateLabelColor(label3, Color.AliceBlue, Color.WhiteSmoke);
                };

                label1.MouseLeave += (sender, e) =>
                {
                    AnimateLabelColor(label1, Color.WhiteSmoke, Color.AliceBlue);
                };

                label2.MouseLeave += (sender, e) =>
                {
                    AnimateLabelColor(label2, Color.WhiteSmoke, Color.AliceBlue);
                };

                label3.MouseLeave += (sender, e) =>
                {
                    AnimateLabelColor(label3, Color.WhiteSmoke, Color.AliceBlue);
                };

                /*Panel panel2 = new Panel();
                panel2.Height = 40;
                panel2.MouseEnter += (sender, e) =>
                {
                    AnimatepanelColor(panel2, Color.Aqua, Color.WhiteSmoke);
                };
                panel2.Width = this.ClientSize.Width;*/
                panel.Click += (sender, e) =>
                {
                    Form2 secondwindow = new Form2(label1.Text, label2.Text);
                    secondwindow.Show();
                };
                label1.Click += (sender, e) =>
                {

                    Form2 secondwindow = new Form2(label1.Text, label2.Text);
                    secondwindow.Show();

                };
                label2.Click += (sender, e) =>
                {

                    Form2 secondwindow = new Form2(label1.Text, label2.Text);
                    secondwindow.Show();

                };
                label3.Click += (sender, e) =>
                {
                    Form2 secondwindow = new Form2(label1.Text, label2.Text);

                    secondwindow.Show();

                };
                this.Controls.Add(label1);
                this.Controls.Add(label2);
                this.Controls.Add(label3);
                this.Controls.Add(panel);
                label1.BringToFront();
                label2.BringToFront();
                label3.BringToFront();
                /*panel.Controls.Add(label1);
                panel.Controls.Add(label2);
                panel.Controls.Add(label3);
                panel.BackColor= Color.AliceBlue;
                mainpanel.Controls.Add(panel);*/

                //this.Controls.Add(panel2);
                a1++;
            }
            connection.Close();
            /*VScrollBar scrollBar = new VScrollBar();
            scrollBar.Dock = DockStyle.Right;
            scrollBar.Scroll += (sender, e) =>
            {
                // Przewijanie zawartości panelu na podstawie pozycji paska przewijania
                mainpanel.Location = new System.Drawing.Point(mainpanel.Location.X, -scrollBar.Value);
            };

            this.Controls.Add(mainpanel);*/
        }

        
    }
}
