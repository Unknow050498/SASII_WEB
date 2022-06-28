<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoExtra.aspx.cs" Inherits="MVP_ASP.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           <table  id="tblMain" class="main" >
		<tbody><tr>
			<td><table class="section" > 
				<tbody>
					<tr>
						<td colspan="2" class="title">Información del Producto</td>
					 </tr><tr>
						<td class="alignlabel">Clave</td>
						<td><asp:TextBox id="textBox1" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
						<td class="alignlabel">Producto</td>
						<td><asp:TextBox id="textBox2" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
					</tr><tr>
						<td class="alignlabel">Presentacion</td>
						<td><asp:TextBox id="textBox3" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
						<td class="alignlabel">Cantidad</td>
						<td><asp:TextBox id="textBox4" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>				 
					</tr><tr>
						<td class="alignlabel">Stock Minimo</td>
						<td><asp:TextBox id="textBox5" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
						<td class="alignlabel">Precio de Venta</td>
						<td><asp:TextBox id="textBox6" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>				 
					</tr><tr>
						<td colspan="2"class="alignlabel">
						<td><asp:Button ID="btnListo" runat="server"  OnClick="btnListo_Click"  OnClientClick="OpenPopUpWorking(true);" ValidationGroup="Listo" Text="Listo" CssClass="btn btn-primary" />
						</td>
					</tr> 
				</tbody></table></td>
			</tr>
		</tbody></table>
</asp:Content>