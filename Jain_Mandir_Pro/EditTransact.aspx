<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTransact.aspx.cs" Inherits="Jain_Mandir_Pro.EditTransact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="my-5"></div>
    <h2 class="text-center t-head">Transaction Master</h2>
    <div class="chadhava1">
        <div class="my-5"></div>

        <asp:Repeater ID="RepeatInformation" runat="server" OnItemCommand="RepeatInformation_ItemCommand">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
               
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="Label2" runat="server" Text="Tithi" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" id="tithi" name="Tithi" value='<%#DataBinder.Eval(Container,"DataItem.Tithi")%>'>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="Label3" runat="server" Text="Month" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" id="month" name="Month" value='<%#DataBinder.Eval(Container,"DataItem.Month")%>'>
                    </div>
                </div>
                <div class="my-3"></div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="Label4" runat="server" Text=" Paksha" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" id="paksha" name="Paksha" value='<%#DataBinder.Eval(Container,"DataItem.Paksha")%>'>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="Label5" runat="server" Text="Year" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" id="year" name="Year" value='<%#DataBinder.Eval(Container,"DataItem.Year")%>'>
                    </div>
                </div>
                <div class="my-3"></div>
                <div class="row">
                    <div class="col-md-6">

                        <asp:Label ID="Label9" runat="server" Text="Date" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" name="Date" value='<%#DataBinder.Eval(Container,"DataItem.Date")%>'>
                    </div>
                    <div class="col-md-6">

                        <asp:Label ID="Label6" runat="server" Text="Chadhava Name" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" name="Chadhava_name" value='<%#DataBinder.Eval(Container,"DataItem.Chadhava_Name")%>'>
                    </div>
                </div>
                <div class="my-3"></div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="Label1" runat="server" Text="Iteration" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" name="Iteration" value='<%#DataBinder.Eval(Container,"DataItem.Iteration")%>'>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="Label7" runat="server" Text="Amount" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" name="Amount" value='<%#DataBinder.Eval(Container,"DataItem.Amount")%>'>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">

                        <asp:Label ID="Label8" runat="server" Text="Donar Name" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" name="Donar_name" value='<%#DataBinder.Eval(Container,"DataItem.Donar_Name")%>'>
                    </div>
                </div>
           

        <div class="my-5"></div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-success txt-clear" Text="SAVE"  />
            </div>
            <div class="col-md-6">
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger txt-clear" Text="CANCEL"/>
            </div>
        </div>
                    </ItemTemplate>
    <FooterTemplate>
        </table>  
    </FooterTemplate>
</asp:Repeater>
    </div>
    <div class="my-5"></div>

</asp:Content>
