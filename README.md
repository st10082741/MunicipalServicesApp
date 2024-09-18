Name:Victor Sumbo
SN:ST10082741
Varsity College, Cape Town

PROJECT OVERVIEW

This project is a C# Windows Forms Application that allows users to report municipal service issues such as sanitation, roads, and utilities. The application consists of a single main form and a modular (can be reused) “UserControl” for submitting issue reports. The reported issues list is stored and managed in the main form, ensuring modularity and ease of use in ways that the same list of issues can be easily reused across different parts of the application for instance if necessary.

KEY FEATURES: 

•	Report issues related to municipal services.

•	Progress bar to track form completion.

•	Image attachment feature for submitting images with reports.

•	Dynamically loaded UserControl for modular form management.

•	Menu to navigate to different sections of the application.

•	Back Button to navigate to the main form thus home page.

SYSTEM REQUIREMENTS:

•	IDE: Visual Studio 2022

•	.NET Framework: .NET Framework 4.8

USING OF SOFTWARE 

MainForm

  •	The MainForm contains the main navigation for the application. It features a menu item labelled "Report Issues" that loads the ReportIssues Control.

Reporting an Issue

1.	Click "Report Issues" to open the issue reporting form.

2.	Fill in the following fields:
   
•	Location: Enter the location where the issue is happening.
•	Category: Select a category (Sanitation, Roads, Utilities) from the dropdown.
•	Description: Provide a detailed description of the issue in the RichTextBox.

4.	Attach an Image:
   
•	Click "Attach Image" to open a file dialog. Select a relevant image from your system. The selected image will appear in the preview section.

6.	Submit the Report:
   
•	Click "Submit" once all fields are filled. The form will reset, and a confirmation message will appear.

8.	Progress Bar:
   
•	The progress bar at the bottom of the form will update as you fill out the fields.

10.	Listbox that displays the issues submitted by the users accompanied by a PictureBox that shows the attached image.

Storing and Managing Issues

•	All reported issues are stored in memory within the MainForm. After submission, the issue is saved in the reportedIssues list, and the details can be accessed programmatically.

NB: after the input is displayed on the Listbox the user can click on it and a message box will appear with all the data entered by the user. 

Github Link: https://github.com/st10082741/MunicipalServicesApp.git



 

