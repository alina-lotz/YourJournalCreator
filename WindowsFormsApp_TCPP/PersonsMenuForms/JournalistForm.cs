using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_TCPP.PersonsMenuForms
{
    public partial class JournalistForm : Form
    {
        public JournalistForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Journalist";
            this.Size = new Size(800, 500);
            this.Shown += CreateButtonDelegate;
        }

        private void JournalistForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            this.Controls.Clear();

            int block1 = 315;
            int height = 100;

            Button addTopicButton = new Button();
            this.Controls.Add(addTopicButton);
            addTopicButton.Text = "Add article";
            addTopicButton.Size = new Size(130, 25);
            addTopicButton.Location = new Point(block1, height);

            Button viewTopicsButton = new Button();
            this.Controls.Add(viewTopicsButton);
            viewTopicsButton.Text = "View articles";
            viewTopicsButton.Size = new Size(130, 25);
            viewTopicsButton.Location = new Point(block1, height+30);

            Button signoutButton = new Button();
            this.Controls.Add(signoutButton);
            signoutButton.Text = "Sign out";
            signoutButton.Size = new Size(130, 25);
            signoutButton.Location = new Point(block1, height+60);

            Button closeButton = new Button();
            this.Controls.Add(closeButton);
            closeButton.Text = "Exit";
            closeButton.Size = new Size(130, 25);
            closeButton.Location = new Point(block1, height+90);

            addTopicButton.Click += addTopicButton_Click;
            viewTopicsButton.Click += viewTopicsButton_Click;
            signoutButton.Click += signoutButton_Click;
            closeButton.Click += closeButton_Click;
        }

        private void addTopicButton_Click(object sender, EventArgs eventArgs)
        {
            this.Controls.Clear();

            int block1 = 100, block2 = 600;
            int height = 20;
            int contentSixe = 400;

            Label topicNameL = new Label();
            this.Controls.Add(topicNameL);
            topicNameL.Text = "Article title";
            topicNameL.Size = new Size(130, 25);
            topicNameL.Location = new Point(block1, height);

            RichTextBox topicNameText = new RichTextBox();
            this.Controls.Add(topicNameText);
            topicNameText.Size = new Size(contentSixe, 25);
            topicNameText.Location = new Point(block1, height+30);

            Label topicContentL = new Label();
            this.Controls.Add(topicContentL);
            topicContentL.Text = "Content";
            topicContentL.Size = new Size(130, 25);
            topicContentL.Location = new Point(block1, height+60);

            RichTextBox topicContectText = new RichTextBox();
            this.Controls.Add(topicContectText);
            topicContectText.Size = new Size(contentSixe, 100);
            topicContectText.Location = new Point(block1, height+3*30);
            topicContectText.WordWrap = true;

            Button addButton = new Button();
            this.Controls.Add(addButton);
            addButton.Text = "Add topic";
            addButton.Size = new Size(130, 25);
            addButton.Location = new Point(block2, height+30);

            Button cancelButton = new Button();
            this.Controls.Add(cancelButton);
            cancelButton.Text = "Cancle";
            cancelButton.Size = new Size(130, 25);
            cancelButton.Location = new Point(block2, height+60);

            addButton.Click += confirmTopicButton_Click;
            cancelButton.Click += CreateButtonDelegate;
        }
        private void viewTopicsButton_Click(object sender, EventArgs eventArgs)
        {

        }
        private void signoutButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Show();
            this.Close();
        }
        private void confirmTopicButton_Click(object sender, EventArgs eventArgs)
        {

        }
        private void closeButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Close();
        }
    }
}
