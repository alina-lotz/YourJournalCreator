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

        private FormsManager()
        {
            //list of forms references
            Forms = new List<Form>();
            //margins
            roles = new string[] { "Journalist", "Photographer", "Editor", "Layout designer" };
            formSize = new Size(1000, 600);
            formPosition = FormStartPosition.CenterScreen;
            height = 120;
            block1 = 410; block2 = 150; block3 = 650;
            buttonWidth = 170;
            buttonHeight = 30;
            buttonSize = new Size(buttonWidth, buttonHeight);
            indent = 38;
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
        }
        
    }
}
