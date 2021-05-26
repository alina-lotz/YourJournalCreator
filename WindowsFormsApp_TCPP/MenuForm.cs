using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_TCPP.PersonsMenuForms;

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

            FormsManager.Instance.Forms.Add(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
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

            foreach (Person person in PersonsList.persons)
            {
                if ((person.Name.Equals(text1)) && (person.Password.Equals(text2)) && (person.Role.Equals(text3)))
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

            if (text3 == "Journalist")
            {
                Journalist journalist = new Journalist();
                journalist.Name = text1;
                journalist.Password = text2;
                JournalistForm JournalistForm1 = new JournalistForm();
                JournalistForm1.Show();
            }
            if (text3 == "Photographer")
            {
                Photographer photographer = new Photographer();
                photographer.Name = text1;
                photographer.Password = text2;
                PhotographerForm PhotographerForm1 = new PhotographerForm();
                PhotographerForm1.Show();
            }
            if (text3 == "Editor")
            {
                Editor editor = new Editor();
                editor.Name = text1;
                editor.Password = text2;
                EditorForm EditorForm1 = new EditorForm();
                EditorForm1.Show();
            }
            if (text3 == "Layout artist")
            {
                LayoutArtist layoutArtist = new LayoutArtist();
                layoutArtist.Name = text1;
                layoutArtist.Password = text2;
                LayoutArtistForm LayoutArtistForm1 = new LayoutArtistForm();
                LayoutArtistForm1.Show();
            }
            this.Hide();
            signupButton_Click(null, null);
            return;
        }

        private void F_loginButton_Click(object sender, EventArgs eventArgs)
        {
            TextBox usernameTextbox = Controls.Find("UsernameTextbox", true)[0] as TextBox;
            string text1 = usernameTextbox.Text;

            TextBox passwordTextbox = Controls.Find("PasswordTextbox", true)[0] as TextBox;
            string text2 = passwordTextbox.Text;

            if (PersonsList.persons.Count == 0)
            {
                MessageBox.Show("Wrong Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (Person person in PersonsList.persons)
            {
                if ((person.Name.Equals(text1)) && (person.Password.Equals(text2)))
                {
                    if (person.Role.Equals("Journalist"))
                    {
                        Journalist journalist = new Journalist();
                        journalist.Name = text1;
                        journalist.Password = text2;
                        JournalistForm JournalistForm1 = new JournalistForm();
                        JournalistForm1.Show();
                    }
                    if (person.Role.Equals("Photographer"))
                    {
                        Photographer photographer = new Photographer();
                        photographer.Name = text1;
                        photographer.Password = text2;
                        PhotographerForm PhotographerForm1 = new PhotographerForm();
                        PhotographerForm1.Show();
                    }
                    if (person.Role.Equals("Editor"))
                    {
                        Editor editor = new Editor();
                        editor.Name = text1;
                        editor.Password = text2;
                        EditorForm EditorForm1 = new EditorForm();
                        EditorForm1.Show();
                    }
                    if (person.Role.Equals("Layout artist"))
                    {
                        LayoutArtist layoutArtist = new LayoutArtist();
                        layoutArtist.Name = text1;
                        layoutArtist.Password = text2;
                        LayoutArtistForm LayoutArtistForm1 = new LayoutArtistForm();
                        LayoutArtistForm1.Show();
                    }
                    this.Hide();
                    loginButton_Click(null, null);
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
