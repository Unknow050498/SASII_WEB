<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaEmpl11.aspx.cs" Inherits="MVP_ASP.AltaEmpl11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table  id="tblMain" class="main" >
		<tbody><tr>
			<td><table class="section" > 
				<tbody>
					<tr>
						<td colspan="2" class="title">Alta de Empleado</td>
					 </tr><tr>
						<td class="alignlabel">Nombre de empleado:</td>
						 <td><asp:TextBox id="textBox1" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>				 
					</tr><tr>
						<td class="alignlabel">Puesto:</td>
						 <td><asp:TextBox id="textBox2" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
					</tr><tr>
						<td class="alignlabel">Salario (Ingresar solo numero):</td>
						 <td><asp:TextBox id="textBox3" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
					</tr><tr>
						<td colspan="2"class="alignlabel">
							<asp:Button ID="btnAceptar" runat="server"  OnClick="btnAceptar_Click"  OnClientClick="OpenPopUpWorking(true);" ValidationGroup="Aceptar" Text="Dar de Alta" CssClass="btn btn-primary" />
							<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" OnClientClick="OpenPopUpWorking(false);" Text="Cancelar" CssClass="btn btn-warning" />				
						</td>
					</tr> 
				</tbody></table></td>
			</tr>
		</tbody></table>
</asp:Content>
