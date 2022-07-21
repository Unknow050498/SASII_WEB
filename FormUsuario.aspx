<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormUsuario.aspx.cs" Inherits="MVP_ASP.FormUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tblMain" class="main">
        <tbody>
            <tr>
                <td>
                    <table border="1" class="section">
                        <tbody>
                            <tr>
                                <th colspan="2" class="title">Seleccion de Usuario</th>
                            </tr>
                            <tr>
                                <th class="alignlabel">Clave</th>
                                <th class="alignlabel">Empleado</th>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="textBox1" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox></td>
                                <td><asp:TextBox ID="textBox2" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox></td>
                            </tr>                            
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
