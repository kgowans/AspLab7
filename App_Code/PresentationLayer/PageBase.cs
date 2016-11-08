using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class PageBase : System.Web.UI.Page
{
    public PageBase(){}

    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButton addNewCourseSideButton = (LinkButton)Master.FindControl("sidebarButton1");
        LinkButton addNewCourseOfferingSideButton = (LinkButton)Master.FindControl("sidebarButton2");
        LinkButton addNewStudentSideButton = (LinkButton)Master.FindControl("sidebarButton3");

        addNewCourseSideButton.Text = "Add Course";
        addNewCourseOfferingSideButton.Text = "Add Course Offering";
        addNewStudentSideButton.Text = "Register Student";

        addNewCourseSideButton.Click += (se, ev) => Response.Redirect("AddCourse.aspx");
        addNewCourseOfferingSideButton.Click += (se, ev) => Response.Redirect("AddCourseOffering.aspx");
        addNewStudentSideButton.Click += (se, ev) => Response.Redirect("AddStudent.aspx");


    }
}