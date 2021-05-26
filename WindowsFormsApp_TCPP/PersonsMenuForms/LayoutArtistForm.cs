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
        public LayoutArtistForm()
        {
            InitializeComponent();
            this.StartPosition = FormsManager.Instance.formPosition;
            this.Text = "Photographer";
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
        private void confirmJournalButton_Click(object sender, EventArgs eventArgs)
        {

        }
        private void exitButton_Click(object sender, EventArgs eventArgs)
        {
            FormsManager.Instance.Forms[0].Close();
        }
    }
}
