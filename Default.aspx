<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes/SiteStyles.css" rel="App_Themese/stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLogo" Runat="Server">
    <br />
    <br />
    <asp:Image runat="server" ID="programLogo" ImageUrl="App_Themes/SAT.png" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h1>Course Registration</h1>
        <p>Welcome to Algonquin College's Course Registration system!</p>
        <p>Click the side buttons to add new courses, new course offerings or register students to course offerings</p>
    </div>
</asp:Content>

