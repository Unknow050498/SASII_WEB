<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Precio.aspx.cs" Inherits="MVP_ASP.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <table  id="tblMain" class="main" >
		<tbody><tr>
			<td><table class="section" > 
				<tbody>
					<tr>
						<td class="title">Aviso</td>
					</tr><tr>
						<td class="alignlabel">¿Quieres establecer tu propio precio?:</td>
					</tr><tr>
						<td class="alignlabel">
							<asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
						</td>
							<asp:RadioButtonList ID="RadioButtonList2" runat="server"></asp:RadioButtonList>
						</td>
					</tr><tr>					
						<td class="alignlabel">
							<asp:Button ID="btnAceptar" runat="server"  OnClick="btnAceptar_Click"  OnClientClick="OpenPopUpWorking(true);" ValidationGroup="Aceptar" Text="Aceptar" CssClass="btn btn-primary" />
						</td>
					</tr>
				</tbody></table></td>
			</tr>
		</tbody></table>
</asp:Content>