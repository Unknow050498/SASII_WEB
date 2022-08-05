<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestEmpl10.aspx.cs" Inherits="MVP_ASP.GestEmpl10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tblMain" class="main">
        <tbody>
            <tr>
                <td>
                    <table border="1" class="section">
                        <tbody>
                            <tr>
                                <td colspan="4" class="title">Gestion de Empleados</td>
                            </tr>
                            <tr>
                                <th class="alignlabel">Clave</th>
                                <th class="alignlabel">Empleado</th>
                                <th class="alignlabel">Puesto</th>
                                <th class="alignlabel">Salario</th>
                            </tr>
                                               
                               <td> <%# getWhileLoopData() %></td>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
