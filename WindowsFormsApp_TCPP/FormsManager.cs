using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_TCPP
{
    public sealed class FormsManager
    {
        private static FormsManager instance = null;
        public static FormsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormsManager();
                }
                return instance;
            }
        }

        public List<Form> Forms;

        public string[] roles;
        public FormStartPosition formPosition;
        public Size formSize;
        public int height;
        public int block1, block2, block3;
        public Size buttonSize;
        public int buttonWidth, buttonHeight;
        public int indent;
        public int fontSize;
        public string textFont;
        public Font fontType;

        public Color bgColor;
        public Color bColor;
        public Color tColor;

        public FlatStyle flatStyle;
        public int borderSize;
        public BorderStyle borderStyle;

        public int panelHeight, panelWidth;
        public Size panelSize;

        public int formHeigth, formWidth;

        private FormsManager()
        {
            //list of forms references
            Forms = new List<Form>();
            //roles
            roles = new string[] { "Journalist", "Photographer", "Editor", "Layout artist" };
            //layouts
            height = 120;
            block1 = 410; block2 = 150; block3 = 650;
            indent = 38;
            //buttons
            buttonWidth = 170;
            buttonHeight = 30;
            buttonSize = new Size(buttonWidth, buttonHeight);
            //font
            fontSize = 12;
            textFont = "Segoe UI";
            fontType = new Font(textFont, fontSize, FontStyle.Bold);
            //colors
            bgColor = System.Drawing.Color.CadetBlue;
            bColor = System.Drawing.Color.SeaShell;
            tColor = System.Drawing.Color.CadetBlue;
            //flat style
            flatStyle = FlatStyle.Flat;
            borderSize = 0;
            borderStyle = 0;
            //forms
            formHeigth = 600;
            formWidth = 1000;
            formSize = new Size(formWidth, formHeigth);
            formPosition = FormStartPosition.CenterScreen;
            //panels
            panelHeight = buttonHeight + 10;
            panelWidth = formWidth - 40;
            panelSize = new Size(panelWidth, panelHeight);
        }

    }
}
