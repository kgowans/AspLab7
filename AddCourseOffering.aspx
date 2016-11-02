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
        </asp:DropDownList>  
    <br />
    <br />
    <asp:Label CssClass="label" runat="server" ID="lblSemester" Width="8em">Semester: </asp:Label>
        <asp:DropDownList CssClass="dropdown" ID="drpSemester" runat="server" Width="10em">
            <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
        </asp:DropDownList>
    <br />
    <br />
    <asp:Button runat="server" OnClick="btnSubmitCourseOffering_Click" Text="Add Course Offering:" />
    <br />
    <div>
        <asp:GridView Width="460" runat="server" AutoGenerateColumns="false" EmptyDataText="No Courses Added" ShowHeaderWhenEmpty="true" ID="gvAddCourseOffering">
                 <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />                    
                 <HeaderStyle BackColor="#ff0080" Font-Bold="True" ForeColor="#F7F7F7" />
                 <Columns>
                   <asp:BoundField DataField="CourseCode" HeaderText="Course Code" ReadOnly="True">
                       <ItemStyle  Width ="100" />
                   </asp:BoundField>
                    <asp:BoundField DataField="Title" HeaderText="Course Title" ReadOnly="True">
                        <ItemStyle  Width ="280" />
                   </asp:BoundField>
                   <asp:BoundField DataField="Year" HeaderText="Year" ReadOnly="True">
                       <ItemStyle  Width ="80" />
                   </asp:BoundField>
                   <asp:BoundField DataField="Semester" HeaderText="Semester" ReadOnly="True">
                       <ItemStyle  Width ="80" />
                   </asp:BoundField>
                </Columns>
          </asp:GridView>
    </div>
</asp:Content>

