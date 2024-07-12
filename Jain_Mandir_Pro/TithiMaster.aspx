<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TithiMaster.aspx.cs" Inherits="Jain_Mandir_Pro.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">
        <section>
            <div class="my-5"></div>

            <h2 class="text-center tm-head">TITHI MASTER</h2>

            <div class="chadhava1">
                <div class="row">
                    <div class="row-md-4 calander">
                        <asp:Label ID="Label1" runat="server" Text="TITHI DATE" CssClass="txt-clr"></asp:Label><br />
                        <asp:Calendar ID="date" runat="server" Height="50px" Width="50px" OnSelectionChanged="date_SelectionChanged"></asp:Calendar>
                    </div>
                    <div class="my-5"></div>
                    <div class="row-md-8">
                        <asp:Repeater ID="RepeatInformation" runat="server" OnItemCommand="RepeatInformation_ItemCommand1">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>

                                <%--<div class="col-md-6">
                                        <asp:Label ID="Label7" runat="server" Text="Tithis ID" CssClass="txt-clr"></asp:Label>
                                        <div class="my-2"></div>
                                        <input type="text" class="form-control txt-clear" name="tithis_id" value='<%#DataBinder.Eval(Container,"DataItem.tithis_id")%>'></input>
                                    </div>--%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label2" runat="server" Text="Date" CssClass="txt-clr"></asp:Label>
                                        <div class="my-2"></div>
                                        <input type="text" class="form-control txt-clear" name="Date" value='<%#DataBinder.Eval(Container,"DataItem.Date")%>'></input>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="Label3" runat="server" Text="Samvat" CssClass="txt-clr"></asp:Label>
                                        <div class="my-2"></div>
                                        <input type="text" class="form-control txt-clear" name="Year" value='<%#DataBinder.Eval(Container,"DataItem.Year")%> '>
                                    </div>
                                </div>
                                <div class="my-3"></div>

                                <div class="row">

                                    <div class="col-md-6">
                                        <asp:Label ID="Label4" runat="server" Text="Month" CssClass="txt-clr"></asp:Label>
                                        <div class="my-2"></div>
                                        <input type="text" class="form-control txt-clear" name="Month" value='<%#DataBinder.Eval(Container,"DataItem.Month")%>'>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="Label6" runat="server" Text="Paksha" CssClass="txt-clr"></asp:Label>
                                        <div class="my-2"></div>
                                        <input type="text" class="form-control txt-clear" name="Paksha" value='<%#DataBinder.Eval(Container,"DataItem.Paksha")%>'>
                                    </div>
                                </div>
                                <div class="my-3"></div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label5" runat="server" Text="Tithi" CssClass="txt-clr"></asp:Label>
                                        <div class="my-2"></div>
                                        <input type="text" class="form-control txt-clear" name="Tithi" value='<%#DataBinder.Eval(Container,"DataItem.Tithi")%> ' />
                                    </div>

                                </div>
                                <div class="my-5"></div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success txt-clear" Text="SAVE" />
                                    </div>
                                    <div class="col-md-4">
                                        <button class="bg-warning"><a href="/EditTithiMaster?tithis_id=<%#DataBinder.Eval(Container,"DataItem.tithis_id")%>">EDIT</a></button>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger txt-clear" Text="CANCEL" />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>  
                            </FooterTemplate>
                        </asp:Repeater>
                        <div class="my-5"></div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>
