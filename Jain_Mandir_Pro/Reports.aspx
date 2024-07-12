<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Jain_Mandir_Pro.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="my-5"></div>
    <h2 class="txt-center">THIS IS REPORT PAGE</h2>
    <div class="main1">
        <div class="container">
        <asp:Repeater ID="repeaterData" runat="server">
            <ItemTemplate>
                <div class="card mb-3" style="max-width: 540px;">
                    <div class="row g-0">
                        <div class="col-md-4">

                            <div style="display: inline-block; margin: 10px;">
                                <h4>Image:
     <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?transact_id=" + Eval("transact_id") %>' Width="150px"  /></h4>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h4 class="card-text">Donar Name: <%# Eval("Donar_Name") %></h4>
                                <h5 class="card-text">Date:<%# Eval("Date") %></h5>
                                <h5 class="card-text">Tithi:<%# Eval("Tithi") %></h5>
                                <h5 class="card-text">Month:<%# Eval("Month") %></h5>
                                <h5 class="card-text">Paksha:<%# Eval("Paksha") %></h5>
                                <h5 class="card-text">Chadhava Name:<%# Eval("Chadhava_name") %></h5>                             
                                <h5 class="card-text">Amount:<%# Eval("Amount") %></h5>
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
       </div>
    </div>
</asp:Content>
