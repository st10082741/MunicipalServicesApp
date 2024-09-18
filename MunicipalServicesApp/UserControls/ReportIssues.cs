using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MunicipalServicesApp.Class_Objects;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MunicipalServicesApp.UserControls
{
    public partial class ReportIssues : UserControl
    {
        private bool messageShown = false;  // Flag to track if the message has been shown

        //----------------------------------------------------------------------//

        /// <summary>
        /// Declare the event handler when the issue is submitted.
        /// </summary>

        public event EventHandler<Issue> IssueSubmitted;
        //A local list to store issues temporarily for display
        private List<Issue> displayedIssues = new List<Issue>();
        public ReportIssues()
        {
            InitializeComponent();

        }

        //----------------------------------------------------------------------//

        /// <summary>
        /// Progress bar logic for user address input on a textbox.
        /// </summary>
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            progressBar.Value = 20;

            if (txtLocation.Text.Length == txtLocation.MaxLength && !messageShown)
            {
                // Show the message once
                MessageBox.Show("You have reached the maximum character limit of 50 characters.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                messageShown = true;  // Set the flag to true
            }

            // Reset the flag if the user deletes characters
            if (txtLocation.Text.Length < txtLocation.MaxLength)
            {
                messageShown = false;  // Allow the message to show again if the user reduces the text length
            }
        }

        //----------------------------------------------------------------------//

        /// <summary>
        /// Progress bar logic for user category selection in comboBox.
        /// </summary>
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            progressBar.Value = 40;
        }

        //----------------------------------------------------------------------//

        /// <summary>
        /// Progress bar logic for user description input.
        /// </summary>
        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            progressBar.Value = 60;
        }
        //----------------------------------------------------------------------//
        /// <summary>
        /// button to attach the media file.
        /// </summary>
        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";  // Restrict file type to images

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                progressBar.Value = 80;  // Update progress bar after image is attached
                picPreview.Image = Image.FromFile(openFileDialog.FileName);  // Display selected image
                picPreview.Tag = openFileDialog.FileName;  // Store the file path for later
            }


        }

        //----------------------------------------------------------------------//

        /// <summary>
        /// Submit button logic to create an issue object and raise the IssueSubmitted event.
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate that all required fields are filled
            if (string.IsNullOrEmpty(txtLocation.Text) || cmbCategory.SelectedIndex == -1 || string.IsNullOrEmpty(rtbDescription.Text) || picPreview.Image == null)
            {
                MessageBox.Show("Please fill out all fields and attach an image.");
                return;
            }

            // Create a new Issue object
            Issue newIssue = new Issue(
                txtLocation.Text,
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text,
                picPreview.Tag.ToString()  // Use the stored image file path

            );

            // Raise the IssueSubmitted event to notify the main form
            IssueSubmitted?.Invoke(this, newIssue);

            // Add the issue to the ListBox
            displayedIssues.Add(newIssue);
            lstIssues.Items.Add(newIssue.ToString());  // Add the issue to the list box

            // Clear the form after submission
            ClearForm();

            MessageBox.Show("Your issue has been successfully submitted!");
            progressBar.Value = 100; // Update progress bar after submission
            progressBar.Value = 0;  // Reset progress bar after submission
        }


        //----------------------------------------------------------------------//

        /// <summary>
        /// Clear the form fields after submission.
        /// </summary>
        private void ClearForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            picPreview.Image = null;

        }

        //----------------------------------------------------------------------//

        /// <summary>
        ///  Display the selected issue details in a message box after clicking the ListBox input.
        /// </summary>
        private void lstIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstIssues.SelectedIndex != -1)
            {
                // Get the selected issue from the list
                Issue selectedIssue = displayedIssues[lstIssues.SelectedIndex];

                // Show issue details in a message box
                MessageBox.Show($"Location: {selectedIssue.Location}\nCategory: {selectedIssue.Category}\nDescription: {selectedIssue.Description}\nMedia: {selectedIssue.MediaPath}");

                // Display the related image in the PictureBox
                picPreview.Image = Image.FromFile(selectedIssue.MediaPath);
            }
        }

        //----------------------------------------------------------------------//

        /// <summary>
        /// Button to go back to the main form
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void ReportIssues_Load(object sender, EventArgs e)
        {
            txtLocation.TextChanged += txtLocation_TextChanged;
        }
        //----------------------------------**End**------------------------------------//
    }
}
