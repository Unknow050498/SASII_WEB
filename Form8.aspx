<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Form8.aspx.cs" Inherits="MVP_ASP.Form8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<table  id="tblMain" class="main" >
	<tbody><tr>
		<td><table class="section" > 
			<tbody>
				<tr>
					<td colspan="2" class="title">Confirmacion</td>
				 </tr><tr>
					<td class="alignlabel">Ingresar vieja contraseña:</td>
					 <td><asp:TextBox id="textBox1" runat="server" MaxLength="10"  CssClass="form-control" Width="77px"></asp:TextBox></td>				 
				</tr><tr>
					<td colspan="2" class="alignlabel">
						<asp:Button ID="btnAceptar" runat="server"  OnClick="btnAceptar_Click"  OnClientClick="OpenPopUpWorking(true);" ValidationGroup="aceptar" Text="Confirmar" CssClass="btn btn-primary" />
					</td>
				</tr> 
		</tbody></table></td>
	</tr>
</tbody></table>
</asp:Content>
