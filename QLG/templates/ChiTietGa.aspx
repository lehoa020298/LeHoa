<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ChiTietGa.aspx.cs" Inherits="QLG.templates.ChiTietGa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../static/Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
    <asp:DataList ID="DataList" runat="server" RepeatColumns="3" OnSelectedIndexChanged="DataList_SelectedIndexChanged" CssClass="active">
        <ItemTemplate>
            <div class="item">
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" style="width:350px;" CommandArgument='<%# Eval("maso") %>' ImageUrl='<%# "~/images/"+Eval("hinhanh") %>' />
                        </td>
                        <td >
                            <h4>Nghệ danh: <asp:Label ID="Label1" runat="server" CommandArgument='<%# Eval("maso") %>' Text='<%# Eval("tenga") %>' Font-Size="25px"></asp:Label></h4>
                            
                            <h5>Mã số: <asp:Label ID="Label2" runat="server" CommandArgument='<%# Eval("maso") %>' Text='<%# Eval("maso") %>'></asp:Label></h5>
                            
                            <h5>Xuất sứ: <asp:Label ID="Label3" runat="server" CommandArgument='<%# Eval("maso") %>' Text='<%# Eval("xuatsu") %>'></asp:Label></h5>
                            
                            <h5>Cân nặng: <asp:Label ID="Label4" runat="server" CommandArgument='<%# Eval("maso") %>' Text='<%# Eval("cannang") %>'></asp:Label></h5>
                            
                            <h5>Giá: <asp:Label ID="Label6" runat="server" CommandArgument='<%# Eval("maso") %>' Text='<%# Eval("gia") %>'></asp:Label></h5>
                            <br />
                            <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("maso") %>' Text="Mua ngay!" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
