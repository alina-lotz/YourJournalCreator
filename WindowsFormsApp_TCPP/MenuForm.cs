using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_TCPP.PersonsMenuForms;

using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace WindowsFormsApp_TCPP
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            this.Text = "Welcome to my Program";
            this.StartPosition = FormsManager.Instance.formPosition;
            this.Size = FormsManager.Instance.formSize;
            this.BackColor = FormsManager.Instance.bgColor;
            
            this.Shown += CreateButtonDelegate;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);

            FormsManager.Instance.Forms.Add(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //read topics from a file
            string fileName = FormsManager.Instance.topicListData;
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                int topicsCount = br.ReadInt32();
                for (int i = 0; i < topicsCount; i++)
                {
                    Topic newTopic = new Topic();
                    newTopic.topicName = br.ReadString();
                    newTopic.topicContent = br.ReadString();
                    newTopic.date = br.ReadString();
                    newTopic.author = br.ReadString();
                    newTopic.readyPhotos = br.ReadBoolean();
                    newTopic.readyForEdit = br.ReadBoolean();
                    newTopic.readyForJournal = br.ReadBoolean();
                    TopicList.Instance.Topics.Add(newTopic);
                }
                br.Close();
            }

            //read journals from a file
            fileName = FormsManager.Instance.journalListData;
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                int journalsCount = br.ReadInt32();
                for (int i = 0; i < journalsCount; i++)
                {
                    Journal newJournal = new Journal();
                    newJournal.journalName = br.ReadString();
                    newJournal.date = br.ReadString();
                    newJournal.author = br.ReadString();
                    newJournal.readyForPrint = br.ReadBoolean();
                    int topicsCount = br.ReadInt32();
                    for (int j = 0; j < topicsCount; j++)
                    {
                        string topicName = br.ReadString();
                        foreach (Topic topic in TopicList.Instance.Topics)
                        {
                            if (topic.topicName.Equals(topicName))
                            {
                                newJournal.journalTopics.Add(topic);
                            }
                        }
                    }
                    JournalList.Instance.Journals.Add(newJournal);
                }
                br.Close();
            }

            //read persons from a file
            fileName = FormsManager.Instance.personListData;
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                int personsCount = br.ReadInt32();
                for (int i = 0; i < personsCount; i++)
                {
                    Person newPerson = new Person();
                    newPerson.Name = br.ReadString();
                    newPerson.Password = br.ReadString();
                    newPerson.Role = br.ReadString();

                    PersonsList.persons.Add(newPerson);
                }
                br.Close();
            }
        }

        private void FormIsClosing(object sender, EventArgs e)
        {
            //write topics to a file
            string fileName = FormsManager.Instance.topicListData;
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(TopicList.Instance.Topics.Count);
            for (int i = 0; i < TopicList.Instance.Topics.Count; i++)
            {               
                bw.Write(TopicList.Instance.Topics[i].topicName);
                bw.Write(TopicList.Instance.Topics[i].topicContent);
                bw.Write(TopicList.Instance.Topics[i].date);
                bw.Write(TopicList.Instance.Topics[i].author);
                bw.Write(TopicList.Instance.Topics[i].readyPhotos);
                bw.Write(TopicList.Instance.Topics[i].readyForEdit);
                bw.Write(TopicList.Instance.Topics[i].readyForJournal);
            }
            bw.Close();

            //write journals to a file
            fileName = FormsManager.Instance.journalListData;
            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            bw = new BinaryWriter(fs);
            bw.Write(JournalList.Instance.Journals.Count);
            for (int i = 0; i < JournalList.Instance.Journals.Count; i++)
            {
                bw.Write(JournalList.Instance.Journals[i].journalName);
                bw.Write(JournalList.Instance.Journals[i].date);
                bw.Write(JournalList.Instance.Journals[i].author);
                bw.Write(JournalList.Instance.Journals[i].readyForPrint);
                bw.Write(JournalList.Instance.Journals[i].journalTopics.Count);
                for (int j = 0; j < JournalList.Instance.Journals[i].journalTopics.Count; j++)
                {
                    bw.Write(JournalList.Instance.Journals[i].journalTopics[j].topicName);
                }
            }
            bw.Close();

            //write persons to a file
            fileName = FormsManager.Instance.personListData;
            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            bw = new BinaryWriter(fs);
            bw.Write(PersonsList.persons.Count);
            for (int i = 0; i < PersonsList.persons.Count; i++)
            {
                bw.Write(PersonsList.persons[i].Name);
                bw.Write(PersonsList.persons[i].Password);
                bw.Write(PersonsList.persons[i].Role);
            }
            bw.Close();
        }

        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            this.Controls.Clear();

            Button loginButton = new Button();
            this.Controls.Add(loginButton);
            loginButton.Text = "Log in";
            loginButton.Size = FormsManager.Instance.buttonSize;
            loginButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height);
            //design
            loginButton.Font = FormsManager.Instance.fontType;
            loginButton.BackColor = FormsManager.Instance.bColor;
            loginButton.ForeColor = FormsManager.Instance.tColor;
            loginButton.FlatStyle = FormsManager.Instance.flatStyle;
            loginButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button signupButton = new Button();
            this.Controls.Add(signupButton);
            signupButton.Text = "Sign up";
            signupButton.Size = FormsManager.Instance.buttonSize;
            signupButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent);
            //design
            signupButton.Font = FormsManager.Instance.fontType;
            signupButton.BackColor = FormsManager.Instance.bColor;
            signupButton.ForeColor = FormsManager.Instance.tColor;
            signupButton.FlatStyle = FormsManager.Instance.flatStyle;
            signupButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button exitButton = new Button();
            this.Controls.Add(exitButton);
            exitButton.Text = "Exit";
            exitButton.Size = FormsManager.Instance.buttonSize;
            exitButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent *2);
            //design
            exitButton.Font = FormsManager.Instance.fontType;
            exitButton.BackColor = FormsManager.Instance.bColor;
            exitButton.ForeColor = FormsManager.Instance.tColor;
            exitButton.FlatStyle = FormsManager.Instance.flatStyle;
            exitButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            loginButton.Click += loginButton_Click;
            signupButton.Click += signupButton_Click;
            exitButton.Click += exitButton_Click;
        }

        private void exitButton_Click(object sender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs eventArgs)
        {
            this.Controls.Clear();

            Label username = new Label();
            this.Controls.Add(username);
            username.Text = "Username";
            username.Size = FormsManager.Instance.buttonSize;
            username.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height);
            //design
            username.Font = FormsManager.Instance.fontType;
            username.ForeColor = FormsManager.Instance.bColor;
            username.FlatStyle = FormsManager.Instance.flatStyle;
            username.TextAlign = ContentAlignment.MiddleLeft;

            TextBox nameTextBox = new TextBox();
            this.Controls.Add(nameTextBox);
            nameTextBox.Size = FormsManager.Instance.buttonSize;
            nameTextBox.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent);
            nameTextBox.Name = "UsernameTextbox";
            //design
            nameTextBox.Font = FormsManager.Instance.fontType;
            nameTextBox.BackColor = FormsManager.Instance.bColor;
            nameTextBox.ForeColor = FormsManager.Instance.tColor;
            nameTextBox.BorderStyle = FormsManager.Instance.borderStyle;

            Label password = new Label();
            this.Controls.Add(password);
            password.Text = "Password";
            password.Size = FormsManager.Instance.buttonSize;
            password.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 2);
            //design
            password.Font = FormsManager.Instance.fontType;
            password.ForeColor = FormsManager.Instance.bColor;
            password.FlatStyle = FormsManager.Instance.flatStyle;
            password.TextAlign = ContentAlignment.MiddleLeft;

            TextBox passwordTextBox = new TextBox();
            this.Controls.Add(passwordTextBox);
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.MaxLength = 16;
            passwordTextBox.Size = FormsManager.Instance.buttonSize;
            passwordTextBox.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 3);
            passwordTextBox.Name = "PasswordTextbox";
            //design
            passwordTextBox.Font = FormsManager.Instance.fontType;
            passwordTextBox.BackColor = FormsManager.Instance.bColor;
            passwordTextBox.ForeColor = FormsManager.Instance.tColor;
            passwordTextBox.BorderStyle = FormsManager.Instance.borderStyle;

            Button loginButton = new Button();
            this.Controls.Add(loginButton);
            loginButton.Size = FormsManager.Instance.buttonSize;
            loginButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 4);
            loginButton.Text = "Log in";
            //design
            loginButton.Font = FormsManager.Instance.fontType;
            loginButton.BackColor = FormsManager.Instance.bColor;
            loginButton.ForeColor = FormsManager.Instance.tColor;
            loginButton.FlatStyle = FormsManager.Instance.flatStyle;
            loginButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button backButton = new Button();
            this.Controls.Add(backButton);
            backButton.Size = FormsManager.Instance.buttonSize;
            backButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 5);
            backButton.Text = "Back";
            //design
            backButton.Font = FormsManager.Instance.fontType;
            backButton.BackColor = FormsManager.Instance.bColor;
            backButton.ForeColor = FormsManager.Instance.tColor;
            backButton.FlatStyle = FormsManager.Instance.flatStyle;
            backButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            backButton.Click += CreateButtonDelegate;
            loginButton.Click += F_loginButton_Click;
        }

        private void signupButton_Click(object sender, EventArgs eventArgs)
        {
            this.Controls.Clear();

            Label username = new Label();
            this.Controls.Add(username);
            username.Text = "Username";
            username.Size = FormsManager.Instance.buttonSize;
            username.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height);
            //design
            username.Font = FormsManager.Instance.fontType;
            username.ForeColor = FormsManager.Instance.bColor;
            username.FlatStyle = FormsManager.Instance.flatStyle;
            username.TextAlign = ContentAlignment.MiddleLeft;

            TextBox nameTextBox = new TextBox();
            this.Controls.Add(nameTextBox);
            nameTextBox.Size = FormsManager.Instance.buttonSize;
            nameTextBox.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent);
            nameTextBox.Name = "UsernameTextbox";
            //design
            nameTextBox.Font = FormsManager.Instance.fontType;
            nameTextBox.BackColor = FormsManager.Instance.bColor;
            nameTextBox.ForeColor = FormsManager.Instance.tColor;
            nameTextBox.BorderStyle = FormsManager.Instance.borderStyle;

            Label password = new Label();
            this.Controls.Add(password);
            password.Text = "Password";
            password.Size = FormsManager.Instance.buttonSize;
            password.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 2);
            //design
            password.Font = FormsManager.Instance.fontType;
            password.ForeColor = FormsManager.Instance.bColor;
            password.FlatStyle = FormsManager.Instance.flatStyle;
            password.TextAlign = ContentAlignment.MiddleLeft;

            TextBox passwordTextBox = new TextBox();
            this.Controls.Add(passwordTextBox);
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.MaxLength = 16;
            passwordTextBox.Size = FormsManager.Instance.buttonSize;
            passwordTextBox.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 3);
            passwordTextBox.Name = "PasswordTextbox";
            //design
            passwordTextBox.Font = FormsManager.Instance.fontType;
            passwordTextBox.BackColor = FormsManager.Instance.bColor;
            passwordTextBox.ForeColor = FormsManager.Instance.tColor;
            passwordTextBox.BorderStyle = FormsManager.Instance.borderStyle;

            Label RoleText = new Label();
            this.Controls.Add(RoleText);
            RoleText.Text = "Choose Role";
            RoleText.Size = FormsManager.Instance.buttonSize;
            RoleText.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 4);
            //design
            RoleText.Font = FormsManager.Instance.fontType;
            RoleText.ForeColor = FormsManager.Instance.bColor;
            RoleText.FlatStyle = FormsManager.Instance.flatStyle;
            RoleText.TextAlign = ContentAlignment.MiddleLeft;

            ComboBox roleComboBox = new ComboBox();
            this.Controls.Add(roleComboBox);
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleComboBox.Items.AddRange(FormsManager.Instance.roles);
            roleComboBox.Size = FormsManager.Instance.buttonSize;
            roleComboBox.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 5);
            roleComboBox.Name = "RoleTextbox";
            //design
            roleComboBox.Font = FormsManager.Instance.fontType;
            roleComboBox.BackColor = FormsManager.Instance.bColor;
            roleComboBox.ForeColor = FormsManager.Instance.tColor;
            roleComboBox.FlatStyle = FormsManager.Instance.flatStyle;

            Button signupButton = new Button();
            this.Controls.Add(signupButton);
            signupButton.Size = FormsManager.Instance.buttonSize;
            signupButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 6);
            signupButton.Text = "Sign Up";
            //design
            signupButton.Font = FormsManager.Instance.fontType;
            signupButton.BackColor = FormsManager.Instance.bColor;
            signupButton.ForeColor = FormsManager.Instance.tColor;
            signupButton.FlatStyle = FormsManager.Instance.flatStyle;
            signupButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            Button backButton = new Button();
            this.Controls.Add(backButton);
            backButton.Size = FormsManager.Instance.buttonSize;
            backButton.Location = new Point(FormsManager.Instance.block1, FormsManager.Instance.height + FormsManager.Instance.indent * 7);
            backButton.Text = "Back";
            //design
            backButton.Font = FormsManager.Instance.fontType;
            backButton.BackColor = FormsManager.Instance.bColor;
            backButton.ForeColor = FormsManager.Instance.tColor;
            backButton.FlatStyle = FormsManager.Instance.flatStyle;
            backButton.FlatAppearance.BorderSize = FormsManager.Instance.borderSize;

            backButton.Click += CreateButtonDelegate;
            signupButton.Click += F_signupButton_Click;
        }
        
        private void F_signupButton_Click(object sender, EventArgs eventArgs)
        {
            TextBox usernameTextbox = Controls.Find("UsernameTextbox", true)[0] as TextBox;
            string text1 = usernameTextbox.Text;

            TextBox passwordTextbox = Controls.Find("PasswordTextbox", true)[0] as TextBox;
            string text2 = passwordTextbox.Text;

            ComboBox roleTextbox = Controls.Find("RoleTextbox", true)[0] as ComboBox;
            string text3 = roleTextbox.Text;

            if (text1 == "" || text2 == "" || text3 == "")
            {
                MessageBox.Show("Wrong format! Fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Person person in PersonsList.persons)
            {
                if ( (person.Name.Equals(text1)) && (person.Password.Equals(text2)) )
                {
                    MessageBox.Show("This account already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    signupButton_Click(null, null);
                    return;
                }
            }

            Person person1;
            person1.Name = text1;
            person1.Password = text2;
            person1.Role = text3;
            PersonsList.persons.Add(person1);

            if (text3 == FormsManager.Instance.roles[0])
            {
                Journalist.Instance.Name = text1;
                Journalist.Instance.Password = text2;
                JournalistForm JournalistForm1 = new JournalistForm();
                JournalistForm1.Show();
            }
            if (text3 == FormsManager.Instance.roles[1])
            {
                Photographer.Instance.Name = text1;
                Photographer.Instance.Password = text2;
                PhotographerForm PhotographerForm1 = new PhotographerForm();
                PhotographerForm1.Show();
            }
            if (text3 == FormsManager.Instance.roles[2])
            {
                Editor.Instance.Name = text1;
                Editor.Instance.Password = text2;
                EditorForm EditorForm1 = new EditorForm();
                EditorForm1.Show();
            }
            if (text3 == FormsManager.Instance.roles[3])
            {
                LayoutArtist.Instance.Name = text1;
                LayoutArtist.Instance.Password = text2;
                LayoutArtistForm LayoutArtistForm1 = new LayoutArtistForm();
                LayoutArtistForm1.Show();
            }
            this.Hide();
            CreateButtonDelegate(null, null);
            return;
        }

        private void F_loginButton_Click(object sender, EventArgs eventArgs)
        {
            TextBox usernameTextbox = Controls.Find("UsernameTextbox", true)[0] as TextBox;
            string text1 = usernameTextbox.Text;

            TextBox passwordTextbox = Controls.Find("PasswordTextbox", true)[0] as TextBox;
            string text2 = passwordTextbox.Text;

            foreach (Person person in PersonsList.persons)
            {
                if ((person.Name.Equals(text1)) && (person.Password.Equals(text2)))
                {
                    if (person.Role.Equals(FormsManager.Instance.roles[0]))
                    {
                        Journalist.Instance.Name = text1;
                        Journalist.Instance.Password = text2;
                        JournalistForm JournalistForm1 = new JournalistForm();
                        JournalistForm1.Show();
                    }
                    if (person.Role.Equals(FormsManager.Instance.roles[1]))
                    {
                        Photographer.Instance.Name = text1;
                        Photographer.Instance.Password = text2;
                        PhotographerForm PhotographerForm1 = new PhotographerForm();
                        PhotographerForm1.Show();
                    }
                    if (person.Role.Equals(FormsManager.Instance.roles[2]))
                    {
                        Editor.Instance.Name = text1;
                        Editor.Instance.Password = text2;
                        EditorForm EditorForm1 = new EditorForm();
                        EditorForm1.Show();
                    }
                    if (person.Role.Equals(FormsManager.Instance.roles[3]))
                    {
                        LayoutArtist.Instance.Name = text1;
                        LayoutArtist.Instance.Password = text2;
                        LayoutArtistForm LayoutArtistForm1 = new LayoutArtistForm();
                        LayoutArtistForm1.Show();
                    }
                    this.Hide();
                    CreateButtonDelegate(null, null);
                    return;
                }

            }
            MessageBox.Show("Wrong Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            loginButton_Click(null, null);
            return;
        }

    }
}
