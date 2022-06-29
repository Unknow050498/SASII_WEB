<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventario6.aspx.cs" Inherits="MVP_ASP.Inventario6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <table  id="tblMain" class="main" >
		<tbody><tr>
			<td><table class="section" > 
				<tbody>
					<tr>
						<td colspan="2" class="title">Inventario</td>
					 </tr><tr>
						 <td class="alignlabel">Todos los registros actuales</td>
						 <td><asp:TextBox id="textBox1" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
						 <td class="alignlabel">Search</td>
						 <td><asp:TextBox id="textBox2" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox></td>
					 </tr><tr>
						<td class="alignlabel">Producto</td>
						<td class="alignlabel">Clave</td>
						<td class="alignlabel">Presentacion</td>
						<td class="alignlabel">Precio</td>
						<td class="alignlabel">M/U</td>
						<td class="alignlabel">Cantidad</td>
						<td class="alignlabel">Stock Min</td>
						<td class="alignlabel">IVA</td>
						<td class="alignlabel">Proveedor(es)</td>
					</tr><tr>
						<td colspan="2"class="alignlabel">
							<asp:ListView ID="ListView1" runat="server"></asp:ListView>
						</td>
					</tr> 
				</tbody></table></td>
			</tr>
		</tbody></table>
</asp:Content>