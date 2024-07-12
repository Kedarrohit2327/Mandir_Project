<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IterationMaster.aspx.cs" Inherits="Jain_Mandir_Pro.IterationMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="my-5"></div>
    <h2 class="text-center m-head">Iteration Master</h2>
    <div class="master1">
        <asp:Label ID="Label1" runat="server" Text="ITERATION" CssClass="txt-clr"></asp:Label>
        <div class="my-2"></div>
        <asp:TextBox ID="iteration" CssClass="form-control" runat="server"></asp:TextBox>
        <div class="my-3"></div>
        <asp:Button ID="SAVE" runat="server" CssClass="btn btn-success" Text="SAVE" OnClick="save_click" />
        <asp:Label ID="Label2" runat="server" Text="Label" CssClass="txt-clr1"></asp:Label>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" Text="CANCEL" OnClick="Cancel_Click" />
        <div class="my-5"></div>
        <asp:Repeater ID="RepeatInformation" runat="server" >
            <HeaderTemplate>
                <table class="table table-primary table-striped">
                    <tr>
                        
                        <th>Iteration
                        </th>
                        <%--<th>Action</th>--%>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tblrowcolor txt-clear">
                  
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.iteration")%>  
                    </td>
                   <%-- <td>
                        <a href="/IterationMaster?iterate_id=<%#DataBinder.Eval(Container,"DataItem.iterate_id")%>">Edit</a>
                    </td>--%>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>  
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
