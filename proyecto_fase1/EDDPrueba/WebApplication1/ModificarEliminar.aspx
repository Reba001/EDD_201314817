<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarEliminar.aspx.cs" Inherits="WebApplication1.ModificarEliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <table style="width: 90%;">
        <tr>
            <td>Nickname </td>
            
            <td><asp:TextBox ID="txtNickname" runat="server"  Width="237px"></asp:TextBox></td>

            <td> <asp:Label ID="Label1" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            
            <td>Contraseña</td>
            
            <td><asp:TextBox ID="txtContrasenia" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label2" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            
            <td>Correo Electronico</td>
            
            <td><asp:TextBox ID="txtCorreo" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label3" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            <td>Cambiar Nickname</td>
            
            <td><asp:TextBox ID="txtUsuarioNuevo" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label4" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        
        <tr>
            <td> <asp:Button ID="btnModificar" runat="server" Text="Guardar Cambios" OnClick="Button4_Click"></asp:Button> </td>
            
            <td> <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Usuario" OnClick="Button5_Click"></asp:Button> </td>
            
            <td> <asp:Label ID="Label5" runat="server" Text=""></asp:Label> </td>
            
        </tr>
    </table>
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </center>
</asp:Content>
