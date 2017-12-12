using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestUtil;

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
        REST rj = new REST("http://ist.rit.edu/api");
        REST googleRj = new REST("http://google.com/coolAPI");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get Home Page
            getHome();

        }

        //home(tab) - page
        private void getHome()
        {
            //get the data json
            string jsonAbout = rj.getJSON("/about/");
            Console.WriteLine(jsonAbout);
            //turn the string into an object
            about = JToken.Parse(jsonAbout).ToObject<About>();
            //set all the text fields
            home_title.Text = about.title;
            home_description.Text = about.description;
            home_quote.Text = about.quote;
            home_quoteAuthor.Text = about.quoteAuthor;

        }
    }
}
