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
    public partial class LayoutArtistForm : Form
    {
        Journal journal = new Journal();
        bool journalAlreadyExist = false;
        int existedJournalId;

        public LayoutArtistForm()
        {
            InitializeComponent();
            this.StartPosition = FormsManager.Instance.formPosition;
            this.Text = "CreateYourJournal";
            this.Size = FormsManager.Instance.formSize;
            this.BackColor = FormsManager.Instance.bgColor;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            this.Shown += CreateButtonDelegate;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);

            FormsManager.Instance.Forms.Add(this);
        }

        public void FormIsClosing(object sender, EventArgs e)
        {
            //FormsManager.Instance.Forms[0].Close();
        }

        private void LayoutArtist_Load(object sender, EventArgs e)
        {

        }

        //Main menu
        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            this.Controls.Clear();
            journal.journalTopics.Clear();
            journal.journalName = "";

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

            Button delAccButton = new Button();
            this.Controls.Add(delAccButton);
            delAccButton.Text = "Remove account";
            delAccButton.Size = FormsManager.Instance.buttonSize;
            delAccButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 5);
            //design
            delAccButton.Font = FormsManager.Instance.fontType;
            delAccButton.BackColor = FormsManager.Instance.bColor;
            delAccButton.ForeColor = FormsManager.Instance.tColor;
            delAccButton.FlatStyle = FormsManager.Instance.flatStyle;
            delAccButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
            delAccButton.Click += delAccButton_Click;

            createJournal.Click += addJournalButton_Click;
            viewJournalsButton.Click += viewJournalsButton_Click;
            signoutButton.Click += signoutButton_Click;
            exitButton.Click += exitButton_Click;
        }


        //Add Journal Button
        private void addJournalButton_Click(object sender, EventArgs eventArgs)
        {
            this.Controls.Clear();

            int journalContentWidth = 400;

            Label journalNameL = new Label();
            this.Controls.Add(journalNameL);
            journalNameL.Text = "Journal title";
            journalNameL.Size = FormsManager.Instance.buttonSize;
            journalNameL.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height);
            journalNameL.Font = FormsManager.Instance.fontType;
            journalNameL.ForeColor = FormsManager.Instance.bColor;
            journalNameL.FlatStyle = FormsManager.Instance.flatStyle;
            journalNameL.TextAlign = ContentAlignment.MiddleLeft;

            RichTextBox journalNameText = new RichTextBox();
            if (journalAlreadyExist)
            {
                journal.journalName = JournalList.Instance.Journals[existedJournalId].journalName;
                journal.journalTopics.Clear();
                for (int i = 0; i < JournalList.Instance.Journals[existedJournalId].journalTopics.Count(); i++)
                {
                    journal.journalTopics.Add(JournalList.Instance.Journals[existedJournalId].journalTopics[i]);
                }
            }
            if (journal.journalName.Length != 0)
            {
                journalNameText.Text = journal.journalName;
            }
            
            this.Controls.Add(journalNameText);
            journalNameText.Size = new Size(journalContentWidth, FormsManager.Instance.buttonHeight);
            journalNameText.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height + FormsManager.Instance.indent);
            journalNameText.Name = "JournalName";
            journalNameText.Font = FormsManager.Instance.fontType;
            journalNameText.BackColor = FormsManager.Instance.bColor;
            journalNameText.ForeColor = FormsManager.Instance.tColor;
            journalNameText.BorderStyle = FormsManager.Instance.borderStyle;

            Button addTtoJButton = new Button();
            this.Controls.Add(addTtoJButton);
            addTtoJButton.Text = "Add article";
            addTtoJButton.Size = FormsManager.Instance.buttonSize;
            addTtoJButton.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height + FormsManager.Instance.indent * 3);
            addTtoJButton.Font = FormsManager.Instance.fontType;
            addTtoJButton.BackColor = FormsManager.Instance.bColor;
            addTtoJButton.ForeColor = FormsManager.Instance.tColor;
            addTtoJButton.FlatStyle = FormsManager.Instance.flatStyle;
            addTtoJButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            viewPanelOfTopics(null, null);

            Button addButton = new Button();
            addButton.Text = "Add journal";
            addButton.Size = FormsManager.Instance.buttonSize;
            addButton.Location = new Point(FormsManager.Instance.block3, journalNameText.Location.Y);
            addButton.Font = FormsManager.Instance.fontType;
            addButton.BackColor = FormsManager.Instance.bColor;
            addButton.ForeColor = FormsManager.Instance.tColor;
            addButton.FlatStyle = FormsManager.Instance.flatStyle;
            addButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button editButton = new Button();
            editButton.Text = "Save changes";
            editButton.Size = FormsManager.Instance.buttonSize;
            editButton.Location = new Point(FormsManager.Instance.block3, journalNameText.Location.Y);
            editButton.Font = FormsManager.Instance.fontType;
            editButton.BackColor = FormsManager.Instance.bColor;
            editButton.ForeColor = FormsManager.Instance.tColor;
            editButton.FlatStyle = FormsManager.Instance.flatStyle;
            editButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            if (journalAlreadyExist)
            {
                this.Controls.Add(editButton);
            }
            else
            {
                this.Controls.Add(addButton);
            }

            Button readyForPrint = new Button();
            this.Controls.Add(readyForPrint);
            readyForPrint.Text = "Send to print";
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

            Button delJournalButton = new Button();
            delJournalButton.Text = "Delete journal";
            delJournalButton.Size = FormsManager.Instance.buttonSize;
            delJournalButton.Location = new Point(10, 10);
            delJournalButton.Font = FormsManager.Instance.fontType;
            delJournalButton.BackColor = FormsManager.Instance.bColor;
            delJournalButton.ForeColor = FormsManager.Instance.tColor;
            delJournalButton.FlatStyle = FormsManager.Instance.flatStyle;
            delJournalButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            if (journalAlreadyExist)
            {
                this.Controls.Add(delJournalButton);
            }

            addButton.Click += confirmJournalButton_Click;
            editButton.Click += confirmJournalButton_Click;
            addTtoJButton.Click += addTtoJButton_Click;
            readyForPrint.Click += readyJournalForPrint_Click;
            if (journalAlreadyExist)
            {
                cancelButton.Click += viewJournalsButton_Click;
            }
            else
            {
                cancelButton.Click += CreateButtonDelegate;
            }
            delJournalButton.Click += delJournalButton_Click;
        }

        private void delJournalButton_Click(object sender, EventArgs eventArgs)
        {
            JournalList.Instance.Journals.RemoveAt(existedJournalId);
            viewJournalsButton_Click(null, null);
        }

        //Add journal Right Buttons
        private void confirmJournalButton_Click(object sender, EventArgs eventArgs)
        {
            RichTextBox JournalName = Controls.Find("JournalName", true)[0] as RichTextBox;
            string text1 = JournalName.Text;

            bool alreadyExists = false;

            foreach (Journal journal1 in JournalList.Instance.Journals)
            {
                if (journal1.journalName.Equals(text1))
                {
                    if (journalAlreadyExist && journal1.journalName.Equals(JournalList.Instance.Journals[existedJournalId].journalName))
                    {
                        break;
                    }
                    alreadyExists = true;
                    MessageBox.Show("A journal with the same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            if (!alreadyExists)
            {
                if (journalAlreadyExist)
                {
                    JournalList.Instance.Journals[existedJournalId].journalName = text1;
                    JournalList.Instance.Journals[existedJournalId].date = DateTime.Now.ToString("MM / dd / yyyy hh: mm tt");
                    JournalList.Instance.Journals[existedJournalId].journalTopics.Clear();
                    for (int i = 0; i < journal.journalTopics.Count(); i++)
                    {
                        JournalList.Instance.Journals[existedJournalId].journalTopics.Add(journal.journalTopics[i]);
                    }
                    journal.journalTopics.Clear();
                    journal.journalName = "";
                    return;
                }
                Journal newJournal = new Journal();
                newJournal.journalName = text1;
                newJournal.date = DateTime.Now.ToString("MM / dd / yyyy hh: mm tt");
                newJournal.author = LayoutArtist.Instance.Name;
                for (int i = 0; i < journal.journalTopics.Count(); i++)
                {
                    newJournal.journalTopics.Add(journal.journalTopics[i]);
                }
                JournalList.Instance.Journals.Add(newJournal);
                journal.journalTopics.Clear();
                journal.journalName = "";
                CreateButtonDelegate(null, null);
            }
        }

        private void readyJournalForPrint_Click(object sender, EventArgs eventArgs)
        {
            RichTextBox JournalName = Controls.Find("JournalName", true)[0] as RichTextBox;
            string text1 = JournalName.Text;

            bool alreadyExists = false;

            foreach (Journal journal1 in JournalList.Instance.Journals)
            {
                if (journal1.journalName.Equals(text1))
                {
                    if (journalAlreadyExist && journal1.journalName.Equals(JournalList.Instance.Journals[existedJournalId].journalName))
                    {
                        break;
                    }
                    alreadyExists = true;
                    MessageBox.Show("A journal with the same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            bool topicsReadyForPrint = true;
            for (int k = 0; k < journal.journalTopics.Count; k++)
            {
                if (journal.journalTopics[k].readyForJournal
                    && journal.journalTopics[k].readyPhotos == false)
                {
                    topicsReadyForPrint = false;
                    break;
                }
            }

            if (!alreadyExists)
            {
                if (journalAlreadyExist)
                {
                    JournalList.Instance.Journals[existedJournalId].journalName = text1;
                    if (topicsReadyForPrint)
                    {
                        JournalList.Instance.Journals[existedJournalId].readyForPrint = true;
                    }
                    JournalList.Instance.Journals[existedJournalId].date = DateTime.Now.ToString("MM / dd / yyyy hh: mm tt");
                    JournalList.Instance.Journals[existedJournalId].journalTopics.Clear();
                    for (int i = 0; i < journal.journalTopics.Count(); i++)
                    {
                        JournalList.Instance.Journals[existedJournalId].journalTopics.Add(journal.journalTopics[i]);
                    }
                    journal.journalTopics.Clear();
                    journal.journalName = "";
                    return;
                }
                Journal newJournal = new Journal();
                newJournal.journalName = text1;
                if(topicsReadyForPrint)
                {
                    newJournal.readyForPrint = true;
                }
                newJournal.date = DateTime.Now.ToString("MM / dd / yyyy hh: mm tt");
                newJournal.author = LayoutArtist.Instance.Name;
                for (int i = 0; i < journal.journalTopics.Count(); i++)
                {
                    newJournal.journalTopics.Add(journal.journalTopics[i]);
                }
                JournalList.Instance.Journals.Add(newJournal);
                journal.journalTopics.Clear();
                journal.journalName = "";
                CreateButtonDelegate(null, null);
                return;
            }
        }

        private void addTtoJButton_Click(object sender, EventArgs eventArgs)
        {
            RichTextBox JournalName = Controls.Find("JournalName", true)[0] as RichTextBox;
            journal.journalName = JournalName.Text;
            viewTopicsButton_Click(null, null);
        }


        //Journal Topics List Panel Buttons
        private void viewPanelOfTopics(object sender, EventArgs eventArgs)
        {
            int panelHeight = 200, panelWidth = 670;

            Panel topicsPanel = new Panel();
            this.Controls.Add(topicsPanel);
            topicsPanel.BorderStyle = BorderStyle.FixedSingle;
            topicsPanel.Name = "PanelOfTopics";
            topicsPanel.Size = new Size(panelWidth, panelHeight);
            topicsPanel.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.height + FormsManager.Instance.indent * 4);

            if (journal.journalTopics.Count() != 0)
            {
                TableLayoutPanel topicsListPanel = new TableLayoutPanel();
                topicsListPanel.AutoScroll = true;
                topicsListPanel.Dock = DockStyle.Fill;
                topicsListPanel.RowCount = journal.journalTopics.Count();
                topicsListPanel.ColumnCount = 5;
                topicsListPanel.ColumnStyles.Clear();
                topicsListPanel.RowStyles.Clear();
                topicsListPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
                topicsListPanel.Top = FormsManager.Instance.panelHeight * journal.journalTopics.Count();
                topicsListPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                topicsListPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                topicsListPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                topicsListPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                topicsListPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                topicsListPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, FormsManager.Instance.panelHeight));
                topicsPanel.Controls.Add(topicsListPanel);

                var topicNameL = new Label();
                var topicReadyForJournalL = new Label();
                var topicReadyPhotosL = new Label();
                //design
                topicNameL.Font = FormsManager.Instance.fontType;
                topicNameL.ForeColor = FormsManager.Instance.bColor;
                topicNameL.FlatStyle = FormsManager.Instance.flatStyle;
                topicNameL.TextAlign = ContentAlignment.MiddleLeft;
                topicNameL.Dock = DockStyle.Fill;

                topicReadyForJournalL.Font = FormsManager.Instance.fontType;
                topicReadyForJournalL.ForeColor = FormsManager.Instance.bColor;
                topicReadyForJournalL.FlatStyle = FormsManager.Instance.flatStyle;
                topicReadyForJournalL.TextAlign = ContentAlignment.MiddleLeft;
                topicReadyForJournalL.Dock = DockStyle.Fill;

                topicReadyPhotosL.Font = FormsManager.Instance.fontType;
                topicReadyPhotosL.ForeColor = FormsManager.Instance.bColor;
                topicReadyPhotosL.FlatStyle = FormsManager.Instance.flatStyle;
                topicReadyPhotosL.TextAlign = ContentAlignment.MiddleLeft;
                topicReadyPhotosL.Dock = DockStyle.Fill;

                int k = 0;

                topicNameL.Text = "Name";
                topicsListPanel.Controls.Add(topicNameL, k++, 0);

                topicReadyForJournalL.Text = "Journal";
                topicsListPanel.Controls.Add(topicReadyForJournalL, k++, 0);

                topicReadyPhotosL.Text = "Photos";
                topicsListPanel.Controls.Add(topicReadyPhotosL, k, 0);

                for (int j = 1; j < journal.journalTopics.Count() + 1; j++)
                {
                    topicsListPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, FormsManager.Instance.panelHeight));
                    var topicName = new Label();
                    var topicReadyForJournal = new Label();
                    var topicReadyPhotos = new Label();
                    //design
                    topicName.Font = FormsManager.Instance.fontType;
                    topicName.ForeColor = FormsManager.Instance.bColor;
                    topicName.FlatStyle = FormsManager.Instance.flatStyle;
                    topicName.TextAlign = ContentAlignment.MiddleLeft;
                    topicName.Dock = DockStyle.Fill;

                    topicReadyForJournal.Font = FormsManager.Instance.fontType;
                    topicReadyForJournal.ForeColor = FormsManager.Instance.bColor;
                    topicReadyForJournal.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyForJournal.TextAlign = ContentAlignment.MiddleCenter;
                    topicReadyForJournal.Dock = DockStyle.Fill;

                    topicReadyPhotos.Font = FormsManager.Instance.fontType;
                    topicReadyPhotos.ForeColor = FormsManager.Instance.bColor;
                    topicReadyPhotos.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyPhotos.TextAlign = ContentAlignment.MiddleCenter;
                    topicReadyPhotos.Dock = DockStyle.Fill;

                    var viewTopicButton = new Button();
                    var delTopicButton = new Button();
                    //design
                    viewTopicButton.Size = FormsManager.Instance.buttonSize;
                    viewTopicButton.Font = FormsManager.Instance.fontType;
                    viewTopicButton.BackColor = FormsManager.Instance.bColor;
                    viewTopicButton.ForeColor = FormsManager.Instance.tColor;
                    viewTopicButton.FlatStyle = FormsManager.Instance.flatStyle;
                    viewTopicButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
                    viewTopicButton.Text = "View";

                    delTopicButton.Size = FormsManager.Instance.buttonSize;
                    delTopicButton.Font = FormsManager.Instance.fontType;
                    delTopicButton.BackColor = FormsManager.Instance.bColor;
                    delTopicButton.ForeColor = FormsManager.Instance.tColor;
                    delTopicButton.FlatStyle = FormsManager.Instance.flatStyle;
                    delTopicButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
                    delTopicButton.Text = "Delete";

                    int i = 0;

                    topicName.Text = journal.journalTopics[j - 1].topicName;
                    topicsListPanel.Controls.Add(topicName, i++, j);

                    topicReadyForJournal.Text = journal.journalTopics[j - 1].readyForJournal == true ? "✓" : "×";
                    topicsListPanel.Controls.Add(topicReadyForJournal, i++, j);

                    topicReadyPhotos.Text = journal.journalTopics[j - 1].readyPhotos == true ? "✓" : "×";
                    topicsListPanel.Controls.Add(topicReadyPhotos, i++, j);

                    topicsListPanel.Controls.Add(viewTopicButton, i++, j);
                    topicsListPanel.Controls.Add(delTopicButton, i, j);

                    int topicId = j - 1;

                    viewTopicButton.Click += (sender1, EventArgs) => { viewOneButton_Click(sender1, eventArgs, topicId); };
                    delTopicButton.Click += (sender1, EventArgs) => { delOneButton_Click(sender1, eventArgs, topicId); };
                }
            }
        }

        private void viewOneButton_Click(object sender, EventArgs eventArgs, int topicId)
        {
            viewTopicButton_Click(null, null, topicId, false);
        }

        private void delOneButton_Click(object sender, EventArgs eventArgs, int topicId)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Name.Equals("PanelOfTopics"))
                {
                    this.Controls.Remove(control);
                    break;
                }
            }
            journal.journalTopics.RemoveAt(topicId);
            viewPanelOfTopics(null, null);
        }


        //View List Of Topics
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

        private void viewListOfTopic(object sender, EventArgs eventArgs)
        {
            if (TopicList.Instance.Topics.Count != 0)
            {
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.AutoScroll = true;
                panel.Width = FormsManager.Instance.panelWidth;
                panel.Height = FormsManager.Instance.panelHeight * (TopicList.Instance.Topics.Count + 1);
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
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

                var topicNameL = new Label();
                var topicDateL = new Label();
                var topicAuthorL = new Label();
                var topicReadyPhotosL = new Label();
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

                topicReadyPhotosL.Font = FormsManager.Instance.fontType;
                topicReadyPhotosL.ForeColor = FormsManager.Instance.bColor;
                topicReadyPhotosL.FlatStyle = FormsManager.Instance.flatStyle;
                topicReadyPhotosL.TextAlign = ContentAlignment.MiddleLeft;
                topicReadyPhotosL.Dock = DockStyle.Fill;

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

                topicReadyPhotosL.Text = "Photos";
                panel.Controls.Add(topicReadyPhotosL, k++, 0);

                topicReadyForJournalL.Text = "Journal";
                panel.Controls.Add(topicReadyForJournalL, k, 0);

                for (int j = 1; j < TopicList.Instance.Topics.Count() + 1; j++)
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    var topicName = new Label();
                    var topicDate = new Label();
                    var topicAuthor = new Label();
                    var topicReadyPhotos = new Label();
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

                    topicReadyPhotos.Font = FormsManager.Instance.fontType;
                    topicReadyPhotos.ForeColor = FormsManager.Instance.bColor;
                    topicReadyPhotos.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyPhotos.TextAlign = ContentAlignment.MiddleCenter;
                    topicReadyPhotos.Dock = DockStyle.Fill;

                    topicReadyForJournal.Font = FormsManager.Instance.fontType;
                    topicReadyForJournal.ForeColor = FormsManager.Instance.bColor;
                    topicReadyForJournal.FlatStyle = FormsManager.Instance.flatStyle;
                    topicReadyForJournal.TextAlign = ContentAlignment.MiddleCenter;
                    topicReadyForJournal.Dock = DockStyle.Fill;

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
                    addTopicButton.Text = "Add";

                    int i = 0;

                    topicName.Text = TopicList.Instance.Topics[j - 1].topicName;
                    panel.Controls.Add(topicName, i++, j);

                    topicDate.Text = TopicList.Instance.Topics[j - 1].date;
                    panel.Controls.Add(topicDate, i++, j);

                    topicAuthor.Text = TopicList.Instance.Topics[j - 1].author;
                    panel.Controls.Add(topicAuthor, i++, j);

                    topicReadyPhotos.Text = TopicList.Instance.Topics[j - 1].readyPhotos == true ? "✓" : "×";
                    panel.Controls.Add(topicReadyPhotos, i++, j);

                    topicReadyForJournal.Text = TopicList.Instance.Topics[j - 1].readyForJournal == true ? "✓" : "×";
                    panel.Controls.Add(topicReadyForJournal, i++, j);

                    panel.Controls.Add(viewTopicButton, i++, j);
                    panel.Controls.Add(addTopicButton, i, j);

                    int topicId = j - 1;

                    viewTopicButton.Click += (sender1, EventArgs) => { viewTopicButton_Click(sender1, EventArgs, topicId, true); };
                    addTopicButton.Click += (sender1, EventArgs) => { addTopicButton_Click(sender1, EventArgs, topicId); };
                }
            }
        }

        private void addTopicButton_Click(object sender, EventArgs eventArgs, int topicId)
        {
            bool alreadyExists = false;

            foreach (Topic topic1 in journal.journalTopics)
            {
                if (topic1.topicName.Equals(TopicList.Instance.Topics[topicId].topicName))
                {
                    alreadyExists = true;
                    MessageBox.Show("A topic with the same name is already in the journal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            if (!alreadyExists)
            {
                journal.journalTopics.Add(TopicList.Instance.Topics[topicId]);
            }
        }

        private void viewTopicButton_Click(object sender, EventArgs eventArgs, int topicId, bool JustList)
        {
            this.Controls.Clear();

            int articleContentWidth = 400, articleContentHeight = 200;
            int photoSize = 280;

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
            topicNameText.WordWrap = true;
            //design
            topicNameText.ReadOnly = true;
            topicNameText.Text = TopicList.Instance.Topics[topicId].topicName;
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
            topicContectText.ReadOnly = true;
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

            Button cancelButton = new Button();
            this.Controls.Add(cancelButton);
            cancelButton.Text = "Back";
            cancelButton.Size = FormsManager.Instance.buttonSize;
            cancelButton.Location = new Point(FormsManager.Instance.block2, FormsManager.Instance.indent / 2);
            //design
            cancelButton.Font = FormsManager.Instance.fontType;
            cancelButton.BackColor = FormsManager.Instance.bColor;
            cancelButton.ForeColor = FormsManager.Instance.tColor;
            cancelButton.FlatStyle = FormsManager.Instance.flatStyle;
            cancelButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            if (JustList)
            {
                cancelButton.Click += viewTopicsButton_Click;
            }
            else
            {
                cancelButton.Click += addJournalButton_Click;
            }
        }


        //View Journal List Button
        private void viewJournalsButton_Click(object sender, EventArgs eventArgs)
        {
            journalAlreadyExist = false;
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

            backButton.Click += CreateButtonDelegate;
            sortComboBox.SelectedIndexChanged += sortJournalsComboBox_IndexChanged;
            viewListOfJournals(null, null);
        }

        private void sortJournalsComboBox_IndexChanged(object sender, EventArgs eventArgs)
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
                JournalList.Instance.Journals.Sort((j1, j2) => j1.journalName.CompareTo(j2.journalName));
            }
            if (selectedSortType == FormsManager.Instance.sort[1])
            {
                JournalList.Instance.Journals.Sort((j1, j2) => j1.date.CompareTo(j2.date));
            }
            if (selectedSortType == FormsManager.Instance.sort[2])
            {
                JournalList.Instance.Journals.Sort((j1, j2) => j1.author.CompareTo(j2.author));
            }

            viewListOfJournals(null, null);
        }

        private void viewListOfJournals(object sender, EventArgs eventArgs)
        {
            if (JournalList.Instance.Journals.Count() != 0)
            {
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.AutoScroll = true;
                panel.Width = FormsManager.Instance.panelWidth;
                panel.Height = FormsManager.Instance.panelHeight * (JournalList.Instance.Journals.Count() + 1);
                panel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                panel.RowCount = TopicList.Instance.Topics.Count();
                panel.ColumnCount = 6;
                panel.ColumnStyles.Clear();
                panel.RowStyles.Clear();
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
                panel.Top = FormsManager.Instance.panelHeight;
                this.Controls.Add(panel);
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

                var journalNameL = new Label();
                var journalDateL = new Label();
                var journalAuthorL = new Label();
                var journalTopicsCountL= new Label();
                var journalReadyForPrintL = new Label();

                //design
                journalNameL.Font = FormsManager.Instance.fontType;
                journalNameL.ForeColor = FormsManager.Instance.bColor;
                journalNameL.FlatStyle = FormsManager.Instance.flatStyle;
                journalNameL.TextAlign = ContentAlignment.MiddleLeft;
                journalNameL.Dock = DockStyle.Fill;

                journalDateL.Font = FormsManager.Instance.fontType;
                journalDateL.ForeColor = FormsManager.Instance.bColor;
                journalDateL.FlatStyle = FormsManager.Instance.flatStyle;
                journalDateL.TextAlign = ContentAlignment.MiddleLeft;
                journalDateL.Dock = DockStyle.Fill;

                journalAuthorL.Font = FormsManager.Instance.fontType;
                journalAuthorL.ForeColor = FormsManager.Instance.bColor;
                journalAuthorL.FlatStyle = FormsManager.Instance.flatStyle;
                journalAuthorL.TextAlign = ContentAlignment.MiddleLeft;
                journalAuthorL.Dock = DockStyle.Fill;

                journalTopicsCountL.Font = FormsManager.Instance.fontType;
                journalTopicsCountL.ForeColor = FormsManager.Instance.bColor;
                journalTopicsCountL.FlatStyle = FormsManager.Instance.flatStyle;
                journalTopicsCountL.TextAlign = ContentAlignment.MiddleLeft;
                journalTopicsCountL.Dock = DockStyle.Fill;

                journalReadyForPrintL.Font = FormsManager.Instance.fontType;
                journalReadyForPrintL.ForeColor = FormsManager.Instance.bColor;
                journalReadyForPrintL.FlatStyle = FormsManager.Instance.flatStyle;
                journalReadyForPrintL.TextAlign = ContentAlignment.MiddleLeft;
                journalReadyForPrintL.Dock = DockStyle.Fill;

                int k = 0;

                journalNameL.Text = "Name";
                panel.Controls.Add(journalNameL, k++, 0);

                journalDateL.Text = "Date";
                panel.Controls.Add(journalDateL, k++, 0);

                journalAuthorL.Text = "Author";
                panel.Controls.Add(journalAuthorL, k++, 0);

                journalTopicsCountL.Text = "Topics";
                panel.Controls.Add(journalTopicsCountL, k++, 0);

                journalReadyForPrintL.Text = "Print";
                panel.Controls.Add(journalReadyForPrintL, k, 0);

                for (int j = 1; j < JournalList.Instance.Journals.Count() + 1; j++)
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    var journalName = new Label();
                    var journalDate = new Label();
                    var journalAuthor = new Label();
                    var journalTopicsCount = new Label();
                    var journalReadyForPrint = new Label();

                    //design
                    journalName.Font = FormsManager.Instance.fontType;
                    journalName.ForeColor = FormsManager.Instance.bColor;
                    journalName.FlatStyle = FormsManager.Instance.flatStyle;
                    journalName.TextAlign = ContentAlignment.TopLeft;
                    journalName.Dock = DockStyle.Fill;

                    journalDate.Font = FormsManager.Instance.fontType;
                    journalDate.ForeColor = FormsManager.Instance.bColor;
                    journalDate.FlatStyle = FormsManager.Instance.flatStyle;
                    journalDate.TextAlign = ContentAlignment.MiddleLeft;
                    journalDate.Dock = DockStyle.Fill;

                    journalAuthor.Font = FormsManager.Instance.fontType;
                    journalAuthor.ForeColor = FormsManager.Instance.bColor;
                    journalAuthor.FlatStyle = FormsManager.Instance.flatStyle;
                    journalAuthor.TextAlign = ContentAlignment.MiddleLeft;
                    journalAuthor.Dock = DockStyle.Fill;

                    journalTopicsCount.Font = FormsManager.Instance.fontType;
                    journalTopicsCount.ForeColor = FormsManager.Instance.bColor;
                    journalTopicsCount.FlatStyle = FormsManager.Instance.flatStyle;
                    journalTopicsCount.TextAlign = ContentAlignment.MiddleCenter;
                    journalTopicsCount.Dock = DockStyle.Fill;

                    journalReadyForPrint.Font = FormsManager.Instance.fontType;
                    journalReadyForPrint.ForeColor = FormsManager.Instance.bColor;
                    journalReadyForPrint.FlatStyle = FormsManager.Instance.flatStyle;
                    journalReadyForPrint.TextAlign = ContentAlignment.MiddleCenter;
                    journalReadyForPrint.Dock = DockStyle.Fill;

                    var editJournalButton = new Button();
                    //design
                    editJournalButton.Size = FormsManager.Instance.buttonSize;
                    editJournalButton.Font = FormsManager.Instance.fontType;
                    editJournalButton.BackColor = FormsManager.Instance.bColor;
                    editJournalButton.ForeColor = FormsManager.Instance.tColor;
                    editJournalButton.FlatStyle = FormsManager.Instance.flatStyle;
                    editJournalButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;
                    editJournalButton.Text = "Edit";

                    int i = 0;

                    journalName.Text = JournalList.Instance.Journals[j - 1].journalName;
                    panel.Controls.Add(journalName, i++, j);

                    journalDate.Text = JournalList.Instance.Journals[j - 1].date;
                    panel.Controls.Add(journalDate, i++, j);

                    journalAuthor.Text = JournalList.Instance.Journals[j - 1].author;
                    panel.Controls.Add(journalAuthor, i++, j);

                    journalTopicsCount.Text = JournalList.Instance.Journals[j - 1].journalTopics.Count.ToString();
                    panel.Controls.Add(journalTopicsCount, i++, j);

                    journalReadyForPrint.Text = JournalList.Instance.Journals[j - 1].readyForPrint == true ? "✓" : "×";
                    panel.Controls.Add(journalReadyForPrint, i++, j);

                    panel.Controls.Add(editJournalButton, i++, j);

                    int journalId = j - 1;

                    editJournalButton.Click += (sender1, EventArgs) => { editJournalTopicButton_Click(sender1, EventArgs, journalId); };
                }
            }
        }

        private void editJournalTopicButton_Click(object sender, EventArgs eventArgs, int journalId)
        {
            journalAlreadyExist = true;
            existedJournalId = journalId;
            addJournalButton_Click(null, null);
        }


        //Sign Out
        private void signoutButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Show();
            FormsManager.Instance.Forms.RemoveAt(FormsManager.Instance.Forms.Count - 1);
            this.Close();
        }


        //Exit
        private void exitButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Close();
        }


        //del accaunt
        private void delAccButton_Click(object sender, EventArgs eventArgs)
        {
            for(int i = 0; i < PersonsList.persons.Count(); i++)
            {
                if (PersonsList.persons[i].Name == LayoutArtist.Instance.Name 
                    && PersonsList.persons[i].Password == LayoutArtist.Instance.Password)
                {
                    PersonsList.persons.RemoveAt(i);
                    break;
                }
            }
            FormsManager.Instance.Forms[0].Show();
            FormsManager.Instance.Forms.RemoveAt(FormsManager.Instance.Forms.Count - 1);
            this.Controls.Clear();
            this.Close();
        }
    }
}
