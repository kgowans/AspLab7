<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes/SiteStyles.css" rel="App_Themese/stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLogo" Runat="Server">
    <br />
    <br />
    <asp:Image runat="server" ID="programLogo" ImageUrl="App_Themes/SAT.png" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Register Student</h1>
    <asp:Label cssClass="label" runat="server" ID="lblCourseofferingList" Width="8em">Course: </asp:Label>
        <asp:DropDownList CssClass="dropdown" ID="drpCourseOfferingList" runat="server" AutoPostBack="true" Width="22.8em">
           <asp:ListItem Text="Select a Course Offering..." Value="-1"></asp:ListItem>
        </asp:DropDownList>  
    <br />
    <br />
    <asp:Label CssClass="label" runat="server" ID="lblStudentNumber" Width="8em">Student Number: </asp:Label>
                <asp:TextBox runat="server" ID="txtStudentNumber"></asp:TextBox>
    <br />
    <br />
    <asp:Label CssClass="label" runat="server" ID="lblStudentName" Width="8em">Student Name: </asp:Label>
                <asp:TextBox runat="server" ID="txtStudentName"></asp:TextBox>
    <br />
    <br />
        <div>
                <asp:RadioButton runat="server" GroupName="rbStudentType" text="Full Time" ID="rbFullTime" Checked="true"/>
            &nbsp;
                <asp:RadioButton runat="server" GroupName="rbStudentType" text="Part Time" ID="rbPartTime" />
            &nbsp;
                <asp:RadioButton runat="server" GroupName="rbStudentType" text="Co-Op" ID="rbCoop" />
            &nbsp;
            <br />
        </div>
        <br />
    <asp:Button runat="server" OnClick="AddStudent_Click" Text="Add Student to the Course Offering" />
    <div>
        <asp:GridView Width="460" runat="server" AutoGenerateColumns="false" EmptyDataText="No Course Offering Selected" ShowHeaderWhenEmpty="true" ID="gvAddStudent">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />                    
            <HeaderStyle BackColor="#ff0080" Font-Bold="True" ForeColor="#F7F7F7" />
            <EmptyDataRowStyle HorizontalAlign="Center" ForeColor="#FF0000" Font-Bold="true" />
            <Columns>
                <asp:BoundField DataField="StudentNum" HeaderText="ID" ReadOnly="True">
                    <ItemStyle  Width ="80" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True">
                    <ItemStyle  Width ="300" />
                </asp:BoundField>
               <%-- <asp:BoundField DataField="Type" HeaderText="Type" ReadOnly="True">
                    <ItemStyle  Width ="80" />
                </asp:BoundField>--%>
               <%-- <asp:BoundField DataField="Fee" HeaderText="Tuition Payable" ReadOnly="True">
                    <ItemStyle  Width ="80" />
                </asp:BoundField>--%>
            </Columns>
         </asp:GridView>
    </div>
</asp:Content>

