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

        public void viewListOfTopic(object sender, EventArgs eventArgs)
        {
            if (TopicList.Instance.Topics.Count != 0)
            {
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.AutoScroll = true;
                panel.Width = FormsManager.Instance.panelWidth;
                panel.Height = FormsManager.Instance.panelHeight * (TopicList.Instance.Topics.Count + 1);
                panel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                panel.RowCount = TopicList.Instance.Topics.Count();
                panel.ColumnCount = 6;
                panel.ColumnStyles.Clear();
                panel.RowStyles.Clear();
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
                panel.Top = FormsManager.Instance.panelHeight;
                this.Controls.Add(panel);
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

                var topicNameL = new Label();
                var topicDateL = new Label();
                var topicAuthorL = new Label();
                var topicReadyContentL = new Label();
                var topicReadyForEditL = new Label();
                //design
                topicNameL.Font = FormsManager.Instance.fontType;
                topicNameL.ForeColor = FormsManager.Instance.bColor;
                topicNameL.FlatStyle = FormsManager.Instance.flatStyle;
                topicNameL.TextAlign = ContentAlignment.MiddleLeft;
                topicNameL.Dock = DockStyle.Fill;

                topicDateL.Font = FormsManager.Instance.fontType;
                topicDateL.ForeColor = FormsManager.Instance.bColor;
                topicDateL.FlatStyle = FormsManager.Instance.flatStyle;
                topicDateL.TextAlign = ContentAlignment.MiddleLeft;
                topicDateL.Dock = DockStyle.Fill;

                topicAuthorL.Font = FormsManager.Instance.fontType;
                topicAuthorL.ForeColor = FormsManager.Instance.bColor;
                topicAuthorL.FlatStyle = FormsManager.Instance.flatStyle;
                topicAuthorL.TextAlign = ContentAlignment.MiddleLeft;
                topicAuthorL.Dock = DockStyle.Fill;

                topicReadyContentL.Font = FormsManager.Instance.fontType;
                topicReadyContentL.ForeColor = FormsManager.Instance.bColor;
                topicReadyContentL.FlatStyle = FormsManager.Instance.flatStyle;
                topicReadyContentL.TextAlign = ContentAlignment.MiddleLeft;
                topicReadyContentL.Dock = DockStyle.Fill;

                topicReadyForEditL.Font = FormsManager.Instance.fontType;
                topicReadyForEditL.ForeColor = FormsManager.Instance.bColor;
                topicReadyForEditL.FlatStyle = FormsManager.Instance.flatStyle;
                topicReadyForEditL.TextAlign = ContentAlignment.MiddleLeft;
                topicReadyForEditL.Dock = DockStyle.Fill;

                int k = 0;

                topicNameL.Text = "Name";
                panel.Controls.Add(topicNameL, k++, 0);

                topicDateL.Text = "Date";
                panel.Controls.Add(topicDateL, k++, 0);

                topicAuthorL.Text = "Author";
                panel.Controls.Add(topicAuthorL, k++, 0);

                topicReadyContentL.Text = "Content";
                panel.Controls.Add(topicReadyContentL, k++, 0);

                topicReadyForEditL.Text = "Photos";
                panel.Controls.Add(topicReadyForEditL, k, 0);

                for (int j = 1; j < TopicList.Instance.Topics.Count() + 1; j++)
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    var topicName = new Label();
                    var topicDate = new Label();
                    var topicAuthor = new Label();
                    var topicReadyForEdit = new Label();
                    var topicReadyPhotos = new Label();
                    //design
                    topicName.Font = FormsManager.Instance.fontType;
                    topicName.ForeColor = FormsManager.Instance.bColor;
                    topicName.FlatStyle = FormsManager.Instance.flatStyle;
                    topicName.TextAlign = ContentAlignment.MiddleLeft;
                    topicName.Dock = DockStyle.Fill;

                    topicDate.Font = FormsManager.Instance.fontType;
                    topicDate.ForeColor = FormsManager.Instance.bColor;
                    topicDate.FlatStyle = FormsManager.Instance.flatStyle;
                    topicDate.TextAlign = ContentAlignment.MiddleLeft;
                    topicDate.Dock = DockStyle.Fill;

                    topicAuthor.Font = FormsManager.Instance.fontType;
                    topicAuthor.ForeColor = FormsManager.Instance.bColor;
                    topicAuthor.FlatStyle = FormsManager.Instance.flatStyle;
                    topicAuthor.TextAlign = ContentAlignment.MiddleLeft;
                    topicAuthor.Dock = DockStyle.Fill;

                    topicReadyForEdit.Font = FormsManager.Instance.fontType;
                    topicReadyForEdit.ForeColor = FormsManager.Instance.bColor;
                    topicReadyForEdit.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyForEdit.TextAlign = ContentAlignment.MiddleCenter;
                    topicReadyForEdit.Dock = DockStyle.Fill;

                    topicReadyPhotos.Font = FormsManager.Instance.fontType;
                    topicReadyPhotos.ForeColor = FormsManager.Instance.bColor;
                    topicReadyPhotos.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyPhotos.TextAlign = ContentAlignment.MiddleCenter;
                    topicReadyPhotos.Dock = DockStyle.Fill;

                    var editButton = new Button();
                    //design
                    editButton.Size = FormsManager.Instance.buttonSize;
                    editButton.Font = FormsManager.Instance.fontType;
                    editButton.BackColor = FormsManager.Instance.bColor;
                    editButton.ForeColor = FormsManager.Instance.tColor;
                    editButton.FlatStyle = FormsManager.Instance.flatStyle;
                    editButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
                    editButton.Text = "Edit";

                    int i = 0;

                    topicName.Text = TopicList.Instance.Topics[j - 1].topicName;
                    panel.Controls.Add(topicName, i++, j);

                    topicDate.Text = TopicList.Instance.Topics[j - 1].date;
                    panel.Controls.Add(topicDate, i++, j);

                    topicAuthor.Text = TopicList.Instance.Topics[j - 1].author;
                    panel.Controls.Add(topicAuthor, i++, j);

                    topicReadyForEdit.Text = TopicList.Instance.Topics[j - 1].readyForEdit == true ? "✓" : "×";
                    panel.Controls.Add(topicReadyForEdit, i++, j);

                    topicReadyPhotos.Text = TopicList.Instance.Topics[j - 1].readyForEdit == true ? "✓" : "×";
                    panel.Controls.Add(topicReadyPhotos, i++, j);

                    panel.Controls.Add(editButton, i, j);

                    int topicId = j - 1;

                    editButton.Click += (sender1, EventArgs) => { editButton_Click(sender1, eventArgs, topicId); };
                }
            }
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
            addButton.Text = "Add article";
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
            TableLayoutPanel buttonsPanel = new TableLayoutPanel();
            buttonsPanel.Name = "ButtonsTablePanel";
            buttonsPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            buttonsPanel.Size = FormsManager.Instance.panelSize;
            buttonsPanel.Top = 0;
            buttonsPanel.BackColor = FormsManager.Instance.bColor;
            buttonsPanel.RowCount = 1;
            buttonsPanel.ColumnCount = 3;
            buttonsPanel.ColumnStyles.Clear();
            buttonsPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            this.Controls.Add(buttonsPanel);
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

            Button backButton = new Button();
            backButton.Font = FormsManager.Instance.fontType;
            backButton.BackColor = FormsManager.Instance.bColor;
            backButton.ForeColor = FormsManager.Instance.tColor;
            backButton.FlatStyle = FormsManager.Instance.flatStyle;
            backButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
            backButton.Text = "Back";
            backButton.Size = FormsManager.Instance.buttonSize;           
            backButton.Click += CreateButtonDelegate;
            buttonsPanel.Controls.Add(backButton, 0, 0);

            Label sortLabel = new Label();
            sortLabel.Text = "Sort by";
            sortLabel.TextAlign = ContentAlignment.MiddleCenter;
            sortLabel.Size = FormsManager.Instance.buttonSize;
            sortLabel.Font = FormsManager.Instance.fontType;
            sortLabel.ForeColor = FormsManager.Instance.tColor;
            sortLabel.FlatStyle = FormsManager.Instance.flatStyle;
            buttonsPanel.Controls.Add(sortLabel, 1, 0);

            ComboBox sortComboBox = new ComboBox();
            sortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortComboBox.Items.AddRange(FormsManager.Instance.sort);
            sortComboBox.Size = FormsManager.Instance.buttonSize;
            sortComboBox.Name = "SortTextbox";
            sortComboBox.Font = FormsManager.Instance.fontType;
            sortComboBox.BackColor = FormsManager.Instance.bColor;
            sortComboBox.ForeColor = FormsManager.Instance.tColor;
            sortComboBox.FlatStyle = FormsManager.Instance.flatStyle;
            buttonsPanel.Controls.Add(sortComboBox, 2, 0);

            sortComboBox.SelectedIndexChanged += sortComboBox_IndexChanged;

            viewListOfTopic(null, null);
        }

        private void sortComboBox_IndexChanged(object sender, EventArgs eventArgs)
        {
            ComboBox TopicName = Controls.Find("SortTextbox", true)[0] as ComboBox;
            string text1 = TopicName.Text;
            
            string selectedSortType = text1;

            foreach (Control control in this.Controls)
            {
                if (!control.Name.Equals("ButtonsTablePanel"))
                        this.Controls.Remove(control);
            }

            if (selectedSortType == FormsManager.Instance.sort[0])
            {
                TopicList.Instance.Topics.Sort((t1, t2) => t1.topicName.CompareTo(t2.topicName));
            }
            if (selectedSortType == FormsManager.Instance.sort[1])
            {
                TopicList.Instance.Topics.Sort((t1, t2) => t1.date.CompareTo(t2.date));
            }
            if (selectedSortType == FormsManager.Instance.sort[2])
            {
                TopicList.Instance.Topics.Sort((t1, t2) => t1.author.CompareTo(t2.author));
            }

            viewListOfTopic(null, null);
        }

        private void editButton_Click(object sender, EventArgs eventArgs, int topicId)
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
                    topic.readyForEdit = true;
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
                newTopic.date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                newTopic.author = Journalist.Instance.Name;
                TopicList.Instance.Topics.Add(newTopic);

                CreateButtonDelegate(null, null);
            }
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
                newTopic.date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                newTopic.author = Journalist.Instance.Name;
                TopicList.Instance.Topics.Add(newTopic);

                CreateButtonDelegate(null, null);
            }
        }
       
        private void exitButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Close();
        }
    }
}
