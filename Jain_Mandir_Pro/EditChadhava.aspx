<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="EditChadhava.aspx.cs" Inherits="Jain_Mandir_Pro.EditChadhava" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="my-5"></div>
     <div class="master">
   <h2 class="text-center">CHADAVA MASTER</h2>
    <asp:Repeater ID="RepeatInformation" runat="server" OnItemCommand="RepeatInformation_ItemCommand">
        <HeaderTemplate>
            <div>
            </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-md-6">
                    <label for="" class="txt-clr">Chadhava Id.</label>
                    <div class="my-2"></div>
                    <input type="text" class="form-control txt-clear" name="Chadhava_id" value='<%#DataBinder.Eval(Container,"DataItem.Chadhava_id")%> '></input>
                </div>
                <div class="col-md-6">
                    <label for="" class="txt-clr">Chadhava Name</label>
                    <div class="my-2"></div>
                    <input type="text" class="form-control txt-clear" name="Chadhava_name" value='<%#DataBinder.Eval(Container,"DataItem.Chadhava_name")%> '>
                </div>
            </div>
            <div class="my-3"></div>
            <div class="row">
                <div class="col-md-6">
                    <label for="" class="txt-clr">Iteration</label>
                    <div class="my-2"></div>
                    <input type="text" class="form-control txt-clear" name="Iteration" value='<%#DataBinder.Eval(Container,"DataItem.Iteration")%> '>
                </div>
                <div class="col-md-6">
                    <label for="" class="txt-clr">Amount</label>
                    <div class="my-2"></div>
                    <input type="text" class="form-control txt-clear" id="Amount" name="Amount" value='<%#DataBinder.Eval(Container,"DataItem.Amount")%> '>
                </div>
            </div>
            <div class="my-3" ></div>
            <div class="row">
                <div class="col-md-6">
                    <label for="" class="txt-clr">W.E.F Date</label>
                    <div class="my-2"></div>
                     <input type="date" name="wef_date" class="form-control txt-clear" value='<%#DataBinder.Eval(Container,"DataItem.wef_date")%>'></input>
                                                          
                </div>

            </div>
            <div class="my-5"></div>
            <div class="row">
                <div class="col-md-6">
                    <asp:Button ID="save" runat="server" CssClass="btn btn-success txt-clear" Text="SAVE" />
                </div>
                <%--<div class="col-md-6">
                    <asp:Button ID="cancel" runat="server" CssClass="btn btn-danger" Text="CANCEL" />
                </div>--%>
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <div class="my-3"></div>
        </div>
</asp:Content>
