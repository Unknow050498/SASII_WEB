<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Form9.aspx.cs" Inherits="MVP_ASP.Form9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tblMain" class="main">
        <tbody>
            <tr>
                <td>
                    <table class="section">
                        <tbody>
                            <tr>
                                <td colspan="2" class="title">Nueva Contraseña</td>
                            </tr>
                            <tr>
                                <td class="alignlabel">Ingresar nueva contraseña:</td>
                                <td>
                                    <asp:TextBox ID="textBox1" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="alignlabel">Confirmar nueva contraseña:</td>
                                <td>
                                    <asp:TextBox ID="textBox2" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox></td>
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
