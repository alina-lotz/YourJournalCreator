using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp_TCPP.PersonsMenuForms
{
    public partial class PhotographerForm : Form
    {
        public PhotographerForm()
        {
            InitializeComponent();
            this.StartPosition = FormsManager.Instance.formPosition;
            this.Text = "Photographer";
            this.Size = FormsManager.Instance.formSize;
            this.BackColor = FormsManager.Instance.bgColor;

            this.Shown += CreateButtonDelegate;

            FormsManager.Instance.Forms.Add(this);
        }

        private void PhotographerForm_Load(object sender, EventArgs e)
        {

        }
        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            this.Controls.Clear();

            /*ImageList imgs = new ImageList();
            String[] paths = { };
            paths = Directory.GetFiles("D:/Application_TCPP");
            //Image myImage = Image.FromFile("D:/Application_TCPP/img.png");
            foreach(String path in paths)
            {
                imgs.Images.Add(Image.FromFile(path));
            }

            ListView listView = new ListView();
            listView.View = View.Details;
            listView.Columns.Add("Space", 150);
            listView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            listView.Location = new Point(FormsManager.Instance.block3, FormsManager.Instance.height);
            listView.Size = new Size(300, 300);
            listView.SmallImageList = imgs;
            listView.Items.Add("lalala", 0);
            //listView.it ImageIndex = 0;

            String selected = listView.SelectedItems[0].SubItems[0].Text;
            MessageBox.Show(selected); */

            string imgPath;

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF" /*|All files (*.*)|*.* */;
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                imgPath = fdlg.FileName;
            }

            Button viewTopicsButton = new Button();
            this.Controls.Add(viewTopicsButton);
            viewTopicsButton.Text = "View all articles";
            viewTopicsButton.Size = FormsManager.Instance.buttonSize;
            viewTopicsButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height);
            //design
            viewTopicsButton.Font = FormsManager.Instance.fontType;
            viewTopicsButton.BackColor = FormsManager.Instance.bColor;
            viewTopicsButton.ForeColor = FormsManager.Instance.tColor;
            viewTopicsButton.FlatStyle = FormsManager.Instance.flatStyle;
            viewTopicsButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button signoutButton = new Button();
            this.Controls.Add(signoutButton);
            signoutButton.Text = "Sign out";
            signoutButton.Size = FormsManager.Instance.buttonSize;
            signoutButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 1);
            //design
            signoutButton.Font = FormsManager.Instance.fontType;
            signoutButton.BackColor = FormsManager.Instance.bColor;
            signoutButton.ForeColor = FormsManager.Instance.tColor;
            signoutButton.FlatStyle = FormsManager.Instance.flatStyle;
            signoutButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button exitButton = new Button();
            this.Controls.Add(exitButton);
            exitButton.Text = "Exit";
            exitButton.Size = FormsManager.Instance.buttonSize;
            exitButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 2);
            //design
            exitButton.Font = FormsManager.Instance.fontType;
            exitButton.BackColor = FormsManager.Instance.bColor;
            exitButton.ForeColor = FormsManager.Instance.tColor;
            exitButton.FlatStyle = FormsManager.Instance.flatStyle;
            exitButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            viewTopicsButton.Click += viewTopicsButton_Click;
            signoutButton.Click += signoutButton_Click;
            exitButton.Click += exitButton_Click;
        }
        private void viewTopicsButton_Click(object sender, EventArgs eventArgs)
        {

        }
        private void signoutButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Show();
            FormsManager.Instance.Forms.RemoveAt(FormsManager.Instance.Forms.Count - 1);
            this.Close();
        }
        private void confirmTopicButton_Click(object sender, EventArgs eventArgs)
        {

        }
        private void exitButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Close();
        }
    }
}
