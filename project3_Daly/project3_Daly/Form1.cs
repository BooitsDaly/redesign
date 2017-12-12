using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project3_Daly
{
    public partial class Form1 : Form
    {
        //all of my gloabl objects
        About about;
        Contact contact;
        Courses courses;
        Degrees degrees;
        Employment employment;
        Footer footer;
        Minors minors;
        News news;
        People people;
        Research research;
        Resources resources;

        //restfull interface
        REST rj = new("http://ist.rit.edu/api");
        REST googleRj = new REST("http://google.com/coolAPI");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
