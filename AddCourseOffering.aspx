<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="AddCourseOffering.aspx.cs" Inherits="AddCourseOffering" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link href="App_Themes/SiteStyles.css" rel="App_Themese/Sitetylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLogo" Runat="Server">
    <br />
    <br />
    <asp:Image runat="server" ID="programLogo" ImageUrl="App_Themes/SAT.png" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add New Course Offering</h1>
     <asp:Label cssClass="label" runat="server" ID="lblCourse" Width="8em">Course: </asp:Label>
         <asp:DropDownList CssClass="dropdown" ID="drpCourse" runat="server" Width="10em">
            <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
        </asp:DropDownList>  
    <br />
    <br />
    <asp:Label cssClass="label" runat="server" ID="lblYears" Width="8em">Offer in Year: </asp:Label>
        <asp:DropDownList CssClass="dropdown" ID="drpYears" runat="server" Width="10em" >
            <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
            <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
            <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
        </asp:DropDownList>  
    <br />
    <br />
    <asp:Label CssClass="label" runat="server" ID="lblSemester" Width="8em">Semester: </asp:Label>
        <asp:DropDownList CssClass="dropdown" ID="drpSemester" runat="server" Width="10em">
            <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
            <asp:ListItem Text="Fall" Value="Fall"></asp:ListItem>
            <asp:ListItem Text="Winter" Value="Winter"></asp:ListItem>
            <asp:ListItem Text="Summer" Value="Summer"></asp:ListItem>
        </asp:DropDownList>
    <br />
    <br />
    <asp:Button runat="server" OnClick="btnSubmitCourseOffering_Click" Text="Add Course Offering:" />
    <br />
    <div>
        <asp:Table runat="server" CssClass="table" ID="tblCourseOffering">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    Course Code
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    Course Title
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    Year
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    Semester
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
</asp:Content>

