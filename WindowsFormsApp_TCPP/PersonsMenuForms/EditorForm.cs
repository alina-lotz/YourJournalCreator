using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_TCPP.PersonsMenuForms
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
            this.StartPosition = FormsManager.Instance.formPosition;
            this.Text = "Editor";
            this.Size = FormsManager.Instance.formSize;
            this.BackColor = FormsManager.Instance.bgColor;

            this.Shown += CreateButtonDelegate;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);

            FormsManager.Instance.Forms.Add(this);
        }

        public void FormIsClosing(object sender, EventArgs e)
        {
            FormsManager.Instance.Forms[0].Close();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            this.Controls.Clear();

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
            signoutButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent);
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

            Button delAccButton = new Button();
            this.Controls.Add(delAccButton);
            delAccButton.Text = "Remove account";
            delAccButton.Size = FormsManager.Instance.buttonSize;
            delAccButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 4);
            //design
            delAccButton.Font = FormsManager.Instance.fontType;
            delAccButton.BackColor = FormsManager.Instance.bColor;
            delAccButton.ForeColor = FormsManager.Instance.tColor;
            delAccButton.FlatStyle = FormsManager.Instance.flatStyle;
            delAccButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
            delAccButton.Click += delAccButton_Click;

            viewTopicsButton.Click += viewTopicsButton_Click;
            signoutButton.Click += signoutButton_Click;
            exitButton.Click += exitButton_Click;
        }

        private void DelAccButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        private void viewListOfTopic(object sender, EventArgs eventArgs)
        {
            if (TopicList.Instance.Topics.Count() != 0)
            {
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.AutoScroll = true;
                panel.Width = FormsManager.Instance.panelWidth;
                panel.Height = FormsManager.Instance.panelHeight * (TopicList.Instance.Topics.Count() + 1);
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
                var topicReadyForEditL = new Label();
                var topicReadyForJournalL = new Label();

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

                topicReadyForEditL.Font = FormsManager.Instance.fontType;
                topicReadyForEditL.ForeColor = FormsManager.Instance.bColor;
                topicReadyForEditL.FlatStyle = FormsManager.Instance.flatStyle;
                topicReadyForEditL.TextAlign = ContentAlignment.MiddleLeft;
                topicReadyForEditL.Dock = DockStyle.Fill;

                topicReadyForJournalL.Font = FormsManager.Instance.fontType;
                topicReadyForJournalL.ForeColor = FormsManager.Instance.bColor;
                topicReadyForJournalL.FlatStyle = FormsManager.Instance.flatStyle;
                topicReadyForJournalL.TextAlign = ContentAlignment.MiddleLeft;
                topicReadyForJournalL.Dock = DockStyle.Fill;

                int k = 0;

                topicNameL.Text = "Name";
                panel.Controls.Add(topicNameL, k++, 0);

                topicDateL.Text = "Date";
                panel.Controls.Add(topicDateL, k++, 0);

                topicAuthorL.Text = "Author";
                panel.Controls.Add(topicAuthorL, k++, 0);

                topicReadyForEditL.Text = "Content";
                panel.Controls.Add(topicReadyForEditL, k++, 0);

                topicReadyForJournalL.Text = "Journal";
                panel.Controls.Add(topicReadyForJournalL, k, 0);

                for (int j = 1; j < TopicList.Instance.Topics.Count() + 1; j++)
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    var topicName = new Label();
                    var topicDate = new Label();
                    var topicAuthor = new Label();
                    var topicReadyForEdit = new Label();
                    var topicReadyForJournal = new Label();
                    //design
                    topicName.Font = FormsManager.Instance.fontType;
                    topicName.ForeColor = FormsManager.Instance.bColor;
                    topicName.FlatStyle = FormsManager.Instance.flatStyle;
                    topicName.TextAlign = ContentAlignment.TopLeft;
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

                    topicReadyForJournal.Font = FormsManager.Instance.fontType;
                    topicReadyForJournal.ForeColor = FormsManager.Instance.bColor;
                    topicReadyForJournal.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyForJournal.TextAlign = ContentAlignment.MiddleCenter;
                    topicReadyForJournal.Dock = DockStyle.Fill;

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

                    topicReadyForJournal.Text = TopicList.Instance.Topics[j - 1].readyForJournal == true ? "✓" : "×";
                    panel.Controls.Add(topicReadyForJournal, i++, j);

                    panel.Controls.Add(editButton, i, j);

                    int topicId = j - 1;

                    editButton.Click += (sender1, EventArgs) => { editButton_Click(sender1, eventArgs, topicId); };
                }
            }
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
            this.Controls.Clear();

            int articleContentWidth = 400, articleContentHeight = 200;
            int photoSize = 280;

            Label topicNameL = new Label();
            this.Controls.Add(topicNameL);
            topicNameL.Text = "Article title";
            topicNameL.Size = FormsManager.Instance.buttonSize;
            topicNameL.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.indent / 2 + FormsManager.Instance.indent * 3);
            //design
            topicNameL.Font = FormsManager.Instance.fontType;
            topicNameL.ForeColor = FormsManager.Instance.bColor;
            topicNameL.FlatStyle = FormsManager.Instance.flatStyle;

            RichTextBox topicNameText = new RichTextBox();
            this.Controls.Add(topicNameText);
            topicNameText.Size = new Size(articleContentWidth, FormsManager.Instance.buttonHeight);
            topicNameText.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.indent / 2 + FormsManager.Instance.indent * 4);
            topicNameText.Name = "TopicName";
            topicNameText.WordWrap = true;
            //design
            topicNameText.Text = TopicList.Instance.Topics[topicId].topicName;
            topicNameText.Font = FormsManager.Instance.fontType;
            topicNameText.BackColor = FormsManager.Instance.bColor;
            topicNameText.ForeColor = FormsManager.Instance.tColor;
            topicNameText.BorderStyle = FormsManager.Instance.borderStyle;

            Label topicContentL = new Label();
            this.Controls.Add(topicContentL);
            topicContentL.Text = "Content";
            topicContentL.Size = FormsManager.Instance.buttonSize;
            topicContentL.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.indent / 2 + FormsManager.Instance.indent * 5);
            //design
            topicContentL.Font = FormsManager.Instance.fontType;
            topicContentL.ForeColor = FormsManager.Instance.bColor;
            topicContentL.FlatStyle = FormsManager.Instance.flatStyle;

            RichTextBox topicContectText = new RichTextBox();
            this.Controls.Add(topicContectText);
            topicContectText.Size = new Size(articleContentWidth, articleContentHeight);
            topicContectText.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.indent / 2 + FormsManager.Instance.indent * 6);
            topicContectText.WordWrap = true;
            topicContectText.Name = "TopicContent";
            //design
            topicContectText.Text = TopicList.Instance.Topics[topicId].topicContent;
            topicContectText.Font = FormsManager.Instance.fontType;
            topicContectText.BackColor = FormsManager.Instance.bColor;
            topicContectText.ForeColor = FormsManager.Instance.tColor;
            topicContectText.BorderStyle = FormsManager.Instance.borderStyle;

            PictureBox imageControl = new PictureBox();
            imageControl.Name = "TopicPhoto";
            imageControl.Size = new Size(photoSize, photoSize);
            imageControl.Location = new Point(FormsManager.Instance.block2 + articleContentWidth + 20, topicNameText.Location.Y);
            imageControl.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(imageControl);
            if (TopicList.Instance.Topics[topicId].topicPhoto != null && TopicList.Instance.Topics[topicId].topicPhoto.Length != 0)
            {
                using (var ms = new MemoryStream(TopicList.Instance.Topics[topicId].topicPhoto))
                {
                    Bitmap tempBM = new Bitmap(ms);
                    //newTopic.topicPhoto = new Bitmap(tempBM);
                    imageControl.Image = tempBM;
                }
            }

            Button editButton = new Button();
            this.Controls.Add(editButton);
            editButton.Text = "Edit";
            editButton.Size = FormsManager.Instance.buttonSize;
            editButton.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.indent / 2);
            //design
            editButton.Font = FormsManager.Instance.fontType;
            editButton.BackColor = FormsManager.Instance.bColor;
            editButton.ForeColor = FormsManager.Instance.tColor;
            editButton.FlatStyle = FormsManager.Instance.flatStyle;
            editButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button readyForJournalButton = new Button();
            this.Controls.Add(readyForJournalButton);
            readyForJournalButton.Text = "Send to Layout";
            readyForJournalButton.Size = FormsManager.Instance.buttonSize;
            readyForJournalButton.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.indent / 2 + FormsManager.Instance.indent);
            //design
            readyForJournalButton.Font = FormsManager.Instance.fontType;
            readyForJournalButton.BackColor = FormsManager.Instance.bColor;
            readyForJournalButton.ForeColor = FormsManager.Instance.tColor;
            readyForJournalButton.FlatStyle = FormsManager.Instance.flatStyle;
            readyForJournalButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button cancelButton = new Button();
            this.Controls.Add(cancelButton);
            cancelButton.Text = "Cancel";
            cancelButton.Size = FormsManager.Instance.buttonSize;
            cancelButton.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.indent / 2 + FormsManager.Instance.indent * 2);
            //design
            cancelButton.Font = FormsManager.Instance.fontType;
            cancelButton.BackColor = FormsManager.Instance.bColor;
            cancelButton.ForeColor = FormsManager.Instance.tColor;
            cancelButton.FlatStyle = FormsManager.Instance.flatStyle;
            cancelButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            editButton.Click += (sender1, EventArgs) => { confirmEditing_Click(sender1, eventArgs, topicId); };
            if (TopicList.Instance.Topics[topicId].readyForEdit)
            {
                readyForJournalButton.Click += (sender1, EventArgs) => { confirmReadyForJournal_Click(sender1, eventArgs, topicId); };
            }
            cancelButton.Click += viewTopicsButton_Click;
        }

        private void confirmEditing_Click(object sender, EventArgs eventArgs, int topicId)
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
                TopicList.Instance.Topics[topicId].topicName = text1;
                TopicList.Instance.Topics[topicId].topicContent = text2;
                TopicList.Instance.Topics[topicId].date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            }
        }

        private void confirmReadyForJournal_Click(object sender, EventArgs eventArgs, int topicId)
        {
            TopicList.Instance.Topics[topicId].readyForJournal = true;
            TopicList.Instance.Topics[topicId].date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        }

        private void signoutButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Show();
            FormsManager.Instance.Forms.RemoveAt(FormsManager.Instance.Forms.Count - 1);
            this.Close();
        }
        
        private void exitButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Close();
        }

        private void delAccButton_Click(object sender, EventArgs eventArgs)
        {
            for (int i = 0; i < PersonsList.persons.Count(); i++)
            {
                if (PersonsList.persons[i].Name == Editor.Instance.Name
                    && PersonsList.persons[i].Password == Editor.Instance.Password)
                {
                    PersonsList.persons.RemoveAt(i);
                    break;
                }
            }
            FormsManager.Instance.Forms[0].Show();
            FormsManager.Instance.Forms.RemoveAt(FormsManager.Instance.Forms.Count - 1);
            this.Close();
        }
    }
}
