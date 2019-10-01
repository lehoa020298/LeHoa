<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="QLG.templates.GioHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("maso") %>' OnClick="LinkButton2_Click">Xóa</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="tenga" HeaderText="Tên hàng" />
            <asp:BoundField DataField="mota" HeaderText="Mô tả" />
            <asp:BoundField DataField="gia" HeaderText="Đơn giá" />
            <asp:TemplateField HeaderText="Số lượng">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("soluong") %>'></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("maso") %>' OnClick="Button1_Click" Text="Sửa" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="thanhtien" HeaderText="Thành tiền" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
