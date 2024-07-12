<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChadavaMaster.aspx.cs" Inherits="Jain_Mandir_Pro.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="my-5"></div>
    <%--<main aria-labelledby="title">--%>
    <h2 class="text-center m-head">CHADAVA MASTER</h2>
    <div class="chadhava1">
        <div>
            <div class="row">
                <div class="col-md-6">
                    <label for="inputEmail4" class="txt-clr">Chadava Name</label>
                    <div class="my-2"></div>
                    <input type="text" class="form-control txt-clear" id="Chadhava_Name" name="Chadhava_Name">
                </div>
                <div class="col-md-6">
                    <asp:Label ID="Label9" runat="server" Text="Iteration" CssClass="txt-clr"></asp:Label><br />
                    <div class="my-2"></div>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control txt-clear"></asp:DropDownList>
                </div>
            </div>
            <div class="my-3"></div>

            <div class="row">
                <div class="col-md-6">
                    <label for="" class="txt-clr">Amount</label>
                    <div class="my-2"></div>
                    <input type="text" class="form-control txt-clear" id="amount" name="amount">
                </div>
                <div class="col-md-6">
                    <label for="" class="txt-clr">W.E.F Date</label>
                    <div class="my-2"></div>
                    <input type="date" class="form-control txt-clear" id="TxtSelect_date" name="TxtSelect_date">
                </div>
            </div>
            <div class="my-3"></div>
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="Label8" runat="server" Text="Image" CssClass="txt-clr"></asp:Label>
                    <div class="my-2"></div>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                
            </div>

            <div class="my-5"></div>

            <div class="row">
                <div class="col-md-6">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success txt-clear" Text="SAVE"  OnClick="savechadava_click" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger txt-clear" Text="CANCEL" OnClick="Cancel_Click" />
                </div>
            </div>
        </div>
        <div class="my-5"></div>
        <asp:Repeater ID="RepeatInformation" runat="server" >
            <HeaderTemplate>
                <table class="table table-primary table-striped">
                    <tr>
                        <th>Chadhava No.
                        </th>
                        <th>Chadava Name
                        </th>
                        <th>Iteration   
                        </th>

                        <th>Amount 
                        </th>

                        <th>W.E.F. Date 
                        </th>

                        <th>Action</th>
                        <th></th>

                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tblrowcolor txt-clear">
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.Chadhava_id")%>  
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.Chadhava_name")%>  
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.Iteration")%>  
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.Amount")%>  
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container,"DataItem.wef_date")%>  
                    </td>
                    <td>
                        <a href="/EditChadhava?Chadhava_id=<%#DataBinder.Eval(Container,"DataItem.Chadhava_id")%>" class="txt-clear">Edit</a>
                    </td>
                    <td>
                        <input type="button" runat="server" class="bg12" data-id='<%#DataBinder.Eval(Container,"DataItem.Chadhava_id")%>' name="your_id" value="DELETE" onserverclick="deleteBtn" /></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>  
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
