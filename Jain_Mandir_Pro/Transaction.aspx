<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="Jain_Mandir_Pro.Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="my-5"></div>
    <h2 class="text-center t-head">Transaction Master</h2>
    <div class="chadhava1">
        <div class="my-5"></div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="Label1" runat="server" Text="Select Date" CssClass="txt-clr"></asp:Label>
                <input type="date" id="TxtSelect_date" name="Select_date" class="txt-clear" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-success txt-clear" Text="Submit" OnClick="Button1_Click" />
            </div>
        </div>
        <div class="my-5"></div>
        <asp:Repeater ID="RepeatInformation" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="Label2" runat="server" Text="Tithi" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" id="tithi" name="tithi" value='<%#DataBinder.Eval(Container,"DataItem.Tithi")%>'>
                    </div>
                  <div class="col-md-6">
                        <asp:Label ID="Label3" runat="server" Text="Month" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" id="month" name="month" value='<%#DataBinder.Eval(Container,"DataItem.Month")%>'>
                    </div>
                </div>
                <div class="my-3"></div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="Label4" runat="server" Text=" Paksha" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" id="paksha" name="paksha" value='<%#DataBinder.Eval(Container,"DataItem.Paksha")%>'>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="Label5" runat="server" Text="Year" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" id="year" name="year" value='<%#DataBinder.Eval(Container,"DataItem.Year")%>'>
                    </div>
                </div>
                <div class="my-3"></div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="Label6" runat="server" Text="Date" CssClass="txt-clr"></asp:Label>
                        <div class="my-2"></div>
                        <input type="text" class="form-control txt-clear" name="Date" value='<%#DataBinder.Eval(Container,"DataItem.Date")%>'>
                    </div>
            </ItemTemplate>
            <FooterTemplate>
                </table>  
            </FooterTemplate>
        </asp:Repeater>
        <div class="col-md-6">
            <asp:Label ID="Label7" runat="server" Text="Chadhava Name" CssClass="txt-clr"></asp:Label>
            <div class="my-2"></div>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control txt-clear"></asp:DropDownList>
        </div>
        <div class="my-3"></div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="Label8" runat="server" Text="Iteration" CssClass="txt-clr"></asp:Label>
                <div class="my-2"></div>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control txt-clear"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <asp:Label ID="Label9" runat="server" Text="Amount" CssClass="txt-clr"></asp:Label>
                <div class="my-2"></div>
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control txt-clear"></asp:DropDownList>
            </div>
        </div>
        <div class="my-3"></div>
        <div class="row">
            <div class="col-md-6">
                <div class="my-2"></div>
                <asp:Label ID="Label10" runat="server" Text="Donar Name" CssClass="txt-clr"></asp:Label>
                <asp:TextBox ID="donar_name" runat="server" CssClass="form-control txt-clear"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="Label11" runat="server" Text="Image" CssClass="txt-clr"></asp:Label>
                <div class="my-2"></div>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
        </div>
        <div class="my-3"></div>
        <div class="row">
            <div class="col-md-6">
                <label for="entryCountInput" class="txt-clr">Number of Entries Allowed:</label>
                <div class="my-2"></div>
                <asp:TextBox ID="EntryCount" runat="server" AutoPostBack="true" CssClass="form-control txt-clear"></asp:TextBox>
            </div>
        </div>
        <div class="my-3"></div>
        <div class="row">
            <div class="col-md-12">
                <h3>
                    <asp:Label ID="Label12" runat="server" CssClass="txt-clr1 " Text="Label"></asp:Label>
                </h3>
            </div>
        </div>
        <div class="my-3"></div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="save" runat="server" CssClass="btn btn-success txt-clear" Text="SAVE" OnClick="save_Click" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="Button3" runat="server" CssClass="btn btn-danger txt-clear" Text="CANCEL" OnClick="Cancel_Click" />
            </div>
        </div>
    </div>
    <div class="my-5"></div>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table class="table table-primary table-striped trans">
                <tr>
                    <th>Transact No.</th>
                    <th>TITHI </th>
                    <th>MONTH</th>
                    <th>PAKSHA</th>
                    <th>YEAR</th>
                    <th>DATE</th>
                    <th>CHADHAVA NAME</th>
                    <th>ITERATION</th>
                    <th>AMOUNT</th>
                    <th>DONAR NAME</th>
                    <th>IMAGE NAME</th>
                    <th>ACTION</th>
                    <th></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="tblrowcolor txt-clear">
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.transact_id")%>  
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.Tithi")%>  
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.Month")%>  
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.Paksha")%>  
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.Year")%>  
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.Date")%>  
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.Chadhava_Name")%>  
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.Iteration")%>
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.Amount")%>  
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.Donar_Name")%>  
                </td>
                <td>
                    <%#DataBinder.Eval(Container,"DataItem.ImageName")%>  
                </td>
                <td>
                    <a href="/EditTransact?transact_id=<%#DataBinder.Eval(Container,"DataItem.transact_id")%>" class="txt-clear">Edit</a>
                </td>
                <td>
                    <input type="button" runat="server" class="bg12" data-id='<%#DataBinder.Eval(Container,"DataItem.transact_id")%>' name="your_id" value="DELETE" onserverclick="deleteBtn" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>  
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
