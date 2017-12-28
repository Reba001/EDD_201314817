<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarEliminar.aspx.cs" Inherits="WebApplication1.ModificarEliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>

        <div style="text-align:center; float:none; width:300px;">Modificar y Eliminar Usuario:
             

        </div>
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
        <div style="text-align:center; float:none; width:300px;">Modificar y Eliminar Juego:
             

        </div>
        <table style="width: 90%;">
        <tr>
            <td>Nickname Base</td>
            
            <td><asp:TextBox ID="txtNickJuego" runat="server"  Width="237px"></asp:TextBox></td>

            <td> <asp:Label ID="Label6" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            
            <td>Nickname Oponente</td>
            
            <td><asp:TextBox ID="txtNicO" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label7" runat="server" Text=""></asp:Label> </td>
            
        </tr>
            <tr>
            
            <td>Nickname Oponente Nuevo</td>
            
            <td><asp:TextBox ID="txtNicoNuevo" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label13" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            
            <td>Unidades Desplegadas</td>
            
            <td><asp:TextBox ID="txtDesplegada" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label8" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            <td>Unidades Sobrevivientes</td>
            
            <td><asp:TextBox ID="txtSobreviviente" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label9" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            <td>Unidades Destruidas</td>
            
            <td><asp:TextBox ID="txtDest" runat="server"  Width="237px"></asp:TextBox></td>
            
            <td> <asp:Label ID="Label11" runat="server" Text=""></asp:Label> </td>
            
        </tr>
         <tr>
            <td>Gano</td>
            
            <td><asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Perdio</asp:ListItem>
                <asp:ListItem>Gano</asp:ListItem>
                </asp:DropDownList></td>
            
            <td> <asp:Label ID="Label12" runat="server" Text=""></asp:Label> </td>
            
        </tr>
        <tr>
            <td> <asp:Button ID="btnGuarJuego" runat="server" Text="Guardar Cambios" OnClick="Button6_Click"></asp:Button> </td>
            
            <td> <asp:Button ID="btnDelete" runat="server" Text="Eliminar Juego" OnClick="Button7_Click"></asp:Button> </td>
            
            <td> <asp:Label ID="Label10" runat="server" Text=""></asp:Label> </td>
            
        </tr>
    </table>
        
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
    </center>
</asp:Content>
