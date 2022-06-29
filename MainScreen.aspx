<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainScreen.aspx.cs" Inherits="MVP_ASP.MainScreen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ImageButton ID="adm_button" runat="server" Height="166px" Width="194px" ImageUrl="~/Resources/adm.png" OnClick="adm_button_Click" />
    <asp:ImageButton ID="usr_button" runat="server" Height="166px" Width="194px" ImageUrl="~/Resources/us1.png" OnClick="usr_button_Click" />

    <table id="tblMain" class="main">
        <tbody>
            <tr>
                <td>
                    <table class="section">
                        <tbody>
                            <tr>
                                <td colspan="2" class="title">Form Name (Substitute)</td>
                            </tr>
                            <tr>
                                <td class="alignlabel">Field 1:</td>
                                <td>
                                    <asp:TextBox ID="textBox1" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="alignlabel">Field 2:
                                    </td>
                                <td>
                                    <asp:TextBox ID="textBox2" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="alignlabel">
                                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" OnClientClick="OpenPopUpWorking(false);" Text="Cancelar" CssClass="btn btn-warning" />
                                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" OnClientClick="OpenPopUpWorking(true);" ValidationGroup="aceptar" Text="Aceptar" CssClass="btn btn-primary" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
