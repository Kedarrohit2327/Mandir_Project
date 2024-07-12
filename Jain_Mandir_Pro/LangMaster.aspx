<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LangMaster.aspx.cs" Inherits="Jain_Mandir_Pro.LangMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="main">
        <div class="my-5"></div>
        <h4>Please select a Language.</h4>
        <%--<asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>
        <div id="google_translate_element"></div>
    </div>
</asp:Content>
