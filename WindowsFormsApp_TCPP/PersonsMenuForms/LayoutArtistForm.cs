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
    public partial class LayoutArtistForm : Form
    {
        Journal journal = new Journal();

        public LayoutArtistForm()
        {
            InitializeComponent();
            this.StartPosition = FormsManager.Instance.formPosition;
            this.Text = "Layout artist";
            this.Size = FormsManager.Instance.formSize;
            this.BackColor = FormsManager.Instance.bgColor;

            this.Shown += CreateButtonDelegate;

            FormsManager.Instance.Forms.Add(this);
        }

        private void LayoutArtist_Load(object sender, EventArgs e)
        {

        }

        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            this.Controls.Clear();

            Button createJournal = new Button();
            this.Controls.Add(createJournal);
            createJournal.Text = "Add journal";
            createJournal.Size = FormsManager.Instance.buttonSize;
            createJournal.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height);
            //design
            createJournal.Font = FormsManager.Instance.fontType;
            createJournal.BackColor = FormsManager.Instance.bColor;
            createJournal.ForeColor = FormsManager.Instance.tColor;
            createJournal.FlatStyle = FormsManager.Instance.flatStyle;
            createJournal.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button viewJournalsButton = new Button();
            this.Controls.Add(viewJournalsButton);
            viewJournalsButton.Text = "View all journals";
            viewJournalsButton.Size = FormsManager.Instance.buttonSize;
            viewJournalsButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent);
            //design
            viewJournalsButton.Font = FormsManager.Instance.fontType;
            viewJournalsButton.BackColor = FormsManager.Instance.bColor;
            viewJournalsButton.ForeColor = FormsManager.Instance.tColor;
            viewJournalsButton.FlatStyle = FormsManager.Instance.flatStyle;
            viewJournalsButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button viewTopicsButton = new Button();
            this.Controls.Add(viewTopicsButton);
            viewTopicsButton.Text = "View articles";
            viewTopicsButton.Size = FormsManager.Instance.buttonSize;
            viewTopicsButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 2);
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
            signoutButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 3);
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
            exitButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 4);
            //design
            exitButton.Font = FormsManager.Instance.fontType;
            exitButton.BackColor = FormsManager.Instance.bColor;
            exitButton.ForeColor = FormsManager.Instance.tColor;
            exitButton.FlatStyle = FormsManager.Instance.flatStyle;
            exitButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            createJournal.Click += addJournalButton_Click;
            //viewJournalsButton.Click +=;
            viewTopicsButton.Click += viewTopicsButton_Click;
            signoutButton.Click += signoutButton_Click;
            exitButton.Click += exitButton_Click;
        }

        private void addJournalButton_Click(object sender, EventArgs eventArgs)
        {
            this.Controls.Clear();

            int journalContentWidth = 400, journalContentHeight = 200;

            Label journalNameL = new Label();
            this.Controls.Add(journalNameL);
            journalNameL.Text = "Journal title";
            journalNameL.Size = FormsManager.Instance.buttonSize;
            journalNameL.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height);
            journalNameL.Font = FormsManager.Instance.fontType;
            journalNameL.ForeColor = FormsManager.Instance.bColor;
            journalNameL.FlatStyle = FormsManager.Instance.flatStyle;

            RichTextBox journalNameText = new RichTextBox();
            this.Controls.Add(journalNameText);
            journalNameText.Size = new Size(journalContentWidth, FormsManager.Instance.buttonHeight);
            journalNameText.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height + FormsManager.Instance.indent);
            journalNameText.Name = "JournalName";
            journalNameText.Font = FormsManager.Instance.fontType;
            journalNameText.BackColor = FormsManager.Instance.bColor;
            journalNameText.ForeColor = FormsManager.Instance.tColor;
            journalNameText.BorderStyle = FormsManager.Instance.borderStyle;

            Button addTopicButton = new Button();
            this.Controls.Add(addTopicButton);
            addTopicButton.Text = "Add article";
            addTopicButton.Size = FormsManager.Instance.buttonSize;
            addTopicButton.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height + FormsManager.Instance.indent * 2);
            addTopicButton.Font = FormsManager.Instance.fontType;
            addTopicButton.BackColor = FormsManager.Instance.bColor;
            addTopicButton.ForeColor = FormsManager.Instance.tColor;
            addTopicButton.FlatStyle = FormsManager.Instance.flatStyle;
            addTopicButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Panel topicsPanel = new Panel();
            topicsPanel.Size = new Size(journalContentWidth, journalContentHeight);
            topicsPanel.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height + FormsManager.Instance.indent * 3);

            if (journal.journalTopics.Count() != 0)
            {
                TableLayoutPanel topicsListPanel = new TableLayoutPanel();
                topicsListPanel.AutoScroll = true;
                topicsListPanel.Width = journalContentWidth;
                topicsListPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                topicsListPanel.RowCount = journal.journalTopics.Count();
                topicsListPanel.ColumnCount = 3;
                topicsListPanel.ColumnStyles.Clear();
                topicsListPanel.RowStyles.Clear();
                topicsListPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
                topicsListPanel.Top = FormsManager.Instance.panelHeight * journal.journalTopics.Count();
                topicsListPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
                topicsListPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
                topicsListPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
                topicsListPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
                topicsListPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                topicsPanel.Controls.Add(topicsListPanel);

                for (int j = 0; j < journal.journalTopics.Count(); j++)
                {
                    var topicName = new Label();
                    var topicDate = new Label();
                    var topicReadyForJournal = new Label();
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

                    topicReadyForJournal.Font = FormsManager.Instance.fontType;
                    topicReadyForJournal.ForeColor = FormsManager.Instance.bColor;
                    topicReadyForJournal.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyForJournal.TextAlign = ContentAlignment.MiddleLeft;
                    topicReadyForJournal.Dock = DockStyle.Fill;

                    topicReadyPhotos.Font = FormsManager.Instance.fontType;
                    topicReadyPhotos.ForeColor = FormsManager.Instance.bColor;
                    topicReadyPhotos.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyPhotos.TextAlign = ContentAlignment.MiddleLeft;
                    topicReadyPhotos.Dock = DockStyle.Fill;

                    var viewTopicButton = new Button();
                    //design
                    viewTopicButton.Size = FormsManager.Instance.buttonSize;
                    viewTopicButton.Font = FormsManager.Instance.fontType;
                    viewTopicButton.BackColor = FormsManager.Instance.bColor;
                    viewTopicButton.ForeColor = FormsManager.Instance.tColor;
                    viewTopicButton.FlatStyle = FormsManager.Instance.flatStyle;
                    viewTopicButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
                    viewTopicButton.Text = "View";

                    int i = 0;

                    topicName.Text = journal.journalTopics[j].topicName;
                    topicsListPanel.Controls.Add(topicName, i++, j);

                    topicDate.Text = journal.journalTopics[j].date.ToString("MM/dd/yyyy hh:mm tt");
                    topicsListPanel.Controls.Add(topicDate, i++, j);

                    topicReadyForJournal.Text = journal.journalTopics[j].readyContent == true ? "✓" : "×";
                    topicsListPanel.Controls.Add(topicReadyForJournal, i++, j);

                    topicReadyPhotos.Text = journal.journalTopics[j].readyPhotos == true ? "✓" : "×";
                    topicsListPanel.Controls.Add(topicReadyPhotos, i, j);
                }
            }

            Button addButton = new Button();
            this.Controls.Add(addButton);
            addButton.Text = "Add article";
            addButton.Size = FormsManager.Instance.buttonSize;
            addButton.Location = new Point(FormsManager.Instance.block3, journalNameText.Location.Y);
            addButton.Font = FormsManager.Instance.fontType;
            addButton.BackColor = FormsManager.Instance.bColor;
            addButton.ForeColor = FormsManager.Instance.tColor;
            addButton.FlatStyle = FormsManager.Instance.flatStyle;
            addButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button readyForPrint = new Button();
            this.Controls.Add(readyForPrint);
            readyForPrint.Text = "Send to the editor";
            readyForPrint.Size = FormsManager.Instance.buttonSize;
            readyForPrint.Location = new Point(FormsManager.Instance.block3, journalNameText.Location.Y + FormsManager.Instance.indent);
            readyForPrint.Font = FormsManager.Instance.fontType;
            readyForPrint.BackColor = FormsManager.Instance.bColor;
            readyForPrint.ForeColor = FormsManager.Instance.tColor;
            readyForPrint.FlatStyle = FormsManager.Instance.flatStyle;
            readyForPrint.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button cancelButton = new Button();
            this.Controls.Add(cancelButton);
            cancelButton.Text = "Cancle";
            cancelButton.Size = FormsManager.Instance.buttonSize;
            cancelButton.Location = new Point(FormsManager.Instance.block3, journalNameText.Location.Y + FormsManager.Instance.indent * 2);
            cancelButton.Font = FormsManager.Instance.fontType;
            cancelButton.BackColor = FormsManager.Instance.bColor;
            cancelButton.ForeColor = FormsManager.Instance.tColor;
            cancelButton.FlatStyle = FormsManager.Instance.flatStyle;
            cancelButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            addTopicButton.Click += viewTopicsButton_Click;
            readyForPrint.Click += readyJournalForPrint_Click;
            addButton.Click += confirmJournalButton_Click;
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

            backButton.Click += addJournalButton_Click;
            sortComboBox.SelectedIndexChanged += sortComboBox_IndexChanged;

            viewListOfTopic(null, null);
        }

        public void viewListOfTopic(object sender, EventArgs eventArgs)
        {
            if (TopicList.Instance.Topics.Count != 0)
            {
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.AutoScroll = true;
                panel.Width = FormsManager.Instance.panelWidth;
                panel.Height = FormsManager.Instance.panelHeight * TopicList.Instance.Topics.Count;
                panel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                panel.RowCount = TopicList.Instance.Topics.Count();
                panel.ColumnCount = 7;
                panel.ColumnStyles.Clear();
                panel.RowStyles.Clear();
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
                panel.Top = FormsManager.Instance.panelHeight;
                this.Controls.Add(panel);
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                for (int j = 0; j < TopicList.Instance.Topics.Count(); j++)
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    var topicName = new Label();
                    var topicDate = new Label();
                    var topicAuthor = new Label();
                    var topicReadyContent = new Label();
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

                    topicReadyContent.Font = FormsManager.Instance.fontType;
                    topicReadyContent.ForeColor = FormsManager.Instance.bColor;
                    topicReadyContent.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyContent.TextAlign = ContentAlignment.MiddleLeft;
                    topicReadyContent.Dock = DockStyle.Fill;

                    topicReadyPhotos.Font = FormsManager.Instance.fontType;
                    topicReadyPhotos.ForeColor = FormsManager.Instance.bColor;
                    topicReadyPhotos.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyPhotos.TextAlign = ContentAlignment.MiddleLeft;
                    topicReadyPhotos.Dock = DockStyle.Fill;

                    var viewTopicButton = new Button();
                    var addTopicButton = new Button();
                    //design
                    viewTopicButton.Size = FormsManager.Instance.buttonSize;
                    viewTopicButton.Font = FormsManager.Instance.fontType;
                    viewTopicButton.BackColor = FormsManager.Instance.bColor;
                    viewTopicButton.ForeColor = FormsManager.Instance.tColor;
                    viewTopicButton.FlatStyle = FormsManager.Instance.flatStyle;
                    viewTopicButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
                    viewTopicButton.Text = "View";

                    addTopicButton.Size = FormsManager.Instance.buttonSize;
                    addTopicButton.Font = FormsManager.Instance.fontType;
                    addTopicButton.BackColor = FormsManager.Instance.bColor;
                    addTopicButton.ForeColor = FormsManager.Instance.tColor;
                    addTopicButton.FlatStyle = FormsManager.Instance.flatStyle;
                    addTopicButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
                    addTopicButton.Text = "Add to journal";

                    int i = 0;

                    topicName.Text = TopicList.Instance.Topics[j].topicName;
                    panel.Controls.Add(topicName, i++, j);

                    topicDate.Text = TopicList.Instance.Topics[j].date.ToString("MM/dd/yyyy hh:mm tt");
                    panel.Controls.Add(topicDate, i++, j);

                    topicAuthor.Text = TopicList.Instance.Topics[j].author;
                    panel.Controls.Add(topicAuthor, i++, j);

                    topicReadyContent.Text = TopicList.Instance.Topics[j].readyContent == true ? "✓" : "×";
                    panel.Controls.Add(topicReadyContent, i++, j);

                    topicReadyPhotos.Text = TopicList.Instance.Topics[j].readyPhotos == true ? "✓" : "×";
                    panel.Controls.Add(topicReadyPhotos, i++, j);

                    panel.Controls.Add(viewTopicButton, i++, j);
                    panel.Controls.Add(addTopicButton, i, j);

                    viewTopicButton.Click += (sender1, EventArgs) => { viewTopicButton_Click(sender1, eventArgs, j); };
                    addTopicButton.Click += (sender1, EventArgs) => { addTopicButton_Click(sender1, eventArgs, j); };
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

        public void addTopicButton_Click(object sender, EventArgs eventArgs, int topicId)
        {
            journal.journalTopics.Add(TopicList.Instance.Topics[topicId]);
        }

        private void viewTopicButton_Click(object sender, EventArgs eventArgs, int topicId)
        {

        }
        
        

        private void readyJournalForPrint_Click(object sender, EventArgs eventArgs)
        {
            bool alreadyExists = false;

            foreach (Journal journal1 in JournalList.Instance.Journals)
            {
                if (journal1.journalName.Equals(journal.journalName))
                {
                    alreadyExists = true;
                    MessageBox.Show("A journal with the same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            if (!alreadyExists)
            {
                Journal newJournal = new Journal();
                newJournal.journalName = journal.journalName;
                newJournal.readyForPrint = true;
                newJournal.date = DateTime.Now;
                newJournal.author = LayoutArtist.Instance.Name;
                for (int i = 0; i < journal.journalTopics.Count(); i++)
                {
                    newJournal.journalTopics.Add(journal.journalTopics[i]);
                }
                JournalList.Instance.Journals.Add(newJournal);
            }

            journal.journalTopics.Clear();

            CreateButtonDelegate(null, null);
        }

        private void confirmJournalButton_Click(object sender, EventArgs eventArgs)
        {
            bool alreadyExists = false;

            foreach (Journal journal1 in JournalList.Instance.Journals)
            {
                if (journal1.journalName.Equals(journal.journalName))
                {
                    alreadyExists = true;
                    MessageBox.Show("A journal with the same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            if (!alreadyExists)
            {
                Journal newJournal = new Journal();
                newJournal.journalName = journal.journalName;
                newJournal.date = DateTime.Now;
                newJournal.author = LayoutArtist.Instance.Name;
                for (int i = 0; i < journal.journalTopics.Count(); i++)
                {
                    newJournal.journalTopics.Add(journal.journalTopics[i]);
                }
                JournalList.Instance.Journals.Add(newJournal);
            }

            journal.journalTopics.Clear();

            CreateButtonDelegate(null, null);
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

    }
}
