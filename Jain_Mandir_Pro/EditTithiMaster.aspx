<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTithiMaster.aspx.cs" Inherits="Jain_Mandir_Pro.EditTithiMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="my-5"></div>
    <div class="master">
        <h2 class="text-center">TITHI MASTER</h2>
        <div class="my-5"></div>
        <asp:Repeater ID="RepeatInformation" runat="server" OnItemCommand="RepeatInformation_ItemCommand">
            <HeaderTemplate>
                <div>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div>
                    <div href="TithiMaster.aspx?tithis_id/='<%#DataBinder.Eval(Container,"DataItem.Date")%>'">
                        <div class="row">
                            <%--<div class="col-md-6">
                                <asp:Label ID="Label7" runat="server" Text="Tithis ID" CssClass="txt-clr"></asp:Label>
                                <div class="my-2"></div>
                                <input type="text" class="form-control txt-clear" name="tithis_id" value='<%#DataBinder.Eval(Container,"DataItem.tithis_id")%>'></input>
                            </div>--%>
                            <div class="col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Date" CssClass="txt-clr"></asp:Label>
                                <div class="my-2"></div>
                                <input type="text" class="form-control txt-clear" name="Date" value='<%#DataBinder.Eval(Container,"DataItem.Date")%>'></input>
                            </div>
                            <div class="my-3"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label3" runat="server" Text="Year" CssClass="txt-clr"></asp:Label>
                                <div class="my-2"></div>
                                <input type="text" class="form-control txt-clear" name="Year" value='<%#DataBinder.Eval(Container,"DataItem.Year")%> '>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label4" runat="server" Text="Month" CssClass="txt-clr"></asp:Label>
                                <div class="my-2"></div>
                                <input type="text" class="form-control txt-clear" name="Month" value='<%#DataBinder.Eval(Container,"DataItem.Month")%>'>
                            </div>
                        </div>
                        <div class="my-3"></div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label5" runat="server" Text="Tithi" CssClass="txt-clr"></asp:Label>
                                <div class="my-2"></div>
                                <input type="text" class="form-control txt-clear" name="Tithi" value='<%#DataBinder.Eval(Container,"DataItem.Tithi")%> ' />
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label6" runat="server" Text="Paksha" CssClass="txt-clr"></asp:Label>
                                <div class="my-2"></div>
                                <input type="text" class="form-control txt-clear" name="Paksha" value='<%#DataBinder.Eval(Container,"DataItem.Paksha")%>'>
                            </div>
                        </div>
                        <div class="my-5"></div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-success txt-clear" Text="SAVE" />
                            </div>
                            <div class="col-md-6">
                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger txt-clear" Text="CANCEL" />
                            </div>
                        </div>

                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
