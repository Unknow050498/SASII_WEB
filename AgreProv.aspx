<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgreProv.aspx.cs" Inherits="MVP_ASP.AgreProv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <table  id="tblMain" class="main" >
		<tbody><tr>
			<td><table class="section" > 
				<tbody>
					<tr>
						<td colspan="2" class="title">Agregar Provedor</td>
					 </tr><tr>
						<td class="alignlabel">Provedor:</td>
						 <td><asp:TextBox id="textBox1" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>				 
					</tr><tr>
						<td class="alignlabel">Correo:</td>
						 <td><asp:TextBox id="textBox2" runat="server" CssClass="form-control"></asp:TextBox></td>
					</tr><tr>
						<td class="alignlabel">Telefono:</td>
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
