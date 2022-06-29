<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicCesForm5.aspx.cs" Inherits="MVP_ASP.InicCesForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table  id="tblMain" class="main" >
	<tbody><tr>
		<td><table class="section" > 
			<tbody>
				<tr>
					<td colspan="2" class="title">Iniciar Sesion</td>
				 </tr><tr>
					<td class="alignlabel">Ingresar contraseña:</td>
					 <td><asp:TextBox id="textBox1" runat="server" MaxLength="10"  CssClass="form-control" Width="77px"></asp:TextBox></td>				 
				</tr><tr>
					<td colspan="2"class="alignlabel">
						<asp:Button ID="btnAceptar" runat="server"  OnClick="btnAceptar_Click"  OnClientClick="OpenPopUpWorking(true);" ValidationGroup="aceptar" Text="Iniciar Sesion" CssClass="btn btn-primary" />
				</tr><tr>
					<td colspan="2"class="alignlabel">	
					<asp:LinkButton ID="LinkButton1" runat="server">Restablecer Contraseña</asp:LinkButton>
					<asp:LinkButton ID="LinkButton2" runat="server">Olvidaste Contraseña</asp:LinkButton>
					</td>
				</tr> 
		</tbody></table></td>
	</tr>
</tbody></table>
</asp:Content>