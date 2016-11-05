<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes/SiteStyles.css" rel="App_Themese/stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLogo" Runat="Server">
    <br />
    <br />
    <asp:Image runat="server" ID="programLogo" ImageUrl="App_Themes/SAT.png" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h1>Add New Courses</h1>
            <div class="firstPanelStuff">
                <asp:Label runat="server" ID="lblCourseNumber" Width="8em">Course Number: </asp:Label>
                <asp:TextBox runat="server" ID="txtCourseNumber"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server" ID="lblCourseName" Width="8em">Course Name: </asp:Label>
                <asp:TextBox runat="server" ID="txtCourseName"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server" ID="lblWeeklyHours" Width="8em">Weekly Hours: </asp:Label>
                <asp:TextBox runat="server" ID="txtWeeklyHours"></asp:TextBox>
                <br />
                <br />
                <asp:Button runat="server" OnClick="btnSubmitCourse_Click" Text="Submit Course Information"></asp:Button>
                <br />
                Following courses are currently in the system:
            </div>
            <div>
                
            <asp:GridView Width="460" runat="server" AutoGenerateColumns="false" EmptyDataText="No Courses Added" ShowHeaderWhenEmpty="true" ID="gvAddCourse">
                <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="#FF0000" Font-Bold="true" /> 
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />                    
                <HeaderStyle BackColor="#ff0080" Font-Bold="True" ForeColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True">
                        <ItemStyle  Width ="80" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CourseTitle" HeaderText="Name" ReadOnly="True">
                        <ItemStyle  Width ="300" />
                    </asp:BoundField>
                    <asp:BoundField DataField="WeeklyHours" HeaderText="Hours" ReadOnly="True">
                        <ItemStyle  Width ="80" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            </div>
    </div>

</asp:Content>

