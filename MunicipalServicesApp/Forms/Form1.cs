using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MunicipalServicesApp.Class_Objects;
using MunicipalServicesApp.UserControls;

namespace MunicipalServicesApp
{
    public partial class Form1 : Form
    {
        private List<Issue> reportedIssues = new List<Issue>();  // List to store Issue objects
        public Form1()
        {

            InitializeComponent();
        }

        //----------------------------------------------------------------------//

        /// <summary>
        /// Menu strip for reporting the issues on a control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportIssuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reportedIssues = new ReportIssues();

            // Subscribe to the IssueSubmitted event
            reportedIssues.IssueSubmitted += OnIssueSubmitted;
            MainPanel.Controls.Clear();
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(reportedIssues);
        }

        //----------------------------------------------------------------------//

        /// <summary>
        /// Form load to display the home user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            var Home = new Home();
            MainPanel.Controls.Clear();
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(Home);

        }

        //----------------------------------------------------------------------//

        /// <summary>
        /// Menu strip acting as button to display the home user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>   
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var Home = new Home();
            Home.Show();
            //Home.Hide();
            MainPanel.Controls.Clear();
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(Home);


        }

        //----------------------------------------------------------------------//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="newIssue"></param>
        private void OnIssueSubmitted(object sender, Issue newIssue)
        {

            // Store the issue in the main form's list
            reportedIssues.Add(newIssue);

            // Display a confirmation message
          //  MessageBox.Show($"Your issue has been successfully submitted: {newIssue.Location} - {newIssue.Category}");
            //var issue = new Issue("Location", "Category", "Description", "MediaPath");
            //reportedIssues.Add(issue);
        }

        //----------------------------------**End**------------------------------------//
    }
}
