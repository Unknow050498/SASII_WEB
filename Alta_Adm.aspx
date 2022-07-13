<%@  Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alta_Adm.aspx.cs" Inherits="MVP_ASP.Alta_Adm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table id="tblMain" class="main">
        <tbody>
            <tr>
                <td>
                    <table class="section">
                        <tbody>
                            <tr>
                                <td colspan="2" class="title" id="AltAdm">Bienvenido</td>
                            </tr>
                            <tr>
                                <td class="alignlabel">Establece tu contraseña</td>
                                <td>
                                    <asp:TextBox ID="textBox1" TextMode="Password" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="alignlabel" style="height:34px">Confirma tu contraseña</td>
                                <td style="height: 34px">
                                    <asp:TextBox ID="textBox2" TextMode="Password" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="alignlabel">Ingresa la direccion que sera utilizada para los tickets:</td>
                                <td>
                                    <asp:TextBox ID="textBox3" TextMode="Email" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="alignlabel">Correo electronico</td>
                                <td>
                                    <asp:TextBox ID="textBox4" TextMode="Email" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2" class="alignlabel">
                                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" OnClientClick="OpenPopUpWorking(true);" ValidationGroup="Aceptar" Text="Guardar" CssClass="btn btn-primary" />
                                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" OnClientClick="OpenPopUpWorking(false);" Text="Cancelar" CssClass="btn btn-warning" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
