<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PPT.aspx.cs" Inherits="Jain_Mandir_Pro.PPT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="my-5"></div>
    <h2 class="text-center m-head2">Generate Powerpoint Presentation </h2>
  
           <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?transact_id=" + Eval("transact_id") %>' Width="200px" />
     <div class="master1">
         <div class="p-mid">
   <asp:Label ID="Label1" runat="server" CssClass="txt-clr" Text="SELECT DATE "></asp:Label>
         <div class="my-2"></div>
   <input type="date" class="form-control txt-clear" id="TxtSelect_date" name="Select_date" />     
   <div class="my-3"></div>
<asp:Button ID="Button1" runat="server" CssClass="btn btn-success txt-clear" Text="GENERATE PPT" OnClick="ppt_Click" />
             </div>
        </div>
    <div class="my-5"></div>
</asp:Content>
