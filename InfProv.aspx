<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfProv.aspx.cs" Inherits="MVP_ASP.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <table  id="tblMain" class="main" >
		<tbody><tr>
			<td><table class="section" > 
				<tbody>
					<tr>
						<td colspan="2" class="title">Información Provedores</td>
					 </tr><tr>
						<td class="alignlabel">Clave:</td>
						 <td><asp:TextBox id="textBox1" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>				 
					</tr><tr>
						<td class="alignlabel">Provedor:</td>
						 <td><asp:TextBox id="textBox2" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
					</tr><tr>
						<td class="alignlabel">Correo:</td>
						 <td><asp:TextBox id="textBox3" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
					</tr><tr>
						<td class="alignlabel">Telefono:</td>
						 <td><asp:TextBox id="textBox4" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>				 
					</tr><tr>
						<td colspan="2"class="alignlabel">
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