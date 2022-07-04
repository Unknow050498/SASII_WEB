<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormUsuario.aspx.cs" Inherits="MVP_ASP.FormUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tblMain" class="main">
        <tbody>
            <tr>
                <td>
                    <table class="section">
                        <tbody>
                            <tr>
                                <td colspan="2" class="title">Seleccion de Usuario</td>
                            </tr>
                            <tr>
                                <td class="alignlabel">Clave</td>
                                <td class="alignlabel">Empleado</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="alignlabel"></td>
                                <asp:Button ID="btnConfirmar" runat="server" OnClick="btnConfirmar_click" OnClientClick="0penPopWorking(true);" ValidationGroup="Confirmar" Text="Confirmar" CssClass="btn-primary" />
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
