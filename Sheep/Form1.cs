using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Sheep
{
    public partial class Form1 : Form
    {
        public static string choosen { get; set; }
        public static string open { get; set; }
        public static string option { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Hide();
            btn1.Show();
            btn2.Show();
            btn3.Show();

            List<string> options = new List<string>() { "1", "2", "3" };
            //set choosen
            int index = randomList(options);
            choosen = options[index];
            options.RemoveAt(index);
            // set open
            index = randomList(options);
            open = options[index];
            addLabel("Hi, 從1-3道門中選擇一扇吧?");
        }

        private void addLabel(string value) {
            Label lbl = new Label();
            lbl.Text = value;
            lbl.ForeColor = System.Drawing.Color.Orange;
            lbl.Width = lbl.PreferredWidth;
            pnlContent.Controls.Add(lbl);
            Label newline = new Label();
            newline.Text = "<br/>";
            newline.Width = pnlContent.Width;
            pnlContent.Controls.Add(newline);
            this.Refresh(); //即時更新
        }

        private int randomList<T>(List<T> list) {
            var random = new Random();
            return random.Next(list.Count);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(option)) {
                openDoor(btn1.Text);
            }
            else 
            {
                showEnd(btn1.Text);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(option))
            {
                openDoor(btn2.Text);
            }
            else
            {
                showEnd(btn2.Text);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(option))
            {
                openDoor(btn3.Text);
            }
            else
            {
                showEnd(btn3.Text);
            }
        }

        private void openDoor(string door) {
            option = door;
            Thread.Sleep(200);
            addLabel("噢, 選定了" + door + "號門嗎?");
            Thread.Sleep(1000);
            addLabel("Hmmm... 要不要再想想?");
            Thread.Sleep(2000);
            addLabel("(推開" + open + "號門, 門後空空如也)");
            Thread.Sleep(1000);
            foreach (Control item in this.Controls) {
                if (item.Name.Equals("btn" + open)) {
                    item.Visible = false;
                }
            }
            addLabel("再給你一次機會w");
            pnlContent.Focus();
        }

        private void showEnd(string door)
        {
            if (door.Equals(choosen))
            {
                addLabel("啊哈! 就是它沒錯");
            }
            else {
                addLabel("噢...不是讓你重選了嗎...");
            }
            btn1.Visible = false;
            btn2.Visible = false;
            btn3.Visible = false;
            btnRestart.Visible = true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            btnRestart.Visible = false;
            btnStart.Visible = true;
            choosen = string.Empty;
            open = string.Empty;
            option = string.Empty;
            pnlContent.Controls.Clear();
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
