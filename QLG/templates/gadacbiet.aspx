<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="gadacbiet.aspx.cs" Inherits="QLG.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>DANH SÁCH GÀ:</p>
    <asp:DataList ID="DataList" runat="server" RepeatColumns="3" OnSelectedIndexChanged="DataList_SelectedIndexChanged"    Width="740" CellPadding="5" CellSpacing="5" ViewStateMode="Enabled" CaptionAlign="Left">
        <ItemTemplate>
            <div class="item" >
                <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("maso") %>' ImageUrl='<%# "~/images/"+Eval("hinhanh") %>' OnClick="ImageButton1_Click" style="width:320px;" /> <br/> 
                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("maso") %>' OnClick="LinkButton1_Click" Text='<%# Eval("tenga") %>'></asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("maso") %>' OnClick="LinkButton1_Click" Text='<%# Eval("maso") %>'></asp:LinkButton><br />
                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("maso") %>' OnClick="LinkButton2_Click">Chi tiết...</asp:LinkButton>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
