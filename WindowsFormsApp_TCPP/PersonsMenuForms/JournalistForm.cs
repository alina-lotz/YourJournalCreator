using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_TCPP.JournalClasses;

namespace WindowsFormsApp_TCPP.PersonsMenuForms
{
    public partial class JournalistForm : Form
    {
        public JournalistForm()
        {
            InitializeComponent();
            this.StartPosition = FormsManager.Instance.formPosition;
            this.Text = "Journalist";
            this.Size = FormsManager.Instance.formSize;
            this.BackColor = FormsManager.Instance.bgColor;

            this.Shown += CreateButtonDelegate;

            FormsManager.Instance.Forms.Add(this);
        }

        private void JournalistForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            this.Controls.Clear();

            Button addTopicButton = new Button();
            this.Controls.Add(addTopicButton);
            addTopicButton.Text = "Add article";
            addTopicButton.Size = FormsManager.Instance.buttonSize;
            addTopicButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height);
            //design
            addTopicButton.Font = FormsManager.Instance.fontType;
            addTopicButton.BackColor = FormsManager.Instance.bColor;
            addTopicButton.ForeColor = FormsManager.Instance.tColor;
            addTopicButton.FlatStyle = FormsManager.Instance.flatStyle;
            addTopicButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button viewTopicsButton = new Button();
            this.Controls.Add(viewTopicsButton);
            viewTopicsButton.Text = "View all articles";
            viewTopicsButton.Size = FormsManager.Instance.buttonSize;
            viewTopicsButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent);
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
            signoutButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 2);
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
            exitButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 3);
            //design
            exitButton.Font = FormsManager.Instance.fontType;
            exitButton.BackColor = FormsManager.Instance.bColor;
            exitButton.ForeColor = FormsManager.Instance.tColor;
            exitButton.FlatStyle = FormsManager.Instance.flatStyle;
            exitButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            addTopicButton.Click += addTopicButton_Click;
            viewTopicsButton.Click += viewTopicsButton_Click;
            signoutButton.Click += signoutButton_Click;
            exitButton.Click += exitButton_Click;
        }

        private void addTopicButton_Click(object sender, EventArgs eventArgs)
        {
            this.Controls.Clear();

            int articleContentWidth = 400, articleContentHeight = 200;

            Label topicNameL = new Label();
            this.Controls.Add(topicNameL);
            topicNameL.Text = "Article title";
            topicNameL.Size = FormsManager.Instance.buttonSize;
            topicNameL.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height);
            //design
            topicNameL.Font = FormsManager.Instance.fontType;
            topicNameL.ForeColor = FormsManager.Instance.bColor;
            topicNameL.FlatStyle = FormsManager.Instance.flatStyle;

            RichTextBox topicNameText = new RichTextBox();
            this.Controls.Add(topicNameText);
            topicNameText.Size = new Size(articleContentWidth, FormsManager.Instance.buttonHeight);
            topicNameText.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height + FormsManager.Instance.indent);
            topicNameText.Name = "TopicName";
            //design
            topicNameText.Font = FormsManager.Instance.fontType;
            topicNameText.BackColor = FormsManager.Instance.bColor;
            topicNameText.ForeColor = FormsManager.Instance.tColor;
            topicNameText.BorderStyle = FormsManager.Instance.borderStyle;

            Label topicContentL = new Label();
            this.Controls.Add(topicContentL);
            topicContentL.Text = "Content";
            topicContentL.Size = FormsManager.Instance.buttonSize;
            topicContentL.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height + FormsManager.Instance.indent * 2);
            //design
            topicContentL.Font = FormsManager.Instance.fontType;
            topicContentL.ForeColor = FormsManager.Instance.bColor;
            topicContentL.FlatStyle = FormsManager.Instance.flatStyle;

            RichTextBox topicContectText = new RichTextBox();
            this.Controls.Add(topicContectText);
            topicContectText.Size = new Size(articleContentWidth, articleContentHeight);
            topicContectText.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height + FormsManager.Instance.indent * 3);
            topicContectText.WordWrap = true;
            topicContectText.Name = "TopicContent";
            //design
            topicContectText.Font = FormsManager.Instance.fontType;
            topicContectText.BackColor = FormsManager.Instance.bColor;
            topicContectText.ForeColor = FormsManager.Instance.tColor;
            topicContectText.BorderStyle = FormsManager.Instance.borderStyle;

            Button addButton = new Button();
            this.Controls.Add(addButton);
            addButton.Text = "Add topic";
            addButton.Size = FormsManager.Instance.buttonSize;
            addButton.Location = new Point(FormsManager.Instance.block3, topicNameText.Location.Y);
            //design
            addButton.Font = FormsManager.Instance.fontType;
            addButton.BackColor = FormsManager.Instance.bColor;
            addButton.ForeColor = FormsManager.Instance.tColor;
            addButton.FlatStyle = FormsManager.Instance.flatStyle;
            addButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button readyForEdit = new Button();
            this.Controls.Add(readyForEdit);
            readyForEdit.Text = "Send to the editor";
            readyForEdit.Size = FormsManager.Instance.buttonSize;
            readyForEdit.Location = new Point(FormsManager.Instance.block3, topicNameText.Location.Y + FormsManager.Instance.indent);
            //design
            readyForEdit.Font = FormsManager.Instance.fontType;
            readyForEdit.BackColor = FormsManager.Instance.bColor;
            readyForEdit.ForeColor = FormsManager.Instance.tColor;
            readyForEdit.FlatStyle = FormsManager.Instance.flatStyle;
            readyForEdit.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button cancelButton = new Button();
            this.Controls.Add(cancelButton);
            cancelButton.Text = "Cancle";
            cancelButton.Size = FormsManager.Instance.buttonSize;
            cancelButton.Location = new Point(FormsManager.Instance.block3, topicNameText.Location.Y + FormsManager.Instance.indent * 2);
            //design
            cancelButton.Font = FormsManager.Instance.fontType;
            cancelButton.BackColor = FormsManager.Instance.bColor;
            cancelButton.ForeColor = FormsManager.Instance.tColor;
            cancelButton.FlatStyle = FormsManager.Instance.flatStyle;
            cancelButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            readyForEdit.Click += readyForEdit_Click;
            addButton.Click += confirmTopicButton_Click;
            cancelButton.Click += CreateButtonDelegate;
        }
        
        private void viewTopicsButton_Click(object sender, EventArgs eventArgs)
        {
            this.Controls.Clear();
            //this.AutoScroll = true;
            TableLayoutPanel buttonsPanel = new TableLayoutPanel();
            buttonsPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            buttonsPanel.Size = FormsManager.Instance.panelSize;
            buttonsPanel.Top = 0;
            buttonsPanel.BackColor = FormsManager.Instance.bColor;
            buttonsPanel.RowCount = 1;
            buttonsPanel.ColumnCount = 2;
            buttonsPanel.ColumnStyles.Clear();
            buttonsPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            this.Controls.Add(buttonsPanel);
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));
            
            var backButton = new Button();
            //design
            backButton.Font = FormsManager.Instance.fontType;
            backButton.BackColor = FormsManager.Instance.bColor;
            backButton.ForeColor = FormsManager.Instance.tColor;
            backButton.FlatStyle = FormsManager.Instance.flatStyle;
            backButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
            backButton.Text = "Test";
            backButton.Size = FormsManager.Instance.buttonSize;           

            buttonsPanel.Controls.Add(backButton, 0, 0);

            backButton.Click += CreateButtonDelegate;
            MessageBox.Show(Journalist.Instance.Name);

            //Panel newPanel = new Panel();
            //newPanel.Height = 30;
            //newPanel.Location = new Point(0, buttonsPanel.Height + i * newPanel.Height);
            //newPanel.Width = this.Width;
            //newPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            //newPanel.BackColor = Color.FromArgb(255, i, 255 - i, 255);
            //this.Controls.Add(newPanel);
            //for (int j = 0; j < 5; j++)
            //{
            //    var but = new Button();
            //    but.Text = "asdasd";
            //    but.Size = FormsManager.Instance.buttonSize;
            //    but.Location = new Point(j * (but.Width + 2), 0);
            //    newPanel.Controls.Add(but);
            //}
            
            if (TopicList.Instance.Topics.Count != 0)
            {
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.AutoScroll = true;
                //panel.Location = new Point(0, buttonsPanel.Height + i * panel.Height);
                panel.Width = FormsManager.Instance.panelWidth;
                panel.Height = FormsManager.Instance.panelHeight * TopicList.Instance.Topics.Count;
                panel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                panel.RowCount = TopicList.Instance.Topics.Count();
                panel.ColumnCount = 6;
                panel.ColumnStyles.Clear();
                panel.RowStyles.Clear();
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                panel.Top = FormsManager.Instance.panelHeight;
                this.Controls.Add(panel);
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                for (int j = 0; j < TopicList.Instance.Topics.Count(); j++)
                {
                    //var but = new Label();
                    //but.Click += (sender1, EventArgs) => { btnClick(sender1, eventArgs, i); };
                    //but.Text = "asdasd";
                    //but.TextAlign = ContentAlignment.MiddleCenter;
                    //but.Location = new Point(j * (but.Width + 2), 0);
                    //but.Size = FormsManager.Instance.buttonSize;
                    //but.Font = FormsManager.Instance.fontType;
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    var topicName = new Label();
                    var topicDate = new Label();
                    var topicAuthor = new Label();
                    var topicReadyContent = new Label();
                    var topicReadyForEdit = new Label();
                    //design
                    topicName.Font = FormsManager.Instance.fontType;
                    topicName.ForeColor = FormsManager.Instance.bColor;
                    topicName.FlatStyle = FormsManager.Instance.flatStyle;
                    topicName.TextAlign = ContentAlignment.MiddleCenter;

                    topicDate.Font = FormsManager.Instance.fontType;
                    topicDate.ForeColor = FormsManager.Instance.bColor;
                    topicDate.FlatStyle = FormsManager.Instance.flatStyle;
                    topicDate.TextAlign = ContentAlignment.MiddleCenter;

                    topicAuthor.Font = FormsManager.Instance.fontType;
                    topicAuthor.ForeColor = FormsManager.Instance.bColor;
                    topicAuthor.FlatStyle = FormsManager.Instance.flatStyle;
                    topicAuthor.TextAlign = ContentAlignment.MiddleCenter;

                    topicReadyContent.Font = FormsManager.Instance.fontType;
                    topicReadyContent.ForeColor = FormsManager.Instance.bColor;
                    topicReadyContent.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyContent.TextAlign = ContentAlignment.MiddleCenter;

                    topicReadyForEdit.Font = FormsManager.Instance.fontType;
                    topicReadyForEdit.ForeColor = FormsManager.Instance.bColor;
                    topicReadyForEdit.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyForEdit.TextAlign = ContentAlignment.MiddleCenter;

                    var but1 = new Button();
                    //design
                    but1.Size = FormsManager.Instance.buttonSize;
                    but1.Font = FormsManager.Instance.fontType;
                    but1.BackColor = FormsManager.Instance.bColor;
                    but1.ForeColor = FormsManager.Instance.tColor;
                    but1.FlatStyle = FormsManager.Instance.flatStyle;
                    but1.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

                    int i = 0;
                    topicName.Text = TopicList.Instance.Topics[j].topicName;
                    panel.Controls.Add(topicName, i++, j);
                    topicDate.Text = TopicList.Instance.Topics[j].date.ToString("MM/dd/yyyy hh:mm tt");
                    panel.Controls.Add(topicDate, i++, j);
                    topicAuthor.Text = TopicList.Instance.Topics[j].author;
                    panel.Controls.Add(topicAuthor, i++, j);
                    topicReadyContent.Text = TopicList.Instance.Topics[j].readyContent == true ? "✓" : "×";
                    panel.Controls.Add(topicReadyContent, i++, j);
                    topicReadyForEdit.Text = TopicList.Instance.Topics[j].readyForEdit == true ? "✓" : "×";
                    panel.Controls.Add(topicReadyForEdit, i++, j);
                    but1.Text = "Edit";
                    but1.Click += (sender1, EventArgs) => { btnClick(sender1, eventArgs, i); };
                    panel.Controls.Add(but1, i, j);
                }
            }
        }

        private void btnClick(object sender, EventArgs eventArgs, int buttonId)
        {
             
        }

        private void signoutButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Show();
            FormsManager.Instance.Forms.RemoveAt(FormsManager.Instance.Forms.Count - 1);
            this.Close();
        }

        private void readyForEdit_Click(object sender, EventArgs eventArgs)
        {
            RichTextBox TopicName = Controls.Find("TopicName", true)[0] as RichTextBox;
            string text1 = TopicName.Text;

            RichTextBox TopicContent = Controls.Find("TopicContent", true)[0] as RichTextBox;
            string text2 = TopicContent.Text;

            bool alreadyExists = false;

            foreach (Topic topic in TopicList.Instance.Topics)
            {
                if (topic.topicName.Equals(text1))
                {
                    alreadyExists = true;
                    MessageBox.Show("An article with the same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            if (!alreadyExists)
            {
                Topic newTopic = new Topic();
                newTopic.topicName = text1;
                newTopic.topicContent = text2;
                newTopic.readyForEdit = true;
                newTopic.date = DateTime.Now;
                newTopic.author = Journalist.Instance.Name;
                TopicList.Instance.Topics.Add(newTopic);
            }

            CreateButtonDelegate(null, null);
        }

        private void confirmTopicButton_Click(object sender, EventArgs eventArgs)
        {
            RichTextBox TopicName = Controls.Find("TopicName", true)[0] as RichTextBox;
            string text1 = TopicName.Text;

            RichTextBox TopicContent = Controls.Find("TopicContent", true)[0] as RichTextBox;
            string text2 = TopicContent.Text;

            bool alreadyExists = false;

            foreach (Topic topic in TopicList.Instance.Topics)
            {
                if (topic.topicName.Equals(text1))
                {
                    alreadyExists = true;
                    MessageBox.Show("An article with the same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            if(!alreadyExists)
            {
                Topic newTopic = new Topic();
                newTopic.topicName = text1;
                newTopic.topicContent = text2;
                newTopic.date = DateTime.Now;
                newTopic.author = Journalist.Instance.Name;
                TopicList.Instance.Topics.Add(newTopic);
            }

            CreateButtonDelegate(null, null);
        }
       
        private void exitButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Close();
        }
    }
}
