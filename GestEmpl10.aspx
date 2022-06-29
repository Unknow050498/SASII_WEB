<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestEmpl10.aspx.cs" Inherits="MVP_ASP.GestEmpl10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <table  id="tblMain" class="main" >
		<tbody><tr>
			<td><table class="section" > 
				<tbody>
					<tr>
						<td colspan="2" class="title">Gestion de Empleados</td>
					 </tr><tr>
						<td class="alignlabel">Clave</td>
						<td class="alignlabel">Empleado</td>
						<td class="alignlabel">Puesto</td>
						<td class="alignlabel">Salario</td>
					</tr><tr>
						<td colspan="2"class="alignlabel"</td>
							<asp:Button ID="btnGenerar" runat="server"  OnClick="btnGenerar_Click"  OnClientClick="OpenPopUpWorking(true);" ValidationGroup="Generar" Text="Generar" CssClass="btn btn-primary" />
							<asp:Button ID="btnAgregar" runat="server"  OnClick="btnAgregar_Click"  OnClientClick="OpenPopUpWorking(true);" ValidationGroup="Agregar" Text="Agregar" CssClass="btn btn-primary" />
							<asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" OnClientClick="OpenPopUpWorking(false);" Text="Eliminar" CssClass="btn btn-warning" />				
							<asp:Button ID="btnModificar" runat="server"  OnClick="btnModificar_Click"  OnClientClick="OpenPopUpWorking(true);" ValidationGroup="Modificar" Text="Modificar" CssClass="btn btn-primary" />
						</td>
					</tr> 
				</tbody></table></td>
			</tr>
		</tbody></table>
</asp:Content>