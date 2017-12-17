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
            // make the window not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //get Home Page
            getHome();
            //get degrees tab
            getDegrees();
            //get minors tab
            getMinors();
            //employment tab
            getEmployment();
            //get coop tab
            getCoop();
            //get the fac staff page
            getFacStaff();
            //get the research areas
            getResearch();
            //get the resources
            getResources();
            //get the news
            getNews();
            //get the contact form

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

            //add the footer stuff
            string jsonFooter = rj.getJSON("/footer/");
            footer = JToken.Parse(jsonFooter).ToObject<Footer>();
            label13.Text = footer.social.title;
            label14.Text = footer.social.tweet;
            label15.Text = footer.social.by;
            linkLabel5.Text = footer.social.twitter;
            linkLabel6.Text = footer.social.facebook ;
            //get the links
            label9.Text = footer.quickLinks[0].title;
            linkLabel1.Text = footer.quickLinks[0].href;
            label10.Text = footer.quickLinks[1].title;
            linkLabel2.Text = footer.quickLinks[1].href;
            label11.Text = footer.quickLinks[2].title;
            linkLabel3.Text = footer.quickLinks[2].href;
            label12.Text = footer.quickLinks[3].title;
            linkLabel4.Text = footer.quickLinks[3].href;

        }

        //degrees tab
        private void getDegrees()
        {
            //get the data json
            string jsonDegrees = rj.getJSON("/degrees/");
            //turn into an object
            degrees = JToken.Parse(jsonDegrees).ToObject<Degrees>();
            Console.Write(degrees);
            degrees_undergrad.Text = "Undergraduate Degrees";
            degrees_grad.Text = "Graduate Degrees";
            
            //dump data for wmc
            degrees_wmc.Text = degrees.undergraduate[0].degreeName + "\n";
            degrees_wmc.Text += degrees.undergraduate[0].title + "\n\n";
            degrees_wmc.Text += "Description: \n";
            degrees_wmc.Text += degrees.undergraduate[0].description + "\n\n";
            degrees_wmc.Text += "Concentrations: \n";
            for(int i =0; i<degrees.undergraduate[0].concentrations.Count; i++)
            {
                degrees_wmc.Text += degrees.undergraduate[0].concentrations[i] + "\n";
            }

            //dump data for hcc
            degrees_hic.Text = degrees.undergraduate[1].degreeName + "\n";
            degrees_hic.Text += degrees.undergraduate[1].title + "\n\n";
            degrees_hic.Text += "Description: \n";
            degrees_hic.Text += degrees.undergraduate[1].description + "\n\n";
            degrees_hic.Text += "Concentrations: \n";
            for (int i = 0; i < degrees.undergraduate[1].concentrations.Count; i++)
            {
                degrees_hic.Text += degrees.undergraduate[1].concentrations[i] + "\n";
            } 

            //dump data for cit
            degrees_cit.Text = degrees.undergraduate[2].degreeName + "\n";
            degrees_cit.Text += degrees.undergraduate[2].title + "\n\n";
            degrees_cit.Text += "Description: \n";
            degrees_cit.Text += degrees.undergraduate[2].description + "\n\n";
            degrees_cit.Text += "Concentrations: \n";
            for (int i = 0; i < degrees.undergraduate[2].concentrations.Count; i++)
            {
                degrees_cit.Text += degrees.undergraduate[2].concentrations[i] + "\n";
            }


            //dump data for graduate-ist
            grad_ist.Text = degrees.graduate[0].degreeName + "\n";
            grad_ist.Text += degrees.graduate[0].title + "\n\n";
            grad_ist.Text += "Description: \n";
            grad_ist.Text += degrees.graduate[0].description + "\n\n";
            grad_ist.Text += "Concentrations: \n";
            for (int i = 0; i < degrees.graduate[0].concentrations.Count; i++)
            {
                grad_ist.Text += degrees.graduate[0].concentrations[i] + "\n";
            }

            //dump data for graduate-hci
            grad_hci.Text = degrees.graduate[1].degreeName + "\n";
            grad_hci.Text += degrees.graduate[1].title + "\n\n";
            grad_hci.Text += "Description: \n";
            grad_hci.Text += degrees.graduate[1].description + "\n\n";
            grad_hci.Text += "Concentrations: \n";
            for (int i = 0; i < degrees.graduate[1].concentrations.Count; i++)
            {
                grad_hci.Text += degrees.graduate[1].concentrations[i] + "\n";
            }

            //dump data for graduate-nsa
            grad_nsa.Text = degrees.graduate[2].degreeName + "\n";
            grad_nsa.Text += degrees.graduate[2].title + "\n\n";
            grad_nsa.Text += "Description: \n";
            grad_nsa.Text += degrees.graduate[2].description + "\n\n";
            grad_nsa.Text += "Concentrations: \n";
            for (int i = 0; i < degrees.graduate[2].concentrations.Count; i++)
            {
                grad_nsa.Text += degrees.graduate[2].concentrations[i] + "\n";
            }

            //dump data for graduate advanced certificates
            graduate_gac.Text = degrees.graduate[3].degreeName + "\n\n";
            graduate_gac.Text += "Available Certificates: \n";
            for(int i = 0; i < degrees.graduate[3].availableCertificates.Count; i++)
            {
                graduate_gac.Text += degrees.graduate[3].availableCertificates[i] + "\n";
            }
        }

        //get all the minors
        public void getMinors()
        {
            //get the json
            string jsonDegrees = rj.getJSON("/minors/");
            //turn into an object
            minors = JToken.Parse(jsonDegrees).ToObject<Minors>();
            Console.Write(minors);
            //set button titles
            minors_database.Text = minors.UgMinors[0].title;
            minors_geographic.Text = minors.UgMinors[1].title;
            minors_health.Text = minors.UgMinors[2].title;
            minors_mobile.Text = minors.UgMinors[3].title;
            minors_mobiledev.Text = minors.UgMinors[4].title;
            minors_networksys.Text = minors.UgMinors[5].title;
            minors_webDesign.Text = minors.UgMinors[6].title;
            minors_webDevelop.Text = minors.UgMinors[7].title;

        }

        //get the employment data
        public void getEmployment()
        {
            //get the json
            String jsonEmployment = rj.getJSON("/employment/");
            //turn it into an object
            employment = JToken.Parse(jsonEmployment).ToObject<Employment>();
            //set up how I want it to look...
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            //create col for table
            listView1.Columns.Add("Employers", 200);
            listView1.Columns.Add("Degree", 200);
            listView1.Columns.Add("City", 200);
            listView1.Columns.Add("Title", 200);
            listView1.Columns.Add("Start Date", 100);
            //throw all the data into the listview
            ListViewItem item;
            for (int i = 0; i < employment.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                item = new ListViewItem(new String[] {
                    employment.employmentTable.professionalEmploymentInformation[i].employer,
                    employment.employmentTable.professionalEmploymentInformation[i].degree,
                    employment.employmentTable.professionalEmploymentInformation[i].city,
                    employment.employmentTable.professionalEmploymentInformation[i].title,
                    employment.employmentTable.professionalEmploymentInformation[i].startDate,

                });
                listView1.Items.Add(item);
            }
            //dump all the other data
            employment_description.Text = employment.introduction.content[0].description;
            employment_stat1.Text = employment.degreeStatistics.statistics[0].value + "\n";
            employment_stat1.Text = employment.degreeStatistics.statistics[0].description;
            employment_stat2.Text = employment.degreeStatistics.statistics[1].value + "\n";
            employment_stat2.Text = employment.degreeStatistics.statistics[1].description;
            employment_stat3.Text = employment.degreeStatistics.statistics[2].value + "\n";
            employment_stat3.Text = employment.degreeStatistics.statistics[2].description;
            employment_stat4.Text = employment.degreeStatistics.statistics[3].value + "\n";
            employment_stat4.Text = employment.degreeStatistics.statistics[3].description;
            //dump in the employers stuffff
            employment_employers.Text = employment.employers.title + "\n";
            for(int i = 0; i < employment.employers.employerNames.Count; i++)
            {
                employment_employers.Text += employment.employers.employerNames[i] + "\n";
            }
            


        }

        //coop tab get all the data things
        public void getCoop()
        {
            //set up how I want it to look...
            listView2.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;
            //create col for table
            listView2.Columns.Add("Employers", 200);
            listView2.Columns.Add("Degree", 200);
            listView2.Columns.Add("City", 200);
            listView2.Columns.Add("Term", 100);
            //throw all the data into the listview
            ListViewItem item;
            for (int i = 0; i < employment.coopTable.coopInformation.Count; i++)
            {
                item = new ListViewItem(new String[] {
                    employment.coopTable.coopInformation[i].employer,
                    employment.coopTable.coopInformation[i].degree,
                    employment.coopTable.coopInformation[i].city,
                    employment.coopTable.coopInformation[i].term
                });
                listView2.Items.Add(item);
            }
            //get all the data and throw into the labels
            coop_companies.Text = employment.careers.title;
            for(int i = 0; i < employment.careers.careerNames.Count; i++)
            {
                coop_companies.Text += employment.careers.careerNames[i];
            }
            coop_title.Text = employment.introduction.content[1].title + "\n";
            coop_description.Text = employment.introduction.content[1].description;
            

        }

        public void getFacStaff()
        {
            //get the data json
            string jsonPeople = rj.getJSON("/people/");
            //turn into an object
            people = JToken.Parse(jsonPeople).ToObject<People>();
            //set up how I want it to look...
            table_fac.View = View.Details;
            table_fac.GridLines = true;
            table_fac.FullRowSelect = true;
            //create col for table
            table_fac.Columns.Add("Name", 100);
            table_fac.Columns.Add("Username", 100);
            table_fac.Columns.Add("Title", 200);
            //set up how I want it to look same thing for the staff
            table_staff.View = View.Details;
            table_staff.GridLines = true;
            table_staff.FullRowSelect = true;
            //create col for table
            table_staff.Columns.Add("Name", 100);
            table_staff.Columns.Add("Username", 100);
            table_staff.Columns.Add("Title", 200);

            //throw all the data into the listview
            ListViewItem item;
            for (int i = 0; i < people.faculty.Count; i++)
            {
                item = new ListViewItem(new String[] {
                    people.faculty[i].name,
                    people.faculty[i].username,
                    people.faculty[i].title,
                });
                table_fac.Items.Add(item);
            }
            for (int i = 0; i < people.staff.Count; i++)
            {
                item = new ListViewItem(new String[] {
                    people.staff[i].name,
                    people.staff[i].username,
                    people.staff[i].title,
                });
                table_staff.Items.Add(item);
            }

            //all the other data 
            facStaff_title.Text = people.title + "\n";
        }

        public void getResearch()
        {
            //get the data json
            string jsonResearch = rj.getJSON("/research/");
            //turn into an object
            research = JToken.Parse(jsonResearch).ToObject<Research>();
            //set up how I want it to look same thing for the research
            research_table.View = View.Details;
            research_table.GridLines = true;
            research_table.FullRowSelect = true;
            //create col for table
            research_table.Columns.Add("Research Areas", 800);

            //populate the table
            ListViewItem item;
            for (int i = 0; i < research.byInterestArea.Count; i++)
            {
                item = new ListViewItem(new String[] {
                   research.byInterestArea[i].areaName,
                });
                research_table.Items.Add(item);
            }
        }

        //get the resources
        public void getResources()
        {
            //get the data json
            string jsonResources = rj.getJSON("/resources/");
            //turn into an object
            resources = JToken.Parse(jsonResources).ToObject<Resources>();
            resources_abroad.Text = resources.studyAbroad.title;
            resources_advising.Text = resources.studentServices.title;
            resources_ambas.Text = resources.studentAmbassadors.title;
            resources_coop.Text = resources.coopEnrollment.title;
            resources_forms.Text = "Forms";
            resources_tutors.Text = resources.tutorsAndLabInformation.title;
        }

        //get the news
        public void getNews()
        {
            //get the data json
            string jsonNews = rj.getJSON("/news/");
            //turn into an object
            news = JToken.Parse(jsonNews).ToObject<News>();
            //set up how I want it to look same thing for the research
            news_table.View = View.Details;
            news_table.GridLines = true;
            news_table.FullRowSelect = true;
            //create col for table
            news_table.Columns.Add("News", 800);

            //populate the table
            ListViewItem item;
            for (int i = 0; i < news.older.Count; i++)
            {
                item = new ListViewItem(new String[] {
                   news.older[i].title,
                });
                news_table.Items.Add(item);
            }
        }




        //onclick listener to populate area with information - database
        private void minors_database_Click(object sender, EventArgs e)
        {
            minors_header.Text = minors.UgMinors[0].title + "\n";
            minors_header.Text += minors.UgMinors[0].name + "\n\n";
            minors_information.Text = minors.UgMinors[0].description + "\n\n";
            minors_information.Text += "Courses: \n";
            for(int i = 0; i < minors.UgMinors[0].courses.Count; i++)
            {
                minors_information.Text += minors.UgMinors[0].courses[i] + "\n"; 
            }

        }

        //onclick listener to populate area with information - geographic
        private void minors_geographic_Click(object sender, EventArgs e)
        {
            minors_header.Text = minors.UgMinors[1].title + "\n";
            minors_header.Text += minors.UgMinors[1].name + "\n\n";
            minors_information.Text = minors.UgMinors[1].description + "\n\n";
            minors_information.Text += "Courses: \n";
            for (int i = 0; i < minors.UgMinors[1].courses.Count; i++)
            {
                minors_information.Text += minors.UgMinors[1].courses[i] + "\n";
            }
        }

        //onclick listener to populate area with information - health
        private void minors_health_Click(object sender, EventArgs e)
        {
            minors_header.Text = minors.UgMinors[2].title + "\n";
            minors_header.Text += minors.UgMinors[2].name + "\n\n";
            minors_information.Text = minors.UgMinors[2].description + "\n\n";
            minors_information.Text += "Courses: \n";
            for (int i = 0; i < minors.UgMinors[2].courses.Count; i++)
            {
                minors_information.Text += minors.UgMinors[2].courses[i] + "\n";
            }
        }

        private void minors_mobile_Click(object sender, EventArgs e)
        {
            minors_header.Text = minors.UgMinors[3].title + "\n";
            minors_header.Text += minors.UgMinors[3].name + "\n\n";
            minors_information.Text = minors.UgMinors[3].description + "\n\n";
            minors_information.Text += "Courses: \n";
            for (int i = 0; i < minors.UgMinors[3].courses.Count; i++)
            {
                minors_information.Text += minors.UgMinors[3].courses[i] + "\n";
            }
        }

        private void minors_mobiledev_Click(object sender, EventArgs e)
        {
            minors_header.Text = minors.UgMinors[4].title + "\n";
            minors_header.Text += minors.UgMinors[4].name + "\n\n";
            minors_information.Text = minors.UgMinors[4].description + "\n\n";
            minors_information.Text += "Courses: \n";
            for (int i = 0; i < minors.UgMinors[4].courses.Count; i++)
            {
                minors_information.Text += minors.UgMinors[4].courses[i] + "\n";
            }
        }

        private void minors_networksys_Click(object sender, EventArgs e)
        {
            minors_header.Text = minors.UgMinors[5].title + "\n";
            minors_header.Text += minors.UgMinors[5].name + "\n\n";
            minors_information.Text = minors.UgMinors[5].description + "\n\n";
            minors_information.Text += "Courses: \n";
            for (int i = 0; i < minors.UgMinors[5].courses.Count; i++)
            {
                minors_information.Text += minors.UgMinors[5].courses[i] + "\n";
            }
        }

        private void minors_webDesign_Click(object sender, EventArgs e)
        {
            minors_header.Text = minors.UgMinors[6].title + "\n";
            minors_header.Text += minors.UgMinors[6].name + "\n\n";
            minors_information.Text = minors.UgMinors[6].description + "\n\n";
            minors_information.Text += "Courses: \n";
            for (int i = 0; i < minors.UgMinors[6].courses.Count; i++)
            {
                minors_information.Text += minors.UgMinors[6].courses[i] + "\n";
            }
        }

        private void minors_webDevelop_Click(object sender, EventArgs e)
        {
            minors_header.Text = minors.UgMinors[7].title + "\n";
            minors_header.Text += minors.UgMinors[7].name + "\n\n";
            minors_information.Text = minors.UgMinors[7].description + "\n\n";
            minors_information.Text += "Courses: \n";
            for (int i = 0; i < minors.UgMinors[7].courses.Count; i++)
            {
                minors_information.Text += minors.UgMinors[7].courses[i] + "\n";
            }
        }

        private void btn_fac_Click(object sender, EventArgs e)
        {
            //get the index of the selected item
            int selectedItem = table_fac.FocusedItem.Index;
            //set the image
            people_pic.Load(people.faculty[selectedItem].imagePath);
            //set the data
            people_info.Text = people.faculty[selectedItem].name + "\n";
            people_info.Text += "User Name: " + people.faculty[selectedItem].username + "\n";
            people_info.Text += "Title: " + people.faculty[selectedItem].title + "\n";
            people_info.Text += "Tag Line: " + people.faculty[selectedItem].tagline + "\n";
            people_info.Text += "Interest Area: " + people.faculty[selectedItem].interestArea + "\n";
            people_info.Text += "Office: " + people.faculty[selectedItem].office + "\n";
            people_info.Text += "Website: " + people.faculty[selectedItem].website + "\n";
            people_info.Text += "Phone: " + people.faculty[selectedItem].phone + "\n";
            people_info.Text += "Email: " + people.faculty[selectedItem].email + "\n";
            people_info.Text += "Twitter: " + people.faculty[selectedItem].twitter + "\n";
            people_info.Text += "Facebook: " + people.faculty[selectedItem].facebook + "\n";

        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            //get the index of the selected item
            int selectedItem = table_staff.FocusedItem.Index;
            //set the image
            people_pic.Load(people.staff[selectedItem].imagePath);
            //set the data
            people_info.Text = people.staff[selectedItem].name + "\n";
            people_info.Text += "User Name: " + people.staff[selectedItem].username + "\n";
            people_info.Text += "Title: " + people.staff[selectedItem].title + "\n";
            people_info.Text += "Tag Line: " + people.staff[selectedItem].tagline + "\n";
            people_info.Text += "Interest Area: " + people.staff[selectedItem].interestArea + "\n";
            people_info.Text += "Office: " + people.staff[selectedItem].office + "\n";
            people_info.Text += "Website: " + people.staff[selectedItem].website + "\n";
            people_info.Text += "Phone: " + people.staff[selectedItem].phone + "\n";
            people_info.Text += "Email: " + people.staff[selectedItem].email + "\n";
            people_info.Text += "Twitter: " + people.staff[selectedItem].twitter + "\n";
            people_info.Text += "Facebook: " + people.staff[selectedItem].facebook + "\n";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the index of the selected itenm
            int selectedItem = research_table.FocusedItem.Index;
            //to clear the box of previous entries
            research_info.Text = "";
            for (int i = 0; i < research.byInterestArea[selectedItem].citations.Count; i++)
            {
                //add everything else
                research_info.Text += research.byInterestArea[selectedItem].citations[i] + "\n\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //get the index of the selected itenm
            int selectedItem = news_table.FocusedItem.Index;
            //to clear the box of previous entries
            news_info.Text = "";
            news_info.Text += news.older[selectedItem].date + "\n";
            news_info.Text += news.older[selectedItem].title + "\n";
            news_info.Text += news.older[selectedItem].description + "\n\n";

        }

        //on click event for study abroad
        private void resources_abroad_Click(object sender, EventArgs e)
        {

            linkLabel7.Text = "";
            linkLabel8.Text = "";
            linkLabel9.Text = "";
            linkLabel10.Text = "";
            linkLabel11.Text = "";
            linkLabel12.Text = "";
            linkLabel13.Text = "";
            linkLabel14.Text = "";
            linkLabel15.Text = "";
            resources_info.Text = "Description: \n";
            resources_info.Text += resources.studyAbroad.description + "\n\n";
            for (int i = 0; i < resources.studyAbroad.places.Count; i++)
            {
                //add everything else
                resources_info.Text += resources.studyAbroad.places[i].nameOfPlace + "\n";
                resources_info.Text += resources.studyAbroad.places[i].description + "\n\n";
            }
        }

        //onclick event for advising
        private void resources_advising_Click(object sender, EventArgs e)
        {
            linkLabel7.Text = "";
            linkLabel8.Text = "";
            linkLabel9.Text = "";
            linkLabel10.Text = "";
            linkLabel11.Text = "";
            linkLabel12.Text = "";
            linkLabel13.Text = "";
            linkLabel14.Text = "";
            linkLabel15.Text = "";
            resources_info.Text = resources.studentServices.academicAdvisors.title + "\n";
            resources_info.Text += resources.studentServices.academicAdvisors.description+ "\n\n";
            resources_info.Text += resources.studentServices.professonalAdvisors.title + "\n";
            for (int i = 0; i < resources.studentServices.professonalAdvisors.advisorInformation.Count; i++)
            {
                //add everything else
                resources_info.Text += resources.studentServices.professonalAdvisors.advisorInformation[i].name + "\n";
                resources_info.Text += resources.studentServices.professonalAdvisors.advisorInformation[i].department + "\n";
                resources_info.Text += resources.studentServices.professonalAdvisors.advisorInformation[i].email + "\n";
            }

            //student services
            resources_info.Text += resources.studentServices.facultyAdvisors.title + "\n";
            resources_info.Text += resources.studentServices.facultyAdvisors.description + "\n\n";

            //ist minor advising
            resources_info.Text += resources.studentServices.istMinorAdvising.title + "\n";
            for (int i = 0; i < resources.studentServices.istMinorAdvising.minorAdvisorInformation.Count; i++)
            {
                //add everything else
                resources_info.Text += resources.studentServices.istMinorAdvising.minorAdvisorInformation[i].title + "\n";
                resources_info.Text += resources.studentServices.istMinorAdvising.minorAdvisorInformation[i].advisor + "\n";
                resources_info.Text += resources.studentServices.istMinorAdvising.minorAdvisorInformation[i].email + "\n";
            }

            

            //studnet ambassators
            resources_info.Text += resources.studentAmbassadors.title + "\n";
            for (int i = 0; i < resources.studentAmbassadors.subSectionContent.Count; i++)
            {
                //add everything else
                resources_info.Text += resources.studentAmbassadors.subSectionContent[i].title + "\n";
                resources_info.Text += resources.studentAmbassadors.subSectionContent[i].description + "\n";
            }

        }

        private void resources_tutors_Click(object sender, EventArgs e)
        {
            linkLabel7.Text = "";
            linkLabel8.Text = "";
            linkLabel9.Text = "";
            linkLabel10.Text = "";
            linkLabel11.Text = "";
            linkLabel12.Text = "";
            linkLabel13.Text = "";
            linkLabel14.Text = "";
            linkLabel15.Text = "";
            //tutors and lab inforamtion
            resources_info.Text = resources.tutorsAndLabInformation.title + "\n";
            resources_info.Text += resources.tutorsAndLabInformation.description + "\n\n";
        }

        private void resources_forms_Click(object sender, EventArgs e)
        {

            resources_info.Text = "";
            linkLabel7.Text = resources.forms.graduateForms[0].href;
            linkLabel8.Text = resources.forms.graduateForms[1].href;
            linkLabel9.Text = resources.forms.graduateForms[2].href;
            linkLabel10.Text = resources.forms.graduateForms[3].href;
            linkLabel11.Text = resources.forms.graduateForms[4].href;
            linkLabel12.Text = resources.forms.graduateForms[5].href;
            linkLabel13.Text = resources.forms.graduateForms[6].href;
            linkLabel14.Text = "";
            linkLabel15.Text = "";

            for (int i = 0; i < resources.forms.graduateForms.Count; i++)
            {
                //add everything else
                resources_info.Text += resources.forms.graduateForms[i].formName + "\n\n";

            }
        }

        private void resources_ambas_Click(object sender, EventArgs e)
        {
            linkLabel7.Text = "";
            linkLabel8.Text = "";
            linkLabel9.Text = "";
            linkLabel10.Text = "";
            linkLabel11.Text = "";
            linkLabel12.Text = "";
            linkLabel13.Text = "";
            linkLabel14.Text = "";
            linkLabel15.Text = "";
            resources_info.Text = resources.studentAmbassadors.title + "\n\n";
            for (int i = 0; i < resources.studentAmbassadors.subSectionContent.Count; i++)
            {
                //add everything else
                resources_info.Text += resources.studentAmbassadors.subSectionContent[i].title + "\n";
                resources_info.Text += resources.studentAmbassadors.subSectionContent[i].description + "\n";
            }
            linkLabel15.Text = resources.studentAmbassadors.applicationFormLink;
        }

        private void resources_coop_Click(object sender, EventArgs e)
        {
            linkLabel7.Text = "";
            linkLabel8.Text = "";
            linkLabel9.Text = "";
            linkLabel10.Text = "";
            linkLabel11.Text = "";
            linkLabel12.Text = "";
            linkLabel13.Text = "";
            linkLabel14.Text = "";
            linkLabel15.Text = "";
            resources_info.Text = resources.coopEnrollment.title + "\n\n";
            for (int i = 0; i < resources.coopEnrollment.enrollmentInformationContent.Count; i++)
            {
                //add everything else
                resources_info.Text += resources.coopEnrollment.enrollmentInformationContent[i].title + "\n";
                resources_info.Text += resources.coopEnrollment.enrollmentInformationContent[i].description + "\n";
            }
            linkLabel14.Text = resources.coopEnrollment.RITJobZoneGuidelink;
        }

        private void linkLabel7_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            Process.Start("ist.rit.edu/" + resources.forms.graduateForms[0].href);
        }

        private void linkLabel8_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start("ist.rit.edu/" + resources.forms.graduateForms[1].href);
        }

        private void linkLabel9_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start("ist.rit.edu/" + resources.forms.graduateForms[2].href);
        }

        private void linkLabel10_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start("ist.rit.edu/" + resources.forms.graduateForms[3].href);
        }

        private void linkLabel11_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start("ist.rit.edu/" + resources.forms.graduateForms[4].href);
        }

        private void linkLabel12_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start("ist.rit.edu/" + resources.forms.graduateForms[5].href);
        }

        private void linkLabel13_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start("ist.rit.edu/" + resources.forms.graduateForms[6].href);
        }

        private void linkLabel14_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start(resources.coopEnrollment.RITJobZoneGuidelink);
        }

        private void linkLabel15_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            Process.Start(resources.studentAmbassadors.applicationFormLink);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            Process.Start(footer.social.twitter);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            Process.Start(footer.social.facebook);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            Process.Start(footer.quickLinks[0].href);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            Process.Start(footer.quickLinks[1].href);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            Process.Start(footer.quickLinks[2].href);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // visited.
            this.linkLabel1.LinkVisited = true;
            // Navigate to a URL.
            Process.Start(footer.quickLinks[3].href);
        }
    }
}
