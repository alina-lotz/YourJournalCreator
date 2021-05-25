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
    class WaterMarkTextBox : TextBox
    {
        private Font oldFont = null;
        private Boolean waterMarkTextEnabled = false;

        #region Attributes 
        private Color _waterMarkColor = Color.Gray;
        public Color WaterMarkColor
        {
            get { return _waterMarkColor; }
            set
            {
                _waterMarkColor = value; Invalidate();/*thanks to Bernhard Elbl
                                                              for Invalidate()*/
            }
        }

        private string _waterMarkText = "Water Mark";
        public string WaterMarkText
        {
            get { return _waterMarkText; }
            set { _waterMarkText = value; Invalidate(); }
        }
        #endregion

        //Default constructor
        public WaterMarkTextBox()
        {
            JoinEvents(true);
        }

        //Override OnCreateControl ... thanks to  "lpgray .. codeproject guy"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            WaterMark_Toggel(null, null);
        }

        //Override OnPaint
        protected override void OnPaint(PaintEventArgs args)
        {
            // Use the same font that was defined in base class
            System.Drawing.Font drawFont = new System.Drawing.Font(Font.FontFamily,
                Font.Size, Font.Style, Font.Unit);
            //Create new brush with gray color or 
            SolidBrush drawBrush = new SolidBrush(WaterMarkColor);//use Water mark color
            //Draw Text or WaterMark
            args.Graphics.DrawString((waterMarkTextEnabled ? WaterMarkText : Text),
                drawFont, drawBrush, new PointF(0.0F, 0.0F));
            base.OnPaint(args);
        }

        private void JoinEvents(Boolean join)
        {
            if (join)
            {
                this.TextChanged += new System.EventHandler(this.WaterMark_Toggel);
                this.LostFocus += new System.EventHandler(this.WaterMark_Toggel);
                this.FontChanged += new System.EventHandler(this.WaterMark_FontChanged);
                //No one of the above events will start immeddiatlly 
                //TextBox control still in constructing, so,
                //Font object (for example) couldn't be catched from within
                //WaterMark_Toggle
                //So, call WaterMark_Toggel through OnCreateControl after TextBox
                //is totally created
                //No doupt, it will be only one time call

                //Old solution uses Timer.Tick event to check Create property
            }
        }

        private void WaterMark_Toggel(object sender, EventArgs args)
        {
            if (this.Text.Length <= 0)
                EnableWaterMark();
            else
                DisbaleWaterMark();
        }

        private void EnableWaterMark()
        {
            //Save current font until returning the UserPaint style to false (NOTE:
            //It is a try and error advice)
            oldFont = new System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style,
               Font.Unit);
            //Enable OnPaint event handler
            this.SetStyle(ControlStyles.UserPaint, true);
            this.waterMarkTextEnabled = true;
            //Triger OnPaint immediatly
            Refresh();
        }

        private void DisbaleWaterMark()
        {
            //Disbale OnPaint event handler
            this.waterMarkTextEnabled = false;
            this.SetStyle(ControlStyles.UserPaint, false);
            //Return back oldFont if existed
            if (oldFont != null)
                this.Font = new System.Drawing.Font(oldFont.FontFamily, oldFont.Size,
                    oldFont.Style, oldFont.Unit);
        }

        private void WaterMark_FontChanged(object sender, EventArgs args)
        {
            if (waterMarkTextEnabled)
            {
                oldFont = new System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style,
                    Font.Unit);
                Refresh();
            }
        }
    }

    public partial class MenuForm : Form
    {
        string[] roles = new string[] { "Journalist", "Photographer", "Editor", "Layout designer" };
        int height = 100;
        int block1 = 315;
        int buttonSize1 = 130, buttonSize2 = 25;
        int indent = 30;

        public MenuForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Welcome to my Program";
            this.Size = new Size(800, 500);
            this.BackColor = System.Drawing.Color.BurlyWood;
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
            loginButton.Font = new Font("Segoe UI", 10);
            loginButton.Size = new Size(buttonSize1, buttonSize2);
            loginButton.Location = new Point(block1, height);

            Button signupButton = new Button();
            this.Controls.Add(signupButton);
            signupButton.Text = "Sign up";
            signupButton.Size = new Size(buttonSize1, buttonSize2);
            signupButton.Location = new Point(block1, height + indent);

            Button closeButton = new Button();
            this.Controls.Add(closeButton);
            closeButton.Text = "Exit";
            closeButton.Size = new Size(buttonSize1, buttonSize2);
            closeButton.Location = new Point(block1, height + indent*2);

            loginButton.Click += loginButton_Click;
            signupButton.Click += signupButton_Click;
            closeButton.Click += closeButton_Click;
        }

        private void closeButton_Click(object sender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs eventArgs)
        {
            this.Controls.Clear();

            WaterMarkTextBox nameTextBox = new WaterMarkTextBox();
            this.Controls.Add(nameTextBox);
            nameTextBox.WaterMarkText = "Username";
            nameTextBox.Size = new Size(buttonSize1, buttonSize2);
            nameTextBox.Location = new Point(block1, height);
            nameTextBox.Name = "UsernameTextbox";

            WaterMarkTextBox passwordTextBox = new WaterMarkTextBox();
            this.Controls.Add(passwordTextBox);
            passwordTextBox.WaterMarkText = "Password";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.MaxLength = 14;
            passwordTextBox.Size = new Size(buttonSize1, buttonSize2);
            passwordTextBox.Location = new Point(block1, height + indent);
            passwordTextBox.Name = "PasswordTextbox";

            Button loginButton = new Button();
            this.Controls.Add(loginButton);
            loginButton.Size = new Size(buttonSize1, buttonSize2);
            loginButton.Location = new Point(block1, height + indent*2);
            loginButton.Text = "Log in";

            Button backButton = new Button();
            this.Controls.Add(backButton);
            backButton.Size = new Size(buttonSize1, buttonSize2);
            backButton.Location = new Point(block1, height + indent*3);
            backButton.Text = "Back";

            backButton.Click += CreateButtonDelegate;
            loginButton.Click += F_loginButton_Click;
        }

        private void signupButton_Click(object sender, EventArgs eventArgs)
        {
            this.Controls.Clear();

            WaterMarkTextBox nameTextBox = new WaterMarkTextBox();
            this.Controls.Add(nameTextBox);
            nameTextBox.WaterMarkText = "Username";
            nameTextBox.Size = new Size(buttonSize1, buttonSize2);
            nameTextBox.Location = new Point(block1, height);
            nameTextBox.Name = "UsernameTextbox";

            WaterMarkTextBox passwordTextBox = new WaterMarkTextBox();
            this.Controls.Add(passwordTextBox);
            passwordTextBox.WaterMarkText = "Password";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.MaxLength = 14;
            passwordTextBox.Size = new Size(buttonSize1, buttonSize2);
            passwordTextBox.Location = new Point(block1, height + indent);
            passwordTextBox.Name = "PasswordTextbox";

            Label RoleText = new Label();
            this.Controls.Add(RoleText);
            RoleText.Text = "Choose Role";
            RoleText.Size = new Size(buttonSize1, buttonSize2);
            RoleText.Location = new Point(block1, height + indent*2);

            ComboBox roleComboBox = new ComboBox();
            this.Controls.Add(roleComboBox);
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleComboBox.Items.AddRange(roles);
            roleComboBox.Size = new Size(buttonSize1, buttonSize2);
            roleComboBox.Location = new Point(block1, height + indent*3);
            roleComboBox.Name = "RoleTextbox";

            Button signupButton = new Button();
            this.Controls.Add(signupButton);
            signupButton.Size = new Size(buttonSize1, buttonSize2);
            signupButton.Location = new Point(block1, height + indent*4);
            signupButton.Text = "Sign Up";

            Button backButton = new Button();
            this.Controls.Add(backButton);
            backButton.Size = new Size(buttonSize1, buttonSize2);
            backButton.Location = new Point(block1, height + indent*5);
            backButton.Text = "Back";

            backButton.PerformClick();
            backButton.Click += CreateButtonDelegate;
            signupButton.Click += F_signupButton_Click;
        }
        
        private void F_signupButton_Click(object sender, EventArgs eventArgs)
        {
            WaterMarkTextBox usernameTextbox = Controls.Find("UsernameTextbox", true)[0] as WaterMarkTextBox;
            string text1 = usernameTextbox.Text;

            WaterMarkTextBox passwordTextbox = Controls.Find("PasswordTextbox", true)[0] as WaterMarkTextBox;
            string text2 = passwordTextbox.Text;

            ComboBox roleTextbox = Controls.Find("RoleTextbox", true)[0] as ComboBox;
            string text3 = roleTextbox.Text;

            foreach (Person person in PersonsList.persons)
            {
                if ((person.Name.Equals(text1)) && (person.Password.Equals(text2)) && (person.Role.Equals(text3)))
                {
                    MessageBox.Show("This account already exists");
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
            if (text3 == "LayoutArtist")
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
            MessageBox.Show("fff");

            WaterMarkTextBox usernameTextbox = Controls.Find("UsernameTextbox", true)[0] as WaterMarkTextBox;
            string text1 = usernameTextbox.Text;

            WaterMarkTextBox passwordTextbox = Controls.Find("PasswordTextbox", true)[0] as WaterMarkTextBox;
            string text2 = passwordTextbox.Text;

            if (PersonsList.persons.Count == 0)
            {
                MessageBox.Show("Wrong Username or Password!");
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
                    if (person.Role.Equals("LayoutArtist"))
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
                    MessageBox.Show("Wrong Username or Password!");
                }
            }
        }

    }
}
